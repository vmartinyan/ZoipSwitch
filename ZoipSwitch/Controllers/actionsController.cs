using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZoipSwitch.DAL;
using ZoipSwitch.Models;

namespace ZoipSwitch.Controllers
{
    public class actionsController : Controller
    {
        // GET: CardiologicalObjectiveDrug
        public ActionResult ReadvwActions([DataSourceRequest]DataSourceRequest request, int? id)
        {
            using (var db = new Context())
            {
                IQueryable<vwAction> item = db.VwAction.Where(p => p.case_id == id);
                DataSourceResult result = item.ToDataSourceResult(request);
                return Json(result);
            }
        }


        public ActionResult ReadActions([DataSourceRequest]DataSourceRequest request, int? id)
        {
            using (var db = new Context())
            {
                IQueryable<actions> item = db.Actions.Where(p => p.case_id == id);
                DataSourceResult result = item.ToDataSourceResult(request);
                return Json(result);
            }
        }
    }
}