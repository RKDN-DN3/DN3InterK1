using System.ComponentModel.DataAnnotations;

namespace Quiz.Entities
{
    public class Accounts : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string Email_User { get; set; }


        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
