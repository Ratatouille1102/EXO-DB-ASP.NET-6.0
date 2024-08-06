using DAL = DAL_DBSlide.Entities;
using BLL = BLL_DBSlide.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BLL_DBSlide.Mappers;
using Common_DBSlide.Repositories;
using BLL_DBSlide.Entities;

namespace BLL_DBSlide.Services
{
    public class StudentService : IStudentRepository<BLL.Student>
    {
        private IStudentRepository<DAL.Student> _repository;
        private ISectionRepository<DAL.Section> _sectionRepository;
        public StudentService(IStudentRepository<DAL.Student> repository, ISectionRepository<DAL.Section> sectionRepository)
        {
            _repository = repository;
            _sectionRepository = sectionRepository;
        }

        public IEnumerable<BLL.Student> Get()
        {
            IEnumerable<BLL.Student> result = _repository.Get().Select(dal => dal.ToBLL());
            foreach (Student bll in result)
            {
                bll.Section = _sectionRepository.GetByStudentId(bll.Student_id).ToBLL();
            }
            return result;
        }

        public BLL.Student Get(int id)
        {
            Student result = _repository.Get(id).ToBLL();
            result.Section = _sectionRepository.GetByStudentId(id).ToBLL();
            return result;
        }

        public int Insert(BLL.Student entity)
        {
            return _repository.Insert(entity.ToDAL());
        }
        public void Update(int id, BLL.Student entity)
        {
            _repository.Update(id,entity.ToDAL());
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Student GetDelegateBySectionId(int section_id)
        {
            Student result =  _repository.GetDelegateBySectionId(section_id).ToBLL();
            result.Section = _sectionRepository.Get(section_id).ToBLL();
            return result;
        }

        public IEnumerable<Student> GetBySectionId(int section_id)
        {
            IEnumerable<Student> result = _repository.GetBySectionId(section_id).Select(dal => dal.ToBLL());
            foreach (Student bll in result)
            {
                bll.Section = _sectionRepository.Get(section_id).ToBLL();
            }
            return result;
        }
    }
}
