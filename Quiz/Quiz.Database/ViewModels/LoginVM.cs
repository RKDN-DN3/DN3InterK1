using System.ComponentModel.DataAnnotations;

namespace Quiz.Database.ViewModels
{
    public class LoginVM
    {
        [Required]
        [Display(Name = "Username")]
        public string Email_User { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string? FlagCheckEmail { get; set; }
        public string? FlagCheckPW { get; set; }
    }
}