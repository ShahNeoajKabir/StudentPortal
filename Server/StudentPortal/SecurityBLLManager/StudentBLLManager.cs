using StudentPortal.DAL;
using StudentPortal.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityBLLManager
{
    public class StudentBLLManager : IStudentBLLManager
    {
        private readonly StudentPortalDbContext _student;
        public StudentBLLManager(StudentPortalDbContext student)
        {
            _student = student;
        }
        public Student AddStudent(Student student)
        {

            student.CreatedDate = DateTime.Now;
            student.CreatedBy = "Admin";

            student.Status = (int)StudentPortal.Common.Enum.Enum.Status.Active;
            _student.Student.Add(student);
            _student.SaveChangesAsync();
            return student;

        }
        public List<Student> GetAll()
        {
            List<Student> students = _student.Student.Where(p => p.Status == (int)StudentPortal.Common.Enum.Enum.Status.Active).ToList();

            return students;
        }
        public Student UpdateStudent(Student student)
        {
            student.UpdatedBy = "CoOrdinator";
            student.UpdatedDate = DateTime.Now;
            _student.Student.Update(student);
            _student.SaveChanges();
            return student;
        }
        public Student GetStudentId(Student student)
        {
            return _student.Student.Find(student.StudentId);
        }
    }

    public interface IStudentBLLManager
    {
        Student AddStudent(Student student);
        List<Student> GetAll();
        Student UpdateStudent(Student student);
        Student GetStudentId(Student student);

    }
}
