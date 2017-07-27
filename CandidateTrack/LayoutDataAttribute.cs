using CandidateTrack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CandidateTrack
{
    public class LayoutDataAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Repository db = new Repository(Properties.Settings.Default.ConStr);

            filterContext.Controller.ViewBag.Pending = db.getPendingCount();
            filterContext.Controller.ViewBag.Confirmed = db.getConfirmedCount();
            filterContext.Controller.ViewBag.Refused = db.getRefusedCount();

            base.OnActionExecuted(filterContext);
        }
    }
}