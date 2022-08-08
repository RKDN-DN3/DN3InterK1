using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Entities
{
    internal class Question_Bank :BaseEntity
    {
        [Key]
        [StringLength(10)]
        [Display(Name = "Question of Bank ")]
        public string ID_Question_Bank { get; set; }

        [Required]
        [StringLength (100)]
        [Display(Name = "Name of bank")]
        public string Name { get; set; }



        [Required]
        [StringLength(1)]
        [Display(Name = "Flag IsDelete")]
        public int IsDelete { get; set; }
         
    }
}
