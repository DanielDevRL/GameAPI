using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameAPI.Models
{
    public class Movement
    {
        [Key]
        public int IdMovement { get; set; }

        public string MovementName { get; set; }


    }
}
