using BusinessLogicLayer;
using Models;
using NCRTask.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCRTask.Implementaion
{
    public class UserRepository : IUserRepository
    {
        
       
        
        

        public async Task<IEnumerable<UserModel>> GetAllUserAsync()
        {
            return await BusinessLogic.Self().GetAllUser();
        }


        public async Task<UserModel> GetUserAsync(int Id)
        {       
            return await BusinessLogic.Self().GetUser(Id);
        }


        public async Task<bool> CreateUser(UserModel user)
        {
            return await BusinessLogic.Self().saveUser(user);
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await BusinessLogic.Self().deleteUser(id);
        }

        public async Task<bool> UpdateUser(int id, UserModel user)
        {
            return await BusinessLogic.Self().updateUser(id, user);
        }

    }
}
