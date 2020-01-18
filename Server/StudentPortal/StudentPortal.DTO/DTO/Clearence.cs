using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPortal.DTO.DTO
{
   public class Clearence
    {
        public int ClearenceId { get; set; }
        public int StudentPaymentId { get; set; }
        public string StudentId { get; set; }
        public short FeeType { get; set; }
        public bool ClearenceStatus { get; set; }
        public int StudentFeeTransactionId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
    }
}
