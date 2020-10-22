using System.Collections.Generic;
using System.Reflection;
using System;
namespace Router.Models
{
    public class Rout
    {
        public string Name { get; set; }

        public Type ClassType { get; set; }

        public MethodInfo ClassMethod { get; set; }

        public Dictionary<string,MethodInfo> MethodParameters { get; set; }

        private object classInstanse { get; set; }

        public object Instance
        {
            get => classInstanse;
            set
            {
                if (classInstanse != null)
                {
                    classInstanse = value;
                }
            }
        }
    }
}