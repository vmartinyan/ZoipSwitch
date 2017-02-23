using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZoipSwitch.DAL;
using ZoipSwitch.Models;

namespace ZoipSwitch.Controllers
{
    public class residentsController : Controller
    {
        // GET: action_types
        private Context db = new Context();

        //[Authorize(Roles = "administrator")]
        //[OutputCache(Duration = 30, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }


        //[Authorize(Roles = "administrator")]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request, string name, string lastname, /*DateTime birthdate,*/ string phone, string email)
        {
            using (db)
            {

                IQueryable<residents> residents = db.Residents;
                if (!string.IsNullOrEmpty(name))
                {
                    residents = residents.Where(p => p.resident_name.StartsWith(name));
                }
                if (!string.IsNullOrEmpty(lastname))
                {
                    residents = residents.Where(p => p.resident_lastname.StartsWith(lastname));
                }
                //if (birthdate != null)
                //{
                //    residents = residents.Where(p => p.resident_birthdate == birthdate);
                //}
                if (!string.IsNullOrEmpty(phone))
                {
                    residents = residents.Where(p => p.resident_phone.StartsWith(phone));
                }
                if (!string.IsNullOrEmpty(email))
                {
                    residents = residents.Where(p => p.resident_email.StartsWith(email));
                }
                DataSourceResult result = residents.ToDataSourceResult(request);
                return Json(result);
            }

        }


        //[Authorize(Roles = "administrator")]
        public ActionResult Details(int? id)
        {
            using (db)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                residents residents = db.Residents.Find(id);
                if (residents == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("Details", residents);
                }
            }
        }

        //[Authorize(Roles = "administrator")]
        public ActionResult Create()
        {
            var item = new residents();
            return View("Template", item);
        }



        //[Authorize(Roles = "administrator")]
        public ActionResult Save(residents residents)
        {
            try
            {
                using (db)
                {
                    if (residents.resident_id == 0)
                    {
                        var entity = new residents
                        {
                            resident_id = residents.resident_id,
                            resident_name = residents.resident_name,
                            resident_lastname = residents.resident_lastname,
                            resident_birthdate = residents.resident_birthdate,
                            resident_phone = residents.resident_phone,
                            resident_email = residents.resident_email
                        };
                        db.Residents.Add(entity);
                    }
                    else
                    {
                        residents item = db.Residents.Find(residents.resident_id);
                        item.resident_id = residents.resident_id;
                        item.resident_name = residents.resident_name;
                        item.resident_lastname = residents.resident_lastname;
                        item.resident_birthdate = residents.resident_birthdate;
                        item.resident_phone = residents.resident_phone;
                        item.resident_email = residents.resident_email;
                        db.Residents.Attach(item);
                        db.Entry(item).State = EntityState.Modified;
                    }

                    db.SaveChanges();
                    return Json("1", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }


        //[Authorize(Roles = "administrator")]
        public ActionResult Update(int? id)
        {
            using (db)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                residents item = db.Residents.Find(id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("Template", item);
                }
            }
        }


        //[Authorize(Roles = "administrator")]
        public ActionResult Delete(int? id)
        {
            try
            {
                using (db)
                {
                    residents item = db.Residents.Find(id);
                    db.Residents.Attach(item);
                    db.Residents.Remove(item);
                    db.SaveChanges();
                }
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}