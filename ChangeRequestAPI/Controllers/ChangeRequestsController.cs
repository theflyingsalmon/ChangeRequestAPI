using ChangeRequestAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChangeRequestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangeRequestsController : Controller
    {

        private readonly ChangeRequestContext _context;

        public ChangeRequestsController(ChangeRequestContext context)
        {
            _context = context;
        }

        // GET ChangeRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChangeRequest>>> GetChangeRequests()
        {
            return await _context.ChangeRequests.ToListAsync();
        }


        //GET ChangeRequest/id
        [HttpGet("{id}")]
        public async Task<ActionResult<ChangeRequest>> GetChangeRequest(Guid id)
        {
            var product = await _context.ChangeRequests.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }


        //PUT ChangeRequest
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChangeRequest(Guid id, ChangeRequest changeRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existing = _context.ChangeRequests.FirstOrDefault(x => x.Id == id);

            if (existing is null) 
            { 
                return NotFound(id);
            }

            existing.Title = changeRequest.Title;
            existing.Description = changeRequest.Description;
            existing.Priority = changeRequest.Priority;
            existing.Category = changeRequest.Category;
            existing.Status = changeRequest.Status;

            await _context.SaveChangesAsync();

            return Ok(existing);
        }

        //POST ChangeRequest
        [HttpPost]
        public async Task<ActionResult<ChangeRequest>> PostChangeRequest(ChangeRequest changeRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.ChangeRequests.Add(changeRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChangeRequest", new { id = changeRequest.Id }, changeRequest);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChangeRequest(Guid id)
        {
            var changeRequest = await _context.ChangeRequests.FindAsync(id);
            if (changeRequest == null)
            {
                return NotFound(id);
            }

            _context.ChangeRequests.Remove(changeRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }



        private bool ChangeRequestExists(Guid id)
        {
            return _context.ChangeRequests.Any(x => x.Id == id);
        }






    }
}
