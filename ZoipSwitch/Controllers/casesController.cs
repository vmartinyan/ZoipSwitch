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
    public class casesController : Controller
    {
        private Context db = new Context();
        // GET: cases
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            using (db)
            {
                //string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                IQueryable<vwCases> items = db.VwCases;
                DataSourceResult result = items.ToDataSourceResult(request);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        //[Authorize(Roles = "administrator")]
        public ActionResult Create()
        {
            OrganizeViewBugs(db);
            var item = new cases();
            item.case_status_id = 2;
            return View("CreateTemplate", item);
        }


        public ActionResult Save(cases cases)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return this.Json(new { statuscode = -1, message = "Model not vaild" }, JsonRequestBehavior.AllowGet);
                }

                using (db)
                {
                    // եթե 2-րդ մակարդակի աղյուսակի տողը նոր գրառումա ավելացնում ենք
                    if (cases.case_id == 0)
                    {
                        
                        //ավելացնել
                        db.Cases.Add(cases);

                        //հետո ավելացնում ենք ենթաաղյոսակների տողերը ամեն մի ենթաաղյուսակի համար, էս դեպքում 4 աղյուսակի համար
                        if (cases.Actions != null)
                        {
                            foreach (var item in cases.Actions)
                            {
                                if (item.RecordStatus == 1)
                                {
                                    item.cases = cases;
                                    db.Actions.Add(item);
                                }
                            }
                            foreach (var itm in cases.Actions)
                            {
                                
                                if (itm.action_status_id == 1)
                                {
                                    cases.initiator = itm.resident;
                                }

                                if (itm.action_status_id == 3)
                                {
                                    cases.case_status_id = 3;
                                    operators oper = db.Operators.Find(itm.operator_id);
                                    cases.creator_operator_name = oper.operatoe_name;
                                    cases.completing_operator_name = oper.operatoe_name;
                                    cases.start_date = itm.date;
                                    cases.end_date = itm.date;
                                    break;
                                }
                                else
                                {
                                    cases.case_status_id = 2;
                                    operators oper = db.Operators.Find(itm.operator_id);
                                    cases.creator_operator_name = oper.operatoe_name;
                                    cases.start_date = itm.date;
                                    cases.end_date = null;
                                }
                            }


                            List<actions> allActions = cases.Actions.ToList();
                            var closedActions = allActions.Where(p => p.action_status_id == 3);
                            var currentActions = allActions.Where(p => p.action_status_id == 2);
                            var creationActions = allActions.Where(p => p.action_status_id == 1);
                            if (closedActions.ToArray().Length > 1)
                            {
                                return Json(new { message = "The case must have only one closed action status" }, JsonRequestBehavior.AllowGet);
                            }
                            if (creationActions.ToArray().Length > 1)
                            {
                                return Json(new { message = "The case must have only one creation action status" }, JsonRequestBehavior.AllowGet);
                            }
                            if (currentActions.ToArray().Length > 0 && creationActions.ToArray().Length == 0 && closedActions.ToArray().Length == 0)
                            {
                                return Json(new { message = "The case can not have only current status" }, JsonRequestBehavior.AllowGet);
                            }

                        }
                        else
                        {
                            return Json(new { message = "The case must have at least one action" }, JsonRequestBehavior.AllowGet);
                        }

                    }
                    else
                    {
                        //Վերջում խմբագրում ենք 2-րդ մակարդակի աղյուսակի գրառումը
                        cases mCases = db.Cases.Find(cases.case_id);

                        //mCases.case_status_id = cases.case_status_id;
                        mCases.case_type_id = cases.case_type_id;
                        mCases.case_urgency_id = cases.case_urgency_id;
                        mCases.case_department_id = cases.case_department_id;
                        // mCases.start_date = cases.start_date;
                        //mCases.end_date = cases.end_date;
                        //mCases.creator_operator_name = cases.creator_operator_name;
                        // mCases.completing_operator_name = cases.completing_operator_name;


                        //db.Entry(mCases).State = EntityState.Modified;

                        //ենթաաղյուսակների լրացում
                        //if (cases.Actions != null)
                        //{


                        foreach (var item in cases.Actions)
                        {
                                if (item.RecordStatus == 1)
                                {
                                    item.cases = mCases;
                                    db.Actions.Add(item);
                                }
                                else if (item.RecordStatus == 2)
                                {
                                    db.Actions.Attach(item);
                                    db.Entry(item).State = EntityState.Modified;
                                }
                                else if (item.RecordStatus == 3)
                                {
                                    actions rAction = db.Actions.Find(item.action_id);
                                    db.Actions.Remove(rAction);
                                }
                                else
                                {
                                    return Json(new { message = "The case must have at least one action" }, JsonRequestBehavior.AllowGet);
                                }
                                db.Entry(mCases).State = EntityState.Modified;
                        }

                        //}

                        List<actions> allActions = mCases.Actions.ToList();
                        var closedActions = allActions.Where(p => p.action_status_id == 3);
                        var currentActions = allActions.Where(p => p.action_status_id == 2);
                        var creationActions = allActions.Where(p => p.action_status_id == 1);
                        if (closedActions.ToArray().Length > 1)
                        {
                            return Json(new { message = "The case must have only one closed action status" }, JsonRequestBehavior.AllowGet);
                        }
                        if (creationActions.ToArray().Length > 1)
                        {
                            return Json(new { message = "The case must have only one creation action status" }, JsonRequestBehavior.AllowGet);
                        }
                        if (currentActions.ToArray().Length > 0 && creationActions.ToArray().Length == 0 && closedActions.ToArray().Length == 0)
                        {
                            return Json(new { message = "The case can not have only current status" }, JsonRequestBehavior.AllowGet);
                        }
                        foreach (var itm in mCases.Actions)
                        {
                            if (itm.action_status_id == 3)
                            {
                                mCases.case_status_id = 3;
                                operators oper = db.Operators.Find(itm.operator_id);
                                mCases.completing_operator_name = oper.operatoe_name;
                                mCases.end_date = itm.date;
                                break;
                            }
                            else
                            {
                                mCases.case_status_id = 2;
                                operators oper = db.Operators.Find(itm.operator_id);
                                mCases.completing_operator_name = " ";
                                mCases.end_date = null;
                            }
                        }

                        db.Entry(mCases).State = EntityState.Modified;
                        
                    }
                    
                    db.SaveChanges();
                    return Json(new { statuscode = 1, message = "" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                //return View("Error", new HandleErrorInfo(ex, "cases", "Save"));
                return Json(new { message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Update(int? id)
        {
            using (db)
            {
                OrganizeViewBugs(db);
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                cases item = db.Cases.Find(id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    if (item.Actions != null) { 
                        foreach (var itm in item.Actions)
                    {
                        if (itm.action_status_id == 3)
                        {
                            item.case_status_id = 3;
                                
                            break;
                        }
                        else
                        {
                            item.case_status_id = 2;
                        }
                    }
                    }

                    //var itmOpen = item.Actions.Where(p => p.action_status_id == 1);
                    //var itmCurrent = item.Actions.Where(p => p.action_status_id == 2);
                    //var itmClose = item.Actions.Where(p => p.action_status_id == 3);
                    //if (itmClose != null)
                    //{
                    //    item.case_status_id = 3;
                    //}

                    //actions[] itm = item.Actions.ToArray();
                    return View("UpdateTemplate", item);
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
                    cases item = db.Cases.Find(id);
                    if (item.Actions != null)
                    {
                        foreach (var itm in item.Actions.ToArray())
                        {
                            db.Actions.Attach(itm);
                            db.Actions.Remove(itm);
                            db.SaveChanges();
                        }
                    }
                    db.Cases.Attach(item);
                    db.Cases.Remove(item);
                    db.SaveChanges();
                }
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        private void OrganizeViewBugs(Context db)
        {
            var lStatuses = new List<SelectListItem>();
            lStatuses = db.Case_Statuses.Select(x => new SelectListItem { Text = x.case_status_name, Value = x.case_status_id.ToString() }).ToList();
            ViewBag.vbStatuses = lStatuses;

            var lTypes = new List<SelectListItem>();
            lTypes = db.Case_Types.Select(x => new SelectListItem { Text = x.case_type_name, Value = x.case_type_id.ToString() }).ToList();
            ViewBag.vbTypes = lTypes;

            var lUrgencises = new List<SelectListItem>();
            lUrgencises = db.Case_Urgencies.Select(x => new SelectListItem { Text = x.case_urgency_name, Value = x.case_urgency_id.ToString() }).ToList();
            ViewBag.vbUrgencises = lUrgencises;

            var lDepartments = new List<SelectListItem>();
            lDepartments = db.Case_Departments.Select(x => new SelectListItem { Text = x.case_department_name, Value = x.case_department_id.ToString() }).ToList();
            ViewBag.vbDepartments = lDepartments;

            var lActionCategories = new List<SelectListItem>();
            lActionCategories = db.Action_Categories.Select(x => new SelectListItem { Text = x.action_category_name, Value = x.action_category_id.ToString() }).ToList();
            ViewBag.vbActionCategories = lActionCategories;

            var lActionTypes = new List<SelectListItem>();
            lActionTypes = db.Action_Types.Select(x => new SelectListItem { Text = x.action_type_name, Value = x.action_type_id.ToString() }).ToList();
            ViewBag.vbActionTypes = lActionTypes;

            var lActionStatuses = new List<SelectListItem>();
            lActionStatuses = db.Action_Statuses.Select(x => new SelectListItem { Text = x.action_status_name, Value = x.action_status_id.ToString() }).ToList();
            ViewBag.vbActionStatuses = lActionStatuses;

            var lOperators = new List<SelectListItem>();
            lOperators = db.Operators.Select(x => new SelectListItem { Text = x.name + " " + x.lastname, Value = x.operator_id.ToString() }).ToList();
            ViewBag.vbOperators = lOperators;
        }
    }
}