using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System;
using System.Reflection;

using Extensions;

using Router.Models;
using Router.Attributes;
namespace Router
{
    public class Router
    {
        public void AddApi<T>()
        {
            var type = typeof(T);
            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                              .ToList();
            var routs = new List<Rout>();
            foreach(var method in methods)
            {
                var attribute = method.GetCustomAttribute<CommandAttribute>();
                if(attribute != null)
                {

                }
            }

        }

        private Rout GetMultiparameters(Rout rout, MethodInfo method, Regex regex, ref string inputLine)
        {
            while(inputLine.MultiContains("{", "}"))
            {
                
            }
            return rout;
        }
    }
}