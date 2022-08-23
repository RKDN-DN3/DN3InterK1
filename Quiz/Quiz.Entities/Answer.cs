using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.Entities
{
    public class Answer : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SEQ { get; set; }

        public Guid Id_Question { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Flag IsCorrect")]
        public string IsCorrect { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Content Of Question")]
        public string Content { get; set; }

        public virtual Question Question { get; set; }
    }
}