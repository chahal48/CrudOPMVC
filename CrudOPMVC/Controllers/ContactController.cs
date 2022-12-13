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
        // GET: Profession/GetAllProfession
        public ActionResult GetAllContacts()
        {
            ContactsRepository contactRepo = new ContactsRepository();
            ModelState.Clear();
            return View(contactRepo.GetAllContacts());
        }
    }
}