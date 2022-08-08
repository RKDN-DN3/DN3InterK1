using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Entities
{
    internal class List_Question_in_Exam: BaseEntity
    {
        [Key]
        [StringLength(10)]
        [Display(Name = "ID Exam")]
        public string ID_Exam { get; set; }

        [Key]
        [StringLength(10)]
        [Display(Name = "ID Question ")]
        public string ID_Question { get; set; }

        [Required]
        [Display(Name = "Location")]
        public int index { get; set; }


        [Required]
        [StringLength(1)]
        [Display(Name = "Flag IsDelete")]
        public string IsDelete { get; set; }    
    }
}
