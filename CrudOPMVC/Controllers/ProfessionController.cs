using CrudOPMVC.Models;
using CrudOPMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace CrudOPMVC.Controllers
{
    public class ProfessionController : Controller
    {
        ProfessionRepository profRepository = new ProfessionRepository();
        // GET: Profession/GetAllProfession
        public ActionResult GetAllProfession()
        {
            ModelState.Clear();
            return View(profRepository.GetAllProfessions());
        }

        // GET: Profession/AddProfession
        public ActionResult AddProfession()
        {
            return View();
        }

        // POST: Profession/AddProfession
        [HttpPost]
        public ActionResult AddProfession(ProfessionModel prof)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (profRepository.AddProfession(prof))
                    {
                        //ViewBag.Message = "Profession details added successfully";
                        return RedirectToAction("GetAllProfession", "Profession");
                    }
                    else
                    {
                        ViewBag.Message = "Error adding profession details";
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        // GET: Profession/EditProfessionDetails/5
        public ActionResult EditProfessionDetails(int id)
        {
            return View(profRepository.GetAllProfessions().Find(prof => prof.ProfessionID == id));
        }

        // POST: Profession/EditProfessionDetails/5
        [HttpPost]

        public ActionResult EditProfessionDetails(int id, ProfessionModel obj)
        {
            try
            {
                profRepository.UpdateProfession(obj);

                return RedirectToAction("GetAllProfessions");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profession/DeleteProfession/5
        public ActionResult DeleteProfession(int id)
        {
            try
            {
                if (profRepository.DeleteProfession(id))
                {
                    ViewBag.AlertMsg = "Profession details deleted successfully";

                }
                return RedirectToAction("GetAllProfession");
            }
            catch
            {
                return View();
            }
        }
    }
}