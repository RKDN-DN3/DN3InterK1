using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public string? DOB { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;
    }
}