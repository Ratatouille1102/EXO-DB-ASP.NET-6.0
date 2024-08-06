using System;
using System.Collections.Generic;
using System.Text;

namespace Common_DBSlide.Repositories
{
    public interface ISectionRepository<TSection> : ICRUDRepository<TSection, int>
    {
        TSection GetByStudentId(int student_id);
        IEnumerable<TSection> GetByDelegateId(int delegate_id);
    }
}
