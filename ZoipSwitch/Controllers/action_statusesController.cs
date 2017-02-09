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
    public class action_statusesController : Controller
    {
        // GET: action_statuses
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

                IQueryable<action_statuses> action_statuses = db.Action_Statuses;
                if (!string.IsNullOrEmpty(name))
                {
                    action_statuses = action_statuses.Where(p => p.action_status_name.StartsWith(name));
                }
                DataSourceResult result = action_statuses.ToDataSourceResult(request);
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
                action_statuses action_statuses = db.Action_Statuses.Find(id);
                if (action_statuses == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("Details", action_statuses);
                }
            }
        }

        //[Authorize(Roles = "administrator")]
        public ActionResult Create()
        {
            var item = new action_statuses();
            return View("Template", item);
        }

        //[Authorize(Roles = "administrator")]
        public ActionResult Save(action_statuses action_statuses)
        {
            try
            {
                using (db)
                {
                    if (action_statuses.action_status_id == 0)
                    {
                        var entity = new action_statuses
                        {
                            action_status_id = action_statuses.action_status_id,
                            action_status_name = action_statuses.action_status_name

                        };
                        db.Action_Statuses.Add(entity);
                    }
                    else
                    {
                        action_statuses item = db.Action_Statuses.Find(action_statuses.action_status_id);
                        item.action_status_id = action_statuses.action_status_id;
                        item.action_status_name = action_statuses.action_status_name;
                        db.Action_Statuses.Attach(item);
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

                action_statuses item = db.Action_Statuses.Find(id);
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
                    action_statuses item = db.Action_Statuses.Find(id);
                    db.Action_Statuses.Attach(item);
                    db.Action_Statuses.Remove(item);
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