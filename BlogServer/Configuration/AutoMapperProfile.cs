using AutoMapper;
using BlogBLL.ModelRequest;
using BlogBLL.ModelRequest.Comment;
using BlogBLL.ModelRequest.Post;
using BlogDAL.Models;

namespace BlogServer.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // post
            CreateMap<PostRequest, Post>();
            CreateMap<Post, PostRequest>();
            CreateMap<PostCreateRequest, Post>();
            CreateMap<PostPutRequest, Post>();

            // comment
            CreateMap<CommentRequest, Comment>();
            CreateMap<Comment, CommentRequest>();
            CreateMap<CommentCreateRequest, Comment>();
            CreateMap<CommentPutRequest, Comment>();

            // User
            CreateMap<UserRequest, User>();
            CreateMap<LoginRequest, User>();
            CreateMap<RegisterRequest, User>();
            CreateMap<UpdateUserRequest, User>();
        }
    }
}
