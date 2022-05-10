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
using BlogRepository.Interfaces;

namespace BlogServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostsController : ControllerBase
    {
        #region Properties
        private readonly IPostService _postService;
        private readonly ILogger<PostsController> _logger;
        private readonly IMapper _mapper;
        #endregion

        #region  Constructor
        public PostsController(IPostService postService, ILogger<PostsController> logger, IMapper mapper)
        {
            _postService = postService;
            _logger = logger;
            _mapper = mapper;
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
                return Ok(postsRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllPost action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/Posts/5
        [HttpGet("{id}", Name = "GetPost")]
        public async Task<IActionResult> GetPost(int id)
        {
            try
            {
                var post = await _postService.GetById(id);
                _logger.LogInformation($"Returned post from database.");

                var postRequest = _mapper.Map<PostRequest>(post);
                return Ok(postRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetByIdPost action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, PostPutRequest postPutRequest)
        {
            try
            {
                if (postPutRequest is null)
                {
                    _logger.LogError("Post object sent from client is null.");
                    return BadRequest("Post object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var post = await _postService.GetById(id);
                if (post is null)
                {
                    _logger.LogError($"post with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(postPutRequest, post);
                await _postService.Update(post);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Update post action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost(PostCreateRequest postCreateRequest)
        {
            try
            {
                if (postCreateRequest is null)
                {
                    _logger.LogError("post object sent from client is null.");
                    return BadRequest("postRequest object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid post object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var post = _mapper.Map<Post>(postCreateRequest);

                await _postService.Create(post);

                var postRequest = _mapper.Map<PostRequest>(post);

                return CreatedAtRoute("GetPost", new { id = postRequest.id }, postRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreatePost action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                var post = await _postService.GetById(id);
                if (post == null)
                {
                    _logger.LogError($"post with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                await _postService.Delete(post);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Delete post action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion
    }
}
