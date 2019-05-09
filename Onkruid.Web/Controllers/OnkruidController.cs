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

        //// GET: Onkruid/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Onkruid/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Onkruid/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Onkruid/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Onkruid/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Onkruid/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Onkruid/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}