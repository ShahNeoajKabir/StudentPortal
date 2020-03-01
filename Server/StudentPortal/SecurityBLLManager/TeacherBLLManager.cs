using StudentPortal.Common.Utility;
using StudentPortal.DAL;
using StudentPortal.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityBLLManager
{
   public class TeacherBLLManager: ITeacherBLLManager
    {
        private readonly StudentPortalDbContext _studentPortalDbContext;
        public TeacherBLLManager(StudentPortalDbContext studentPortalDbContext)
        {
            _studentPortalDbContext = studentPortalDbContext;

        }
        public Teacher AddTeacher(Teacher teacher)
        {
            try
            {
                _studentPortalDbContext.Database.BeginTransaction();
                //teacher.CreatedBy = "Admin";
                teacher.CreatedDate = DateTime.Now;
                _studentPortalDbContext.Teacher.Add(teacher);
                _studentPortalDbContext.SaveChanges();
                User user = new User
                {
                    UserName = teacher.TeacherName,
                    Email = teacher.Email,
                    UserTypeId = (int)StudentPortal.Common.Enum.Enum.UserType.Teacher,
                    MobileNo = teacher.Mobile,
                    Status = (int)StudentPortal.Common.Enum.Enum.Status.Active,
                    CreatedBy = teacher.CreatedBy,
                    CreatedDate = teacher.CreatedDate
                };
                user.Password = new EncryptionService().Encrypt("123456");
                _studentPortalDbContext.User.Add(user);
                _studentPortalDbContext.SaveChanges();
                UserMapping userMapping = new UserMapping
                {
                    IdentityId = teacher.TeacherId,
                    Status = (int)StudentPortal.Common.Enum.Enum.Status.Active,
                    UserId = user.UserId,
                    CreatedBy = teacher.CreatedBy,
                    CreatedDate = teacher.CreatedDate,
                    UserTypeId = (int)StudentPortal.Common.Enum.Enum.UserType.Teacher
                };
                _studentPortalDbContext.UserMapping.Add(userMapping);
                _studentPortalDbContext.SaveChanges();
                _studentPortalDbContext.Database.CommitTransaction();
                return teacher;

            }
            catch (Exception ex)
            {
                _studentPortalDbContext.Database.RollbackTransaction();

                throw;
            }

        }
        public List<Teacher> GetAll()
        {
            List<Teacher> teacher = _studentPortalDbContext.Teacher.Where(p => p.Status == (int)StudentPortal.Common.Enum.Enum.Status.Active).ToList();
            return teacher;
        }
        public Teacher UpdateTeacher(Teacher teacher)
        {
            teacher.UpdatedBy = "Admin";
            teacher.UpdatedDate = DateTime.Now;
            _studentPortalDbContext.Teacher.Update(teacher);
            _studentPortalDbContext.SaveChanges();
            return teacher;
        }
        public Teacher GetTeacherById(Teacher teacher)
        {
           return _studentPortalDbContext.Teacher.Find(teacher.TeacherId);
        }
            
    }
    public interface ITeacherBLLManager
    {
        Teacher AddTeacher(Teacher teacher);
        List<Teacher> GetAll();
        Teacher UpdateTeacher(Teacher teacher);
        Teacher GetTeacherById(Teacher teacher);
    }
}
