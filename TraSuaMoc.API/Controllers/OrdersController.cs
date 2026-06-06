using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraSuaMoc.API.Data;
using TraSuaMoc.API.DTOs;
using TraSuaMoc.API.Models;

namespace TraSuaMoc.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController(AppDbContext db) : ControllerBase
{
    // POST /api/orders  — khách gọi món (public)
    [HttpPost]
    public async Task<ActionResult<OrderResponseDto>> PlaceOrder(PlaceOrderDto dto)
    {
        var order = new Order
        {
            TableNumber = dto.TableNumber,
            Total = dto.Items.Sum(i => i.UnitPrice * i.Quantity),
            Status = "new",
            Items = dto.Items.Select(i => new OrderItem
            {
                Name = i.Name, Quantity = i.Quantity,
                UnitPrice = i.UnitPrice, Note = i.Note
            }).ToList()
        };
        db.Orders.Add(order);
        await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = order.Id }, ToDto(order));
    }

    // GET /api/orders  — admin only
    [HttpGet]
    [Authorize]
    public async Task<IEnumerable<OrderResponseDto>> GetAll([FromQuery] string? status)
    {
        var q = db.Orders.Include(o => o.Items).OrderByDescending(o => o.CreatedAt).AsQueryable();
        if (!string.IsNullOrEmpty(status)) q = q.Where(o => o.Status == status);
        return (await q.ToListAsync()).Select(ToDto);
    }

    // GET /api/orders/{id}
    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<OrderResponseDto>> GetById(int id)
    {
        var order = await db.Orders.Include(o => o.Items).FirstOrDefaultAsync(o => o.Id == id);
        return order is null ? NotFound() : ToDto(order);
    }

    // PATCH /api/orders/{id}/status
    [HttpPatch("{id}/status")]
    [Authorize]
    public async Task<ActionResult<OrderResponseDto>> UpdateStatus(int id, UpdateOrderStatusDto dto)
    {
        var order = await db.Orders.Include(o => o.Items).FirstOrDefaultAsync(o => o.Id == id);
        if (order is null) return NotFound();
        if (!new[] { "new", "making", "done" }.Contains(dto.Status))
            return BadRequest("Status phải là: new, making, done");
        order.Status = dto.Status;
        await db.SaveChangesAsync();
        return ToDto(order);
    }

    // DELETE /api/orders/{id}
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        var order = await db.Orders.FindAsync(id);
        if (order is null) return NotFound();
        db.Orders.Remove(order);
        await db.SaveChangesAsync();
        return NoContent();
    }

    private static OrderResponseDto ToDto(Order o) => new(
        o.Id, o.TableNumber, o.Status, o.Total,
        o.CreatedAt.ToString("HH:mm:ss dd/MM/yyyy"),
        o.Items.Select(i => new OrderItemDto(i.Name, i.Quantity, i.UnitPrice, i.Note)).ToList()
    );
}
