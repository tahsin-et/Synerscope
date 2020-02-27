using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Synerscope.DataAccess;
using Synerscope.Models;
using PagedList; 

namespace Synerscope.Controllers
{
    public class PeopleController : Controller
    {
        private HobbiesContext db = new HobbiesContext();

        // GET: People
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.FNameSortParm = String.IsNullOrEmpty(sortOrder) ? "fname_desc" : "";
            ViewBag.LNameSortParm = String.IsNullOrEmpty(sortOrder) ? "lname_desc" : "";


            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            var people = from s in db.People select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                people = people.Where(s => s.LastName.Contains(searchString) || s.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "fname_desc":
                    people = people.OrderByDescending(s => s.FirstName);
                    break;
                case "lname_desc":
                    people = people.OrderByDescending(s => s.LastName);
                    break;
                default:
                    people = people.OrderBy(s => s.LastName);
                    break;
            }

            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(people.ToPagedList(pageNumber, pageSize));
            //return View(db.People.ToList());
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LastName,FirstName")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }
        

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LastName,FirstName")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.People.Find(id);
            db.People.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: People/DeleteHobby/5
        public ActionResult DeleteHobby(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hobby hobby = db.Hobbies.Find(id);
            if (hobby == null)
            {
                return HttpNotFound();
            }
            return View(hobby);
        }

        // POST: People/DeleteHobby/5
        [HttpPost, ActionName("DeleteHobby")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteHobbyConfirmed(int id)
        {
            Hobby hobby = db.Hobbies.Find(id);
            db.Hobbies.Remove(hobby);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: People/AddHobby/5
        public ActionResult AddHobby(int? id)
        {
            return View();
        }

        // POST: People/AddHobby/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddHobby([Bind(Include = "PersonID,Name")] Hobby hobby)
        {
            if (ModelState.IsValid)
            {
                db.Hobbies.Add(hobby);
                db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
