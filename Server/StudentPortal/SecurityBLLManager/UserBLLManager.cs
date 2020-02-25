using StudentPortal.DAL;
using StudentPortal.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using StudentPortal.Common.Utility;

namespace SecurityBLLManager
{
    public class UserBLLManager : IUserBLLManager
    {
        private readonly StudentPortalDbContext _db;
        public UserBLLManager(StudentPortalDbContext db)
        {
            _db = db;
        }
        public User AddUser(User user)
        {
            user.CreatedBy = "Admin";
            user.CreatedDate = DateTime.Now;

            user.Password = new EncryptionService().Encrypt(user.Password);

            _db.User.Add(user);
            _db.SaveChanges();
            return user;
        }

        public List<User> GetAll()
        {
            List<User> user = _db.User.Where(p=>p.Status==(int)StudentPortal.Common.Enum.Enum.Status.Active).ToList();
            return user;
        }

        public User UpdateUser(User user)
        {
            user.UpdatedBy = "Admin";
            user.UpdatedDate = DateTime.Now;

            _db.User.Update(user);
             _db.SaveChanges();
            return user;
        }
        public User GetUserByID(User user)
        {
            return _db.User.Find(user.UserId); 
        }
    }
    public interface IUserBLLManager
    {
        User AddUser(User user);
        User UpdateUser(User user);
        User GetUserByID(User user);

        List<User> GetAll();





    }
}
