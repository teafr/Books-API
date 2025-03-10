﻿using booksAPI.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using booksAPI.Services;

namespace booksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : BaseController
    {
        private readonly ICrudService<Review> _reviewService;

        public ReviewsController(ICrudService<Review> reviewService, ILogger<ReviewsController> logger) : base(logger)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await ExceptionHandle(async () =>
            {
                var reviews = await _reviewService.GetAsync();
                return Ok(reviews);
            });
        }

        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> GetById(int id)
        {
            return await ExceptionHandle(async () =>
            {
                var review = await _reviewService.GetByIdAsync(id);

                if (review == null)
                {
                    return NotFoundStatusCode();
                }

                return Ok(review);
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post(Review review)
        {
            return await ExceptionHandle(async () =>
            {
                var createdReview = await _reviewService.CreateAsync(review);
                return CreatedAtAction(nameof(Post), createdReview);
            });
        }

        [HttpPut]
        public async Task<IActionResult> Put(Review reviewToUpdate)
        {
            return await ExceptionHandle(async () =>
            {
                var existingReview = await _reviewService.GetByIdAsync(reviewToUpdate.Id);

                if (existingReview == null)
                {
                    return NotFoundStatusCode();
                }

                existingReview.Id = reviewToUpdate.Id;
                existingReview.Text = reviewToUpdate.Text;
                existingReview.User = reviewToUpdate.User;
                existingReview.Rating = reviewToUpdate.Rating;
                existingReview.Book = reviewToUpdate.Book;

                await _reviewService.UpdateAsync(existingReview);
                return NoContent();
            });
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            return await ExceptionHandle(async () =>
            {
                var existingReview = await _reviewService.GetByIdAsync(id);

                if (existingReview == null)
                {
                    return NotFoundStatusCode();
                }

                await _reviewService.DeleteAsync(existingReview);
                return NoContent();
            });
        }
    }
}
