using StudentPortal.Common.Utility;
using StudentPortal.DAL;
using StudentPortal.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager
{
   public class ParentsBLLManager: IParentsBLLManager
    {
        private readonly StudentPortalDbContext studentPortalDbContext;
        public ParentsBLLManager(StudentPortalDbContext studentPortalDbContext)
        {
            this.studentPortalDbContext = studentPortalDbContext;

        }
        public Parents AddParents(Parents parents)
        {
            try
            {
                this.studentPortalDbContext.Database.BeginTransaction();
                parents.CreatedDate = DateTime.Now;
                this.studentPortalDbContext.Parents.Add(parents);
                this.studentPortalDbContext.SaveChanges();
                User user = new User
                {
                    UserName = parents.ParentsName,
                    Email = parents.Email,
                    MobileNo = parents.MobileNo,
                    Status = (int)StudentPortal.Common.Enum.Enum.Status.Active,
                    CreatedBy = parents.CreatedBy,
                    UserTypeId = (int)StudentPortal.Common.Enum.Enum.UserType.Parents,
                    CreatedDate = parents.CreatedDate
                };
                user.Password = new EncryptionService().Encrypt("123456");
                this.studentPortalDbContext.User.Add(user);
                this.studentPortalDbContext.SaveChanges();
                UserMapping userMapping = new UserMapping
                {
                    UserId = user.UserId,
                    IdentityId = parents.ParentsId,
                    UserTypeId = (int)StudentPortal.Common.Enum.Enum.UserType.Parents,
                    Status = (int)StudentPortal.Common.Enum.Enum.Status.Active,
                    CreatedBy = parents.CreatedBy,
                    CreatedDate = parents.CreatedDate

                };
                this.studentPortalDbContext.UserMapping.Add(userMapping);
                this.studentPortalDbContext.SaveChanges();
                this.studentPortalDbContext.Database.CommitTransaction();

                return parents;

            }
            catch (Exception ex)
            {
                this.studentPortalDbContext.Database.RollbackTransaction();

                throw;
            }
        }
        public List<Parents> GetAll()
        {
            List<Parents> parents = this.studentPortalDbContext.Parents.Where(p => p.Status == (int)StudentPortal.Common.Enum.Enum.Status.Active).Select(t=> new Parents() { 
            Address=t.Address,
            BloodGroup=t.BloodGroup,
            CreatedBy=t.CreatedBy,
            CreatedDate=t.CreatedDate,
            Email=t.Email,
            Image=t.Image,
            MobileNo=t.MobileNo,
            ParentsId=t.ParentsId,
            ParentsName=t.ParentsName,
            Status=t.Status,
            Student=t.Student,
            StudentId=t.StudentId
            
            
            }).ToList();
            return parents;
        }
        public Parents UpdateParents(Parents parents)
        {
            parents.UpdatedBy = "Admin";
            parents.UpdatedDate = DateTime.Now;
            this.studentPortalDbContext.Parents.Update(parents);
            this.studentPortalDbContext.SaveChanges();
            return parents;
        }
        public Parents GetParentsById(Parents parents)
        {
            return this.studentPortalDbContext.Parents.Find(parents.ParentsId);
        }
    }
    public interface IParentsBLLManager
    {
        Parents AddParents(Parents parents);
        List<Parents> GetAll();
        Parents UpdateParents(Parents parents);
        Parents GetParentsById(Parents parents);

    }
}
