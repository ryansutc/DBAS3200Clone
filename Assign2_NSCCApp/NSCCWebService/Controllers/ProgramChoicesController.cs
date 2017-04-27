using NSCCModelDB;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;

namespace NSCCWebService.Controllers
{
    public class ProgramChoicesController : ODataController
    {
        NSCCDBContext context = new NSCCDBContext();
        
        private bool ProgramExists(int key)
        {
            return context.ProgramChoices.Any(a => a.ProgramChoiceId == key);
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

        //CRUD
        //GET
        [EnableQuery]
        public IQueryable<ProgramChoice> Get()
        {
            return context.ProgramChoices;
        }
        [EnableQuery]
        public SingleResult<ProgramChoice> Get([FromODataUri] int key)
        {
            IQueryable<ProgramChoice> result = context.ProgramChoices.Where(a => a.ProgramChoiceId == key);
            return SingleResult.Create(result);
        }

        //POST
        public async Task<IHttpActionResult> Post(ProgramChoice ProgramChoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.ProgramChoices.Add(ProgramChoice);
            await context.SaveChangesAsync();
            return Created(ProgramChoice);
        }

        //UPDATE

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<ProgramChoice> ProgramChoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await context.ProgramChoices.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            ProgramChoice.Patch(entity);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(entity);
        }

        //DELETE

        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var ProgramChoice = await context.ProgramChoices.FindAsync(key);
            if (ProgramChoice == null)
            {
                return NotFound();
            }
            context.ProgramChoices.Remove(ProgramChoice);
            await context.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}