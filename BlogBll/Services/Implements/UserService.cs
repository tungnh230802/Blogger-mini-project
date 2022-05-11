using AutoMapper;
using BlogBLL.ModelRequest;
using BlogBLL.Services.Interfaces;
using BlogDAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogBLL.Services
{
    public class UserService : IUserService
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private IConfiguration _configuration;
        private IMapper _mapper;
        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration, IMapper mapper)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<string> Authenticate(LoginRequest authenticateRequest)
        {
            if (authenticateRequest == null) throw new ArgumentNullException(nameof(authenticateRequest));

            try
            {
                var user = await _userManager.FindByNameAsync(authenticateRequest.Username);
                if (user == null)
                    throw new Exception("Can't find user");

                var result = await _signInManager.PasswordSignInAsync(user, authenticateRequest.Password, authenticateRequest.Remember, false);

                if (!result.Succeeded)
                    return null;

                Claim[] claims = await GetClaim(user);

                return GetToken(claims);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Register(RegisterRequest registerRequest)
        {
            if (registerRequest == null) throw new ArgumentNullException(nameof(registerRequest));

            try
            {
                var user = _mapper.Map<AppUser>(registerRequest);
                user.Id = Guid.NewGuid();

                var result = await _userManager.CreateAsync(user, registerRequest.Password);

                await _userManager.AddToRoleAsync(user, "member");

                if (result.Succeeded)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
        }

        private async Task<Claim[]> GetClaim(AppUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            if (roles == null) throw new Exception("Can't get role of user");

            var claims = new[]
            {
                //new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.UserName),
                new Claim(ClaimTypes.Role, string.Join(";",roles))
            };
            return claims;
        }

        private string GetToken(Claim[] claims)
        {
            string TokensKey = _configuration["Tokens:Key"];
            string TokenIssuer = _configuration["Tokens:Issuer"];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokensKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(TokenIssuer,
                TokensKey,
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
