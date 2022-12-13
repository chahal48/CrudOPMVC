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

        // GET: Profession/GetAllProfession
        public ActionResult GetAllProfession()
        {
            ProfessionRepository professionRepo = new ProfessionRepository();
            ModelState.Clear();
            return View(professionRepo.GetAllProfessions());
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
                    ProfessionRepository profRepository = new ProfessionRepository();

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
            ProfessionRepository profRepository = new ProfessionRepository();
            return View(profRepository.GetAllProfessions().Find(prof => prof.ProfessionID == id));

        }

        // POST: Profession/EditProfessionDetails/5
        [HttpPost]

        public ActionResult EditProfessionDetails(int id, ProfessionModel obj)
        {
            try
            {
                ProfessionRepository profRepository = new ProfessionRepository();

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
                ProfessionRepository professionRepository = new ProfessionRepository();
                if (professionRepository.DeleteProfession(id))
                {
                    ViewBag.AlertMsg = "Employee details deleted successfully";

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