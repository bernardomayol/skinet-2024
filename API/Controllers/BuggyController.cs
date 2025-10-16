using API.DTOs;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        [HttpGet("unauthorized")]
        public ActionResult GetUnauthorized()
        {
            return Unauthorized(); // 401
        }
        [HttpGet("notfound")]
        public ActionResult GetNotFound()
        {
            return NotFound(); // 404

        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest("This is a bad request"); // 400           
        }
        [HttpGet("internalerror")]
        public ActionResult GetInternalError()
        {
            throw new Exception("This is an internal error"); // 500
        }
        [HttpPost("validationerror")]
        public ActionResult GetValidationError(CreateProductDto product)
        {
            return Ok();
        } 

    }
}