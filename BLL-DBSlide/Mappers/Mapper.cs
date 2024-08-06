using BLL = BLL_DBSlide.Entities;
using DAL = DAL_DBSlide.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_DBSlide.Mappers
{
    internal static class Mapper
    {
        #region Student
        public static BLL.Student ToBLL(this DAL.Student entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new BLL.Student()
            {
                Student_id = entity.Student_id,
                First_name = entity.First_name,
                Last_name = entity.Last_name,
                Birth_date = entity.Birth_date,
                Year_result = entity.Year_result,
                Course_id = entity.Course_id,
                Section = null
            };
        }

        public static DAL.Student ToDAL(this BLL.Student entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new DAL.Student()
            {
                Student_id = entity.Student_id,
                First_name = entity.First_name,
                Last_name = entity.Last_name,
                Birth_date = entity.Birth_date,
                Login = entity.Login,
                Section_id = entity.Section.Section_Id,
                Year_result = entity.Year_result,
                Course_id = entity.Course_id
            };
        }
        #endregion
        #region Section
        public static BLL.Section ToBLL(this DAL.Section entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new BLL.Section()
            {
                Section_Id = entity.Section_id,
                Section_Name = entity.Section_name,
                Delegate = null,
                Students = null
            };
        }
        public static DAL.Section ToDAL(this BLL.Section entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new DAL.Section()
            {
                Section_id = entity.Section_Id,
                Section_name = entity.Section_Name,
                Delegate_id = entity.Delegate?.Student_id
            };
        }
        #endregion
    }
}
