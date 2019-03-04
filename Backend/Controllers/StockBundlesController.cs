using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Model;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockBundlesController : ControllerBase
    {
        private readonly BackendContext _context;

        public StockBundlesController(BackendContext context)
        {
            _context = context;
        }

        // GET: api/StockBundles
        [HttpGet]
        public IEnumerable<StockBundle> GetStockBundle()
        {
            return _context.StockBundle;
        }

        // GET: api/StockBundles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStockBundle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stockBundle = await _context.StockBundle.FindAsync(id);

            if (stockBundle == null)
            {
                return NotFound();
            }

            return Ok(stockBundle);
        }

        // PUT: api/StockBundles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockBundle([FromRoute] int id, [FromBody] StockBundle stockBundle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stockBundle.Id)
            {
                return BadRequest();
            }

            _context.Entry(stockBundle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockBundleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StockBundles
        [HttpPost]
        public async Task<IActionResult> PostStockBundle([FromBody] StockBundle stockBundle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StockBundle.Add(stockBundle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockBundle", new { id = stockBundle.Id }, stockBundle);
        }

        // DELETE: api/StockBundles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStockBundle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stockBundle = await _context.StockBundle.FindAsync(id);
            if (stockBundle == null)
            {
                return NotFound();
            }

            _context.StockBundle.Remove(stockBundle);
            await _context.SaveChangesAsync();

            return Ok(stockBundle);
        }

        private bool StockBundleExists(int id)
        {
            return _context.StockBundle.Any(e => e.Id == id);
        }
    }
}