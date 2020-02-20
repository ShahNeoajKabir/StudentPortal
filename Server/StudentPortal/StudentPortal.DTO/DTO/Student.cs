using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPortal.DTO.DTO
{
   public class Student
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string Nationality { get; set; }
        public string BloodGroup { get; set; }
        public string Batch { get; set; }
        public string Address { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        public string Image { get; set; }



        public ICollection<Marks> Marks { get; set; }
        public ICollection<StudentRegistration> StudentRegistration { get; set; }
        public ICollection<StudentFeeTransaction> StudentFeeTransaction { get; set; }

        public ICollection<StudentPayment> StudentPayment { get; set; }
        public ICollection<Attendances> Attendances { get; set; }




    }
}
