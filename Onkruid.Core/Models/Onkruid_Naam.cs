using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Onkruid.Core.Models
{
    public class Onkruid_Naam
    {
        [Column("Wetenschappelijke Naam")]
        public string Wetenschappelijke_Naam { get; set; }

        [Column("Nederlandse Naam")]
        public string Nederlandse_Naam { get; set; }


        public string Familie_Naam { get; set; } //fk

        public string Gebruik_Nr { get; set; } //fk

        //look-up properties
        public Familie Familie { get; set; }
        public Gebruik Gebruik { get; set; }

        //calculated property
        [NotMapped]
        public string Image => $"Images/{Wetenschappelijke_Naam}jpg";
    }
}
