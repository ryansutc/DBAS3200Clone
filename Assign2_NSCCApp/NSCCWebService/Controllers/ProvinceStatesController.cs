using NSCCModelDB;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace NSCCWebService.Controllers
{
    public class ProvinceStatesController : ODataController
    {
        NSCCDBContext context = new NSCCDBContext();
        
        //update for composite keys
        private bool ProvinceStateExists(string ProvinceStateCode, string CountryCode)
        {
            return context.ProvinceStates.Any(a => a.ProvinceStateCode == ProvinceStateCode && a.CountryCode == CountryCode);
        }
        
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

        //CRUD
        //GET
        [EnableQuery]
        public IQueryable<ProvinceState> Get()
        {
            return context.ProvinceStates;
        }
        
        [EnableQuery]
        // http://localhost:1690/ProvinceStates(ProvinceStateCode='AB',CountryCode='CA')
        [ODataRoute("ProvinceStates(ProvinceStateCode={psc},CountryCode={cc})")]
        public SingleResult<ProvinceState> Get([FromODataUri] string psc, [FromODataUri] string cc)
        {
            IQueryable<ProvinceState> result = context.ProvinceStates.Where(a => a.ProvinceStateCode == psc &&
                a.CountryCode == cc);
            return SingleResult.Create(result);
            //return Ok(new Stadium { Capacity = 2300, Country = country, Name = name, Owner = "FC Zug" });
        }
        

        //POST
        public async Task<IHttpActionResult> Post(ProvinceState ProvinceState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.ProvinceStates.Add(ProvinceState);
            await context.SaveChangesAsync();
            return Created(ProvinceState);
        }

        //UPDATE
        [ODataRoute("ProvinceStates(ProvinceStateCode={ProvinceStateCode},CountryCode={CountryCode})")]
        public async Task<IHttpActionResult> Patch([FromODataUri]  string ProvinceStateCode, [FromODataUri] string CountryCode,
            Delta<ProvinceState> ProvinceState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await context.ProvinceStates.FindAsync(ProvinceStateCode, CountryCode);
            if (entity == null)
            {
                return NotFound();
            }
            ProvinceState.Patch(entity);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvinceStateExists(ProvinceStateCode, CountryCode))
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
            var ProvinceState = await context.ProvinceStates.FindAsync(key);
            if (ProvinceState == null)
            {
                return NotFound();
            }
            context.ProvinceStates.Remove(ProvinceState);
            await context.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}