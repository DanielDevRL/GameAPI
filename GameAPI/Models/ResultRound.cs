using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameAPI.Models
{
    public class ResultRound
    {
        public int Id { get; set; }
       [Required]
        public int IdRound { get; set; }
        [Required]
        public long CodGame { get; set; }

        public string Result { get; set; }

        public int IdUser { get; set; }

    }
}
