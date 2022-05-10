using BlogBLL.Services;
using BlogBLL.Services.Interfaces;
using BlogDAL.Models;
using BlogRepository;
using BlogRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogService.ExtensionMethod
{
    public static class ConfigDIServiceExtension
    {
        public static IServiceCollection AddConfigDI(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<BlogContext>(options =>
            {
                string ConnectString = config.GetConnectionString("BlogContext");
                options.UseSqlServer(ConnectString);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
