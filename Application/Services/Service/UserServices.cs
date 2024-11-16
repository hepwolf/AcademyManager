using AcademyManager.Application.DTO;
using AcademyManager.Application.Validators;
using AcademyManager.Domain.Entities;
using AcademyManager.Domain.Repositories.CommandRepositories;
using AcademyManager.Domain.Repositories.QueryRepositories;
using Chessie.ErrorHandling;
using System.Security.Cryptography;
using System.Text;

namespace AcademyManager.Application.Services.Service
{
    public class UserServices:IUserServices
    {
        private readonly IUserCommandRepository _userCommandRepository;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
       
        public UserServices(IUserCommandRepository userCommandRepository, 
            IUserQueryRepository userQueryRepository, IJwtTokenGenerator
            jwtTokenGenerator
            )
        {
            _userCommandRepository = userCommandRepository;
            _userQueryRepository = userQueryRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }


        public async Task<UserAccount> RegisterUserAsync(RegisterUserDto registerDto)
        {

            if (await _userQueryRepository.GetUserByEmailAsync(registerDto.Email) != null ||
                await _userQueryRepository.GetUserByUsernameAsync(registerDto.UserName) != null)
            {
                return null;
            }

            string salt = GenerateSalt();

            var hashedpassword = HashPasswordWithSalt(registerDto.Password, salt);


            var user = new UserAccount
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                Password = hashedpassword,
                Salt = GenerateSalt(),
                UserRoles = new List<UserRole>()
            };

            await _userCommandRepository.AddUserAsync(user);
            await _userCommandRepository.SaveChangesAsync();

            return user;
        }

        public async Task<string> LoginUserAsync(LoginUserDto loginDto)
        {
            var user = await _userQueryRepository.GetUserByUsernameAsync(loginDto.UserName);

            if (user == null || !VerifyPassword(user.Password, loginDto.Password, user.Salt))
            {
                return null;
            }

            // Generate JWT Token
            var token = await _jwtTokenGenerator.GenerateTokenAsync(user);

            var userTkoken = new UserToken()
            {
                UserId = user.Id,
                Token = token,
                Expiration = DateTime.UtcNow.AddMinutes(60),
            };
            await _userCommandRepository.AddUserTokenAsync(userTkoken);
            await _userCommandRepository.SaveChangesAsync();
            return token;
        }

        private string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        private bool VerifyPassword(string hashedPassword, string inputPassword, string salt)
        {
            var hashedInputPassword = HashPasswordWithSalt(inputPassword, salt);
            return hashedPassword == hashedInputPassword;
        }

        private string HashPasswordWithSalt(string password, string salt)
        {
            var combinedpassword = password + salt;


            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combinedpassword));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}
