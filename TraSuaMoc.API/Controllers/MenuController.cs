using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraSuaMoc.API.Data;
using TraSuaMoc.API.DTOs;
using TraSuaMoc.API.Models;

namespace TraSuaMoc.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuController(AppDbContext db) : ControllerBase
{
    // GET /api/menu  — public, trả về món không bị ẩn
    [HttpGet]
    public async Task<IEnumerable<MenuItemDto>> GetAll([FromQuery] string? category)
    {
        var q = db.MenuItems.Where(m => !m.IsHidden);
        if (!string.IsNullOrEmpty(category))
            q = q.Where(m => m.Category == category);
        return await q.OrderBy(m => m.Id)
            .Select(m => ToDto(m))
            .ToListAsync();
    }

    // GET /api/menu/all  — admin only, trả về cả món ẩn
    [HttpGet("all")]
    [Authorize]
    public async Task<IEnumerable<MenuItemDto>> GetAllAdmin() =>
        await db.MenuItems.OrderBy(m => m.Id).Select(m => ToDto(m)).ToListAsync();

    // POST /api/menu
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<MenuItemDto>> Create(CreateMenuItemDto dto)
    {
        var item = new MenuItem
        {
            Name = dto.Name, Description = dto.Description, Price = dto.Price,
            Emoji = dto.Emoji, Category = dto.Category,
            IsHot = dto.IsHot, IsNew = dto.IsNew, IsHidden = dto.IsHidden
        };
        db.MenuItems.Add(item);
        await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), new { id = item.Id }, ToDto(item));
    }

    // PUT /api/menu/{id}
    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<MenuItemDto>> Update(int id, UpdateMenuItemDto dto)
    {
        var item = await db.MenuItems.FindAsync(id);
        if (item is null) return NotFound();

        if (dto.Name is not null) item.Name = dto.Name;
        if (dto.Description is not null) item.Description = dto.Description;
        if (dto.Price.HasValue) item.Price = dto.Price.Value;
        if (dto.Emoji is not null) item.Emoji = dto.Emoji;
        if (dto.Category is not null) item.Category = dto.Category;
        if (dto.IsHot.HasValue) item.IsHot = dto.IsHot.Value;
        if (dto.IsNew.HasValue) item.IsNew = dto.IsNew.Value;
        if (dto.IsHidden.HasValue) item.IsHidden = dto.IsHidden.Value;
        if (dto.Image is not null) item.Image = dto.Image;

        await db.SaveChangesAsync();
        return ToDto(item);
    }

    // DELETE /api/menu/{id}
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await db.MenuItems.FindAsync(id);
        if (item is null) return NotFound();
        db.MenuItems.Remove(item);
        await db.SaveChangesAsync();
        return NoContent();
    }

    private static MenuItemDto ToDto(MenuItem m) =>
        new(m.Id, m.Name, m.Description, m.Price, m.Emoji, m.Category, m.IsHot, m.IsNew, m.IsHidden);
}
