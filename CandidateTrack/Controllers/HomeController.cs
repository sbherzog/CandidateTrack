using CandidateTrack.Data;
using CandidateTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CandidateTrack.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCandidate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCandidate(CandidateDB person)
        {
            Repository db = new Repository(Properties.Settings.Default.ConStr);
            db.AddCandidate(person);
            return Redirect("/Home/ViewPending");
        }

        public ActionResult ViewPending()
        {
            Repository db = new Repository(Properties.Settings.Default.ConStr);
            ViewCandidateVM vm = new ViewCandidateVM();
            vm.candidate = db.getAllCandidate("Pending");
            vm.type = "Pending";
            return View(vm);
        }
        
        public ActionResult UpdateCandidate(int id, bool action)
        {
            Repository db = new Repository(Properties.Settings.Default.ConStr);
            db.UpdateCandidate(id, action);
            return Json(new 
            {
                ConfirmedCount = db.getConfirmedCount(),
                PendingCount = db.getPendingCount(),
                RefusedCount = db.getRefusedCount()
            }, JsonRequestBehavior.AllowGet);

        }
        
        public ActionResult ViewConfirmed()
        {
            Repository db = new Repository(Properties.Settings.Default.ConStr);
            ViewCandidateVM vm = new ViewCandidateVM();
            vm.candidate = db.getAllCandidate("Confirmed");
            vm.type = "Confirmed";
            return View(vm);
        }

        public ActionResult ViewRefused()
        {
            Repository db = new Repository(Properties.Settings.Default.ConStr);
            ViewCandidateVM vm = new ViewCandidateVM();
            vm.candidate = db.getAllCandidate("Refused");
            vm.type = "Refused";
            return View("ViewConfirmed", vm);
        }

    }
}