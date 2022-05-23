using PostgresAPI.DTO;

namespace PostgresAPI.Services
{
    public interface IUserService {
        public bool Login(LoginUserDTO loginUserDTO);
        public bool Register(RegisterUserDTO registerUserDTO);
    
    }
    public class UserService : IUserService
    {
        public bool Login(LoginUserDTO loginUserDTO)
        {
            throw new NotImplementedException();
        }

        public bool Register(RegisterUserDTO registerUserDTO)
        {
            throw new NotImplementedException();
        }
    }
}
