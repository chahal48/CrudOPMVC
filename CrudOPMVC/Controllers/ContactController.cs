using CrudOPMVC.Models;
using CrudOPMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudOPMVC.Controllers
{
    public class ContactController : Controller
    {
        const string ConnectionErrorMessage = "Invalid credentials or connection erorr.";

        ContactsRepository contactRepo = new ContactsRepository();
        ProfessionRepository professionRepo = new ProfessionRepository();
        // GET: Contact/GetAllContact
        public ActionResult GetAllContacts()
        {
            ModelState.Clear();
            return View(contactRepo.GetAllContacts());
        }

        // GET: Contact/AddContact
        public ActionResult AddContact()
        {
            ViewBag.itemlist = new SelectList(professionRepo.GetAllProfessions().OrderBy(e => e.Profession), "ProfessionID", "Profession");

            return View();
        }

        // POST: Contact/AddContact
        [HttpPost]
        public ActionResult AddContact(ContactModel contactModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if (contactRepo.AddContact(contactModel))
                    {
                        //ViewBag.Message = "Contact details added successfully";
                        return RedirectToAction("GetAllContacts", "Contact");
                    }
                    else
                    {
                        ViewBag.Message = ConnectionErrorMessage;
                    }
                }
                ViewBag.itemlist = new SelectList(professionRepo.GetAllProfessions().OrderBy(e => e.Profession), "ProfessionID", "Profession");
                return View();
            }
            catch
            {
                ViewBag.Message = ConnectionErrorMessage;
                ViewBag.itemlist = new SelectList(professionRepo.GetAllProfessions().OrderBy(e => e.Profession), "ProfessionID", "Profession");
                return View();
            }
        }

        // GET: Contact/EditContactDetails/5
        public ActionResult EditContactDetails(int id)
        {
            ViewBag.itemlist = new SelectList(professionRepo.GetAllProfessions().OrderBy(e => e.Profession), "ProfessionID", "Profession");
            return View(contactRepo.GetAllContacts().Find(Contact => Contact.ContactID == id));
        }

        // POST: Contact/EditContactDetails/5
        [HttpPost]

        public ActionResult EditContactDetails(int id, ContactModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (contactRepo.UpdateContact(obj))
                    {
                        //ViewBag.Message = "Contact details added successfully";
                        return RedirectToAction("GetAllContacts", "Contact");
                    }
                    else
                    {
                        ViewBag.Message = ConnectionErrorMessage;
                    }
                }
                ViewBag.itemlist = new SelectList(professionRepo.GetAllProfessions().OrderBy(e => e.Profession), "ProfessionID", "Profession");
                return View();
            }
            catch
            {
                ViewBag.Message = ConnectionErrorMessage;
                ViewBag.itemlist = new SelectList(professionRepo.GetAllProfessions().OrderBy(e => e.Profession), "ProfessionID", "Profession");
                return View();
            }
        }

        // GET: Contact/DeleteContact/5
        public ActionResult DeleteContact(int id)
        {
            try
            {
                if (contactRepo.DeleteContact(id))
                {
                    ViewBag.AlertMsg = "Contact details deleted successfully";
                }
                return RedirectToAction("GetAllContacts");
            }
            catch
            {
                return View();
            }
        }
    }
}