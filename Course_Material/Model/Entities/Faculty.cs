namespace Course_Material.Model.Entities
{
    public class Faculty : BaseEntity
    {
        public string Name { get; set; } = default!;
        public ICollection<Department> ListOfDepartments { get; set; } = [];
    }
}
