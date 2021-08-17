using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameAPI.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public long CodGame { get; set; }
       
        public DateTime CrateGame { get; set; }
    }
}
