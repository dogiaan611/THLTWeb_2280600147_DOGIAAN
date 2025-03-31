using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace THLTWeb_2280600147_DOGIAAN.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Age { get; set; }
    }
}
