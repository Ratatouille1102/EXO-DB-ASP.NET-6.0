using ASP_DBSlide.Mapper;
using ASP_DBSlide.Models.Section;
using BLL_DBSlide.Entities;
using Common_DBSlide.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_DBSlide.Controllers
{
    public class SectionController : Controller
    {
        private readonly ISectionRepository<Section> _sectionRepository;

        public SectionController(ISectionRepository<Section> sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        // GET: SectionController
        public ActionResult Index()
        {
            IEnumerable<SectionListItem> model = _sectionRepository.Get().Select(bll => bll.ToListItem());
            return View(model);
        }

        // GET: SectionController/Details/5
        public ActionResult Details(int id)
        {
            SectionDetailsViewModel model = _sectionRepository.Get(id).ToDetails();
            return View(model);
        }

        // GET: SectionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SectionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SectionCreateForm form)
        {
            try
            {
                if (!ModelState.IsValid) { throw new Exception(); }
                int id = _sectionRepository.Insert(form.ToBLL());
                return RedirectToAction(nameof(Details), new { id } );
            }
            catch
            {
                return View(form);
            }
        }

        // GET: SectionController/Edit/5
        public ActionResult Edit(int id)
        {
            SectionEditForm model = _sectionRepository.Get(id).ToEdit();
            return View(model);
        }

        // POST: SectionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SectionEditForm form)
        {
            try
            {
                if (!ModelState.IsValid) { throw new Exception(); }
                Section sectionBll = _sectionRepository.Get(id);
                sectionBll.Section_Name = form.Section_Name;
                sectionBll.Delegate = (form.Delegate_Id is null)? null :
                    new Student
                {
                    Student_id = (int)form.Delegate_Id
                };
                _sectionRepository.Update(id, sectionBll);
                return RedirectToAction(nameof(Details), new { id });
            }
            catch
            {
                return View(form);
            }
        }

        // GET: SectionController/Delete/5
        public ActionResult Delete(int id)
        {
            SectionDeleteForm model = _sectionRepository.Get(id).ToDelete();
            return View(model);
        }

        // POST: SectionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SectionDeleteForm form)
        {
            try
            {
                if (!ModelState.IsValid) { throw new Exception(); }
                _sectionRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(form);
            }
        }
    }
}
