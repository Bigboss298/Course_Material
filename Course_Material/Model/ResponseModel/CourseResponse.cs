using Course_Material.Model.Entities;

namespace Course_Material.Model.ResponseModel
{
    public class CourseResponse
    {
    }
    public class GetSingleCourse
    {
        public string Id { get; set; } = default!;
        public string DepartmentName { get; set; } = default!;
        public string DepartmentId { get; set; } = default!;
        public string FacultyName { get; set; } = default!;
        public string FacultyId { get; set; } = default!;
        public ICollection<Materials> Materials { get; set; } = [];
       
    }
    public class GetManyCourses
    {
        public string Id { get; set; } = default!;
        public string DepartmentName { get; set; } = default!;
        public string DepartmentId { get; set; } = default!;
        public string FacultyName { get; set; } = default!;
        public string FacultyId { get; set; } = default!;
    }
}
