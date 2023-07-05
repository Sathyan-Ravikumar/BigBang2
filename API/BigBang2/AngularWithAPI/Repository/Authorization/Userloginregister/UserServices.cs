using AngularWithAPI.Data;
using AngularWithAPI.Models;
using AngularWithAPI.Models.DTO;
using AngularWithAPI.Repository.Authorization.Token;
using AngularWithAPI.Repository.Authorization.Userfolder;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace AngularWithAPI.Repository.Authorization.Userloginregister
{
    public class UserServices :IUserservice
    {
        private readonly IUser _userRepo;
        private readonly IToken _tokenService;
    
        private static List<RegisterationDTO> doctorList = new List<RegisterationDTO>();


        public UserServices(IUser userRepo, IToken tokenService)
        {
            _userRepo = userRepo;
            _tokenService = tokenService;
          

        }
        
        public async Task<UserDTO> LogIN(UserDTO userDTO)
        {
            UserDTO user = null;
            var userData = await _userRepo.Get(userDTO);
            if (userData != null)
            {
                var hmac = new HMACSHA512(userData.Hashkey);
                var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                for (int i = 0; i < userPass.Length; i++)
                {
                    if (userPass[i] != userData.Password[i])
                        return null;
                }
                user = new UserDTO();
                user.userid = userData.Userid;
                user.UserName = userData.Username;
                user.Role = userData.Role;
                user.Token = _tokenService.GenerateToken(user);
            }
            return user;
        }

        public async Task<UserDTO> Register(RegisterationDTO userRegisterDTO)
        {
            UserDTO user = null;
            RegisterationDTO userToDelete = doctorList.Find(user => user.Username == userRegisterDTO.Username);
            if (userToDelete != null)
            {
                // Remove the object from the list
                doctorList.Remove(userToDelete);
            }
            using (var hmac = new HMACSHA512())
            {
                userRegisterDTO.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDTO.UserPassword));
                userRegisterDTO.Hashkey = hmac.Key;
                var resultUser = await _userRepo.Add(userRegisterDTO);
                if (resultUser != null)
                {
                    user = new UserDTO();
                    user.UserName = resultUser.Username;
                    user.Role = resultUser.Role;
                    user.Token = _tokenService.GenerateToken(user);
                }
            }
            return user;
        }

        public async Task<RegisterationDTO?> doctorRegister(RegisterationDTO userRegisterDTO, DoctorDetailsDTO doctorDTO)
        {
            var users = await _userRepo.GetAll();
            var newstaff = users.SingleOrDefault(u => u.Username == userRegisterDTO.Username);
            RegisterationDTO desiredUser = doctorList.SingleOrDefault(u => u.Username == userRegisterDTO.Username);
            if (newstaff == null && desiredUser == null)
            {

                RegisterationDTO user1 = new RegisterationDTO();
               
                user1.Email = userRegisterDTO.Email;
                user1.Username = userRegisterDTO.Username;


                user1.Role = userRegisterDTO.Role;
                user1.UserPassword= userRegisterDTO.UserPassword;

                doctorList.Add(userRegisterDTO);
                doctorDTO.get(doctorDTO);





                return userRegisterDTO;
            }


            return null;

        }
        public async Task<RegisterationDTO?> deletedoctorinlist(RegisterationDTO userRegisterDTO)
        {
            RegisterationDTO userToDelete =  doctorList.Find(user => user.Username == userRegisterDTO.Username);
            if (userToDelete != null)
            {
                // Remove the object from the list
                doctorList.Remove(userToDelete);
                return userRegisterDTO;
            }

            return null;
        }

        public async Task<List<RegisterationDTO>> View_All_doctorRequest(DoctorDetailsDTO doctorDTO)
        {
            /* var obj = doctorDTO.GetDoctorList();
             List<UserRegisterDTO> retrievedList = obj.;
             if (retrievedList == null)
             {
                 return null;
             }
             return retrievedList;*/

            if (doctorList == null)
            {
                return null;
            }
            return doctorList;


        }



        public async Task<UserDTO> Update(RegisterationDTO user)
        {
            var users = await _userRepo.GetAll();
            User myUser = users.SingleOrDefault(u => u.Username == user.Username);
            if (myUser != null)
            {
               /* myUser.Name = user.Name;*/


                var hmac = new HMACSHA512();
                myUser.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.UserPassword));
                myUser.Hashkey = hmac.Key;
                myUser.Role = user.Role;
                myUser.Email = user.Email;
                UserDTO userDTO = new UserDTO();
                userDTO.UserName = myUser.Username;
                userDTO.Role = myUser.Role;
                userDTO.Token = _tokenService.GenerateToken(userDTO);
                var newUser = _userRepo.Update(myUser);
                if (newUser != null)
                {
                    return userDTO;
                }
                return null;
            }
            return null;
        }

        public async Task<bool> Update_Password(UserDTO userDTO)
        {
            User user = new User();
            var users = await _userRepo.GetAll();
            var myUser = users.SingleOrDefault(u => u.Username == userDTO.UserName);
            if (myUser != null)
            {
                var hmac = new HMACSHA512();
                user.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                user.Hashkey = hmac.Key;
                /*user.Name = myUser.Name;*/
                user.Role = myUser.Role;


                user.Email = myUser.Email;
                var newUser = _userRepo.Update(user);
                if (newUser != null)
                {
                    return true;
                }
            }
            return false;
        }
        

    }
}

