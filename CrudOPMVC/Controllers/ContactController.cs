using CrudOPMVC.Models;
using CrudOPMVC.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

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
                    if (contactModel.Image != null && contactModel.Image.ContentLength > 0)
                    {
                        string mapPath = Server.MapPath("/Upload");
                        Guid guid = Guid.NewGuid();
                        string fileExtention = Path.GetExtension(contactModel.Image.FileName);
                        string FullImageName = guid.ToString() + fileExtention;
                        string fullPath = Path.Combine(mapPath, FullImageName);
                        contactModel.Image.SaveAs(fullPath);

                        contactModel.ContactImage = FullImageName;
                    }

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

        public ActionResult EditContactDetails(int id, ContactModel contactModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (contactModel.Image != null && contactModel.Image.ContentLength > 0)
                    {
                        string mapPath = Server.MapPath("/Upload");
                        Guid guid = Guid.NewGuid();
                        string fileExtention = Path.GetExtension(contactModel.Image.FileName);
                        string FullImageName = guid.ToString() + fileExtention;
                        string fullPath = Path.Combine(mapPath, FullImageName);
                        contactModel.Image.SaveAs(fullPath);

                        #region Delete Previous Image
                        string DeleteFile = contactRepo.GetAllContacts().Find(Contact => Contact.ContactID == id).ContactImage;
                        string DeleteFilePath = Path.Combine(mapPath, DeleteFile);
                        FileInfo file = new FileInfo(DeleteFilePath);
                        if (file.Exists)//check file exsit or not  
                        {
                            file.Delete();
                        }
                        #endregion

                        contactModel.ContactImage = FullImageName;
                    }
                    else
                    {
                        contactModel.ContactImage = contactRepo.GetAllContacts().Find(Contact => Contact.ContactID == id).ContactImage;
                    }

                    if (contactRepo.UpdateContact(contactModel))
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
                return View(contactModel);
            }
            catch
            {
                ViewBag.Message = ConnectionErrorMessage;
                ViewBag.itemlist = new SelectList(professionRepo.GetAllProfessions().OrderBy(e => e.Profession), "ProfessionID", "Profession");
                return View(contactModel);
            }
        }

        // GET: Contact/ContactDetails/5
        public ActionResult ContactDetails(int id)
        {
            return View(contactRepo.GetAllContacts().Find(Contact => Contact.ContactID == id));
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

        // GET: Contact/NextContact/5
        public ActionResult NextContact(int id)
        {
            try
            {
                var Result = contactRepo.GetAllContacts().SkipWhile(Contact => Contact.ContactID != id).Skip(1).FirstOrDefault();
                
                if (Result != null)
                {
                    return RedirectToAction("ContactDetails", new RouteValueDictionary(new { controller = "Contact", action = "ContactDetails", id = Result.ContactID }));
                }
                else
                {
                    int FirstRecord = contactRepo.GetAllContacts().First().ContactID;
                    return RedirectToAction("ContactDetails", new RouteValueDictionary(new { controller = "Contact", action = "ContactDetails", id = FirstRecord }));
                }
            }
            catch
            {
                return RedirectToAction("GetAllContacts", "Contact");
            }
        }
        
        // GET: Contact/PreviousContact/5
        public ActionResult PreviousContact(int id)
        {
            try
            {
                var Result = contactRepo.GetAllContacts().OrderByDescending(Contact => Contact.ContactID).SkipWhile(Contact => Contact.ContactID != id).Skip(1).FirstOrDefault();

                if (Result != null)
                {
                    return RedirectToAction("ContactDetails", new RouteValueDictionary(new
                    {
                        controller = "Contact",
                        action = "ContactDetails",
                        id = Result.ContactID
                    }));
                }
                else
                {
                    int LastRecord = contactRepo.GetAllContacts().OrderByDescending(Contact => Contact.ContactID).First().ContactID;
                    return RedirectToAction("ContactDetails", new RouteValueDictionary(new { controller = "Contact", action = "ContactDetails", id = LastRecord }));
                }
            }
            catch
            {
                return RedirectToAction("GetAllContacts", "Contact");
            }
        }

        // Unique field validation
        [HttpPost]
        public JsonResult IsEmailAvailable([Bind(Prefix = "emailAddr")] string emailAddr, string initialEmail)
        {
            if (initialEmail != "")
            {
                if (emailAddr.ToLower() == initialEmail.ToLower())
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }

            var result = contactRepo.GetAllContacts().FirstOrDefault(a => a.emailAddr.ToLower() == emailAddr.ToLower());
            if (result == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}