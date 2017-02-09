using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZoipSwitch.DAL;
using ZoipSwitch.Models;

namespace ZoipSwitch.Controllers
{
    public class case_typesController : Controller
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

                IQueryable<case_types> case_types = db.Case_Types;
                if (!string.IsNullOrEmpty(name))
                {
                    case_types = case_types.Where(p => p.case_type_name.StartsWith(name));
                }
                DataSourceResult result = case_types.ToDataSourceResult(request);
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
                case_types case_types = db.Case_Types.Find(id);
                if (case_types == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("Details", case_types);
                }
            }
        }

        //[Authorize(Roles = "administrator")]
        public ActionResult Create()
        {
            var item = new case_types();
            return View("Template", item);
        }

        //[Authorize(Roles = "administrator")]
        public ActionResult Save(case_types case_types)
        {
            try
            {
                using (db)
                {
                    if (case_types.case_type_id == 0)
                    {
                        var entity = new case_types
                        {
                            case_type_id = case_types.case_type_id,
                            case_type_name = case_types.case_type_name

                        };
                        db.Case_Types.Add(entity);
                    }
                    else
                    {
                        case_types item = db.Case_Types.Find(case_types.case_type_id);
                        item.case_type_id = case_types.case_type_id;
                        item.case_type_name = case_types.case_type_name;
                        db.Case_Types.Attach(item);
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

                case_types item = db.Case_Types.Find(id);
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
                    case_types item = db.Case_Types.Find(id);
                    db.Case_Types.Attach(item);
                    db.Case_Types.Remove(item);
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
