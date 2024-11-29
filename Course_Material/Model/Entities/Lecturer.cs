namespace Course_Material.Model.Entities
{
    public class Lecturer : BaseEntity
    {
        public string DepartmentName { get; set; } = default!;
        public string DepartmentId { get; set; } = default!;
        public string FacultyName { get; set; } = default!;
        public string FacultyId { get; set; } = default!;
        public Faculty? Faculty { get; set; }
        public Department? Department { get; set; }

    }
}
