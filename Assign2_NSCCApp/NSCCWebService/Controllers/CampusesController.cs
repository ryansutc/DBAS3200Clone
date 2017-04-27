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
    public class CampusesController : ODataController
    {
        NSCCDBContext context = new NSCCDBContext();
        
        private bool CampusExists(int key)
        {
            return context.Campuses.Any(a => a.CampusId == key);
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

        //CRUD
        //GET
        [EnableQuery]
        public IQueryable<Campus> Get()
        {
            return context.Campuses;
        }
        [EnableQuery]
        public SingleResult<Campus> Get([FromODataUri] int key)
        {
            IQueryable<Campus> result = context.Campuses.Where(a => a.CampusId == key);
            return SingleResult.Create(result);
        }

        //POST
        public async Task<IHttpActionResult> Post(Campus Campus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Campuses.Add(Campus);
            await context.SaveChangesAsync();
            return Created(Campus);
        }

        //UPDATE

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Campus> Campus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await context.Campuses.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            Campus.Patch(entity);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampusExists(key))
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
            var Campus = await context.Campuses.FindAsync(key);
            if (Campus == null)
            {
                return NotFound();
            }
            context.Campuses.Remove(Campus);
            await context.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}