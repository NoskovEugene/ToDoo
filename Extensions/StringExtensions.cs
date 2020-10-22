namespace Extensions
{
    public static class StringExtensions
    {
        public static string Trim(this string line, string separators)
        {
            return line.Trim(separators.ToCharArray());
        }

        public static bool MultiContains(this string line, params string[] items)
        {
            var outPut = false;
            foreach (var item in items)
            {
                if (line.Contains(item))
                {
                    outPut = true;
                }
            }
            return outPut;
        }
    }
}