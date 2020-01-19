using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPortal.DTO.DTO
{
   public class StudentFeeTransaction
    {
        public StudentFeeTransaction()
        {
            Student = new Student();
        }
        public int StudentFeeTransactionId { get; set; }
        public string StudentId { get; set; }
        public int StudentRegistrationId { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public decimal Due { get; set; }


        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }

        public virtual Student Student { get; set; }
    }
}
