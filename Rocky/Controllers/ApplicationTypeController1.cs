﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rocky_DataAccess;
using Rocky_DataAccess.Repository.IRepository;
using Rocky_Models;
using Rocky_Utility;

namespace Rocky.Controllers
{
    [Authorize(Roles = WC.AdminRole)]
    public class ApplicationTypeController1 : Controller
    {

        private readonly IApplicationTypeRepository _appTypeRepo;

        public ApplicationTypeController1(IApplicationTypeRepository appTypeRepo)
        {
            _appTypeRepo = appTypeRepo;
        }





        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = _appTypeRepo.GetAll();

            return View(objList);
        }


        //Get -Create
        public IActionResult Create()
        {
           

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Get -Create
        public IActionResult Create(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _appTypeRepo.Add(obj);
                _appTypeRepo.Save();

                return RedirectToAction("Index");
            }
            return View(obj);
           
        }

        // Get- Edit
        public IActionResult Edit(int? id)
        {

            if(id == null)
            {
                return NotFound();

            }

            var obj = _appTypeRepo.Find(id.GetValueOrDefault());
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Post- Edit
        public IActionResult Edit(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _appTypeRepo.Update(obj);

                _appTypeRepo.Save();
                return RedirectToAction("Index");

            }
            return View(obj);
        }

        //Get -Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _appTypeRepo.Find(id.GetValueOrDefault());
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Post -Delete
        public IActionResult DeletePost(int? id)
        {
            var obj = _appTypeRepo.Find(id.GetValueOrDefault());
            if (obj == null)
            {
                return NotFound();
            }
            _appTypeRepo.Remove(obj);
            _appTypeRepo.Save();


            return RedirectToAction("Index");



        }
    }
}
