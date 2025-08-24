using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BackendAPI.ViewModel
{
    public class RegisterViewModel : IdentityUser
    {
        public string? Name { get; set; }
        [Required]
        public string? userEmail { get; set; }
        [Required]
        public string? Password { get; set; }
        
    }
}
