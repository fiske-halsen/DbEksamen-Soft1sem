using Common.ErrorHandling;
using Common.Models;
using PostgresAPI.Repository;

namespace PostgresAPI.Services
{
    public interface IUserService
    {
        public Task<Response> Register(RegisterUserDTO registerUserDTO);
    }
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }
        public async Task<Response> Register(RegisterUserDTO registerUserDTO)
        {
            var password = registerUserDTO.Password;
            var confirmPassword = registerUserDTO.PasswordRepeated;

            var user = await _userRepository.GetUserByEmail(registerUserDTO.Email);

            if (user != null)
            {
                throw new HttpStatusException(StatusCodes.Status400BadRequest, "User with the givne email already exists");
            }

            if (!password.Equals(confirmPassword))
            {
                throw new HttpStatusException(StatusCodes.Status400BadRequest, "Passwords not matching..");
            }

            return await _userRepository.Register(registerUserDTO);
        }

    }
}
