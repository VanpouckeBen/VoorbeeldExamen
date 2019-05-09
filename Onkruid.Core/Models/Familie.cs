using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Onkruid.Core.Models
{
    
    public class Familie
    {
        [Key]
        public string Familie_Naam { get; set; }
    }
}
