using AutoMapper;
using BlogBLL.ModelRequest;
using BlogBLL.ModelRequest.Comment;
using BlogBLL.ModelRequest.Post;
using BlogBLL.Utility.Common;
using BlogDAL.Models;
using System;

namespace BlogServer.Configuration
{
    public class AutoMapperProfile : Profile
    {
        //private IStorageService _storageService;
        public AutoMapperProfile()
        {
            //_storageService = storageService ?? throw new ArgumentNullException(nameof(storageService));
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
            CreateMap<UserRequest, AppUser>();
            CreateMap<LoginRequest, AppUser>();
            CreateMap<RegisterRequest, AppUser>();
            CreateMap<UpdateUserRequest, AppUser>();
        }
    }
}
