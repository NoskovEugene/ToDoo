using System;
using ToDoo.Models.Enums;
namespace ToDoo.Models
{
    public interface IToDo
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime NextShowDate { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public ToDoType Type { get; set; }

        public DayOfWeek[] Days { get; set; }

        public bool IsEnd { get; set; }
    }
}