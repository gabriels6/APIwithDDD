using DDDAPI.Domain.Entities;
using DDDAPI.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDAPI.Domain.Interfaces;

namespace DDDAPI.Infrastructure.Data.Repositories
{
    public class ProductRepository : ControllerBase,IProductRepository
    {
        private readonly MySQLContext _context;

        public ProductRepository(MySQLContext context) 
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _context.Produtos.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        public async Task<IActionResult> Update(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckExists(id))
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

        public async Task<ActionResult<Product>> Create(Product product)
        {
            _context.Produtos.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Produtos.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CheckExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }


}

