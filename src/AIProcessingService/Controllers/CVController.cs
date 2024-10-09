using Microsoft.AspNetCore.Mvc;
using AIProcessingService.Models;
using AIProcessingService.Services;
using System.Threading.Tasks;
using AIProcessingService.Services;


namespace AIProcessingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CVController : ControllerBase
    {
        private readonly CVSummarizationService _summarizationService;
        private readonly RelevanceAssessmentService _relevanceService;
        private readonly OpenAIService _openAIService; // Add OpenAI service

        public CVController(CVSummarizationService summarizationService, 
                            RelevanceAssessmentService relevanceService,
                            OpenAIService openAIService) // Inject OpenAI service
        {
            _summarizationService = summarizationService;
            _relevanceService = relevanceService;
            _openAIService = openAIService; // Assign OpenAI service
        }

        // POST: api/CV/Upload
        [HttpPost("Upload")]
        public async Task<IActionResult> UploadCV([FromBody] CV cv)
        {
            if (cv == null)
            {
                return BadRequest("CV data is required.");
            }

            // Summarize the CV using custom summarization
            var summary = await _summarizationService.SummarizeCVAsync(cv);
            
            // Alternatively, use OpenAI for summary
            // var summary = await _openAIService.GetCompletion(cv.ToString());

            // Assess relevance
            var relevance = await _relevanceService.CalculateRelevanceAsync(cv);

            return Ok(new
            {
                Message = "CV uploaded successfully.",
                Summary = summary,
                RelevanceScore = relevance
            });
        }

        // GET: api/CV/Summary/{id}
        [HttpGet("Summary/{id}")]
        public async Task<IActionResult> GetCVSummary(int id)
        {
            var summary = await _summarizationService.GetSummaryByIdAsync(id);
            if (summary == null)
            {
                return NotFound($"No summary found for CV with ID {id}.");
            }

            return Ok(summary);
        }

        // GET: api/CV/Relevance/{id}
        [HttpGet("Relevance/{id}")]
        public async Task<IActionResult> GetRelevanceScore(int id)
        {
            var relevance = await _relevanceService.GetRelevanceByIdAsync(id);
            if (relevance == null)
            {
                return NotFound($"No relevance score found for CV with ID {id}.");
            }

            return Ok(relevance);
        }
    }
}
