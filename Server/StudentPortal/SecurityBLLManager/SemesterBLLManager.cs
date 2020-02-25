using StudentPortal.DAL;
using StudentPortal.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityBLLManager
{
   public class SemesterBLLManager: ISemesterBLLManager
    {
        private readonly StudentPortalDbContext studentPortalDbContext;
        public SemesterBLLManager(StudentPortalDbContext studentPortalDbContext)
        {
            this.studentPortalDbContext = studentPortalDbContext;

        }
        public Semester AddSemester(Semester semester)
        {
            semester.CreatedBy = "Admin";
            semester.CreatedDate = DateTime.Now;
            this.studentPortalDbContext.Semester.Add(semester);
            this.studentPortalDbContext.SaveChanges();
            return semester;

        }
        public List<Semester> GetAll()
        {
            List<Semester> semesters = this.studentPortalDbContext.Semester.Where(p => p.Status == (int)StudentPortal.Common.Enum.Enum.Status.Active).ToList();

            return semesters;
        }
        public Semester UpdateSemester(Semester semester)
        {
            semester.UpdatedBy = "Admin";
            semester.UpdatedDate = DateTime.Now;
            this.studentPortalDbContext.Semester.Update(semester);
            this.studentPortalDbContext.SaveChanges();
            return semester;
        }
        public Semester GetSemesterById(Semester semester)
        {
            return this.studentPortalDbContext.Semester.Find(semester.SemesterId);
        }
    }
    public interface ISemesterBLLManager
    {
        Semester AddSemester(Semester semester);
        List<Semester> GetAll();
        Semester UpdateSemester(Semester semester);
        Semester GetSemesterById(Semester semester);

    }
}
