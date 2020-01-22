using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPortal.DTO.DTO
{
   public class CourseTeacherMapping
    {
        public CourseTeacherMapping()
        {
            Course = new Course();
            Teacher = new Teacher();
            Semester = new Semester();
            Marks = new HashSet<Marks>();
        }
        public int CourseTeacherMappingId { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public int SemesterId { get; set; }
        public int SectionId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }

        public virtual Course Course { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Semester Semester { get; set; }

        public ICollection<Marks> Marks { get; set; }



    }
}
