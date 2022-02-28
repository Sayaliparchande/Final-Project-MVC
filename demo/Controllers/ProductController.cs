using demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductDbContext dbContext = new ProductDbContext();

    /*    [Route("api/product")]*/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productlist>>> GetProducts()
        {
            return await dbContext.Productlists.ToListAsync();
        }


        [Route("api/addproduct")]
        [HttpPost]
        public IActionResult Create(Productlist newproduct)
        {
            dbContext.Productlists.Add(newproduct);
            dbContext.SaveChanges();
            return Ok();
        }

      /* [Route("api/updateproduct")]*/
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Productlist product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            dbContext.Entry(product).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        /* [Route("api/deleteproduct")]*/
        [HttpDelete("{id}")]
        public async Task<ActionResult<Productlist>> DeleteProduct(int id)
        {
            var product = await dbContext.Productlists.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            dbContext.Productlists.Remove(product);
            await dbContext.SaveChangesAsync();

            return product;

        }
        private bool ProductExists(int id)
        {
            return dbContext.Productlists.Any(e => e.Id == id);
        }
    }
}



    


       
        

   
