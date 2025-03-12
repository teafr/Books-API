﻿using Microsoft.AspNetCore.Mvc;
using booksAPI.Models.DatabaseModels;
using booksAPI.Services;

namespace booksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly ICrudService<User> _repository;

        public UsersController(ICrudService<User> repository, ILogger<UsersController> logger) : base(logger)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return await ExceptionHandle(async () =>
            {
                var users = await _repository.GetAsync();
                return Ok(users);
            });
        }

        [HttpGet("{id:int:min(1)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            return await ExceptionHandle(async () =>
            {
                var user = await _repository.GetByIdAsync(id);

                if (user == null)
                {
                    return GetNotFoundResponse();
                }

                return Ok(user);
            });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(User user)
        {
            return await ExceptionHandle(async () =>
            {
                if (user is null)
                {
                    return GetBadRequestResponse();
                }

                if (user.Username is null && user.Email is null && user.Name is null)
                {
                    return GetUnprocessableEntityResponse();
                }

                var createdUser = await _repository.CreateAsync(user);
                return CreatedAtAction(nameof(Post), createdUser);
            });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Put(User UserToUpdate)
        {
            return await ExceptionHandle(async () =>
            {
                if (UserToUpdate is null)
                {
                    return GetBadRequestResponse();
                }

                if (UserToUpdate.Username is null && UserToUpdate.Email is null && UserToUpdate.Name is null)
                {
                    return GetUnprocessableEntityResponse();
                }

                var user = await _repository.GetByIdAsync(UserToUpdate.Id);

                if (user == null)
                {
                    return GetNotFoundResponse();
                }

                user.Name = UserToUpdate.Name;
                user.Email = UserToUpdate.Email!;
                user.Description = UserToUpdate.Description;
                user.Username = UserToUpdate.Username!;

                await _repository.UpdateAsync(user);
                return NoContent();
            });
        }

        [HttpDelete("{id:int:min(1)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            return await ExceptionHandle(async () =>
            {
                var user = await _repository.GetByIdAsync(id);

                if (user == null)
                {
                    return GetNotFoundResponse();
                }

                await _repository.DeleteAsync(user);
                return NoContent();
            });
        }
    }
}
