using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using JobPortalApi.Models;

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]//attribute that defines url pattern and here [controller] replaced with controller class name without word controller, so the url pattern will be http://localhost:5000/api/jobs/[action] where [action] is the name of the action method in this controller class.
    [ApiController] //attribute that indicates that this class is an API controller, enabling automatic model validation, response formatting, and other API-specific behaviors.
    public class JobsController : ControllerBase//base class for API controllers that provides common functionality for handling HTTP requests and responses.
    {
        [HttpGet]
        public IActionResult GetJobs()
        {

            List<Job> jobs = new List<Job>
            {
                new Job { Id = 1, Title = "Software Engineer", Company = "ABC Tech", Location = "New York", Salary = 80000, Description = "Develop and maintain software applications." },
                new Job{ Id = 2, Title = "Data Analyst", Company = "XYZ Analytics", Location = "San Francisco", Salary = 70000, Description = "Analyze data and generate insights for business decisions." },
                new Job { Id = 3, Title = "Project Manager", Company = "Global Solutions", Location = "Chicago", Salary = 90000, Description = "Manage projects and coordinate teams to achieve project goals." },
                new Job{ Id = 4, Title = "UX Designer", Company = "Creative Minds", Location = "Los Angeles", Salary = 75000, Description = "Design user interfaces and experiences for web and mobile applications." }
            };
            return Ok(jobs); //returns a 200 OK response with the list of jobs as the response body.
        }

        [HttpGet("{id}")]
        public IActionResult GetJobById(int id)
        {
            List<Job> jobs = new List<Job>
            {
                new Job { Id = 1, Title = "Software Engineer", Company = "ABC Tech", Location = "New York", Salary = 80000, Description = "Develop and maintain software applications." },
                new Job{ Id = 2, Title = "Data Analyst", Company = "XYZ Analytics", Location = "San Francisco", Salary = 70000, Description = "Analyze data and generate insights for business decisions." },
                new Job { Id = 3, Title = "Project Manager", Company = "Global Solutions", Location = "Chicago", Salary = 90000, Description = "Manage projects and coordinate teams to achieve project goals." },
                new Job{ Id = 4, Title = "UX Designer", Company = "Creative Minds", Location = "Los Angeles", Salary = 75000, Description = "Design user interfaces and experiences for web and mobile applications." }
            };
            var job = jobs.FirstOrDefault(j => j.Id == id);
            if (job == null)
            {
                return NotFound(); //returns a 404 Not Found response if the job with the specified id is not found.
            }
            return Ok(job); //returns a 200 OK response with the job details as the response body.
    
        }
        
        [HttpPost]
        public IActionResult CreateJob(Job job)
        {
            // In a real application, you would typically save the job to a database here.
            // For this example, we'll just return the created job with a 201 Created response.
            return CreatedAtAction(nameof(GetJobById), new { id = job.Id }, job); //returns a 201 Created response with the location of the newly created job and the job details as the response body.
        }
    }
}
