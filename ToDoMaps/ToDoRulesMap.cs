using System;
using System.Collections.Generic;
using System.ComponentModel;
using ToDoo.Models.Enums;
using ToDoo.Models;

namespace ToDoo.ToDoMaps
{
    public class ToDoRulesMap
    {
        public Dictionary<ToDoType, Action<IToDo>> Rules { get; set; }

        private ToDoType TemporaryType { get; set; }

        public ToDoRulesMap()
        {
            Rules = new Dictionary<ToDoType, Action<IToDo>>();
        }

        public ToDoRulesMap For(ToDoType type)
        {
            TemporaryType = type;
            return this;
        }

        public void AddRule(Action<IToDo> action)
        {
            Rules.Add(TemporaryType, action);
        }

        public bool Get(ToDoType type, out Action<IToDo> action)
        {
            action = null;
            if (Rules.ContainsKey(type))
            {
                action = Rules[type];
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}