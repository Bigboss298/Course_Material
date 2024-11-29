namespace Course_Material.Model.Entities
{
    public class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString()[..9];
        public DateTime DateCreated  { get; set; } = new DateTime();
    }
}
