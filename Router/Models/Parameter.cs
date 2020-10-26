using System.Collections.Generic;
using System.Reflection;
namespace Router.Models
{
    public class Parameter : NamedEntity
    {
        public ParameterInfo Info { get; set; }

        public string Description { get; set; }

        public bool IsMultiSelect { get; set; }

        public List<string> EnabledValue { get; set; } = new List<string>();
    }
}