using System.Linq;
using System.Diagnostics;
using System.Threading;
using System;

namespace ToDoo
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = "";
            ((DayOfWeek[])Enum.GetValues(typeof(DayOfWeek))).ToList().ForEach(x=> 
            {
                line += $"[{x.ToString()}] ";
            });
            Console.WriteLine(line);

            var todoo = new ToDoService();
            Console.ReadKey();
        }


    }
}
