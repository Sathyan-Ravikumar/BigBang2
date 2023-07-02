namespace AngularWithAPI.Models.DTO
{
    public class DoctorDetailsDTO
    {
        public List<RegisterationDTO> doctorList { get; set; }
        public object? GlobalObject { get; set; }
        public DoctorDetailsDTO()
        {
            doctorList = new List<RegisterationDTO>();
        }
        /*public void AddStaff(RegisterationDTO staff)
        {
            staffList.Add(staff);
        }
        */
        public void get(DoctorDetailsDTO dto)
        {
            GlobalObject = dto;
        }
        public object GetDoctorList()
        {
            return GlobalObject;
        }
    }
}
