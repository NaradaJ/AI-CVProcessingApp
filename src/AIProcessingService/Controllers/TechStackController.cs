using Microsoft.AspNetCore.Mvc;
using AIProcessingService.Models;
using AIProcessingService.Services;
using System.Threading.Tasks;

namespace AIProcessingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechStackController : ControllerBase
    {
        private readonly TechStackHighlightService _techStackService;

        public TechStackController(TechStackHighlightService techStackService)
        {
            _techStackService = techStackService;
        }

        // POST: api/TechStack/Extract
        [HttpPost("Extract")]
        public async Task<IActionResult> ExtractTechStack([FromBody] CV cv)
        {
            if (cv == null)
            {
                return BadRequest("CV data is required.");
            }

            // Extract and highlight tech stack from the CV
            var techStack = await _techStackService.ExtractTechStackAsync(cv);

            return Ok(new
            {
                Message = "Tech stack extracted successfully.",
                TechStack = techStack
            });
        }

        // GET: api/TechStack/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTechStack(int id)
        {
            var techStack = await _techStackService.GetTechStackByIdAsync(id);
            if (techStack == null)
            {
                return NotFound($"No tech stack found for CV with ID {id}.");
            }

            return Ok(techStack);
        }
    }
}
