
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
using AngularWithAPI.Repository.Tables.AppointmentTable;

namespace AngularWithAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointment _context;

        public AppointmentsController(IAppointment context)
        {
            _context = context;
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<List<Appointment>>> GetAppointments()
        {
            try
            {
                return Ok(await _context.GetAppointments());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            try
            {
                return Ok(await _context.GetAppointment(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<List<Appointment>>> PostAppointment(Appointment appointment)
        {
            try

            {
                return Ok(await _context.PostAppointment(appointment));
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("Get_Appointment_Details_For_Particular_Doctor")]
        public async Task<ActionResult<List<Appointment>>> GetDoctorDetails(int doctorid)
        {
            try

            {
                return Ok(await _context.GetDoctorDetails(doctorid));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

      
    }
}
