using System.ComponentModel.DataAnnotations;

namespace Quiz.Entities
{
    public class BaseEntity
    {
        public DateTime CreateDate { get; set; }

        public Guid UserCreate { get; set; }
        public DateTime UpdateDate { get; set; }

        public Guid UserUpdate { get; set; }
    }
}
