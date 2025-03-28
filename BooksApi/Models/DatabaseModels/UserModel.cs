﻿namespace booksAPI.Models.DatabaseModels
{
    public class UserModel
    {
        public int Id { get; set; }

        public required string Username { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public string? Description { get; set; }
    }
}