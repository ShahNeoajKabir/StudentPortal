using StudentPortal.DAL;
using StudentPortal.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager
{
   public class RoutineBLLManager
    {
        private readonly StudentPortalDbContext studentPortalDbContext;
        public RoutineBLLManager(StudentPortalDbContext studentPortalDbContext)
        {
            this.studentPortalDbContext = studentPortalDbContext;

        }
        public async Task<Routine>AddRoutine(Routine routine)
        {
            routine.CreatedBy = "Admin";
            routine.CreatedDate = DateTime.Now;
            await this.studentPortalDbContext.Routine.AddAsync(routine);
            await this.studentPortalDbContext.SaveChangesAsync();
            return routine;
        }
        public Routine UpdateRoutine(Routine routine)
        {
            routine.UpdatedBy = "Admin";
            routine.UpdatedDate = DateTime.Now;
             this.studentPortalDbContext.Routine.Update(routine);
            this.studentPortalDbContext.SaveChanges();
            return routine;
        }
        public Routine GetRoutineById(Routine routine)
        {
            return this.studentPortalDbContext.Routine.Find(routine.RoutineId);
        }
        public List<Routine> GetAll()
        {
            List<Routine> routine = this.studentPortalDbContext.Routine.Where(p => p.Status == (int)StudentPortal.Common.Enum.Enum.Status.Active).ToList();
            return routine;
        }
    }
    public interface IRoutineBLLManager
    {
        Task<Routine> AddRoutine(Routine routine);
        Routine UpdateRoutine(Routine routine);
        List<Routine> GetAll();
        Routine GetRoutineById(Routine routine);

    }
}
