using System.Timers;
using System;
using ToDoo.Models;
namespace ToDoo
{
    class Program
    {
        static void Main(string[] args)
        {
            var todoService = new ToDoService();
            todoService.AddTodo(new Todo(){StartDate = DateTime.Now});
            todoService.AddTodo(new Todo(){StartDate = DateTime.Now});
            Console.ReadKey();
        }
    }
}
