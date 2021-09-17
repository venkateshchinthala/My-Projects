using StudentsProject.Models;
using StudentsProject.Repository;
using System.Collections.Generic;

namespace StudentsProject.Business
{
    public class StudentBusiness : IStudentBusiness
    {
        private readonly IStudentRepository _studentRepository;

        public StudentBusiness(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        /// <summary>
        /// Method to Create Student
        /// </summary>
        /// <param name="studentDto"></param>
        /// <returns>bool</returns>
        public bool CreateStudent(StudentDto studentDto) 
        {
            return _studentRepository.CreateStudent(studentDto);
        }

        /// <summary>
        /// Method to Update Student
        /// </summary>
        /// <param name="studentDto"></param>
        /// <returns>bool</returns>
        public bool UpdateStudent(StudentDto studentDto)
        {
            return _studentRepository.UpdateStudent(studentDto);
        }

        /// <summary>
        /// Method to Get Student By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>StudentDto</returns>
        public StudentDto GetStudentById(int id)
        {
            return _studentRepository.GetStudentById(id);
        }

        /// <summary>
        /// Method to Delete Student By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public bool DeleteStudent(int id)
        {
            return _studentRepository.DeleteStudent(id);
        }

        /// <summary>
        /// Method to Get All Students
        /// </summary>
        /// <returns>List<StudentDto></returns>
        public List<StudentDto> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }

    }
}