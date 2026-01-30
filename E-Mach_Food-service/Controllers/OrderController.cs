using Microsoft.AspNetCore.Mvc;
using E_Mach_Food_service.Data;
using E_Mach_Food_service.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Mach_Food_service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/order
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            if (order == null || order.Items.Count == 0)
                return BadRequest("Order must contain at least one item.");

            order.CreatedAt = DateTime.UtcNow;

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();   // ✅ actually writes to PostgreSQL

            return Ok(order);
        }

        // GET: api/order
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _context.Orders
                .Include(o => o.Items)   // ✅ load items too
                .ToListAsync();

            return Ok(orders);
        }

        // GET: api/order/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return NotFound();
            return Ok(order);
        }
    }
}
