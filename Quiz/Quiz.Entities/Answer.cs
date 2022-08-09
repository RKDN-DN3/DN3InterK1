using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Entities
{
    public class Answer : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 0)]
        public int SEQ { get; set; }


        
        [Key]
        [Column(Order = 1)]
        [Display(Name = "ID Of Question ")]
        [StringLength(10)]
        public string ID_Question { get; set; }


        [Required]
        [StringLength(1)]
        [Display(Name = "Flag IsCorrect")]
        public string IsCorrect { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Content Of Question")]
        public string Content { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Flag IsDelete")]
        public string IsDelete { get; set; }


    }
}
