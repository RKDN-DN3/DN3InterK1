using System.ComponentModel.DataAnnotations;

namespace Quiz.Entities
{
    public class BaseEntity
    {
        //[Key]
        //public Guid Id { get; set; }
        public DateTime? CreateDate { get; set; }

        public string? UserCreate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public string? UserUpdate { get; set; }
    }
}
