﻿using System.ComponentModel.DataAnnotations.Schema;
using booksAPI.Enums;

namespace booksAPI.Entities
{
    [Table("m2m_books_users")]
    public class BookAndUser
    {
        [ForeignKey("User")]
        [Column("user_id")]
        public required int UserId { get; set; }

        [ForeignKey("Book")]
        [Column("book_id")]
        public required int BookId { get; set; }

        [Column("status")]
        public Status Status { get; set; }

        public required User User { get; set; }

        public required Book Book { get; set; }
    }
}
