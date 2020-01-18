using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPortal.DTO.DTO
{
   public class Parents
    {
        public int ParentsId { get; set; }
        public string StudentId { get; set; }
        public string ParentsName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string BloodGroup { get; set; }
        public string Address { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
    }
}
