using AngularWithAPI.Models.DTO;
using AngularWithAPI.Models;

namespace AngularWithAPI.Repository.Authorization.Userfolder
{
    public interface IUser
    {
        Task<User> Add(User user);
        Task<User> Update(User user);
        User Delete(UserDTO userDTO);
        Task<User> Get(UserDTO userDTO);
        Task<List<User>?> GetAll();
    }
}
