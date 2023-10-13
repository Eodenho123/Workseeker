using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WorkSeekerAPI.Models;

namespace WorkSeekerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobOfferFormController : ControllerBase
    {
        private readonly WorkseekerContext DBContext;

        public JobOfferFormController(WorkseekerContext DBContext)
        {
            this.DBContext = DBContext;
        }
        [HttpGet("GetJobOfferForms")]
        public async Task<ActionResult<List<JobOfferForm>>> Get()
        {
            var List = await DBContext.JobOfferForms.Select(
                s => new JobOfferForm
                {
                    Id = s.Id,
                    StartDate = s.StartDate,
                    EndDate = s.EndDate,
                    Title = s.Title,
                    Description = s.Description,
                    FieldId = s.FieldId,
                    UserId = s.UserId,
                    Requirements = s.Requirements,
                    TemplateId = s.TemplateId
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
        [HttpGet("GetJobOfferFormById")]
        public async Task<ActionResult<JobOfferForm>> GetJobOfferFormById(int Id)
        {
            JobOfferForm JobOffer = await DBContext.JobOfferForms.Select(s => new JobOfferForm
            {
                Id = s.Id,
                StartDate = s.StartDate,
                EndDate = s.EndDate,
                Title = s.Title,
                Description = s.Description,
                FieldId = s.FieldId,
                UserId = s.UserId,
                Requirements = s.Requirements,
                TemplateId = s.TemplateId,
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
        [HttpPost("InsertJobOfferForm")]
        public async Task<HttpStatusCode> InsertUser(JobOfferForm JobOffer)
        {
            var entity = new JobOfferForm()
            {
                Id = JobOffer.Id,
                StartDate = JobOffer.StartDate,
                EndDate = JobOffer.EndDate,
                Title = JobOffer.Title,
                Description = JobOffer.Description,
                FieldId = JobOffer.FieldId,
                UserId = JobOffer.UserId,
                Requirements = JobOffer.Requirements,
                TemplateId = JobOffer.TemplateId
            };
            DBContext.JobOfferForms.Add(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        [HttpPut("UpdateJobOfferForm")]
        public async Task<HttpStatusCode> UpdateJobOfferForm(JobOfferForm JobOffer)
        {
            var entity = await DBContext.JobOfferForms.FirstOrDefaultAsync(s => s.Id == JobOffer.Id);
            entity.StartDate = JobOffer.StartDate;
            entity.EndDate = JobOffer.EndDate;
            entity.Title = JobOffer.Title;
            entity.Description = JobOffer.Description;
            entity.FieldId = JobOffer.FieldId;
            entity.UserId = JobOffer.UserId;
            entity.Requirements = JobOffer.Requirements;
            entity.TemplateId = JobOffer.TemplateId;
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        [HttpDelete("DeleteJobOfferForm/{Id}")]
        public async Task<HttpStatusCode> DeleteJobOfferForm(int Id)
        {
            var entity = new JobOfferForm()
            {
                Id = Id
            };
            DBContext.JobOfferForms.Attach(entity);
            DBContext.JobOfferForms.Remove(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
