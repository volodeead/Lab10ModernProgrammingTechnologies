using LanguageCourseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace LanguageCourseApp.Controllers
{
    public class CoursesController : ApiController
    {
        private static List<Course> courses = new List<Course>
        {
            new Course { Id = 1, Name = "English Basic", Price = 200, StartDate = new DateTime(2024, 1, 1) },
            new Course { Id = 2, Name = "French Intermediate", Price = 300, StartDate = new DateTime(2024, 2, 1) },
            new Course { Id = 3, Name = "German Advanced", Price = 500, StartDate = new DateTime(2024, 3, 1) }
        };

        // GET: api/Courses
        public IEnumerable<Course> GetAllCourses()
        {
            return courses;
        }

        // GET: api/Courses/5
        [ResponseType(typeof(Course))]
        public IHttpActionResult GetCourse(int id)
        {
            Course course = courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        // POST: api/Courses
        [ResponseType(typeof(Course))]
        public IHttpActionResult PostCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            courses.Add(course);
            return CreatedAtRoute("DefaultApi", new { id = course.Id }, course);
        }

        // PUT: api/Courses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCourse(int id, Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != course.Id)
            {
                return BadRequest();
            }

            var existingCourse = courses.FirstOrDefault(c => c.Id == id);
            if (existingCourse == null)
            {
                return NotFound();
            }

            existingCourse.Name = course.Name;
            existingCourse.Price = course.Price;
            existingCourse.StartDate = course.StartDate;

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Courses/5
        [ResponseType(typeof(Course))]
        public IHttpActionResult DeleteCourse(int id)
        {
            Course course = courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            courses.Remove(course);
            return Ok(course);
        }

    }

}
