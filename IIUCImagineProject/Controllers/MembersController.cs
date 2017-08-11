using IIUCImagineProject.BLL;
using IIUCImagineProject.Models;
using System;
using System.Web.Mvc;

namespace IIUCImagineProject.Controllers
{
    public class MembersController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        private MemberManager aManager = new MemberManager();
        // GET: Members
        public ActionResult Index()
        {

            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Tittle");
            ViewBag.DoYouKnowID = new SelectList(db.DoYouKnows, "ID", "Tittle");
            ViewBag.ParticipateID = new SelectList(db.Participates, "ID", "Tittle");
            return View();
        }

        // POST: Members
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Member member)
        {

            if (ModelState.IsValid)
            {

                member.SubmitDate = DateTime.Today;
                //db.Members.Add(member);
                //db.SaveChanges();
                //ModelState.Clear();
                //return RedirectToAction("Success");
                ViewBag.Message = aManager.Save(member);
                if (ViewBag.Message == "Saved Successfully")
                {
                    ModelState.Clear();
                }

            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Tittle", member.DepartmentID);
            ViewBag.DoYouKnowID = new SelectList(db.DoYouKnows, "ID", "Tittle", member.DoYouKnowID);
            ViewBag.ParticipateID = new SelectList(db.Participates, "ID", "Tittle", member.ParticipateID);
            return View();
        }






        public ActionResult Success()
        {
            return View();
        }

    }
}
