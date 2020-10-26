using System.IO.Pipes;
using System.Runtime.InteropServices;
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
        private const string PARAMETER_PATTERN = @"\[.+?\]";
        private const string OPTIONPARAMETER_PATTERN = @"\{.+?\}";

        public List<Utility> Utilities { get; set; }

        public Router()
        {
            Utilities = new List<Utility>();
        }

        public void AddUtility<T>()
        {
            var utility = new Utility();
            var type = typeof(T);
            var att = type.GetCustomAttribute<UtilityAttribute>();
            if (att != null)
            {
                utility.Name = att.UtilityName;
            }
            else
            {
                utility.Name = type.Name;
            }

            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                              .ToList();
            var routs = new List<Rout>();
            foreach (var method in methods)
            {
                var attribute = method.GetCustomAttribute<CommandAttribute>();
                if (attribute != null)
                {
                    var rout = new Rout();
                    rout.Class = type;
                    rout.Name = attribute.CommandName;
                    rout.Method = method;
                    rout.MethodParameters.AddRange(GetParameters(rout, method, attribute.Parameters));
                    rout.FullRout = $"{utility.Name}:{rout.Name}";
                    utility.Routs.Add(rout);
                }
            }
            Utilities.Add(utility);
        }

        public Rout MapRout(string command, IEnumerable<string> parameters)
        {
            foreach(var utility in Utilities)
            {
                var rout = utility.Routs.Where(x=> x.FullRout == command && x.MethodParameters.Count == parameters.Count()).FirstOrDefault();
                return rout;
            }
            return null;
        }


        public void Report()
        {
            Utilities.ForEach(x=> {Console.WriteLine(x.ToString());});
        }
        private List<Parameter> GetParameters(Rout rout, MethodInfo method, string input)
        {
            var parameters = method.GetParameters();
            var needParameters = new List<Parameter>();
            var optionalParams = new List<Parameter>();
            var parameterRegex = new Regex(PARAMETER_PATTERN);
            var optionalRegex = new Regex(OPTIONPARAMETER_PATTERN);
            while (input.MultiContains("{", "}"))
            {
                var line = GetAndRemove(ref input, optionalRegex).Trim("{").Trim("}");
                var parameter = GetMultiplyParameter(line, parameterRegex);
                parameter.IsMultiSelect = true;
                optionalParams.Add(parameter);
            }
            while (input.MultiContains("[", "]"))
            {
                var line = GetAndRemove(ref input, parameterRegex);
                var parameter = new Parameter()
                {
                    Name = line
                };
                needParameters.Add(parameter);
            }
            needParameters.AddRange(optionalParams);


            if (parameters.Count() == needParameters.Count())
            {
                for (int i = 0; i < needParameters.Count(); i++)
                {
                    var currentParameter = needParameters[i];
                    currentParameter.Info = parameters[i];
                    if (currentParameter.IsMultiSelect)
                    {
                        currentParameter.Name = parameters[i].Name;
                    }
                }
            }
            return needParameters;
        }

        private Parameter GetMultiplyParameter(string input, Regex regex)
        {
            var parameter = new Parameter();
            while (input.MultiContains("[", "]"))
            {
                var param = GetAndRemove(ref input, regex);
                parameter.EnabledValue.Add(param);
            }
            return parameter;
        }

        private string GetAndRemove(ref string input, Regex regex)
        {
            var outLine = regex.Match(input).Value;
            input = input.Replace(outLine, string.Empty);
            return outLine;
        }
    }
}