namespace Interview360.Domain.Abstraction
{
    public abstract class Entity<TId>
    {
        public TId Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}