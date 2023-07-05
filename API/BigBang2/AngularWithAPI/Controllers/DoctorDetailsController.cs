using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularWithAPI.Data;
using AngularWithAPI.Models;
using AngularWithAPI.Repository.Tables.DoctorDetailsTable;

namespace AngularWithAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorDetailsController : ControllerBase
    {
        private readonly IDoctorDetails _context;

        public DoctorDetailsController(IDoctorDetails context)
        {
            _context = context;
        }

        // GET: api/DoctorDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDetail>>> GetDoctorDetails()
        {
            try
            {
                return Ok(await _context.GetDoctorDetails());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/DoctorDetails/5
        [HttpGet("doctorname")]
        public async Task<ActionResult<DoctorDetail>> GetDoctorDetail(string doctorName)
        {
            try
            {
                return Ok(await _context.GetDoctorDetail(doctorName));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/DoctorDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("doctorname")]
        public async Task<ActionResult<List<DoctorDetail>>> PutDoctorDetail(int doctorid, DoctorDetail doctorDetail)
        {

            try
            {
                return Ok(await _context.PutDoctorDetail(doctorid, doctorDetail));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        // POST: api/DoctorDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<List<DoctorDetail>>> PostDoctorDetail(DoctorDetail doctorDetail)
        {
            try
            {
                return Ok(await _context.PostDoctorDetail(doctorDetail));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }


        }

        // DELETE: api/DoctorDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<DoctorDetail>>> DeleteDoctorDetail(int id)
        {
            try
            {
                return Ok(await _context.DeleteDoctorDetail(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

       

    }
}
