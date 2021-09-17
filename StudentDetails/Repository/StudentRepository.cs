using StudentsProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace StudentsProject.Repository
{
    /// <summary>
    /// Student Repository
    /// </summary>
    public class StudentRepository : IStudentRepository
    {
       // string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string connectionString = @"Data Source=ALIPL0495;Initial Catalog=StudentInformation;Integrated Security=true";

        public bool CreateStudent(StudentDto student)
        {
            using (SqlConnection sqlconnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[CreateStudent]", sqlconnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Name ", student.StudentName);
                    sqlCommand.Parameters.AddWithValue("@Fathername", student.FatherName);
                    sqlCommand.Parameters.AddWithValue("@Age", student.Age);
                    sqlCommand.Parameters.AddWithValue("@City", student.City);
                    sqlCommand.Parameters.AddWithValue("@ContactNumber", student.ContactNumber);
                    sqlCommand.Parameters.AddWithValue("@Email", student.Email);
                    sqlconnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlconnection.Close();
                }
            }
            return true;
        }

        /// <summary>
        /// Method to Update Student
        /// </summary>
        /// <param name="student"></param>
        /// <returns>bool</returns>
        public bool UpdateStudent(StudentDto student)
        {
            using (SqlConnection sqlconnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[UpdateStudent]", sqlconnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Id", student.Id);
                    sqlCommand.Parameters.AddWithValue("@Name ", student.StudentName);
                    sqlCommand.Parameters.AddWithValue("@Fathername", student.FatherName);
                    sqlCommand.Parameters.AddWithValue("@Age", student.Age);
                    sqlCommand.Parameters.AddWithValue("@City", student.City);
                    sqlCommand.Parameters.AddWithValue("@ContactNumber", student.ContactNumber);
                    sqlCommand.Parameters.AddWithValue("@Email", student.Email);
                    sqlconnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlconnection.Close();
                }
            }
            return true;
        }


        /// <summary>
        /// Method to Get Student By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>StudentDto</returns>
        public StudentDto GetStudentById(int id)
        {
            StudentDto dto = new StudentDto();
          
            using (SqlConnection sqlconnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[GetStudentById]", sqlconnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Id", id);

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlconnection.Open();
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        dto.Id = Convert.ToInt32(dataReader["Id"]);
                        dto.StudentName = dataReader["Name"].ToString();
                        dto.FatherName = dataReader["fatherName"].ToString();
                        dto.Age = Convert.ToInt32(dataReader["Age"]);
                        dto.City = dataReader["City"].ToString();
                        dto.ContactNumber = Convert.ToInt64(dataReader["contactNumber"]);
                        dto.Email = dataReader["Email"].ToString();
                    }
                    sqlconnection.Close();
                }
            }
            return dto;
        }

        /// <summary>
        /// Delete Student By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteStudent(int id)
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("[dbo].[DeleteStudent]", sqlconnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Id", id);
            sqlconnection.Open();
            int i = sqlCommand.ExecuteNonQuery();
            sqlconnection.Close();
            return true;
        }


        /// <summary>
        /// Get List Of Students
        /// </summary>
        /// <returns>List<StudentDto></returns>
        public List<StudentDto> GetAllStudents()
        {
            List<StudentDto> studentDtos = new List<StudentDto>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = new SqlCommand("[dbo].[GetAllStudents]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlConnection.Open();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                StudentDto student = new StudentDto();
                student.Id = Convert.ToInt32(dataRow["id"]);
                student.StudentName = Convert.ToString(dataRow["Name"]);
                student.FatherName = Convert.ToString(dataRow["FatherName"]);
                student.Age = Convert.ToInt32(dataRow["Age"]);
                student.City = Convert.ToString(dataRow["City"]);
                student.ContactNumber = Convert.ToInt64(dataRow["ContactNumber"]);
                student.Email = Convert.ToString(dataRow["Email"]);
                studentDtos.Add(student);
            }
            return studentDtos;
        }
    }
}