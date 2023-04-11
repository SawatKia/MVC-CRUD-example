using bascicASP.Data;
using bascicASP.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace bascicASP.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext _db;

        //dependency injection make you can access to table in db via object(from ApplicationDBContext) _db
        //constructure
        public StudentController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable <Student> allStudent = _db.Students;
            return View(allStudent);  
        }
        //default is GET method
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]// check no script in input
        public IActionResult Create(Student obj)
        {
            //check input requirement from data-annontation in model Student
            //such as [required],[range(0,100)]
            if(ModelState.IsValid)
            {
                _db.Students.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);//return data the have informed
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Students.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]// check no script in input
        public IActionResult Edit(Student obj)
        {
            //check input requirement from data-annontation in model Student
            //such as [required],[range(0,100)]
            if (ModelState.IsValid)
            {
                _db.Students.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);//return data the have informed
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //ค้นหาข้อมูล
            var obj = _db.Students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Students.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
