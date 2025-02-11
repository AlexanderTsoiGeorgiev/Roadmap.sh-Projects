using System;
using System.ComponentModel.DataAnnotations;

namespace TodoListAPI.Web.Models.Identity
{
    public class RegisterUserDTO
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
