
using Microsoft.AspNetCore.Mvc;
using JobPortalApi.Models;
using JobPortal.API.Data;   
using Microsoft.EntityFrameworkCore;

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        // Shared list
        private readonly ApplicationDbContext _context;

        public JobsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            var jobs = await _context.Jobs.ToListAsync();
            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public IActionResult GetJobById(int id)
        {
            var job = jobs.FirstOrDefault(j => j.Id == id);

            if (job == null)
                return NotFound();

            return Ok(job);
        }

        [HttpPost]
        public IActionResult CreateJob(Job job)
        {
            job.Id = jobs.Max(j => j.Id) + 1;

            jobs.Add(job);

            return CreatedAtAction(
                nameof(GetJobById),
                new { id = job.Id },
                job
            );
        }

        [HttpPut("{id}")]
        public IActionResult UpdateJob(int id, Job updatedJob)
        {
            var job = jobs.FirstOrDefault(j => j.Id == id);
            if (job == null) { 

                return NotFound();
              }

            job.Title = updatedJob.Title;
            job.Company = updatedJob.Company;
            job.Location = updatedJob.Location;
            job.Salary = updatedJob.Salary;
            job.Description = updatedJob.Description;
            return Ok(job);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJob(int id)
        {
            var job = jobs.FirstOrDefault(j => j.Id == id);
            if (job == null)
                return NotFound("Job not found.");

            jobs.Remove(job);
            return Ok("Job deleted successfully.");
        }
    }
}
