﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace web_api_for_books_app.Models
{
    [Table("reviewers")]
    public class Reviewer
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        [Column("user_id")]
        public int UserId { get; set; }

        public User User { get; set; }

        [JsonIgnore]
        public List<Review>? Reviews { get; set; }
    }
}
