using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Entities
{
    internal class Exam_History
    {
        [Key]
        [StringLength(10)]
        [Display(Name = "ID Exam")]
        public string ID_Exam { get; set; }

        [Key]
        [StringLength(100)]
        [Display(Name = "Email Address")]
        public string Email_User { get; set; }

        [Key]
        [DataType(DataType.Date)]
        [Display(Name = "Date Do Exam ")]
        public DateTime DateDoExam { get; set; }

        [Required]
        [Display(Name ="Mark")]
        public int Mark { get; set; }

        [Required]
        [Display(Name = "Time Do Exam")]
        public int TimeDoExam { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }
        [Required]
        [StringLength(1)]
        [Display(Name = "Flag IsDelete")]
        public string IsDelete { get; set; }
    }
}
