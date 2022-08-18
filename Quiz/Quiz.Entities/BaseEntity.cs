using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Entities
{
    public class BaseEntity
    {
        [StringLength(1)]
        public String IsDelete { get; set; }
        public DateTime? CreateDate { get; set; }
        public Guid? UserCreate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UserUpdate { get; set; }
    }
}