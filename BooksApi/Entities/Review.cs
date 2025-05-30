﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using booksAPI.Enums;

namespace booksAPI.Entities
{
    [Table("reviews")]
    public class Review : IDatabaseEntity
    {
        [Key]
        [Column("id")]
        public required int Id { get; set; }

        [Column("text")]
        public string? Text { get; set; }

        [Column("rating")]
        public required Rate Rating { get; set; }

        [Column("reviewer_id")]
        [ForeignKey("User")]
        public required int UserId { get; set; }

        [Column("book_id")]
        [ForeignKey("Book")]
        public required int BookId { get; set; }

        public required Book Book { get; set; }

        public required User User { get; set; }
    }
}
