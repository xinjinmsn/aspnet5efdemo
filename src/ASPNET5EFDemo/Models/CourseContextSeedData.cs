using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET5EFDemo.Models
{
    public class CourseContextSeedData
    {
        private CourseContext _context;

        public CourseContextSeedData(CourseContext context)
        {
            _context = context;
        }
        public void EnsureSeedData()
        {
            if(!_context.Courses.Any())
            {
                //Add New Data
                var courseList = new List<Course>()
                {
                    new Course { Name="Advanced Powershell", Description="Windows PowerShell Desired State Configuration (DSC) is a new management system in Windows PowerShell 4.0 that enables the deployment and management of configuration data for software services and the environment in which these services run.", Customized=true, Audience="All", Prerequisites="None"},
                    new Course { Name=".Net Advanced Debugging", Description="This workshop will enable you to learn more about debugging .net application.", Customized=true, Audience="All", Prerequisites="None"},
                    new Course { Name="VS2015: Roslyn introduction", Description="The .NET Compiler Platform (\"Roslyn\") provides open-source C# and Visual Basic compilers with rich code analysis APIs. It enables building code analysis tools with the same APIs that are used by Visual Studio.", Customized=true, Audience="All", Prerequisites="None"},
                    new Course { Name="Writing Secure Code", Description="To help secure their systems is to write code that can withstand attack and use security features properly. This 2-day workshop will introduce how to padlock their applications throughout the entire development process—from designing secure applications to writing robust code that can withstand repeated attacks to testing applications for security flaws", Customized=true, Audience="All", Prerequisites="None"},
                    new Course { Name="Entity Framework Introduction", Description="Entity Framework (EF) is an object-relational mapper that enables .NET developers to work with relational data using domain-specific objects.", Customized=true, Audience="All", Prerequisites="None"}
                };

                _context.Courses.AddRange(courseList);
                _context.SaveChanges();
            }
        }
    }
}
