using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPortal.DTO.DTO
{
    public class Course
    {
        public Course()
        {
            CourseTeacherMapping = new HashSet<CourseTeacherMapping>();
            StudentRegistration = new HashSet<StudentRegistration>();
            Attendances = new HashSet<Attendances>(); 



        }
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public short CourseCredit { get; set; }
        public decimal CourseFee { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        public ICollection<CourseTeacherMapping> CourseTeacherMapping { get; set; }

        public ICollection<StudentRegistration> StudentRegistration { get; set; }
        public ICollection<Attendances> Attendances { get; set; }

    }
}
