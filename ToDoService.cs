using System;
using System.Linq;
using System.Collections.Generic;
using System.Timers;
using ToDoo.Models;
using ToDoo.Extensions;
namespace ToDoo
{
    public class ToDoService
    {
        private List<IToDo> toDos { get; set; }

        private Timer timer { get; set; }

        public ToDoService()
        {
            timer = new Timer(1000);
            toDos = new List<IToDo>();
            timer.Elapsed += TimerTick;
            timer.Enabled = true;
        }

        public void InvokeJob(IToDo toDo)
        {
            toDo.Enabled = true;
        }

        public void AddTodo(IToDo toDo)
        {
            var nextId = 1;
            if (toDos.Count() != 0)
            {
                nextId = toDos.Select(x => x.Id).Max() + 1;
            }
            toDo.Id = nextId;
            toDos.Add(toDo);
        }

        private void TimerTick(object source, ElapsedEventArgs e)
        {
            var queryLast = toDos.Where(x => x.StartDate < e.SignalTime && !x.Enabled);
            var query = toDos.Where(x => e.SignalTime == x.StartDate);
            var res = queryLast.Concat(query).Distinct();
            res.ForEach(x =>
            {
                InvokeJob(x);
            });
            res.ForEach(x =>
            {
                Console.WriteLine($"{x.Id}, {x.Enabled}");
            });
        }

    }
}