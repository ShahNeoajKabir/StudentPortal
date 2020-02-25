using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPortal.DTO.DTO
{
   public class StudentPayment
    {
        public int StudentPaymentId { get; set; }
        public int StudentId { get; set; }
        public int StudentFeeTransactionId { get; set; }
        public decimal Amount { get; set; }
        public int SemesterId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }

        public virtual Student Student { get; set; }
    }
}
