using CrudOPMVC.Models;
using CrudOPMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace CrudOPMVC.Controllers
{
    public class ProfessionController : Controller
    {
        const string ConnectionErrorMessage = "Invalid credentials or connection erorr.";

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
                        ViewBag.Message = ConnectionErrorMessage;
                    }
                }
                return View();
            }
            catch
            {
                ViewBag.Message = ConnectionErrorMessage;
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
                if (profRepository.UpdateProfession(obj))
                {
                    //ViewBag.Message = "Profession details added successfully";
                    return RedirectToAction("GetAllProfession", "Profession");
                }
                else
                {
                    ViewBag.Message = ConnectionErrorMessage;
                }
                return View(obj);
            }
            catch
            {
                ViewBag.Message = ConnectionErrorMessage;
                return View(obj);
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

        [HttpPost]
        public JsonResult IsProfessionAvailable([Bind(Prefix = "Profession")] string Profession, string initialProfession)
        {
            if (initialProfession != "")
            {
                if (Profession.ToLower() == initialProfession.ToLower())
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }

            var result = profRepository.GetAllProfessions().FirstOrDefault(a => a.Profession.ToLower() == Profession.ToLower());
            if (result == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}