﻿namespace superheroapi.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Instructor { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string LessonCount { get; set; } = string.Empty;
        public string CourseDetails { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;

    }
}
