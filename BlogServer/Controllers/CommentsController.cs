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
            _commentService = commentService;
            _logger = logger;
            _mapper = mapper;
        }
        #endregion

        #region Method
        // GET: api/Comments
        [HttpGet]
        public async Task<IActionResult> GetComments(int idPost)
        {
            try
            {
                var comments = await _commentService.GetAll(idPost);
                _logger.LogInformation($"Returned all comments of post id:{idPost} from database.");

                var commentsRequest = _mapper.Map<IEnumerable<CommentRequest>>(comments);
                return Ok(commentsRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllComment of post id:{idPost} action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/Comments/5
        [HttpGet("{id}", Name = "GetComment")]
        public async Task<IActionResult> GetComment(int id)
        {
            try
            {
                var comment = await _commentService.GetById(id);
                _logger.LogInformation($"Returned comment from database.");

                var commentRequest = _mapper.Map<CommentRequest>(comment);
                return Ok(commentRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetByIdComment action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/Comments/5
        // To protect from overcommenting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, CommentPutRequest commentPutRequest)
        {
            try
            {
                if (commentPutRequest is null)
                {
                    _logger.LogError("Comment object sent from client is null.");
                    return BadRequest("Comment object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var comment = await _commentService.GetById(id);
                if (comment is null)
                {
                    _logger.LogError($"comment with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(commentPutRequest, comment);
                await _commentService.Update(comment);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Update comment action: {ex.Message}");
                return StatusCode(500, "Internal server error");
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
                    return BadRequest("commentRequest object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid comment object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var comment = _mapper.Map<Comment>(commentCreateRequest);

                await _commentService.Create(comment);

                var commentRequest = _mapper.Map<CommentRequest>(comment);

                return CreatedAtRoute("GetComment", new { id = commentRequest.id }, commentRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateComment action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            try
            {
                var comment = await _commentService.GetById(id);
                if (comment == null)
                {
                    _logger.LogError($"comment with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                await _commentService.Delete(comment);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Delete comment action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion
    }
}
