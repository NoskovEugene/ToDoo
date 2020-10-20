using System;
using System.Linq;
using System.Collections.Generic;
using System.Timers;
using ToDoo.Models;
using ToDoo.Models.Enums;
using ToDoo.ToDoMaps;
namespace ToDoo
{
    public class ToDoService
    {
        private List<IToDo> toDos { get; set; }

        private List<IToDo> History { get; set; }

        private ToDoRulesMap Map { get; set; }

        private Timer timer { get; set; }

        public ToDoService()
        {
            timer = new Timer(1000);
            toDos = new List<IToDo>();
            History = new List<IToDo>();
            timer.Elapsed += TimerTick;
            timer.Enabled = true;
            InitMap();
        }

        private void InitMap()
        {
            Map = new ToDoRulesMap();

            Map.For(ToDoType.OneTime).AddRule((todo) =>
            {
                toDos.Remove(todo);
                todo.IsEnd = true;
                Console.WriteLine(todo.Message);
            });



        }

        public void InvokeJob(IToDo toDo)
        {
            Console.Beep(800, 200);
            Action<IToDo> def = (todo) =>
            {
                toDos.Remove(todo);
                todo.IsEnd = true;
                Console.WriteLine(todo.Message);
            };

            if (Map.Get(toDo.Type, out var action))
            {
                action(toDo);
            }
            else
            {
                def(toDo);
            }
            toDo.IsEnd = true;

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
            var res = toDos.Where(x => x.StartDate <= e.SignalTime && x.NextShowDate <= e.SignalTime && !x.IsEnd).ToList();
            res.ForEach(x =>
            {
                InvokeJob(x);
                History.Add(x);
            });
        }

    }
}