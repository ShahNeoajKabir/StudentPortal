using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPortal.Common.Enum
{
  public  class Enum
    {
        public enum Gender {
        Male=1,
        Female=2
        }
        public enum Status
        {
            Active = 1,
            Inactive = 2,
            Delete=3
        }
        public enum MarksType
        {
            Quiz1=1,
            Quiz2=2,
            Quiz3=3,
            MidTerm=4,
            Final=5

        }
        public enum UserType
        {
            Admin = 1,
            CoOrdinator = 2,
            Studen = 3,
            Accounts = 4,
            Teacher = 5,
            Parents = 6,
            SuperAdmin = -1
        }
    }
}
