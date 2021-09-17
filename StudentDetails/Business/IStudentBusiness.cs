using StudentsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProject.Business
{
    public interface IStudentBusiness
    {
        bool CreateStudent(StudentDto student);
        bool UpdateStudent(StudentDto student);
        StudentDto GetStudentById(int id);
        bool DeleteStudent(int id);
        List<StudentDto> GetAllStudents();
    }
}
