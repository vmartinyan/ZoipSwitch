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
    public class case_departmentsController : Controller
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

                IQueryable<case_departments> case_departments = db.Case_Departments;
                if (!string.IsNullOrEmpty(name))
                {
                    case_departments = case_departments.Where(p => p.case_department_name.StartsWith(name));
                }
                DataSourceResult result = case_departments.ToDataSourceResult(request);
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
                case_departments case_departments = db.Case_Departments.Find(id);
                if (case_departments == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("Details", case_departments);
                }
            }
        }

        //[Authorize(Roles = "administrator")]
        public ActionResult Create()
        {
            var item = new case_departments();
            return View("Template", item);
        }

        //[Authorize(Roles = "administrator")]
        public ActionResult Save(case_departments case_departments)
        {
            try
            {
                using (db)
                {
                    if (case_departments.case_department_id == 0)
                    {
                        var entity = new case_departments
                        {
                            case_department_id = case_departments.case_department_id,
                            case_department_name = case_departments.case_department_name

                        };
                        db.Case_Departments.Add(entity);
                    }
                    else
                    {
                        case_departments item = db.Case_Departments.Find(case_departments.case_department_id);
                        item.case_department_id = case_departments.case_department_id;
                        item.case_department_name = case_departments.case_department_name;
                        db.Case_Departments.Attach(item);
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

                case_departments item = db.Case_Departments.Find(id);
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
                    case_departments item = db.Case_Departments.Find(id);
                    db.Case_Departments.Attach(item);
                    db.Case_Departments.Remove(item);
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