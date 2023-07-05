
using AngularWithAPI.Data;
using AngularWithAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularWithAPI.Repository.Tables.AppointmentTable
{
    public class AppointmentService : IAppointment
    {
        private readonly DoctorBookingContext? _dbcontext;
        public AppointmentService(DoctorBookingContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async  Task<List<Appointment>> GetAppointments()
        {
            return await _dbcontext.Appointments.ToListAsync();
        }
        public async Task<Appointment> GetAppointment(int id)
        {
            var doc = await _dbcontext.Appointments.FindAsync(id);
            if (doc == null)
            {
                throw new ArithmeticException("No Data available");
            }
            return doc;
        }
        public async Task<List<Appointment>> PostAppointment(Appointment appointment)
        {
            var doc = await _dbcontext.Appointments.AddAsync(appointment);
            if (doc == null)
            {
                throw new ArithmeticException("Data Not Added");
            }
            await _dbcontext.SaveChangesAsync();
            return await _dbcontext.Appointments.ToListAsync();
        }
        public async Task<List<Appointment>> GetDoctorDetails(int doctorid)
        {
            var doc = await _dbcontext.Appointments.Where(a => a.Doctorid == doctorid).ToListAsync();
            return doc;
        }



    }
}
