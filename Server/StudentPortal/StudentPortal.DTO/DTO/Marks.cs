using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPortal.DTO.DTO
{
   public class Marks
    {
        public int MarksId { get; set; }
        public decimal Mark { get; set; }
        public int CourseTeacherMappingId { get; set; }
        public int StudentId { get; set; }
        public short MarksType { get; set; }
        public int SemesterId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }

        public virtual Student Student { get; set; }
        public virtual CourseTeacherMapping CourseTeacherMapping { get; set; }
        public virtual Semester Semester { get; set; }



    }
}
