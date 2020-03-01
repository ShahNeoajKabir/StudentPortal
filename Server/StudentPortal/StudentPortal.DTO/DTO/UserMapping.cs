using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPortal.DTO.DTO
{
   public class UserMapping
    {
        public int UserMappingId { get; set; }
        public int UserId { get; set; }
        public int UserTypeId { get; set; }
        public int IdentityId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }

        public virtual User User { get; set; }
    }
}
