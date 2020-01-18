using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPortal.DTO.DTO
{
   public class Attendances
    {
        public int AttendanceId { get; set; }
        public int CourseTeacherId { get; set; }
        public string StudentId { get; set; }
        public bool Attendance { get; set; }
        public DateTime AttendanceDate { get; set; }
        public int SemesterId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }

    }
}
