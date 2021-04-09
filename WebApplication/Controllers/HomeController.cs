using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Data;
using WebApplication.Data.Models;
using ApplicContext = WebApplication.Data.ApplicContext;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        Status status = new Status();
        private ApplicContext db;
       

        public HomeController(ApplicContext context)
        {
            db = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        public IActionResult GetEvents()
        {
            var events = db.Event.ToList();
            return new JsonResult(events);
        }

        [HttpPost]
         public IActionResult SaveEvent(Event e)
         
        {
            status.status = false;
            if (e.eventId > 0)
            {
                var v = db.Event.Where(a => a.eventId == e.eventId).FirstOrDefault();
                if (v != null)
                {
                    v.subject = e.subject;
                    v.start = e.start;
                    v.end = e.end;
                    v.description = e.description;
                    v.isFullDay = e.isFullDay;
                    v.themeColor = e.themeColor;
                }
            }
            else
            {
                db.Event.Add(e);
            }

            db.SaveChanges();
            status.status = true;

            return new JsonResult(status);
         }

        [HttpPost]
        public IActionResult DeleteEvent(int eventId)
        {
            status.status = false;

            var v = db.Event.Where(a => a.eventId == eventId).FirstOrDefault();
            if (v != null)
            {
                db.Event.Remove(v);
                db.SaveChanges();
                status.status = true;
            }
            
            return new JsonResult (status);
        }

    }
}
