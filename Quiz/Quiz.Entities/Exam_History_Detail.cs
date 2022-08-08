using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Entities
{
    internal class Exam_History_Detail:BaseEntity
    {
        [Key]
        [StringLength(10)]
        [Display(Name = "ID Exam")]
        public string ID_Exam { get; set; }


        [Key]
        [StringLength(100)]
        [EmailAddress]
        public string Email_User { get; set; }

        [Key]
        [DataType(DataType.Date)]
        [Display(Name = "Date_Do_Exam")]
        public DateTime Date_Do_Exam { get; set; }

        [Key]
        [StringLength(10)]
        [Display(Name = "ID Question")]
        public string ID_Question { get; set; }



        [Required]
        [StringLength(10)]
        [Display(Name = "ID Answer Chose")]
        public string ID_Answer_Chose { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Flag Delete")]
        public string IsDelete { get; set; }

    }
}
