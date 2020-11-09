using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Assignment1.Model
{
    public class User
    {
        [Required]
        [NotNull]
        public string Username { get; set; }
        [Required]
        [NotNull]
        public string Password { get; set; }
        [Required]
        [NotNull]
        public string FirstName { get; set; }
        [Required]
        [NotNull]
        public string LastName { get; set; }
    }
    
}