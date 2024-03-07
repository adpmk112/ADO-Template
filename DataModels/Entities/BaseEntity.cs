namespace DataModels.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime createdDate { get; set; }
        public long createdUser { get; set; }
        public DateTime updatedDate { get; set; }
        public long updatedUser { get; set; }
        public bool is_delete { get; set; } = false;
    }
}
