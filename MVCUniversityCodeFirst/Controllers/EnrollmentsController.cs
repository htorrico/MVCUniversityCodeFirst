using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCUniversityCodeFirst.Models;

namespace MVCUniversityCodeFirst.Controllers
{
    public class EnrollmentsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Enrollments
        public ActionResult Index()
        {
            var enrollments = db.Enrollments.Include(e => e.Course).Include(e => e.Student);
            return View(enrollments.ToList());
        }

        // GET: Enrollments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // GET: Enrollments/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Title");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "LastName");
            return View();
        }

        // POST: Enrollments/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnrollmentId,CreatedOn,StudentId,CourseId")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Enrollments.Add(enrollment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Title", enrollment.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "LastName", enrollment.StudentId);
            return View(enrollment);
        }




        public ActionResult CreateCustom()
        {           
            return View();
        }

        // POST: Enrollments/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCustom(EnrollmentCustom enrollmentCustom)
        {
            if (ModelState.IsValid)
            {


                //Obtener el id del student
                var student = db.Students.Where(x => x.LastName == enrollmentCustom.LastName).FirstOrDefault();
                //Obtener el id del curso
                var course = db.Courses.Where(x => x.Title == enrollmentCustom.Title).FirstOrDefault();

                db.Enrollments.Add(new Enrollment
                {
                    CreatedOn = enrollmentCustom.CreatedOn,
                    Student = student !=null ? student  : new Student { LastName = enrollmentCustom.LastName },
                    Course = course != null ? course : new Course { Title = enrollmentCustom.Title }                
                });
                db.SaveChanges();



                ////Insertar a estudiante

                //db.Students.Add( new Student { LastName= enrollmentCustom.LastName }  );
                //db.SaveChanges();

                ////Insertar a Course

                //db.Courses.Add(new Course { Title = enrollmentCustom.Title });
                //db.SaveChanges();

                ////Obtener el id del student

                //var student = db.Students.Where(x => x.LastName == enrollmentCustom.LastName).FirstOrDefault();

                ////Obtener el id del curso

                //var course = db.Courses.Where(x => x.Title == enrollmentCustom.Title).FirstOrDefault();

                ////Insertar a Enrollment

                //db.Enrollments.Add(new Enrollment { 
                //CreatedOn= enrollmentCustom.CreatedOn,
                //StudentId=student.StudentId,
                //CourseId= course.CourseId                
                //} );
                //db.SaveChanges();


                return RedirectToAction("Index");
            }
            
            return View(enrollmentCustom);
        }



        // GET: Enrollments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Title", enrollment.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "LastName", enrollment.StudentId);
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnrollmentId,CreatedOn,StudentId,CourseId")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Title", enrollment.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "LastName", enrollment.StudentId);
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enrollment enrollment = db.Enrollments.Find(id);
            db.Enrollments.Remove(enrollment);
            db.SaveChanges();
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
