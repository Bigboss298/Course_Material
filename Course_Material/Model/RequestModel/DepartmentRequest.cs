using Course_Material.Model.Entities;

namespace Course_Material.Model.RequestModel
{
    public class DepartmentRequest
    {
        public string Name { get; set; } = default!;
        public string FacultyId { get; set; } = default!;
    }
    public class GetManyDepartment
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string FacultyName { get; set; } = default!;
        public string FacultyId { get; set; } = default!;
    }
}
