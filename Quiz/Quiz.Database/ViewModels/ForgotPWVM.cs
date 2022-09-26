using System.ComponentModel.DataAnnotations;


namespace Quiz.Database.ViewModels
{
    public class ForgotPWVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
