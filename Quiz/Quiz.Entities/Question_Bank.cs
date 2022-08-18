using System.ComponentModel.DataAnnotations;

namespace Quiz.Entities
{
    public class Question_Bank : BaseEntity
    {
        public Question_Bank()
        {
            this.Questions = new HashSet<Question>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Name of bank")]
        public string Name { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}