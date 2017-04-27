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
    public class CountriesController : ODataController
    {
        NSCCDBContext context = new NSCCDBContext();
        
        private bool CountryExists(string key)
        {
            return context.Countries.Any(a => a.CountryCode == key);
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

        //CRUD
        //GET
        [EnableQuery]
        public IQueryable<Country> Get()
        {
            return context.Countries;
        }
        [EnableQuery]
        public SingleResult<Country> Get([FromODataUri] string key)
        {
            IQueryable<Country> result = context.Countries.Where(a => a.CountryCode == key);
            return SingleResult.Create(result);
        }

        //POST
        public async Task<IHttpActionResult> Post(Country Country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Countries.Add(Country);
            await context.SaveChangesAsync();
            return Created(Country);
        }

        //UPDATE

        public async Task<IHttpActionResult> Patch([FromODataUri] string key, Delta<Country> Country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await context.Countries.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            Country.Patch(entity);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(key))
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

        public async Task<IHttpActionResult> Delete([FromODataUri] string key)
        {
            var Country = await context.Countries.FindAsync(key);
            if (Country == null)
            {
                return NotFound();
            }
            context.Countries.Remove(Country);
            await context.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}