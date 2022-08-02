using System.ComponentModel.DataAnnotations;

namespace Quiz.Entities
{
    public class Accounts : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
