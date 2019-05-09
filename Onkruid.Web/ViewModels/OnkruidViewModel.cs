using Microsoft.AspNetCore.Mvc.Rendering;
using Onkruid.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onkruid.Web.ViewModels
{
    public class OnkruidViewModel
    {

       
        //properties
        public SelectList Families { get; set; }

        public string SelectedFamilie { get; set; }


    }
}
