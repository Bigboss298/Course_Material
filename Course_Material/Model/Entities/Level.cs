namespace Course_Material.Model.Entities
{
    public class Level : BaseEntity
    {
        public string Name { get; set; } = default!;
        public ICollection<Student> Students { get; set; } = [];
    }
}
