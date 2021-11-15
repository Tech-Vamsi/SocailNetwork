using Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using  System.Threading.Tasks;
using Domain;
namespace API.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class ActivitiesController : ControllerBase
    {
        private readonly DBContext context;
        public ActivitiesController(DBContext context)
        {
            this.context=context;
        }
        
        [HttpGet("Acitivities")]
        public async Task<ActionResult<List<Activity>>> GetActivitie()
        {
            return await context.Activities.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await context.Activities.FindAsync(id);
        }
    }
}