using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sport.Models.Entities;
using Sport.Services.Interfaces;
using Swashbuckle.Swagger.Annotations;
using System.Security.Claims;
using Sport.API.Filters;
using Sport.Models.DTOModels.Articles;
using Sport.Services.Services;

namespace Sport.API.Controllers
{
    [Route("likes")]
    [ApiController]
    [CustomExceptionFilter]
    public class LikesController : ControllerBase
    {
        private readonly ILikesService _likesService;

        public LikesController(ILikesService likesService)
        {
            _likesService = likesService;
        }

        /// <summary>
        /// Add like info for article
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        [HttpPost()]
        [SwaggerResponse(200, "Request_Succeeded")]
        [RoleAuthorization(UserRoles.SuperAdmin, UserRoles.Author, UserRoles.User)]
        public async Task<IActionResult> AddLike([FromQuery] string articleId)
        {
            var authorId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            await _likesService.AddLikeInfo(articleId, authorId);
            return Ok();
        }

        /// <summary>
        /// Remove like info from article
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        [HttpDelete()]
        [SwaggerResponse(200, "Request_Succeeded")]
        [RoleAuthorization(UserRoles.SuperAdmin, UserRoles.Author, UserRoles.User)]
        public async Task<IActionResult> RemoveLike([FromQuery] string articleId)
        {
            var authorId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            await _likesService.RemoveLikeInfo(articleId, authorId);
            return Ok();
        }

        /// <summary>
        /// Get Id of articles, liked by user
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [SwaggerResponse(200, "Request_Succeeded", typeof(HashSet<string>))]
        [RoleAuthorization(UserRoles.SuperAdmin, UserRoles.Author, UserRoles.User)]
        public async Task<IActionResult> GetLikesInfo()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var list = await _likesService.GetLikeInfo(userId);
            return Ok(list);
        }

        /// <summary>
        /// Get amount of likes
        /// </summary>
        /// <returns></returns>
        [HttpGet("count")]
        [SwaggerResponse(200, "Request_Succeeded", typeof(int))]
        public async Task<IActionResult> GetLikesCounter([FromQuery] string articleId)
        {
            var count = await _likesService.GetLikeCount(articleId);
            return Ok(count);
        }
    }
}
