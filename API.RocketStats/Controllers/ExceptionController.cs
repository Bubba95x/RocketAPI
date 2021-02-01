using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace API.RocketStats.Controllers
{
    [ApiController]
    public class ExceptionController : ControllerBase
    {
        public ExceptionController()
        {

        }

        [HttpGet("error")]
        public IActionResult Error() {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            var ex = context.Error.InnerException;

            return Problem(
                detail: "Rykey",
                title: "living",
                statusCode: 404);
        }
    }
}
