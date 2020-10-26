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
            router.AddUtility<ToDoApi>();
            router.Report();
            var line = Console.ReadLine().Split(' ').ToList();
            var command = line.First();
            line.Remove(command);
            var rout = router.MapRout(command,line);
            Console.WriteLine(rout.ToString());
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
