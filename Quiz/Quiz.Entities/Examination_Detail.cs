using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Entities
{
    internal class Examination_Detail : BaseEntity
    {
        [Key]
        [StringLength(10)]
        [Display(Name = "ID Exam")]
        public string ID_Exam {get; set;}
        [Key]
        [StringLength(10)]
        [Display(Name = "ID Question Bank")]
        public string ID_Question_Bank { get; set;}

        [Required]
        [Display(Name = "Sum Of Question")]
        public int Count { get; set;}

        [Required]
        [Display(Name = "Flag Delete")   ] 
        public string IsDelete { get; set;}
    }
}
