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
            Console.WriteLine($"change in {toDo.Id}, {toDo.Enabled} to {true.ToString()}");
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
            var res = toDos.Where(x => x.StartDate <= e.SignalTime && !x.Enabled);
            res.ForEach(x =>
            {
                InvokeJob(x);
            });
        }

    }
}