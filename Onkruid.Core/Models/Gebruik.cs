using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Onkruid.Core.Models
{
    public class Gebruik
    {
        [Key]
        public string Gebruik_Nr { get; set; }

        public string Gebruik_Beschrijving { get; set; }
    }
}
