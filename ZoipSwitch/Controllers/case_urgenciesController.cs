using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ZoipSwitch.Models;
using ZoipSwitch.DAL;

namespace ZoipSwitch.Controllers
{
    public class case_urgenciesController : Controller
    {
        private Context db = new Context();

        //[Authorize(Roles = "administrator")]
        //[OutputCache(Duration = 30, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }

        //[Authorize(Roles = "administrator")]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request, string name)
        {
            using (db)
            {

                IQueryable<case_urgencies> case_urgencies = db.Case_Urgencies;
                if (!string.IsNullOrEmpty(name))
                {
                    case_urgencies = case_urgencies.Where(p => p.case_urgency_name.StartsWith(name));
                }
                DataSourceResult result = case_urgencies.ToDataSourceResult(request);
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
                case_urgencies case_urgencies = db.Case_Urgencies.Find(id);
                if (case_urgencies == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("Details", case_urgencies);
                }
            }
        }

        //[Authorize(Roles = "administrator")]
        public ActionResult Create()
        {
            var item = new case_urgencies();
            return View("Template", item);
        }

        //[Authorize(Roles = "administrator")]
        public ActionResult Save(case_urgencies case_urgencies)
        {
            try
            {
                using (db)
                {
                    if (case_urgencies.case_urgency_id == 0)
                    {
                        var entity = new case_urgencies
                        {
                            case_urgency_id = case_urgencies.case_urgency_id,
                            case_urgency_name = case_urgencies.case_urgency_name

                        };
                        db.Case_Urgencies.Add(entity);
                    }
                    else
                    {
                        case_urgencies item = db.Case_Urgencies.Find(case_urgencies.case_urgency_id);
                        item.case_urgency_id = case_urgencies.case_urgency_id;
                        item.case_urgency_name = case_urgencies.case_urgency_name;
                        db.Case_Urgencies.Attach(item);
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

                case_urgencies item = db.Case_Urgencies.Find(id);
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
                    case_urgencies item = db.Case_Urgencies.Find(id);
                    db.Case_Urgencies.Attach(item);
                    db.Case_Urgencies.Remove(item);
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