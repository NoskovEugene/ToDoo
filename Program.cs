using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading;
using System;
using System.Text.RegularExpressions;
using Extensions;

namespace ToDoo
{
    class Program
    {
        delegate void delAction(ref string input, string pattern);

        static void Main(string[] args)
        {
            var router = new Router.Router();
            
            router.AddApi<ToDoApi>();

            var input = "[Start datetime] [ToDoType] {[Sunday] [Monday] [Tuesday] [Wednesday] [Thursday] [Friday] [Saturday]} {[one more params]}";
            var multiParamsRegex = new Regex(@"\{.+?\}\s{0,1}");
            var paramsRegex = new Regex(@"\[.+?\]\s{0,1}");
            while(input.MultiContains("{","}"))
            {
                Console.WriteLine(GetAndRemove(ref input,multiParamsRegex));
            }
            while(input.MultiContains("[","]"))
            {
                Console.WriteLine(GetAndRemove(ref input,paramsRegex));
            }

            Console.ReadKey();
        }

        static string GetAndRemove(ref string input, Regex regex)
        {
            var outPutString = regex.Match(input).Value;
            input = input.Replace(outPutString ,string.Empty);
            return outPutString;
        }
    }



}
