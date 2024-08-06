using DAL_DBSlide.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL_DBSlide.Mappers
{
    internal static class Mapper
    {
        public static Student ToStudent(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record), "Aucune informations");
            return new Student()
            {
                Student_id = (int)record[nameof(Student.Student_id)],
                First_name = record[nameof(Student.First_name)].ToString(),
                Last_name = record[nameof(Student.Last_name)].ToString(),
                Birth_date = (DateTime)record[nameof(Student.Birth_date)],
                Login = record[nameof(Student.Login)].ToString(),
                Section_id = (int)record[nameof(Student.Section_id)],
                Year_result = (record[nameof(Student.Year_result)] is DBNull) ? null : (int?)record[nameof(Student.Year_result)],
                Course_id = record[nameof(Student.Course_id)].ToString()
            };
        }
        public static Section ToSection(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record), "Aucune informations");
            return new Section()
            {
                Section_id = (int)record[nameof(Section.Section_id)],
                Section_name = record[nameof(Section.Section_name)].ToString(),
                Delegate_id = (record[nameof(Section.Delegate_id)] is DBNull) ? null : (int?)record[nameof(Section.Delegate_id)]
            };
        }
    }
}
