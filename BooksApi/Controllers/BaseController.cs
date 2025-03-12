﻿using Microsoft.AspNetCore.Mvc;

namespace booksAPI.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly ILogger<BaseController> _logger;
        protected readonly object recordNotFound = new
        {
            statusCode = 404,
            message = "Record not found"
        };
        protected readonly object unprocessableEntity = new
        {
            statusCode = 422,
            message = $"Invalid input data"
        };

        protected BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }

        protected async Task<IActionResult> ExceptionHandle(Func<Task<IActionResult>> function)
        {
            try
            {
                return await function();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "{Message}", new { exception.Message });

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    statusCode = 500,
                    message = exception.Message
                });
            }
        }

        protected IActionResult GetNotFoundResponse()
        {
            _logger.LogWarning("Record was not found by user. Response: {NotFoundInfo}", recordNotFound);
            return NotFound(recordNotFound);
        }

        protected IActionResult GetUnprocessableEntityResponse()
        {
            _logger.LogWarning("User gave an invalid argument. Response: {UnprocessableEntity}", unprocessableEntity);
            return UnprocessableEntity(unprocessableEntity);
        }
    }
}
