namespace ToDoo.Attributes
{
    public class CommandAttribute : System.Attribute
    {
        public string CommandName { get; set; }

        public string Parameters { get; set; }

        public string ParametersParser { get; set; }

        public string Flags { get; set; }

        public string FlagsParser { get; set; }
    }
}