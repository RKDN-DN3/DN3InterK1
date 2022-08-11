using System.ComponentModel.DataAnnotations;

namespace Quiz.Entities
{
    public class Accounts : BaseEntity
    {
        [Key]       
        [StringLength(100)]
        [EmailAddress]

        public string Email_User { get; set; }
       


        [Required]
        [StringLength(100)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [Required]
        [StringLength(1)]
        [Display(Name = "Authority")]
        public string Authority { get; set; }


        [StringLength(100)]
        [Display(Name = "Name Of User")]
        public string Name { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public string DOB { get; set; }


        [StringLength(100)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


        [Required]
        [StringLength(1)]
        [Display(Name = "Flag IsDelete")]
        public string IsDelete { get; set; }
        
        public virtual ICollection<Exam_History> Exam_Historys { get; set; }
    }
}