using Lab05.Helper;
using Lab05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab05.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Email()
        {
            return View();
        }

        public ActionResult EmailDetails(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        public ActionResult EmailCreate()
        {
            return View();
        }

        public ActionResult Logo(int LogoID, int IDLogo)
        {
            using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            {
                var email = db.CUSTOMER_EMAIL.Where(x => x.IdEmail == IDLogo && LogoID == x.IdCustomer).FirstOrDefault();
                if (email == null) return HttpNotFound();
                email.IsRead = true;
                db.SaveChanges();
            }
            return View();
        }

        [HttpPost]
        public ActionResult EmailCreate(EmailSendModel data)
        {
            if (!ModelState.IsValid) return View();

            using (THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities())
            {
                EMAIL e = new EMAIL();
                e.EmailTitle = data.title;
                e.EmailContent = data.content;
                db.EMAILs.Add(e);
                db.SaveChanges();
                foreach (var customer in db.CUSTOMERs.ToList())
                {
                    CUSTOMER_EMAIL c = new CUSTOMER_EMAIL();
                    c.IdCustomer = customer.IdCustomer;
                    
                    e.CUSTOMER_EMAIL.Add(c);
                    try
                    {
                        SendMail.Send(data.title, data.content, customer, e.IdEmail);
                        c.IsRead = false;
                    }
                    catch (Exception ex)
                    {

                    }
                }
                db.SaveChanges();
            }



            return RedirectToAction("Email");
        }
    }
}