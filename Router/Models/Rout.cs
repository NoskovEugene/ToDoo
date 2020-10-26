using System.Collections.Generic;
using System.Reflection;
using System;
namespace Router.Models
{
    public class Rout : NamedEntity
    {

        public string FullRout { get; set; }

        public Type Class { get; set; }

        public MethodInfo Method { get; set; }

        public List<Parameter> MethodParameters { get; set; }

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

        public Rout()
        {
            MethodParameters = new List<Parameter>();
        }

        public override string ToString()
        {
            var outs = "";
            foreach (var item in MethodParameters)
            {
                outs += $"--->{item.Name}: {item.Info.ParameterType}\r\n";
            }
            return $"Rout for {Name} to {Method.Name} with params: \r\n{outs}";
        }

    }
}