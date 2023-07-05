using AngularWithAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularWithAPI.Repository.Tables.AppointmentTable
{
    public interface IAppointment
    {
        public  Task<List<Appointment>> GetAppointments();
        public Task<Appointment> GetAppointment(int id);
        public Task<List<Appointment>> PostAppointment(Appointment appointment);
        public Task<List<Appointment>> GetDoctorDetails(int doctorid);

    }
}
