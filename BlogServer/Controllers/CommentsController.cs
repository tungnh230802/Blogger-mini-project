using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogDAL.Models;
using BlogBLL.Services.Interfaces;
using BlogBLL.ModelRequest;
using System;
using Microsoft.Extensions.Logging;
using AutoMapper;
using System.Collections.Generic;
using BlogBLL.ModelRequest.Comment;
using Microsoft.AspNetCore.Authorization;
using BlogBLL;

namespace BlogServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        #region Properties
        private readonly ICommentService _commentService;
        private readonly ILogger<CommentsController> _logger;
        private readonly IMapper _mapper;
        #endregion

        #region  Constructor
        public CommentsController(ICommentService commentService, ILogger<CommentsController> logger, IMapper mapper)
        {
            _commentService = commentService ?? throw new ArgumentNullException(nameof(commentService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion

        #region Method
        // GET: api/Comments
        [HttpGet]
        public async Task<IActionResult> GetComments(Guid idPost)
        {
            try
            {
                var comments = await _commentService.GetAll(idPost);
                _logger.LogInformation($"Returned all comments of post id:{idPost} from database.");

                var commentsRequest = _mapper.Map<IEnumerable<CommentRequest>>(comments);

                return Ok(new Response<IEnumerable<CommentRequest>>(commentsRequest));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllComment of post id:{idPost} action: {ex.Message}");

                return StatusCode(500, new Response<CommentRequest>("Internal server error: "));
            }
        }

        // GET: api/Comments/5
        [HttpGet("{id}", Name = "GetComment")]
        public async Task<IActionResult> GetComment(Guid id)
        {
            try
            {
                var comment = await _commentService.GetById(id);
                _logger.LogInformation($"Returned comment from database.");

                var commentRequest = _mapper.Map<CommentRequest>(comment);
                return Ok(new Response<CommentRequest>(commentRequest));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetByIdComment action: {ex.Message}");

                return StatusCode(500, new Response<CommentRequest>("Internal server error: "));
            }
        }

        // PUT: api/Comments/5
        // To protect from overcommenting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(Guid id, CommentPutRequest commentPutRequest)
        {
            try
            {
                if (commentPutRequest is null)
                {
                    _logger.LogError("Comment object sent from client is null.");
                    return BadRequest(new Response<CommentRequest>("Comment object is null"));
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest(new Response<CommentRequest>("Invalid model object"));
                }
                var comment = await _commentService.GetById(id);
                if (comment is null)
                {
                    _logger.LogError($"comment with id: {id}, hasn't been found in db.");
                    return NotFound(new Response<CommentRequest>("Not found"));
                }

                _mapper.Map(commentPutRequest, comment);
                await _commentService.Update(comment);

                return Ok(new Response<CommentRequest>());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Update comment action: {ex.Message}");
                return StatusCode(500, new Response<CommentRequest>("Internal server error: "));
            }
        }

        // POST: api/Comments
        // To protect from overcommenting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Comment>> CreateComment(CommentCreateRequest commentCreateRequest)
        {
            try
            {
                if (commentCreateRequest is null)
                {
                    _logger.LogError("comment object sent from client is null.");
                    return BadRequest(new Response<CommentRequest>("commentRequest object is null"));
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid comment object sent from client.");
                    return BadRequest(new Response<CommentRequest>("Invalid model object"));
                }
                var comment = _mapper.Map<Comment>(commentCreateRequest);

                await _commentService.Create(comment);

                var commentRequest = _mapper.Map<CommentRequest>(comment);

                return CreatedAtRoute("GetComment", new { id = commentRequest.id }, new Response<CommentRequest>(commentRequest));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateComment action: {ex.Message}");
                return StatusCode(500, new Response<CommentRequest>("Internal server error: "));
            }
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            try
            {
                var comment = await _commentService.GetById(id);
                if (comment == null)
                {
                    _logger.LogError($"comment with id: {id}, hasn't been found in db.");
                    return NotFound(new Response<CommentRequest>("Not found"));
                }
                await _commentService.Delete(comment);
                return Ok(new Response<CommentRequest>());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Delete comment action: {ex.Message}");
                return StatusCode(500, new Response<CommentRequest>("Internal server error"));
            }
        }
        #endregion
    }
}
