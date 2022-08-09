using System.ComponentModel.DataAnnotations;

namespace Quiz.Entities
{
    public class Accounts : BaseEntity
    {
<<<<<<< HEAD
=======
        [Key]
        public Guid Id { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string Email_User { get; set; }


>>>>>>> f94785ee11c8189997317e72cbf10a5a4f3f033d
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
