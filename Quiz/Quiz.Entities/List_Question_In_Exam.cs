using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.Entities
{
    public class List_Question_In_Exam
    {
        public Guid Id_Exam { get; set; }

        public Guid Id_Question { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int index { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Flag Delete")]
        public string IsDelete { get; set; }

        public virtual Examination Examination { get; set; }
        public virtual Question Question { get; set; }
    }
}