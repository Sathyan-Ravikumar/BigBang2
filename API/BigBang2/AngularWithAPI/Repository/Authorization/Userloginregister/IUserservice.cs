using AngularWithAPI.Models;
using AngularWithAPI.Models.DTO;

namespace AngularWithAPI.Repository.Authorization.Userloginregister
{
    public interface IUserservice
    {
        Task<UserDTO> Register(RegisterationDTO userRegisterDTO);
        Task<UserDTO> LogIN(UserDTO userDTO);
        Task<UserDTO> Update(RegisterationDTO user);
        Task<bool> Update_Password(UserDTO userRegisterDTO);

        Task<RegisterationDTO?> doctorRegister(RegisterationDTO userRegisterDTO, DoctorDetailsDTO doctorDTO);

        Task<List<RegisterationDTO>> View_All_doctorRequest(DoctorDetailsDTO doctorDTO);
        Task<RegisterationDTO?> deletedoctorinlist(RegisterationDTO userRegisterDTO);
       
    }
}
