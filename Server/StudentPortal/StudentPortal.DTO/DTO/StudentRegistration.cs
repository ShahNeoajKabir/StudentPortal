using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPortal.DTO.DTO
{
   public class StudentRegistration
    {
        public StudentRegistration()
        {
            Student = new Student();
            Course = new Course();
        }
        public int StudentRegistrationId { get; set; }
        public string StudentId { get; set; }
        public int CourseId { get; set; }
        public int SemesterId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }


    }
}
