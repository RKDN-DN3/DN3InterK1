using System.ComponentModel.DataAnnotations;

namespace Quiz.Entities
{
    public class Question : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Content { get; set; }

        [Display(Name = "Image Of Question")]
        public string ImageUrl { get; set; }


        [Required]
        [StringLength(1)]
        public string Level { get; set; }


        [StringLength(100)]
        public string? Type { get; set; }
        public string? Explaint { get; set; }


        [Required]
        [StringLength(1)]
        [Display(Name = "Flag Delete")]
        public string IsDelete { get; set; }
    }
}
