using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WorkSeekerAPI.Models;

namespace WorkSeekerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly WorkseekerContext DBContext;

        public UserController(WorkseekerContext DBContext)
        {
            this.DBContext = DBContext;
        }
        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<User>>> Get()
        {
            var List = await DBContext.Users.Select(
                s => new User
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Username = s.Username,
                    Password = s.Password,
                    RegistrationDate = s.RegistrationDate,
                    Email = s.Email,
                    Address = s.Address,
                    StatusId = s.StatusId,
                    CompanyId = s.CompanyId
                }
            ).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }
        [HttpGet("GetUserById")]
        public async Task<ActionResult<User>> GetUserById(int Id)
        {
            User User = await DBContext.Users.Select(s => new User
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Username = s.Username,
                Password = s.Password,
                RegistrationDate = s.RegistrationDate,
                Email = s.Email,
                Address = s.Address,
                StatusId = s.StatusId,
                CompanyId = s.CompanyId
            }).FirstOrDefaultAsync(s => s.Id == Id);
            if (User == null)
            {
                return NotFound();
            }
            else
            {
                return User;
            }
        }
        [HttpPost("InsertUser")]
        public async Task<HttpStatusCode> InsertUser(User User)
        {
            var entity = new User()
            {
                FirstName = User.FirstName,
                LastName = User.LastName,
                Username = User.Username,
                Password = User.Password,
                RegistrationDate = User.RegistrationDate,
                Email = User.Email,
                Address = User.Address,
                StatusId = User.StatusId,
                CompanyId = User.CompanyId
            };
            DBContext.Users.Add(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        [HttpPut("UpdateUser")]
        public async Task<HttpStatusCode> UpdateUser(User User)
        {
            var entity = await DBContext.Users.FirstOrDefaultAsync(s => s.Id == User.Id);
            entity.FirstName = User.FirstName;
            entity.LastName = User.LastName;
            entity.Username = User.Username;
            entity.Password = User.Password;
            entity.RegistrationDate = User.RegistrationDate;
            entity.Email = User.Email;
            entity.Address = User.Address;
            entity.StatusId = User.StatusId;
            entity.CompanyId = User.CompanyId;
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        [HttpDelete("DeleteUser/{Id}")]
        public async Task<HttpStatusCode> DeleteUser(int Id)
        {
            var entity = new User()
            {
                Id = Id
            };
            DBContext.Users.Attach(entity);
            DBContext.Users.Remove(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
