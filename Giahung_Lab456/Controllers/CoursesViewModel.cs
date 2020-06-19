using System.Linq;
using Giahung_Lab456.Models;

namespace Giahung_Lab456.Controllers
{
    internal class CoursesViewModel
    {
        public object Follows { get; set; }
        public bool ShowAction { get; set; }
        public IQueryable<Course> UpcomingCourses { get; set; }
    }
}