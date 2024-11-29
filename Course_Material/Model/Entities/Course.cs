namespace Course_Material.Model.Entities
{
    public class Course : BaseEntity
    {
        public string Code { get; set; } = default!;
        public string DepartmentName { get; set; } = default!;
        public string DepartmentId { get; set; } = default!;
        public string FacultyName { get; set; } = default!;
        public string FacultyId { get; set; } = default!;
        public string LevelId { get; set; } = default!; 
        public string LevelName { get; set; } = default!;
        public Level? Level { get; set; }
        public ICollection<Materials> Materials { get; set; } = [];
        public Faculty? Faculty { get; set; }
        public Department? Department { get; set; }
    }

    public class Materials : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? MaterialLink { get; set; }
    }
}
