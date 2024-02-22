using Back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AddressController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var address = await _context.Addresses.FindAsync(id);

                if (address == null)
                    return NotFound();

                return Ok(address);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("list/{userId}")]
        public async Task<IActionResult> List(int userId)
        {
            try
            {
                var addresses = await _context.Addresses.Where(x => x.UserId == userId).ToListAsync();

                if (addresses == null)
                    return NotFound();

                return Ok(addresses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Address address)
        {
            try
            {
                _context.Addresses.Add(address);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                var address = await _context.Addresses.FindAsync(id);

                if (address == null)
                    return NotFound();

                _context.Addresses.Remove(address);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Put(Address addressDto)
        {
            try
            {
                var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == addressDto.Id);

                if (address == null)
                    return NotFound();

                address.Name = addressDto.Name;
                address.FirstName = addressDto.FirstName;
                address.LastName = addressDto.LastName;
                address.Phone = addressDto.Phone;
                address.Street = addressDto.Street;
                address.StreetNumber = addressDto.StreetNumber;
                address.Department = addressDto.Department;
                address.DepartmentFloor = addressDto.DepartmentFloor;
                address.DepartmentTower = addressDto.DepartmentTower;
                address.ZipCode = addressDto.ZipCode;
                address.State = addressDto.State;
                address.City = addressDto.City;

                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
