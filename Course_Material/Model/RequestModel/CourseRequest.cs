namespace Course_Material.Model.RequestModel
{
    public class CourseRequest
    {
        public string DepartmentId { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string LevelId { get; set; } = default!;

    }
    public class CourseUpdate
    {
        public string CourseId { get; set; } = default!;
        public string NewDepartmentId { get; set; } = default!;
    }
}
