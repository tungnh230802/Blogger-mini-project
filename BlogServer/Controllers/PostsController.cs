using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogDAL.Models;
using BlogBLL.Services.Interfaces;
using BlogBLL.ModelRequest;
using Microsoft.Extensions.Logging;
using AutoMapper;
using System;
using BlogBLL.ModelRequest.Post;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using BlogBLL;
using BlogBLL.Utility.Common;

namespace BlogServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PostsController : ControllerBase
    {
        #region Properties
        private readonly IPostService _postService;
        private readonly ILogger<PostsController> _logger;
        private readonly IMapper _mapper;
        private readonly IStorageService _storageService;
        #endregion

        #region  Constructor
        public PostsController(IPostService postService, ILogger<PostsController> logger, IMapper mapper, IStorageService storageService)
        {
            _postService = postService ?? throw new ArgumentNullException(nameof(postService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _storageService = storageService ?? throw new ArgumentNullException(nameof(storageService));
        }
        #endregion

        #region Method
        // GET: api/Posts
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            try
            {
                var posts = await _postService.GetAll();
                _logger.LogInformation($"Returned all posts from database.");

                var postsRequest = _mapper.Map<IEnumerable<PostRequest>>(posts);
                return Ok(new Response<IEnumerable<PostRequest>>(postsRequest,""));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllPost action: {ex.Message}");
                return StatusCode(500, new Response<PostRequest>("Internal server error"));
            }
        }

        // GET: api/Posts/5
        [HttpGet("{id}", Name = "GetPost")]
        public async Task<IActionResult> GetPost([FromQuery]Guid id)
        {
            try
            {
                var post = await _postService.GetById(id);
                _logger.LogInformation($"Returned post from database.");

                var postRequest = _mapper.Map<PostRequest>(post);
                return Ok(new Response<PostRequest>(postRequest));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetByIdPost action: {ex.Message}");
                return StatusCode(500, new Response<PostRequest>("Internal server error"));
            }
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost([FromForm]Guid id, [FromForm]PostPutRequest postPutRequest)
        {
            try
            {
                if (postPutRequest is null)
                {
                    _logger.LogError("Post object sent from client is null.");
                    return BadRequest(new Response<PostRequest>("Post object is null"));
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest(new Response<PostRequest>("Invalid model object"));
                }
                var post = await _postService.GetById(id);
                if (post is null)
                {
                    _logger.LogError($"post with id: {id}, hasn't been found in db.");
                    return NotFound(new Response<PostRequest>("Not found"));
                }

                _mapper.Map(postPutRequest, post);
                post.thumbnail = await _storageService.SaveFile(postPutRequest.thumbnail);
                await _postService.Update(post);

                return Ok(new Response<PostRequest>());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Update post action: {ex.Message}");
                return StatusCode(500, new Response<PostRequest>("Internal server error"));
            }
        }

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost([FromForm]PostCreateRequest postCreateRequest)
        {
            try
            {
                if (postCreateRequest is null)
                {
                    _logger.LogError("post object sent from client is null.");
                    return BadRequest(new Response<PostRequest>("postRequest object is null"));
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid post object sent from client.");
                    return BadRequest(new Response<PostRequest>("Invalid model object"));
                }
                var post = _mapper.Map<Post>(postCreateRequest);
                post.thumbnail = await _storageService.SaveFile(postCreateRequest.thumbnail);

                await _postService.Create(post);

                var postRequest = _mapper.Map<PostRequest>(post);

                return CreatedAtRoute("GetPost", new { id = postRequest.id },new Response<PostRequest>(postRequest));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreatePost action: {ex.Message}");
                return StatusCode(500, new Response<PostRequest>("Internal server error"));
            }
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost([FromQuery] Guid id)
        {
            try
            {
                var post = await _postService.GetById(id);
                if (post == null)
                {
                    _logger.LogError($"post with id: {id}, hasn't been found in db.");
                    return NotFound(new Response<PostRequest>("Not found"));
                }
                await _postService.Delete(post);
                return Ok(new Response<PostRequest>());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Delete post action: {ex.Message}");
                return StatusCode(500, new Response<PostRequest>("Internal server error"));
            }
        }
        #endregion
    }
}
