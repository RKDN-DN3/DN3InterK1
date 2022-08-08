using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Entities
{
    public class Question_Bank : BaseEntity
    {

        [Required]
        [StringLength(100)]
        [Display(Name = "Name of bank")]
        public string Name { get; set; }


        [Required]
        [StringLength(1)]
        [Display(Name = "Flag IsDelete")]
        public string IsDelete { get; set; }
    }
}
