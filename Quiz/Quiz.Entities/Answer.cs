using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Entities 
{
    internal class Answer : BaseEntity
    {
        [Key]
        [Display(Name = "ID Auto Increment")]
        public int SEQ { get; set; }

        [ForeignKey("ID_Question")]
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
