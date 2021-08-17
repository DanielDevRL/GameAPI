using GameAPI.Models;
using GameAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoundController : ControllerBase
    {

        private readonly AplicationDbContext _context;

        public RoundController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("ListResultRount")]
        public async Task<IActionResult> Get(long codGame)
        {
            try
            {
                var list =  _context.ResultRound.Where(p => p.CodGame == codGame).ToList();

                return Ok(list);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("RegisterMovement")]
        public async Task<IActionResult> Post(bool calc, [FromBody] Round round)
        {
            try
            {

                _context.Add(round);
                await _context.SaveChangesAsync();

                //calc = true calcula es resultado de la ronda si no solo registra el movimiento
                if (calc)
                {
                    CalculateWinner cw = new CalculateWinner(_context);
                  var responseWr =  cw.WinnerRound(round.CodGame, round.RoundNumber);

                    if(responseWr.typeReponse == 0)
                    {
                        return BadRequest(responseWr.message);
                    }

                    var responsWG = cw.WinnerGame(responseWr.resultRount.IdUser, responseWr.resultRount.CodGame);

                    if(responsWG.TypeRespose == 0)
                    {
                        return BadRequest(responsWG.message);
                    }

                    return Ok(responsWG);

                }
                else
                {
                    return Ok(new { message = "Siguiente"});
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
