using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TraSuaMoc.API.Data;

var builder = WebApplication.CreateBuilder(args);

// ── Database ──────────────────────────────────────────────
var rawConn = Environment.GetEnvironmentVariable("DATABASE_URL")
    ?? builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new Exception("Thiếu connection string DATABASE_URL");

// Convert postgresql:// → format Npgsql đọc được
string connStr;
if (rawConn.StartsWith("postgresql://") || rawConn.StartsWith("postgres://"))
{
    var uri = new Uri(rawConn);
    var userInfo = uri.UserInfo.Split(':');
    var host = uri.Host;
    var port = uri.Port > 0 ? uri.Port : 5432; // ✅ fallback 5432 nếu URI không có port
    var database = uri.AbsolutePath.TrimStart('/');
    var username = userInfo[0];
    var password = userInfo[1];

    connStr = $"Host={host};Port={port};Database={database};" +
              $"Username={username};Password={password};" +
              $"SSL Mode=Require;Trust Server Certificate=true";
}
else
{
    connStr = rawConn;
}

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(connStr));

// ── JWT Auth ──────────────────────────────────────────────
var jwtKey = builder.Configuration["Jwt:Key"]
    ?? Environment.GetEnvironmentVariable("JWT_KEY")
    ?? "super-secret-key-change-in-production-min-32chars!!";

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt => {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"] ?? "TraSuaMoc",
            ValidAudience = builder.Configuration["Jwt:Audience"] ?? "TraSuaMoc",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddControllers();

// ── CORS ──────────────────────────────────────────────────
builder.Services.AddCors(opt => opt.AddPolicy("FrontendPolicy", p =>
    p.AllowAnyOrigin()
     .AllowAnyHeader()
     .AllowAnyMethod()));

builder.Services.AddCors(opt => opt.AddPolicy("FrontendPolicy", p =>
    p.WithOrigins(allowedOrigins.Split(','))
     .AllowAnyHeader()
     .AllowAnyMethod()));

// ── Swagger ───────────────────────────────────────────────
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Trà Sữa Mộc API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {{
        new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }},
        Array.Empty<string>()
    }});
});

// ✅ Render inject PORT tự động
var appPort = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://0.0.0.0:{appPort}");

var app = builder.Build();

// ── Auto migrate + seed ───────────────────────────────────
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("FrontendPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
