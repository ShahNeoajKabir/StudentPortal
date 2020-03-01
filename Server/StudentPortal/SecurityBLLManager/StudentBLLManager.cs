using StudentPortal.Common.Utility;
using StudentPortal.DAL;
using StudentPortal.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityBLLManager
{
    public class StudentBLLManager : IStudentBLLManager
    {
        private readonly StudentPortalDbContext _student;
        public StudentBLLManager(StudentPortalDbContext student)
        {
            _student = student;
        }
        public Student AddStudent(Student student)
        {

            try
            {
                _student.Database.BeginTransaction();

                student.CreatedDate = DateTime.Now;

                student.Status = (int)StudentPortal.Common.Enum.Enum.Status.Active;
                _student.Student.Add(student);
                _student.SaveChangesAsync();


                User user = new User()
                {
                    Email = student.Email,
                    MobileNo = student.MobileNo,
                    UserTypeId = (int)StudentPortal.Common.Enum.Enum.UserType.Studen,
                    UserName = student.StudentName,
                    Status = (int)StudentPortal.Common.Enum.Enum.Status.Active,
                    CreatedBy = student.CreatedBy,
                    CreatedDate = student.CreatedDate

                };
                user.Password= new EncryptionService().Encrypt("123456");
                _student.User.Add(user);
                _student.SaveChanges();

                UserMapping userMapping = new UserMapping()
                {
                    UserId = user.UserId,
                    IdentityId = student.StudentId,
                    UserTypeId = (int)StudentPortal.Common.Enum.Enum.UserType.Studen,
                    Status = (int)StudentPortal.Common.Enum.Enum.Status.Active,
                    CreatedBy = student.CreatedBy,
                    CreatedDate = student.CreatedDate

                };
                _student.UserMapping.Add(userMapping);
                _student.SaveChanges();
                _student.Database.CommitTransaction();
                return student;
            }
            catch (Exception ex)
            {
                _student.Database.RollbackTransaction();

                throw;
            }

        }
        public List<Student> GetAll()
        {
            List<Student> students = _student.Student.Where(p => p.Status == (int)StudentPortal.Common.Enum.Enum.Status.Active).ToList();

            return students;
        }
        public Student UpdateStudent(Student student)
        {
            student.UpdatedBy = "CoOrdinator";
            student.UpdatedDate = DateTime.Now;
            _student.Student.Update(student);
            _student.SaveChanges();
            return student;
        }
        public Student GetStudentId(Student student)
        {
            return _student.Student.Find(student.StudentId);
        }
    }

    public interface IStudentBLLManager
    {
        Student AddStudent(Student student);
        List<Student> GetAll();
        Student UpdateStudent(Student student);
        Student GetStudentId(Student student);

    }
}
