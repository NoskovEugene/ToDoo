using System;

namespace ToDoo.Models
{
    public class Todo : IToDo
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime NextShowDate { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public bool Enabled { get; set; }
    }
}