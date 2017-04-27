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
    public class CitizenshipsController : ODataController
    {
        NSCCDBContext context = new NSCCDBContext();
        
        private bool CitizenshipExists(int key)
        {
            return context.Citizenships.Any(a => a.CitizenshipId == key);
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

        //CRUD
        //GET
        [EnableQuery]
        public IQueryable<Citizenship> Get()
        {
            return context.Citizenships;
        }
        [EnableQuery]
        public SingleResult<Citizenship> Get([FromODataUri] int key)
        {
            IQueryable<Citizenship> result = context.Citizenships.Where(a => a.CitizenshipId == key);
            return SingleResult.Create(result);
        }

        //POST
        public async Task<IHttpActionResult> Post(Citizenship Citizenship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Citizenships.Add(Citizenship);
            await context.SaveChangesAsync();
            return Created(Citizenship);
        }

        //UPDATE

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Citizenship> Citizenship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await context.Citizenships.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            Citizenship.Patch(entity);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitizenshipExists(key))
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
            var Citizenship = await context.Citizenships.FindAsync(key);
            if (Citizenship == null)
            {
                return NotFound();
            }
            context.Citizenships.Remove(Citizenship);
            await context.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}