using Course_Material.Interface.Repositories;
using Course_Material.Interface.Service;
using Course_Material.Model.Entities;
using Course_Material.Model.Exceptions;
using Course_Material.Model.RequestModel;
using Course_Material.Model.ResponseModel;
using System.Runtime.CompilerServices;

namespace Course_Material.Implementation.Service

{
    public class CourseService(IRepositoryManager repositoryManager) : ICourseService
    {
        private readonly IUnitOfWork _unitOWork = repositoryManager.UnitOfWork; 
        private readonly ICourseRepository _courseRepository = repositoryManager.CourseRepository;
        private readonly IDepartmentRepository _departmentRepository = repositoryManager.DepartmentRepository;
        private readonly ILevelRepository _levelRepository = repositoryManager.LevelRepository;
        private readonly IMaterialRepository _materialRepository = repositoryManager.MaterialRepository;
        public async Task<(bool success, string message)> Create(CourseRequest courseRequest)
        {
            var checkCourse = await _courseRepository.CheckCourse(courseRequest.Code);
            if (checkCourse) throw new BadRequestException($"Course with the name {courseRequest.Code} already exist");

            var getDepartment = await _departmentRepository.GetSingle(x => x.Id == courseRequest.DepartmentId) ?? throw new NotFoundException("Department not found");

            var getLevel = await _levelRepository.GetSingle(x => x.Id == courseRequest.LevelId) ?? throw new NotFoundException("Level not found");

            Course course = new()
            {
                Code = courseRequest.Code,
                DepartmentName = getDepartment.Name,
                DepartmentId = courseRequest.DepartmentId,
                FacultyName = getDepartment.FacultyName,
                FacultyId = getDepartment.FacultyId,
                LevelId = getLevel.Id,
                LevelName = getLevel.Name,
            };

            await _courseRepository.Insert(course);
            await _unitOWork.SaveChangesAsync();

            return (true, "Course Created succesfully!!!");
        }

        public async Task<(bool success, string message)> Delete(string id)
        {
            var getCourse = await _courseRepository.GetSingle(x => x.Id == id) ?? throw new NotFoundException("Course not found!!!");

            if(getCourse.Materials.Any())
            {
                _materialRepository.DeleteRange((List<Materials>)getCourse.Materials);
            }

            _courseRepository.Delete(getCourse);
            await _unitOWork.SaveChangesAsync();
            return (true, "Course and its Materials Deleted successfully!!!");
           
        }

        public async Task<List<GetManyCourses>> GetAll()
        {
            var courses = await _courseRepository.GetAll();
            if (!courses.Any()) return [];

            return courses.Select(x => new GetManyCourses
            {
                Id = x.Id,
                DepartmentId = x.DepartmentId,
                DepartmentName = x.DepartmentName,
                FacultyId = x.FacultyId,
                FacultyName = x.FacultyName,
            }).ToList();

        }

        public async Task<List<GetManyCourses>> GetMany(string param)
        {
            var courses = await _courseRepository.GetMany(x => x.DepartmentName.ToLower() == param.ToLower());
            if (!courses.Any()) return [];

            return courses.Select(x => new GetManyCourses
            {
                Id = x.Id,
                DepartmentId = x.DepartmentId,
                DepartmentName = x.DepartmentName,
                FacultyId = x.FacultyId,
                FacultyName = x.FacultyName,
            }).ToList();
        }

        public async Task<GetSingleCourse> GetSingle(string id)
        {
            var course = await _courseRepository.GetSingle(x => x.Id == id) ?? throw new NotFoundException("Course not found!!!");

            GetSingleCourse singleCourse = new()
            {
                Id = course.Id,
                DepartmentId = course.DepartmentId,
                DepartmentName = course.DepartmentName,
                FacultyId = course.FacultyId,
                FacultyName = course.FacultyName,
                Materials = [.. course.Materials],
            };
            return singleCourse;
        }

        public async Task<(bool success, string message)> Update(CourseUpdate courseUpdate)
        {
            var course = await _courseRepository.GetSingle(x => x.Id == courseUpdate.CourseId) ?? throw new NotFoundException("Course not found!!!");

            var getDeparment = await _departmentRepository.GetSingle(x => x.Id == courseUpdate.NewDepartmentId) ?? throw new NotFoundException("Department not Found!!!");

            course.DepartmentName = getDeparment.Name;
            course.FacultyName = getDeparment.FacultyName;
            course.DepartmentId = getDeparment.Id;
            course.FacultyId = getDeparment.FacultyId;

            _courseRepository.Update(course);
            await _unitOWork.SaveChangesAsync();

            return (true, "Course updated successfully!!!");
        }
    }
}
