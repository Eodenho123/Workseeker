using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WorkSeekerAPI.Models;

namespace WorkSeekerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobSearchFormController : ControllerBase
    {
        private readonly WorkseekerContext DBContext;

        public JobSearchFormController(WorkseekerContext DBContext)
        {
            this.DBContext = DBContext;
        }
        [HttpGet("GetJobOfferForms")]
        public async Task<ActionResult<List<JobSearchForm>>> Get()
        {
            var List = await DBContext.JobSearchForms.Select(
                s => new JobSearchForm
                {
                    Id = s.Id,
                    Title = s.Title,
                    Description = s.Description,
                    FieldId = s.FieldId,
                    UserId = s.UserId,
                    Experience = s.Experience,
                    Skills = s.Skills
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
        [HttpGet("GetJobSearchFormById")]
        public async Task<ActionResult<JobSearchForm>> GetJobOfferFormById(int Id)
        {
            JobSearchForm JobOffer = await DBContext.JobSearchForms.Select(s => new JobSearchForm
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                FieldId = s.FieldId,
                UserId = s.UserId,
                Experience = s.Experience,
                Skills = s.Skills
            }).FirstOrDefaultAsync(s => s.Id == Id);
            if (JobOffer == null)
            {
                return NotFound();
            }
            else
            {
                return JobOffer;
            }
        }
        [HttpPost("InsertJobSearchForm")]
        public async Task<HttpStatusCode> InsertUser(JobSearchForm JobSearch)
        {
            var entity = new JobSearchForm()
            {
                Id = JobSearch.Id,
                Title = JobSearch.Title,
                Description = JobSearch.Description,
                FieldId = JobSearch.FieldId,
                UserId = JobSearch.UserId,
                Experience = JobSearch.Experience,
                Skills = JobSearch.Skills
            };
            DBContext.JobSearchForms.Add(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        [HttpPut("UpdateJobSearchForm")]
        public async Task<HttpStatusCode> UpdateJobOfferForm(JobSearchForm JobSearch)
        {
            var entity = await DBContext.JobSearchForms.FirstOrDefaultAsync(s => s.Id == JobSearch.Id);
            entity.Title = JobSearch.Title;
            entity.Description = JobSearch.Description;
            entity.FieldId = JobSearch.FieldId;
            entity.UserId = JobSearch.UserId;
            entity.Experience = JobSearch.Experience;
            entity.Skills = JobSearch.Skills;
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        [HttpDelete("DeleteJobSearchForm/{Id}")]
        public async Task<HttpStatusCode> DeleteJobSearchForm(int Id)
        {
            var entity = new JobSearchForm()
            {
                Id = Id
            };
            DBContext.JobSearchForms.Attach(entity);
            DBContext.JobSearchForms.Remove(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
