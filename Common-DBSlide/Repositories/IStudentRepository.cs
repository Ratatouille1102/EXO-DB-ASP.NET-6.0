using System;
using System.Collections.Generic;
using System.Text;

namespace Common_DBSlide.Repositories
{
    public interface IStudentRepository<TStudent> : ICRUDRepository<TStudent,int>
    {
        TStudent GetDelegateBySectionId(int section_id);
        IEnumerable<TStudent> GetBySectionId(int section_id);
    }
}
