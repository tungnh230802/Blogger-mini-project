using BlogBLL.ModelRequest;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlogBLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> Authenticate(LoginRequest authenticateRequest);
        Task<bool> Register(RegisterRequest registerRequest);
    }
}
