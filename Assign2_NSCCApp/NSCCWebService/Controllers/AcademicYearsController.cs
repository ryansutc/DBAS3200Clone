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
    public class AcademicYearsController : ODataController
    {
        NSCCDBContext context = new NSCCDBContext();

        private bool ApplicantExists(int key)
        {
            return context.AcademicYears.Any(a => a.AcademicYearId == key);
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

        //CRUD
        //GET
        [EnableQuery]
        public IQueryable<AcademicYear> Get()
        {
            return context.AcademicYears;
        }
        [EnableQuery]
        public SingleResult<AcademicYear> Get([FromODataUri] int key)
        {
            IQueryable<AcademicYear> result = context.AcademicYears.Where(a => a.AcademicYearId == key);
            return SingleResult.Create(result);
        }

        //POST
        public async Task<IHttpActionResult> Post(AcademicYear AcademicYear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.AcademicYears.Add(AcademicYear);
            await context.SaveChangesAsync();
            return Created(AcademicYear);
        }

        //UPDATE

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<AcademicYear> AcademicYear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await context.AcademicYears.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            AcademicYear.Patch(entity);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicantExists(key))
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
            var AcademicYear = await context.AcademicYears.FindAsync(key);
            if (AcademicYear == null)
            {
                return NotFound();
            }
            context.AcademicYears.Remove(AcademicYear);
            await context.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}