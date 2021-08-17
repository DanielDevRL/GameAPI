using GameAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameAPI.Response
{
    public class ResponseCalculateWinner
    {
        public string message { get; set; }
        public int typeReponse { get; set; }
        public ResultRound resultRount {get;set;}

    }
}
