using GameAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameAPI.Service
{
    public class RegisterMovements
    {

        private readonly AplicationDbContext _context;

        public string[] Movents = new string []{ "Piedra", "Papel", "Tijera" };
        public RegisterMovements (AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateMovents()
        {
            try
            {
                foreach(string m in Movents)
                {
                    Movement data = new Movement();

                    data.MovementName = m;

                    _context.Add(data);
                    await _context.SaveChangesAsync();

                }

                return "OK";
                

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

    }
}
