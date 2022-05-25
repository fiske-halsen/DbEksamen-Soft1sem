using Common.ErrorHandling;
using PostgresAPI.DTO;
using PostgresAPI.Repository;

namespace PostgresAPI.Services
{
    public class UserService
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

            if (!registerUserDTO.Equals(confirmPassword))
            {
                throw new HttpStatusException(StatusCodes.Status400BadRequest, "Passwords not matching..");
            }

            return await _userRepository.Register(registerUserDTO);
        }

    }
}
