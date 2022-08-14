namespace Quiz.Entities
{
    public class BaseEntity
    {
        //[Key]
        //public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }

        public Guid UserCreate { get; set; }
        public DateTime UpdateDate { get; set; }

        public Guid UserUpdate { get; set; }
    }
}