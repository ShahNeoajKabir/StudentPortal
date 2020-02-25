using StudentPortal.DAL;
using StudentPortal.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityBLLManager
{
   public class CourseBLLManager: ICourseBLLManager
    {
        private readonly StudentPortalDbContext studentPortalDbContext;
        public CourseBLLManager(StudentPortalDbContext studentPortalDbContext)
        {
            this.studentPortalDbContext = studentPortalDbContext;

        }
        public Course AddCourse(Course course)
        {
            course.CreatedDate = DateTime.Now;
            course.CreatedBy = "Admin";
            this.studentPortalDbContext.Course.Add(course);
            this.studentPortalDbContext.SaveChanges();
            return course;
        }
        public List<Course> GetAll()
        {
            List<Course> courses = this.studentPortalDbContext.Course.Where(p => p.Status == (int)StudentPortal.Common.Enum.Enum.Status.Active).ToList();
            return courses;
        }
        public Course UpdateCourse(Course course)
        {
            course.UpdatedBy = "Admin";
            course.UpdatedDate = DateTime.Now;
            this.studentPortalDbContext.Course.Update(course);
            this.studentPortalDbContext.SaveChanges();
            return course;
        }
        public Course GetCourseById(Course course)
        {
            return this.studentPortalDbContext.Course.Find(course.CourseId);
        }
    }
    public interface ICourseBLLManager
    {
        Course AddCourse(Course course);
        List<Course> GetAll();
        Course UpdateCourse(Course course);
        Course GetCourseById(Course course);
    }
}
