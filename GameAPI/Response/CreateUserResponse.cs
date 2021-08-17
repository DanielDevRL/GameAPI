using GameAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameAPI.Response
{
    public class CreateUserResponse
    {
        public string message { get; set; }
        public string CodGame { get; set; }
        public string RoundNumer { get; set; }
         public User Player1 { get; set; }

        public User Player2 { get; set; }

    }
}
