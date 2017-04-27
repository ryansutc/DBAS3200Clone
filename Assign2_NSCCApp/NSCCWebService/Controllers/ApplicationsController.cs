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
    public class ApplicationsController : ODataController
    {
        NSCCDBContext context = new NSCCDBContext();

        private bool ApplicationExists(int key)
        {
            return context.Applications.Any(a => a.ApplicationId == key);
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

        //CRUD
        //GET
        [EnableQuery]
        public IQueryable<Application> Get()
        {
            return context.Applications;
        }
        [EnableQuery]
        public SingleResult<Application> Get([FromODataUri] int key)
        {
            IQueryable<Application> result = context.Applications.Where(a => a.ApplicationId == key);
            return SingleResult.Create(result);
        }

        //POST
        public async Task<IHttpActionResult> Post(Application Application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Applications.Add(Application);
            await context.SaveChangesAsync();
            return Created(Application);
        }

        //UPDATE

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Application> Application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await context.Applications.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            Application.Patch(entity);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationExists(key))
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
            var Application = await context.Applications.FindAsync(key);
            if (Application == null)
            {
                return NotFound();
            }
            context.Applications.Remove(Application);
            await context.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}