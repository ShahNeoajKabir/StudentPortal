using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPortal.DTO.DTO
{
    public class Attendances
    {

        public int AttendanceId { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public int StudentId { get; set; }

        public bool Attendance { get; set; }
        public DateTime AttendanceDate { get; set; }
        public int SemesterId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
        public virtual Teacher Teacher { get; set; }


    }
}
