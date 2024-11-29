namespace Course_Material.Model.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string FacultyName { get; set; } = default!;
        public string FacultyId { get; set; } = default!;
        public Faculty Faculty { get; set; } = default!;
        public ICollection<Student> ListOfStudent {  get; set; } = [];
        public ICollection<Course> ListOfCourses { get; set; } = [];
    }
}
