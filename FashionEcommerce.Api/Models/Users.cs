using System;
using System.ComponentModel.DataAnnotations;

namespace FashionEcommerce.Api.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string? Username { get; set; }

        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        public string? GoogleId { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public string? AvatarUrl { get; set; }

        // QUAN TRỌNG
        [Required]
        public string Role { get; set; } = "Customer";

        // Không cho nullable
        public bool IsLocked { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}