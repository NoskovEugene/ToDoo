using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System;
using System.Reflection;


using Router.Models;
using Router.Attributes;
namespace Router
{
    public class Router
    {
        public Dictionary<string, Rout[]> Routs = new Dictionary<string, Rout[]>();

        public void AddApi<T>()
        {
            var type = typeof(T);
            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                              .ToList();
            foreach(var x in methods)
            {
                var routs = new List<Rout>();
                var attribute = x.GetCustomAttribute<CommandAttribute>();
                if (attribute != null)
                {
                    var rout = new Rout()
                    {
                        Name = attribute.CommandName
                    };
                    var stringParams = attribute.Parameters.Split(attribute.ParametersSeparator,StringSplitOptions.RemoveEmptyEntries);
                    var parameters = x.GetParameters();
                    
                }
            }

        }
    }
}