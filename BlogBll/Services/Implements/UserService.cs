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
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IConfiguration _configuration;
        private IMapper _mapper;
        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<string> Authenticate(LoginRequest authenticateRequest)
        {
            var user = await _userManager.FindByNameAsync(authenticateRequest.Username);
            if (user == null)
                return null;

            var result = await _signInManager.PasswordSignInAsync(user, authenticateRequest.Password, authenticateRequest.Remember, false);

            if (!result.Succeeded)
                return null;

            await _userManager.AddToRolesAsync(user, new[] { "Member" });

            Claim[] claims = await GetClaim(user);

            return GetToken(claims);
        }

        public async Task<bool> Register(RegisterRequest registerRequest)
        {
            var user = _mapper.Map<User>(registerRequest);

            var result = await _userManager.CreateAsync(user, registerRequest.Password);

            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }

        private async Task<Claim[]> GetClaim(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
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
