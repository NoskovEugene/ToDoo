using System.Collections.Generic;
using Router.Models;

namespace Router.Models
{
    public class Utility : NamedEntity
    {
        public List<Rout> Routs { get; set; } = new List<Rout>();

        public override string ToString()
        {
            var outs = "";
            foreach (var item in Routs)
            {
                outs += $"-->{item.ToString()}";
            }
            return $"Utility {Name} with routs \r\n{outs}";
        }
    }
}