namespace Router.Attributes
{
    public class CommandAttribute : System.Attribute
    {
        public string CommandName { get; set; }

        public string Parameters { get; set; }

        public string ParametersSeparator { get; set; }

        public string Flags { get; set; }

        public string FlagsSeparator { get; set; }
    }
}