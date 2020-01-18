using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPortal.DTO.DTO
{
   public class Routine
    {
        public int RoutineId { get; set; }
        public string CourseCode { get; set; }
        public int SemesterId { get; set; }
        public short Day { get; set; }
        public short Slot { get; set; }
        public string TeacherInitial { get; set; }
        public int TeacherId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }

    }
}
