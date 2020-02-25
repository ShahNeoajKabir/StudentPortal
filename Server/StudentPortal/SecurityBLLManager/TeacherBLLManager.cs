using StudentPortal.DAL;
using StudentPortal.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityBLLManager
{
   public class TeacherBLLManager: ITeacherBLLManager
    {
        private readonly StudentPortalDbContext studentPortalDbContext;
        public TeacherBLLManager(StudentPortalDbContext studentPortalDbContext)
        {
            this.studentPortalDbContext = studentPortalDbContext;

        }
        public Teacher AddTeacher(Teacher teacher)
        {
            teacher.CreatedBy = "Admin";
            teacher.CreatedDate = DateTime.Now;
            this.studentPortalDbContext.Teacher.Add(teacher);
            this.studentPortalDbContext.SaveChanges();
            return teacher;
        }
        public List<Teacher> GetAll()
        {
            List<Teacher> teacher = this.studentPortalDbContext.Teacher.Where(p => p.Status == (int)StudentPortal.Common.Enum.Enum.Status.Active).ToList();
            return teacher;
        }
        public Teacher UpdateTeacher(Teacher teacher)
        {
            teacher.UpdatedBy = "Admin";
            teacher.UpdatedDate = DateTime.Now;
            this.studentPortalDbContext.Teacher.Update(teacher);
            this.studentPortalDbContext.SaveChanges();
            return teacher;
        }
        public Teacher GetTeacherById(Teacher teacher)
        {
            return this.studentPortalDbContext.Teacher.Find(teacher.TeacherId);
        }
            
    }
    public interface ITeacherBLLManager
    {
        Teacher AddTeacher(Teacher teacher);
        List<Teacher> GetAll();
        Teacher UpdateTeacher(Teacher teacher);
        Teacher GetTeacherById(Teacher teacher);
    }
}
