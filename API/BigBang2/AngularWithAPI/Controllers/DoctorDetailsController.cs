using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularWithAPI.Data;
using AngularWithAPI.Models;

namespace AngularWithAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorDetailsController : ControllerBase
    {
        private readonly DoctorBookingContext _context;

        public DoctorDetailsController(DoctorBookingContext context)
        {
            _context = context;
        }

        // GET: api/DoctorDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDetail>>> GetDoctorDetails()
        {
          if (_context.DoctorDetails == null)
          {
              return NotFound();
          }
            return await _context.DoctorDetails.ToListAsync();
        }

        // GET: api/DoctorDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDetail>> GetDoctorDetail(int id)
        {
          if (_context.DoctorDetails == null)
          {
              return NotFound();
          }
            var doctorDetail = await _context.DoctorDetails.FindAsync(id);

            if (doctorDetail == null)
            {
                return NotFound();
            }

            return doctorDetail;
        }

        // PUT: api/DoctorDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctorDetail(int id, DoctorDetail doctorDetail)
        {
            if (id != doctorDetail.Doctorid)
            {
                return BadRequest();
            }

            _context.Entry(doctorDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DoctorDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DoctorDetail>> PostDoctorDetail(DoctorDetail doctorDetail)
        {
          if (_context.DoctorDetails == null)
          {
              return Problem("Entity set 'DoctorBookingContext.DoctorDetails'  is null.");
          }
            _context.DoctorDetails.Add(doctorDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctorDetail", new { id = doctorDetail.Doctorid }, doctorDetail);
        }

        // DELETE: api/DoctorDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctorDetail(int id)
        {
            if (_context.DoctorDetails == null)
            {
                return NotFound();
            }
            var doctorDetail = await _context.DoctorDetails.FindAsync(id);
            if (doctorDetail == null)
            {
                return NotFound();
            }

            _context.DoctorDetails.Remove(doctorDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoctorDetailExists(int id)
        {
            return (_context.DoctorDetails?.Any(e => e.Doctorid == id)).GetValueOrDefault();
        }
    }
}
