using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET5EFDemo.Models
{
    public class CourseRepository : ICourseRepository
    {
        private CourseContext _context;

        public CourseRepository(CourseContext context)
        {
            _context = context;
        }
        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses.OrderBy(t => t.Name).ToList();
        }
    }
}
