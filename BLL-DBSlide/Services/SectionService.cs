using DAL = DAL_DBSlide.Entities;
using BLL_DBSlide.Entities;
using Common_DBSlide.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BLL_DBSlide.Mappers;

namespace BLL_DBSlide.Services
{
    public class SectionService : ISectionRepository<Section>
    {
        private ISectionRepository<DAL.Section> _repository;
        private IStudentRepository<DAL.Student> _studentRepository;

        public SectionService(ISectionRepository<DAL.Section> repository, IStudentRepository<DAL.Student> studentRepository)
        {
            _repository = repository;
            _studentRepository = studentRepository;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Section> Get()
        {
            IEnumerable<Section> result = _repository.Get().Select(dal => dal.ToBLL());
            foreach (Section bll in result)
            {
                bll.Delegate = _studentRepository.GetDelegateBySectionId(bll.Section_Id).ToBLL();
                bll.Students = _studentRepository.GetBySectionId(bll.Section_Id).Select(dal => dal.ToBLL());
            }
            return result;
        }

        public Section Get(int id)
        {
            Section result = _repository.Get(id).ToBLL();
            result.Delegate = _studentRepository.GetDelegateBySectionId(id).ToBLL();
            result.Students = _studentRepository.GetBySectionId(id).Select(dal => dal.ToBLL());
            return result;
        }

        public IEnumerable<Section> GetByDelegateId(int delegate_id)
        {
            IEnumerable<Section> result = _repository.GetByDelegateId(delegate_id).Select(dal => dal.ToBLL());
            foreach (Section bll in result)
            {
                bll.Delegate = _studentRepository.Get(delegate_id).ToBLL();
                bll.Students = _studentRepository.GetBySectionId(bll.Section_Id).Select(dal => dal.ToBLL());
            }
            return result;
        }

        public Section GetByStudentId(int student_id)
        {
            Section result = _repository.GetByStudentId(student_id).ToBLL();
            result.Delegate = _studentRepository.GetDelegateBySectionId(result.Section_Id).ToBLL();
            result.Students = _studentRepository.GetBySectionId(result.Section_Id).Select(dal => dal.ToBLL());
            return result;
        }

        public int Insert(Section entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public void Update(int id, Section entity)
        {
            _repository.Update(id, entity.ToDAL());
        }
    }
}
