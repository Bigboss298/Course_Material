using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Course_Material.Model.Entities
{
    public class Student : BaseEntity
    {
        public string MatricNumber { get; set; } = default!;
        public string LevelId { get; set; } = default!;
        public string LevelName { get; set; } = default!;
        public string DepartmentName { get; set; } = default!;
        public string DepartmentId { get; set; } = default!;
        public string UserId { get; set; } = default!; 
        public string FacultyName { get; set; } = default!; 
        public string FacultyId { get; set; } = default!;
        public Faculty Faculty { get; set; } = default!;
        public Level Level { get; set; } = default!;
        public Department Department { get; set; } = default!;
        public User User { get; set; } = default!;

    }
}
