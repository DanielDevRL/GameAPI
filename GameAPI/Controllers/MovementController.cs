using GameAPI.Models;
using GameAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public MovementController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("getListMovement")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List <Movement> listMovement = new List<Movement>();

                listMovement = await _context.Movement.ToListAsync();
                
                if (listMovement.Count == 0)
                {
                    RegisterMovements register = new RegisterMovements(_context);

                    await register.CreateMovents();
                }

                listMovement = await _context.Movement.ToListAsync();


                return Ok(listMovement);


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
