using StudentPortal.DAL;
using StudentPortal.DTO.DTO;
using StudentPortal.DTO.ViewModel;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace SecurityBLLManager
{
    public class SecurityBLLManager: ISecurityBLLManager
    {
        private readonly StudentPortalDbContext _studentPortalDbContext;
        public SecurityBLLManager(StudentPortalDbContext studentPortalDbContext)
        {
            _studentPortalDbContext = studentPortalDbContext;
        }

        public async Task<User> Login(VMLogin vMLogin)
        {
            User objuser = new User();
            try
            {
                objuser =  _studentPortalDbContext.User.Where(p => p.UserName == vMLogin.UserName && p.Password == vMLogin.Password).Select(u=> new User() { 
                UserTypeId=u.UserTypeId,
                UserName=u.UserName,
                Email=u.Email
                
                
                }).FirstOrDefault();

             
            }
            catch (Exception ex)
            {

                
            }
            return objuser;
        }
    }

    public interface ISecurityBLLManager
    {
        Task<User> Login(VMLogin vMLogin);
    }
}
