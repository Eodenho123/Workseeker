using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WorkSeekerAPI.Models;

namespace WorkSeekerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly WorkseekerContext DBContext;

        public CompanyController(WorkseekerContext DBContext)
        {
            this.DBContext = DBContext;
        }
        [HttpGet("GetCompanies")]
        public async Task<ActionResult<List<Company>>> Get()
        {
            var List = await DBContext.Companies.Select(
                s => new Company
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    Phone = s.Phone,
                    Email = s.Email,
                    Address = s.Address,
                    Employees = s.Employees
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
        [HttpGet("GetEmployees")]
        public async Task<ActionResult<List<User>>> GetEmployees(int id)
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
            ).Where(s => s.CompanyId == id).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }
        [HttpGet("GetCompanyById")]
        public async Task<ActionResult<Company>> GetCompanyById(int Id)
        {
            Company User = await DBContext.Companies.Select(s => new Company
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                Phone = s.Phone,
                Email = s.Email,
                Address = s.Address,
                Employees = s.Employees
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
        [HttpPost("InsertCompany")]
        public async Task<HttpStatusCode> InsertCompany(Company company)
        {
            var entity = new Company()
            {
                Id = company.Id,
                Name = company.Name,
                Description = company.Description,
                Phone = company.Phone,
                Email = company.Email,
                Address = company.Address,
                Employees = company.Employees
            };
            DBContext.Companies.Add(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        [HttpPut("UpdateCompany")]
        public async Task<HttpStatusCode> UpdateCompany(Company company)
        {
            var entity = await DBContext.Companies.FirstOrDefaultAsync(s => s.Id == company.Id);
            entity.Id = company.Id;
            entity.Name = company.Name;
            entity.Description = company.Description;
            entity.Phone = company.Phone;
            entity.Email = company.Email;
            entity.Address = company.Address;
            entity.Employees = company.Employees;
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        [HttpDelete("DeleteCompany/{Id}")]
        public async Task<HttpStatusCode> Deletecompany(int Id)
        {
            var entity = new Company()
            {
                Id = Id
            };
            DBContext.Companies.Attach(entity);
            DBContext.Companies.Remove(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
