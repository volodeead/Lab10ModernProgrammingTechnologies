﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageCourseApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
    }

}