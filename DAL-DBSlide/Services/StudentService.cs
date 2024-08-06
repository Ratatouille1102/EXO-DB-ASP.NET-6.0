using Common_DBSlide.Repositories;
using DAL_DBSlide.Entities;
using DAL_DBSlide.Mappers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace DAL_DBSlide.Services
{
    public class StudentService : BaseService, IStudentRepository<Student>
    {
        private readonly DbProviderFactory _factory = SqlClientFactory.Instance;

        public StudentService(IConfiguration config) : base(config, "DBSlide")
        {
        }

        public IEnumerable<Student> Get()
        {
            using (DbConnection connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM student";
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToStudent();
                        }
                    }
                }
            }
        }
        public Student Get(int id)
        {
            using (DbConnection connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM student WHERE student_id = @id";
                    DbParameter p_id = command.CreateParameter();
                    p_id.Value = id;
                    p_id.ParameterName = "id";
                    command.Parameters.Add(p_id);
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToStudent();
                        }
                        throw new ArgumentOutOfRangeException(nameof(id),"Identifiant non-valide");
                    }
                }
            }
        }

        public int Insert(Student entity)
        {
            using (DbConnection connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) OUTPUT inserted.student_id VALUES (@first_name, @last_name, @birth_date, @login, @section_id, @year_result, @course_id)";
                    #region Parameters
                    DbParameter p_fn = command.CreateParameter();
                    p_fn.Value = entity.First_name;
                    p_fn.ParameterName = "first_name";
                    command.Parameters.Add(p_fn);
                    DbParameter p_ln = command.CreateParameter();
                    p_ln.Value = entity.Last_name;
                    p_ln.ParameterName = "last_name";
                    command.Parameters.Add(p_ln);
                    DbParameter p_bd = command.CreateParameter();
                    p_bd.Value = entity.Birth_date;
                    p_bd.ParameterName = "birth_date";
                    command.Parameters.Add(p_bd);
                    DbParameter p_lg = command.CreateParameter();
                    p_lg.Value = entity.Login;
                    p_lg.ParameterName = "login";
                    command.Parameters.Add(p_lg);
                    DbParameter p_sid = command.CreateParameter();
                    p_sid.Value = entity.Section_id;
                    p_sid.ParameterName = "section_id";
                    command.Parameters.Add(p_sid);
                    DbParameter p_yr = command.CreateParameter();
                    p_yr.Value = (object?)entity.Year_result ?? DBNull.Value;
                    p_yr.ParameterName = "year_result";
                    command.Parameters.Add(p_yr);
                    DbParameter p_cid = command.CreateParameter();
                    p_cid.Value = entity.Course_id;
                    p_cid.ParameterName = "course_id";
                    command.Parameters.Add(p_cid); 
                    #endregion
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void Update(int id, Student entity) 
        {
            using (DbConnection connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE student SET first_name = @first_name, last_name = @last_name, birth_date = @birth_date, login = @login, section_id = @section_id, year_result = @year_result, course_id = @course_id WHERE student_id = @id";
                    #region Parameters
                    DbParameter p_fn = command.CreateParameter();
                    p_fn.Value = entity.First_name;
                    p_fn.ParameterName = "first_name";
                    command.Parameters.Add(p_fn);
                    DbParameter p_ln = command.CreateParameter();
                    p_ln.Value = entity.Last_name;
                    p_ln.ParameterName = "last_name";
                    command.Parameters.Add(p_ln);
                    DbParameter p_bd = command.CreateParameter();
                    p_bd.Value = entity.Birth_date;
                    p_bd.ParameterName = "birth_date";
                    command.Parameters.Add(p_bd);
                    DbParameter p_lg = command.CreateParameter();
                    p_lg.Value = entity.Login;
                    p_lg.ParameterName = "login";
                    command.Parameters.Add(p_lg);
                    DbParameter p_sid = command.CreateParameter();
                    p_sid.Value = entity.Section_id;
                    p_sid.ParameterName = "section_id";
                    command.Parameters.Add(p_sid);
                    DbParameter p_yr = command.CreateParameter();
                    p_yr.Value = (object?)entity.Year_result ?? DBNull.Value;
                    p_yr.ParameterName = "year_result";
                    command.Parameters.Add(p_yr);
                    DbParameter p_cid = command.CreateParameter();
                    p_cid.Value = entity.Course_id;
                    p_cid.ParameterName = "course_id";
                    command.Parameters.Add(p_cid);
                    DbParameter p_id = command.CreateParameter();
                    p_id.Value = id;
                    p_id.ParameterName = "id";
                    command.Parameters.Add(p_id);
                    #endregion
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (DbConnection connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM student WHERE student_id = @id";
                    #region Parameters
                    DbParameter p_id = command.CreateParameter();
                    p_id.Value = id;
                    p_id.ParameterName = "id";
                    command.Parameters.Add(p_id);
                    #endregion
                    command.ExecuteNonQuery();
                }
            }
        }

        public Student GetDelegateBySectionId(int section_id)
        {
            using(DbConnection connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT student_id, first_name, last_name, birth_date, login, student.section_id, year_result, course_id FROM section JOIN student ON section.delegate_id = student.student_id WHERE section.section_id = @section_id";
                    DbParameter p_sid = command.CreateParameter();
                    p_sid.Value = section_id;
                    p_sid.ParameterName = "section_id";
                    command.Parameters.Add(p_sid);
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToStudent();
                        }
                        throw new ArgumentOutOfRangeException(nameof(section_id), "Identifiant non-valide");
                    }
                }
            }
        }

        public IEnumerable<Student> GetBySectionId(int section_id)
        {
            using (DbConnection connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM student WHERE section_id = @section_id";
                    DbParameter p_sid = command.CreateParameter();
                    p_sid.Value = section_id;
                    p_sid.ParameterName = "section_id";
                    command.Parameters.Add(p_sid);
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToStudent();
                        }
                    }
                }
            }
        }
    }
}
