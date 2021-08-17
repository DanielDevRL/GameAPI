using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameAPI.Models
{
    public class Round
    {
        [Key]
        public int IdRound { get; set; }
        public long CodGame { get; set; }
        public int IdUSer { get; set; }
        public int IdMovement { get; set; }
        public int  RoundNumber { get;set; }
    }
}
