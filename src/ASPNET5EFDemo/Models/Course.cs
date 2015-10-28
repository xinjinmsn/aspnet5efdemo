using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET5EFDemo.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Customized { get; set; }
        public string Description { get; set; }
        public string Audience { get; set; }
        public string Prerequisites { get; set; }
    }
}
