using AngularWithAPI.Models.DTO;

namespace AngularWithAPI.Repository.Authorization.Token
{
    public interface IToken
    {
        public string GenerateToken(UserDTO user);
    }
}
