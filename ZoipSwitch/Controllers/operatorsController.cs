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
    public class operatorsController : Controller
    {
        // GET: action_types
        private Context db = new Context();

        //[Authorize(Roles = "administrator")]
        //[OutputCache(Duration = 30, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }


        private void OrganizeViewBugs(Context db)
        {
            var lextensions = new List<SelectListItem>();
            lextensions = db.Agents.Select(x => new SelectListItem { Text = x.name.Substring(0, x.name.IndexOf("@")), Value = x.name }).ToList();
            ViewBag.vbextensions = lextensions;

        }


        //[Authorize(Roles = "administrator")]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request, string name, string lastname, /*DateTime birthdate,*/ string phone, string email, string ext)
        {
            using (db)
            {

                IQueryable<operators> operators = db.Operators;
                if (!string.IsNullOrEmpty(name))
                {
                    operators = operators.Where(p => p.name.StartsWith(name));
                }
                if (!string.IsNullOrEmpty(lastname))
                {
                    operators = operators.Where(p => p.lastname.StartsWith(lastname));
                }
                //if (birthdate != null)
                //{
                //    operators = operators.Where(p => p.resident_birthdate == birthdate);
                //}
                if (!string.IsNullOrEmpty(phone))
                {
                    operators = operators.Where(p => p.phone.StartsWith(phone));
                }
                if (!string.IsNullOrEmpty(ext))
                {
                    operators = operators.Where(p => p.extension.StartsWith(ext));
                }
                if (!string.IsNullOrEmpty(email))
                {
                    operators = operators.Where(p => p.email.StartsWith(email));
                }
                DataSourceResult result = operators.ToDataSourceResult(request);
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
                operators operators = db.Operators.Find(id);
                if (operators == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("Details", operators);
                }
            }
        }

        //[Authorize(Roles = "administrator")]
        public ActionResult Create()
        {
            OrganizeViewBugs(db);
            var item = new operators();
            return View("Template", item);
        }

        //[Authorize(Roles = "administrator")]
        public ActionResult Save(operators operators)
        {
            try
            {
                using (db)
                {
                    if (operators.operator_id == 0)
                    {
                        var entity = new operators
                        {
                            operator_id = operators.operator_id,
                            extension = operators.extension,
                            name = operators.name,
                            lastname = operators.lastname,
                            birthdate = operators.birthdate,
                            phone = operators.phone,
                            email = operators.email
                        };
                        db.Operators.Add(entity);
                    }
                    else
                    {
                        operators item = db.Operators.Find(operators.operator_id);
                        item.operator_id = operators.operator_id;
                        item.extension = operators.extension;
                        item.name = operators.name;
                        item.lastname = operators.lastname;
                        item.birthdate = operators.birthdate;
                        item.phone = operators.phone;
                        item.email = operators.email;
                        db.Operators.Attach(item);
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
            OrganizeViewBugs(db);
            using (db)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                operators item = db.Operators.Find(id);
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
                    operators item = db.Operators.Find(id);
                    db.Operators.Attach(item);
                    db.Operators.Remove(item);
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