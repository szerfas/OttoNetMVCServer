using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OttoNetMVCServer.DAL;
using OttoNetMVCServer.Models.DBEntities;

namespace OttoNetMVCServer.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly OttoDbContext _context;

        public ManufacturerController(OttoDbContext context)
        {
            this._context = context;
        }
        [HttpGet("api/manufacturer")]
        [Authorize]   //Okta offers a similar set of attributes to either Authorize or AllowAnonymous
        public IActionResult getManufacturer()
        {
            var manufacturers = _context.Manufacturer.ToList();

            return Ok(manufacturers);
        }
        [HttpPost("api/manufacturer")]
        [Authorize]   //Okta offers a similar set of attributes to either Authorize or AllowAnonymous
        public IActionResult createManufacturer([FromBody] Manufacturer manufacturer)
        {
            var result = _context.Manufacturer.Add(manufacturer);
            _context.SaveChanges();
            return Ok(result.Entity);
        }

        [HttpDelete("api/manufacturer/{id:int}")]
        [Authorize]  //[Authorize(Roles = "Administrator")]
        public IActionResult deleteManufacturer(int id)
        {
            var manufacturerToDelete = _context.Manufacturer.Find(id);

            if (manufacturerToDelete == null)
            {
                return NotFound();
            }
            _context.Manufacturer.Remove(manufacturerToDelete);
            _context.SaveChanges();
            return Ok();
        }
    }
}
