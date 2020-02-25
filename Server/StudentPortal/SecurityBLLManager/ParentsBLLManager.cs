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
            parents.CreatedDate = DateTime.Now;
            parents.CreatedBy = "Admin";
            this.studentPortalDbContext.Parents.Add(parents);
             this.studentPortalDbContext.SaveChanges();
            return parents;
        }
        public List<Parents> GetAll()
        {
            List<Parents> parents = this.studentPortalDbContext.Parents.Where(p => p.Status == (int)StudentPortal.Common.Enum.Enum.Status.Active).ToList();
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
