using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using Models;
using NCRTask.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NCRTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

       private readonly IUserRepository _userRepo;

       private readonly INCRlog _ncrlog;

        public UserController(IUserRepository userRepo , INCRlog ncrlog)
        {
            _userRepo = userRepo;
            _ncrlog = ncrlog;
        }



        // GET: api/<UserController>
        [HttpGet("/GetUsers")]
        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            try
            {
                return await _userRepo.GetAllUserAsync();
            }
            catch (Exception ex)
            {
                _ncrlog.log(ex);
                throw;
            }
            
        }

        // GET api/<UserController>/5
        [HttpGet("/GetUser/{id}")]
        public async Task<UserModel> Get(int id)
        {
            try
            {
                return await _userRepo.GetUserAsync(id);
            }
            catch (Exception ex)
            {

                if (ex.Message == "Sequence contains no elements")
                {
                   throw new InvalidOperationException("User Not IN DB");
                    _ncrlog.log("User Not IN DB");
                }
                else
                {
                    _ncrlog.log(ex);
                    throw;
                } 
            }       
            
        }
        
        // POST api/<UserController>
        [HttpPost("/SaveUser")]
        public async Task<string>SaveUser([FromBody] UserModel us)
        {
            try
            {
                bool result = await _userRepo.CreateUser(us);


                return (result) ? "User Inserted Succcessuffly" : "Error. please contact admins";          
            }
            catch (Exception ex)
            {
                _ncrlog.log(ex);
                throw;
            }
            
        }

        // PUT api/<UserController>/5
        [HttpPut("/UpdateUser/{id}")]
        public async Task<string> Put(int id, [FromBody] UserModel us)
        {
            try
            {
                bool result = await _userRepo.UpdateUser(id,us);


                return (result) ? "User Updated Succcessuffly" : "Error. please contact admins";
            }
            catch (Exception ex)
            {
                _ncrlog.log(ex);
                throw;
            }

        }

        // DELETE api/<UserController>/5
        [HttpDelete("/DeleteUser/{id}")]
        public async Task<bool> Delete(int id)
        {
            try
            {
                return await _userRepo.DeleteUser(id);
            }
            catch (Exception ex)
            {
                _ncrlog.log(ex);
                throw;
            }
            
        }
    }
}
