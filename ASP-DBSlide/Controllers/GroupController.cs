using ASP_DBSlide.Handlers;
using ASP_DBSlide.Mapper;
using ASP_DBSlide.Models.Group;
using ASP_DBSlide.Models.Student;
using BLL_DBSlide.Entities;
using Common_DBSlide.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASP_DBSlide.Controllers
{
    public class GroupController : Controller
    {
        private SessionManager _session;
        private readonly IStudentRepository<Student> _studentRepository;
        public GroupController(SessionManager session, IStudentRepository<Student> studentRepository) {
            _session = session;
            _studentRepository = studentRepository;
        }
        public IActionResult Index()
        {
            StudentGroup? group = _session.CurrentGroup;
            if (group is null) return RedirectToAction(nameof(Create));
            GroupDetailsViewModel model = group.ToDetails();
            return View(model);
        }

        public IActionResult AddStudent() {
            IEnumerable<StudentListItem> model = _studentRepository.Get().Select(bll=>bll.ToListItem());
            return View(model);
        }
        [HttpPost]
        public IActionResult AddStudent(int student_id)
        {
            try
            {
                StudentGroup? group = _session.CurrentGroup;
                if (group is null) throw new NullReferenceException();
                Student result = _studentRepository.Get(student_id);
                if (!group.AddStudent(result)) throw new Exception();
                _session.CurrentGroup = group;
                return RedirectToAction(nameof(Index));
                
            }
            catch (NullReferenceException ex) { 
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                IEnumerable<StudentListItem> model = _studentRepository.Get().Select(bll => bll.ToListItem());
                return View(model);
            }
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(GroupCreateForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                //Sauvegarde en session
                StudentGroup group = form.ToBLL();
                _session.CurrentGroup = group;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(form);
            }
        }
    }
}
