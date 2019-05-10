using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Onkruid.Core.Models;
using Onkruid.Core.Repositories;
using Onkruid.Web.ViewModels;

namespace Onkruid.Web.Controllers
{
    public class OnkruidController : Controller
    {
        //fields
        private readonly IOnkruidRepo _repo;

        //constructor
        public OnkruidController(IOnkruidRepo repo)
        {
            this._repo = repo;
        }    

        // GET: Onkruid
        public async Task<IActionResult> Index()
        {
            //1. families ophalen
            var families = await _repo.GetFamiliesAsync();

            //2. vul view model
            OnkruidViewModel onkruidVM = new OnkruidViewModel()
            {
                Families = new SelectList(families, "Familie_Naam", "Familie_Naam"),
               
            };


            return View(onkruidVM);
        }

        [HttpPost]
        public async Task<IActionResult> Index(OnkruidViewModel onkruidVM)
        {
            //1. families ophalen
            IEnumerable<Familie> families = await _repo.GetFamiliesAsync();
            IEnumerable<Onkruid_Naam> onkruid_Namen = await _repo.GetOnkruidNamenAsync(onkruidVM.SelectedFamilie);

            //2. vul view model
            onkruidVM = new OnkruidViewModel()
            {
                Families = new SelectList(families, "Familie_Naam", "Familie_Naam",onkruidVM.SelectedFamilie),
                Onkruid_Namen = onkruid_Namen.ToList()
            };

            //3. toon view
            return View(onkruidVM);
        }

        // GET: Onkruid/Details/5
        public async Task<IActionResult> Details(string wetenschappelijkeNaam)
        {
            //1. details opvragen bij familie
            Onkruid_Naam Onkruid_Naam = await _repo.GetOnkruidNaamAsync(wetenschappelijkeNaam);

            //2. toon details
            return View(Onkruid_Naam);
        }

    }
}