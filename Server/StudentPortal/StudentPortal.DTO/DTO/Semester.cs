using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPortal.DTO.DTO
{
   public class Semester
    {
        public Semester()
        {
            CourseTeacherMapping = new HashSet<CourseTeacherMapping>();
        }
        public int SemesterId { get; set; }
        public string SemesterName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }

        public ICollection<CourseTeacherMapping> CourseTeacherMapping { get; set; }
    }
}
