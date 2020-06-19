using Giahung_Lab456.Models;
using System;
using System.Collections.Generic;
using Giahung_Lab456.ViewModels;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _dbConText.Catagories.ToList();
                return View("Create", viewModel);
            }
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Place = viewModel.Place
            };
            _dbConText.Courses.Add(course);
            _dbConText.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
    
}