﻿namespace Exam7_REST_API.Models
{
    public class TodoModel
    {
        public int id { get; set; }
        public string todo { get; set; }
        public bool completed { get; set; }
        public int userId { get; set; }
    }
}
