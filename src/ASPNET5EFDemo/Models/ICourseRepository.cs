using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET5EFDemo.Models
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAllCourses();
    }
}
