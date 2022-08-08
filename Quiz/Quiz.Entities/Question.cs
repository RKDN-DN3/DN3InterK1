using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.Entities
{
    public class Question:BaseEntity
    {

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
