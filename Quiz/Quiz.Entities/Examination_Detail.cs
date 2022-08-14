using System.ComponentModel.DataAnnotations;

namespace Quiz.Entities
{
    public class Examination_Detail
    {
        public Guid Id_Exam { get; set; }

        public Guid Id_Question_Bank { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Flag Delete")]
        public string IsDelete { get; set; }

        public virtual Examination Examination { get; set; }
    }
}