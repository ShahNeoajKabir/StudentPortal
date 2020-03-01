using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPortal.DTO.DTO
{
   public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserTypeName { get; set; }
        public string MobileNo { get; set; }
        public string Password { get; set; }
        public int UserTypeId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        public ICollection<UserMapping> UserMapping { get; set; }
    }
}
