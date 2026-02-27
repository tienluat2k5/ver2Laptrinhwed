using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionEcommerce.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string? Username { get; set; }

        public string? PasswordHash { get; set; }

        [Required]
        public string Email { get; set; } = string.Empty;

        public string? GoogleId { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public string? AvatarUrl { get; set; }

        public string? Role { get; set; }

        public bool? IsLocked { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}