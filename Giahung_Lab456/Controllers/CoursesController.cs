using Giahung_Lab456.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Giahung_Lab456.ViewModels;
using Microsoft.AspNet.Identity;

namespace Giahung_Lab456.Controllers
{
    public class CoursesController : Controller
    {

        private readonly ApplicationDbContext _dbConText;
        public CoursesController()
        {
            _dbConText = new ApplicationDbContext();
        }

        // GET: Courses
    
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbConText.Catagories.ToList()
            };
            return View(viewModel);

        }

    }
    [Authorize]
    [HttpPost]
    public ActionResult Create(CourseViewModel ViewModel)
    {
        var course = new Course
        {
            LecturerId = User.Identity.GetUserId(),
            DateTime = ViewModel.GetDateTime(),
            CategoryId = ViewModel.Category,
            Place = ViewModel.Place
        };
    }
}