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
    public class ProgramsController : ODataController
    {
        NSCCDBContext context = new NSCCDBContext();
        
        private bool ProgramExists(int key)
        {
            return context.Programs.Any(a => a.ProgramId == key);
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

        //CRUD
        //GET
        [EnableQuery]
        public IQueryable<Program> Get()
        {
            return context.Programs;
        }
        [EnableQuery]
        public SingleResult<Program> Get([FromODataUri] int key)
        {
            IQueryable<Program> result = context.Programs.Where(a => a.ProgramId == key);
            return SingleResult.Create(result);
        }

        //POST
        public async Task<IHttpActionResult> Post(Program Program)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Programs.Add(Program);
            await context.SaveChangesAsync();
            return Created(Program);
        }

        //UPDATE

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Program> Program)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await context.Programs.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            Program.Patch(entity);
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
            var Program = await context.Programs.FindAsync(key);
            if (Program == null)
            {
                return NotFound();
            }
            context.Programs.Remove(Program);
            await context.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}