using GameAPI.Models;
using GameAPI.Response;
using GameAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public UserController (AplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {

                var listUser = await _context.User.ToListAsync();
                return Ok(listUser);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                User data = await _context.User.FindAsync(id);

                if(data == null)
                {
                    return NotFound("Usuario no exite en la base de datos");
                }

                return Ok(data);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] List<User> users)
        {
            try
            {
                foreach(User user in users)
                {
                    var existUser = _context.User.Where(p => p.UserName == user.UserName).FirstOrDefault();

                    if(existUser == null)
                    {
                        _context.Add(user);
                        await _context.SaveChangesAsync();
                    }            
                }

                GameService gs = new GameService(_context);

                CreateUserResponse dataResponse = gs.CreateGame(users);

                if(dataResponse.message != "OK")
                {
                    return NotFound(dataResponse.message);
                }
            
                return Ok(dataResponse);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {

            try
            {
                if(user.IdUSer != id)
                {
                    return NotFound();
                }

                _context.Update(user);
                 await _context.SaveChangesAsync();
                return Ok(new { message = "Usuario Modificado Correctamente " });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                var data = await _context.User.FindAsync(id);


                if (data == null)
                {
                    return NotFound("Usuario no Existen en la base de datos");
                }

                _context.User.Remove(data);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Usuario Eliminado Correctamente" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

         
        }
    }
}
