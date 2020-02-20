using StudentPortal.DAL;
using StudentPortal.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityBLLManager
{
    public class StudentBLLManager:IStudentBLLManager
    {
        private readonly StudentPortalDbContext _student;
        public StudentBLLManager(StudentPortalDbContext student)
        {
            _student = student;
        }
        public Student AddStudent(Student student)
        {
            
            student.CreatedDate = DateTime.Now;
            student.UpdatedDate = DateTime.Now;
            _student.Student.Add(student);
            _student.SaveChangesAsync();
            return student;

        }
        public List<Student> GetAll()
        {
            List<Student> students = _student.Student.ToList();
            return students;
        }
    }

    public interface IStudentBLLManager
    {
        Student AddStudent(Student student);
        List<Student> GetAll();

    }
}
