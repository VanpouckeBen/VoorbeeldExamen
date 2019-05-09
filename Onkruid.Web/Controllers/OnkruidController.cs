using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onkruid.Core.Repositories;

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
            var families = await _repo.GetFamiliesAsync();



            return View(families);
        }

        // GET: Onkruid/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Onkruid/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Onkruid/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Onkruid/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Onkruid/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Onkruid/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Onkruid/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}