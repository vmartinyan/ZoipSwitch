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
    public class action_categoriesController : Controller
    {
        // GET: action_categories
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

                IQueryable<action_categories> action_categories = db.Action_Categories;
                if (!string.IsNullOrEmpty(name))
                {
                    action_categories = action_categories.Where(p => p.action_category_name.StartsWith(name));
                }
                DataSourceResult result = action_categories.ToDataSourceResult(request);
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
                action_categories action_categories = db.Action_Categories.Find(id);
                if (action_categories == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("Details", action_categories);
                }
            }
        }

        //[Authorize(Roles = "administrator")]
        public ActionResult Create()
        {
            var item = new action_categories();
            return View("Template", item);
        }

        //[Authorize(Roles = "administrator")]
        public ActionResult Save(action_categories action_categories)
        {
            try
            {
                using (db)
                {
                    if (action_categories.action_category_id == 0)
                    {
                        var entity = new action_categories
                        {
                            action_category_id = action_categories.action_category_id,
                            action_category_name = action_categories.action_category_name

                        };
                        db.Action_Categories.Add(entity);
                    }
                    else
                    {
                        action_categories item = db.Action_Categories.Find(action_categories.action_category_id);
                        item.action_category_id = action_categories.action_category_id;
                        item.action_category_name = action_categories.action_category_name;
                        db.Action_Categories.Attach(item);
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

                action_categories item = db.Action_Categories.Find(id);
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
                    action_categories item = db.Action_Categories.Find(id);
                    db.Action_Categories.Attach(item);
                    db.Action_Categories.Remove(item);
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