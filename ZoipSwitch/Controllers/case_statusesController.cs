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
    public class case_statusesController : Controller
    {
        private Context db = new Context();

        //[Authorize(Roles = "administrator")]
        public ActionResult Index()
        {
            using (db)
            {
                return View("Index", db.Case_Statuses.ToList());
            }
        }

        //[Authorize(Roles = "administrator")]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request, string name)
        {
            using (db)
            {

                IQueryable<case_statuses> case_statuses = db.Case_Statuses;
                if (!string.IsNullOrEmpty(name))
                {
                    case_statuses = case_statuses.Where(p => p.case_status_name.StartsWith(name));
                }
                
                DataSourceResult result = case_statuses.ToDataSourceResult(request);
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
                case_statuses case_statuses = db.Case_Statuses.Find(id);
                if (case_statuses == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("Details", case_statuses);
                }
            }
        }

        //[Authorize(Roles = "administrator")]
        public ActionResult Create()
        {
            var item = new case_statuses();
            return View("Template", item);
        }

        //[Authorize(Roles = "administrator")]
        public ActionResult Save(case_statuses case_statuses)
        {
            try
            {
                using (db)
                {
                    if (case_statuses.case_status_id == 0)
                    {
                        var entity = new case_statuses
                        {
                            case_status_id = case_statuses.case_status_id,
                            case_status_name = case_statuses.case_status_name

                        };
                        db.Case_Statuses.Add(entity);
                    }
                    else
                    {
                        case_statuses item = db.Case_Statuses.Find(case_statuses.case_status_id);
                        item.case_status_id = case_statuses.case_status_id;
                        item.case_status_name = case_statuses.case_status_name;
                        db.Case_Statuses.Attach(item);
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

                case_statuses item = db.Case_Statuses.Find(id);
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
                    case_statuses item = db.Case_Statuses.Find(id);
                    db.Case_Statuses.Attach(item);
                    db.Case_Statuses.Remove(item);
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
