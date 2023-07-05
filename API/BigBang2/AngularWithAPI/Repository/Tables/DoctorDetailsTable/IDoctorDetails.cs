using AngularWithAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularWithAPI.Repository.Tables.DoctorDetailsTable
{
    public interface IDoctorDetails
    {
        public  Task<IEnumerable<DoctorDetail>> GetDoctorDetails();
        public Task<DoctorDetail> GetDoctorDetail(string doctorName);
        public Task<List<DoctorDetail>> PutDoctorDetail(int doctorid, DoctorDetail doctorDetail);
        public Task<List<DoctorDetail>> PostDoctorDetail(DoctorDetail doctorDetail);

        public Task<List<DoctorDetail>> DeleteDoctorDetail(int id);


    }
}
