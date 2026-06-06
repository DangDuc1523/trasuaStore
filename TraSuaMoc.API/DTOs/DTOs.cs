namespace TraSuaMoc.API.DTOs;

// Menu
public record MenuItemDto(int Id, string Name, string Description, decimal Price,
    string Emoji, string Category, bool IsHot, bool IsNew, bool IsHidden);

public record CreateMenuItemDto(string Name, string Description, decimal Price,
    string Emoji, string Category, bool IsHot, bool IsNew, bool IsHidden);

public record UpdateMenuItemDto(string? Name, string? Description, decimal? Price,
    string? Emoji, string? Category, bool? IsHot, bool? IsNew, bool? IsHidden);

// Order
public record PlaceOrderDto(string TableNumber, List<OrderItemDto> Items);
public record OrderItemDto(string Name, int Quantity, decimal UnitPrice, string Note);

public record OrderResponseDto(int Id, string TableNumber, string Status,
    decimal Total, string CreatedAt, List<OrderItemDto> Items);

public record UpdateOrderStatusDto(string Status);

// Auth
public record LoginDto(string Username, string Password);
public record LoginResponseDto(string Token, string Username);
