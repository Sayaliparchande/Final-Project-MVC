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
    public class UserSignupController : Controller
    { 
            ProductDbContext dbContext = new ProductDbContext();

            /*    [Route("api/product")]*/
            [HttpGet]
            public List<SignupUser> GetUsers()
            {
                return dbContext.SignupUsers.ToList();
            }


        [Route("api/adduser")]
            [HttpPost]
            public IActionResult Create(SignupUser newuser)
            {
            dbContext.SignupUsers.Add(newuser);
                dbContext.SaveChanges();
                return Ok();
            }

            /* [Route("api/updateproduct")]*/
            [HttpPut("{id}")]
            public async Task<IActionResult> Putuser(int id, SignupUser user)
            {
                if (id != user.Id)
                {
                    return BadRequest();
                }

                dbContext.Entry(user).State = EntityState.Modified;

                try
                {
                    await dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!userExists(id))
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

        private bool userExists(int id)
        {
            throw new NotImplementedException();
        }

        /* [Route("api/deleteuser")]*/
        [HttpDelete("{id}")]
            public async Task<ActionResult<SignupUser>> DeleteUser(int id)
            {
                var user = await dbContext.SignupUsers.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                dbContext.SignupUsers.Remove(user);
                await dbContext.SaveChangesAsync();

                return user;

            }
            private bool UserExists(int id)
            {
                return dbContext.SignupUsers.Any(e => e.Id == id);
            }
        }
    }


    

