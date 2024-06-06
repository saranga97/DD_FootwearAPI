using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DD_FootwearAPI.Data;
using DD_FootwearAPI.Models;

namespace DD_FootwearAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreOrdersController : ControllerBase
    {
        private readonly DDContext _context;

        public PreOrdersController(DDContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreOrder>>> GetPreOrders()
        {
            return await _context.PreOrders.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PreOrder>> GetPreOrder(int id)
        {
            var preOrder = await _context.PreOrders.FindAsync(id);

            if (preOrder == null)
            {
                return NotFound();
            }

            return preOrder;
        }

        [HttpPost]
        public async Task<ActionResult<PreOrder>> PostPreOrder(PreOrder preOrder)
        {
            // Check if the productID exists in the Products table
            var productExists = await _context.Products.AnyAsync(p => p.ProductID == preOrder.ProductID);
            if (!productExists)
            {
                return NotFound("Item not found");
            }

            _context.PreOrders.Add(preOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreOrder", new { id = preOrder.PreOrderID }, preOrder);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreOrder(int id)
        {
            var preOrder = await _context.PreOrders.FindAsync(id);
            if (preOrder == null)
            {
                return NotFound();
            }

            _context.PreOrders.Remove(preOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
