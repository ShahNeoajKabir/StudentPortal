using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPortal.DTO.ViewModel
{
    public class TempMessage
    {
        public string UserId { get; set; }
        public long? SessionId { get; set; }
        public string Content { get; set; }
        public int? UserTypeId { get; set; }
    }
}
