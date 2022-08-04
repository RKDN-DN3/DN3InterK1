using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.Entities
{
    public class Questions : BaseEntity
    {

        public string Content { get; set; }

        [Display(Name = "Image Of Question")]
        public string ImageUrl { get; set; }


        [Required]
        [StringLength(1)]
        public string Level { get; set; }


        [StringLength(100)]
        public string? Type { get; set; }
        public string? Explaint { get; set; }


        [Required]
        [StringLength(1)]
        [Display(Name = "Flag Delete")]
        public string IsDelete { get; set; }

       /* public Guid Id_ { get; set; }
        [ForeignKey("Id")]*/

        //[Required]
        //[DataType(DataType.Date)]
        //[Display(Name = "Date Create Question")]
        //public DateTime CreateDate { get; set; }


        //[Required]
        //[StringLength(100)]
        //[Display(Name = "Question Creator")]
        //public string CreateUser { get; set; }


        //[DataType(DataType.Date)]
        //[Display(Name = "Date Update Question")]
        //public DateTime UpdateDate { get; set; }


        //[StringLength(100)]
        //[Display(Name = "Question Updater")]
        //public string UpdateUser { get; set; }


        //[StringLength(10)]
        //public int ID_Question_Bank { get; set; }
        //public Question_Bank Question_Bank { get; set; }
    }
}
