using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPortal.DTO.DTO
{
   public class Teacher
    {
        public Teacher()
        {
            CourseTeacherMapping = new HashSet<CourseTeacherMapping>();
            Attendances = new HashSet<Attendances>();

        }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherCode { get; set; }
        public string TeacherInitial { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BloodGroup { get; set; }
        public string Address { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        public string Image { get; set; }

        public ICollection<CourseTeacherMapping> CourseTeacherMapping { get; set; }
        public ICollection<Attendances> Attendances { get; set; }


    }
}
