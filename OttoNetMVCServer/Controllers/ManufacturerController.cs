using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OttoNetMVCServer.DAL;

namespace OttoNetMVCServer.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly OttoDbContext _context;

        public ManufacturerController(OttoDbContext context)
        {
            this._context = context;
        }
        [Route("api/manufacturer")]
        [Authorize]   //Okta offers a similar set of attributes to either Authorize or AllowAnonymous
        public IActionResult Index()
        {
            var manufacturers = _context.Manufacturer.ToList();

            return Ok(manufacturers);
        }
    }
}
