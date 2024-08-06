using ASP_DBSlide.Models.Section;
using ASP_DBSlide.Models.Student;
using BLL_DBSlide.Entities;

namespace ASP_DBSlide.Mapper
{
    public static class Mapper
    {
        #region Student
        public static StudentListItem ToListItem(this Student entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new StudentListItem()
            {
                Student_Id = entity.Student_id,
                First_Name = entity.First_name,
                Last_Name = entity.Last_name
            };
        }

        public static StudentDetailsViewModel ToDetails(this Student entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new StudentDetailsViewModel()
            {
                Student_Id = entity.Student_id,
                First_Name = entity.First_name,
                Last_Name = entity.Last_name,
                Login = entity.Login,
                Birth_Date = entity.Birth_date,
                SectionDetails = entity.Section.ToDetails(),
                Year_Result = entity.Year_result,
                Course_Id = entity.Course_id
            };
        }
        public static StudentDeleteForm ToDelete(this Student entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new StudentDeleteForm()
            {
                First_Name = entity.First_name,
                Last_Name = entity.Last_name,
                Section_Id = entity.Section.Section_Id
            };
        }
        public static StudentEditForm ToEdit(this Student entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new StudentEditForm()
            {
                Section_Id = entity.Section.Section_Id,
                Year_Result = entity.Year_result,
                Course_Id = entity.Course_id
            };
        }

        public static Student ToBLL(this StudentCreateForm entity) {
            if(entity is null) throw new ArgumentNullException(nameof(entity));
            return new Student()
            {
                First_name = entity.First_Name,
                Last_name = entity.Last_Name,
                Birth_date = entity.Birth_Date,
                Section = new Section
                {
                    Section_Id = entity.Section_id,
                },
                Course_id = "0"
            };
        }
        public static Student ToBLL(this StudentEditForm entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new Student()
            {
                Course_id = entity.Course_Id,
                Section = new Section
                {
                    Section_Id = entity.Section_Id
                },
                Year_result = entity.Year_Result
            };
        }
        #endregion
        #region Section

        public static SectionDetailsViewModel ToDetails(this Section entity)
        {
            if(entity is null) throw new ArgumentNullException(nameof (entity));
            return new SectionDetailsViewModel()
            {
                Section_Id = entity.Section_Id,
                Section_Name = entity.Section_Name,
                Delegate = entity.Delegate?.ToListItem(),
                Students = entity.Students?.Select(bll => bll.ToListItem())
            };
        }

        public static SectionListItem ToListItem(this Section entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new SectionListItem()
            {
                Section_Id = entity.Section_Id,
                Section_Name = entity.Section_Name
            };
        }

        public static SectionEditForm ToEdit(this Section entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new SectionEditForm()
            {
                Section_Name = entity.Section_Name,
                Delegate_Id = entity.Delegate?.Student_id
            };
        }

        public static SectionDeleteForm ToDelete(this Section entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new SectionDeleteForm()
            {
                Section_Name = entity.Section_Name
            };
        }

        public static Section ToBLL(this SectionEditForm entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new Section()
            {
                Section_Name = entity.Section_Name,
                Delegate = new Student
                {
                    Student_id = (int)entity.Delegate_Id
                }
            };
        }
        public static Section ToBLL(this SectionCreateForm entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new Section()
            {
                Section_Id = entity.Section_Id,
                Section_Name = entity.Section_Name
            };
        }
        #endregion
    }
}
