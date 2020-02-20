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
        public async Task<User> AddUser(User user)
        {
            user.CreatedBy = "Bappy";
            user.CreatedDate = DateTime.Now;
            user.UserTypeId = 1;

            //user.Password = new EncryptionService().Encrypt(user.Password);
           await _db.User.AddAsync(user);
           await _db.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAll()
        {
            List<User> user = _db.User.ToList();
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            _db.User.Update(user);
            await _db.SaveChangesAsync();
            return user;
        }
        public async Task<User> DeleteUser(User user)
        {
            _db.User.Remove(user);
            await _db.SaveChangesAsync();
            return user;
        }
    }
    public interface IUserBLLManager
    {
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<List<User>> GetAll();
        Task<User> DeleteUser(User user);





    }
}
