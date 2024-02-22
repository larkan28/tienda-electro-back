using AutoMapper;
using Back.Models;
using Back.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrderController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var order = await _context.Orders.FindAsync(id);

                if (order == null)
                    return NotFound();

                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("listOrders/{userId}")]
        public async Task<IActionResult> ListOrders(int userId)
        {
            try
            {
                var orders = await _context.Orders.Where(x => x.UserId == userId).ToListAsync();

                if (orders == null)
                    return NotFound();

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("listProducts/{orderId}")]
        public async Task<IActionResult> ListProducts(int orderId)
        {
            try
            {
                var orders = await _context.OrderProducts.Where(x => x.OrderId == orderId).ToListAsync();

                if (orders == null)
                    return NotFound();

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(OrderDto orderDto)
        {
            try
            {
                var order = _mapper.Map<Order>(orderDto);
                order.CreatedTime = DateTime.Now;
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                var products = new List<OrderProduct>();

                foreach (var item in orderDto.Products)
                {
                    OrderProduct product = new()
                    {
                        OrderId = order.Id,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity
                    };

                    products.Add(product);
                }

                _context.OrderProducts.AddRange(products);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
