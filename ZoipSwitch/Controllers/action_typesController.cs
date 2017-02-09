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
    public class action_typesController : Controller
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
        public ActionResult Read([DataSourceRequest]DataSourceRequest request, string name)
        {
            using (db)
            {

                IQueryable<action_types> action_types = db.Action_Types;
                if (!string.IsNullOrEmpty(name))
                {
                    action_types = action_types.Where(p => p.action_type_name.StartsWith(name));
                }
                DataSourceResult result = action_types.ToDataSourceResult(request);
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
                action_types action_types = db.Action_Types.Find(id);
                if (action_types == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("Details", action_types);
                }
            }
        }

        //[Authorize(Roles = "administrator")]
        public ActionResult Create()
        {
            var item = new action_types();
            return View("Template", item);
        }

        //[Authorize(Roles = "administrator")]
        public ActionResult Save(action_types action_types)
        {
            try
            {
                using (db)
                {
                    if (action_types.action_type_id == 0)
                    {
                        var entity = new action_types
                        {
                            action_type_id = action_types.action_type_id,
                            action_type_name = action_types.action_type_name

                        };
                        db.Action_Types.Add(entity);
                    }
                    else
                    {
                        action_types item = db.Action_Types.Find(action_types.action_type_id);
                        item.action_type_id = action_types.action_type_id;
                        item.action_type_name = action_types.action_type_name;
                        db.Action_Types.Attach(item);
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

                action_types item = db.Action_Types.Find(id);
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
                    action_types item = db.Action_Types.Find(id);
                    db.Action_Types.Attach(item);
                    db.Action_Types.Remove(item);
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