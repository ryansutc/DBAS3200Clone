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
    public class ApplicantsController : ODataController
    {
        NSCCDBContext context = new NSCCDBContext();
        
        private bool ApplicantExists(int key)
        {
            return context.Applicants.Any(a => a.ApplicantId == key);
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

        //CRUD
        //GET
        [EnableQuery]
        public IQueryable<Applicant> Get()
        {
            return context.Applicants;
        }
        [EnableQuery]
        public SingleResult<Applicant> Get([FromODataUri] int key)
        {
            IQueryable<Applicant> result = context.Applicants.Where(a => a.ApplicantId == key);
            return SingleResult.Create(result);
        }

        //POST
        public async Task<IHttpActionResult> Post(Applicant applicant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Applicants.Add(applicant);
            await context.SaveChangesAsync();
            return Created(applicant);
        }

        //UPDATE

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Applicant> applicant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await context.Applicants.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            applicant.Patch(entity);
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
            var applicant = await context.Applicants.FindAsync(key);
            if (applicant == null)
            {
                return NotFound();
            }
            context.Applicants.Remove(applicant);
            await context.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}