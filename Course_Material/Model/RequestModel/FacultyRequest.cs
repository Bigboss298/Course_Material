using Course_Material.Model.Entities;

namespace Course_Material.Model.RequestModel
{
    public class FacultyRequest
    {
    }
    public class GetManyFaculty
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
    }
}
