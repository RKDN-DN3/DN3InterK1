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
        public Question_Bank()
        {
            this.Questions = new HashSet<Question>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Name of bank")]
        public string Name { get; set; }


        [Required]
        [StringLength(1)]
        [Display(Name = "Flag IsDelete")]
        public string IsDelete { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
