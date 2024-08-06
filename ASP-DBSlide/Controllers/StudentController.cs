using ASP_DBSlide.Mapper;
using ASP_DBSlide.Models.Student;
using BLL_DBSlide.Entities;
using Common_DBSlide.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_DBSlide.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository<Student> _studentRepository;
        public StudentController(IStudentRepository<Student> studentRepository) { 
            _studentRepository = studentRepository;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            IEnumerable<StudentListItem> model = _studentRepository.Get().Select(bll => bll.ToListItem());
            return View(model);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            StudentDetailsViewModel model = _studentRepository.Get(id).ToDetails();
            return View(model);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentCreateForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                int id = _studentRepository.Insert(form.ToBLL());
                return RedirectToAction(nameof(Details), new { id });
            }
            catch
            {
                return View(form);
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            StudentEditForm model = _studentRepository.Get(id).ToEdit();
            return View(model);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StudentEditForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                Student bllStudent = _studentRepository.Get(id);
                bllStudent.Course_id = form.Course_Id;
                bllStudent.Section = new Section
                {
                    Section_Id = form.Section_Id
                };
                bllStudent.Year_result = form.Year_Result;
                _studentRepository.Update(id, bllStudent);
                return RedirectToAction(nameof(Details), new { id });
            }
            catch
            {
                return View(form);
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            StudentDeleteForm model = _studentRepository.Get(id).ToDelete();
            return View(model);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, StudentDeleteForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                _studentRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(form);
            }
        }
    }
}
