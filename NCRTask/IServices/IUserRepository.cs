using Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCRTask.IServices
{
  
        public interface IUserRepository
        {

            public Task<IEnumerable<UserModel>> GetAllUserAsync();
            public Task<UserModel> GetUserAsync(int Id);
            public Task<bool> CreateUser(UserModel user);
            public Task<bool> DeleteUser(int id);
        public Task<bool> UpdateUser(int id, UserModel user);


    }

    
}
