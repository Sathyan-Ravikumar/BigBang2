using AngularWithAPI.Data;
using AngularWithAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;

namespace AngularWithAPI.Repository.Tables.DoctorDetailsTable
{
    public class DoctorDetailsService : IDoctorDetails
    {
        private readonly DoctorBookingContext? _dbcontext;
        public DoctorDetailsService(DoctorBookingContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IEnumerable<DoctorDetail>> GetDoctorDetails()
        {
            return await _dbcontext.DoctorDetails.ToListAsync();
        }
        public async Task<DoctorDetail> GetDoctorDetail(string doctorName)
        {
            var doc = await _dbcontext.DoctorDetails.FirstOrDefaultAsync(d => d.DoctorName==doctorName);
            return doc;
        }
        public async Task<List<DoctorDetail>> PutDoctorDetail(int doctorid, DoctorDetail doctorDetail)
        {
            var doc = await _dbcontext.DoctorDetails.FirstOrDefaultAsync(x=>x.Doctorid==doctorid);

            doc.Experience = doctorDetail.Experience;
            doc.Email = doctorDetail.Email;
            doc.ContactNumber = doctorDetail.ContactNumber;
            _dbcontext.SaveChanges();
            /*            if (doc == null)
                        {
                            throw new ArithmeticException("No Data Found or Updated");
                        }*/

            /*await _dbcontext.SaveChangesAsync();*/
            return await _dbcontext.DoctorDetails.ToListAsync();

        }
        public async Task<List<DoctorDetail>> PostDoctorDetail(DoctorDetail doctorDetail)
        {
            var doc = await _dbcontext.DoctorDetails.AddAsync(doctorDetail);
            if (doc == null)
            {
                throw new ArithmeticException("Data Not Added");
            }
            await _dbcontext.SaveChangesAsync();
            return await _dbcontext.DoctorDetails.ToListAsync();
        }
        public async Task<List<DoctorDetail>> DeleteDoctorDetail(int id)
        {
            var doc = await _dbcontext.DoctorDetails.FindAsync(id);
            _dbcontext.DoctorDetails.Remove(doc);
            if (doc == null)
            {
                throw new ArithmeticException("Data is not deleted");
            }
            await _dbcontext.SaveChangesAsync();
            return await _dbcontext.DoctorDetails.ToListAsync();
        }


      
    }
}
