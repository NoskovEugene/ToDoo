using System.Text.RegularExpressions;
namespace ToDoo.Utils
{
    public static class StringUtils
    {
        public static string GetAndRemove(ref string input, string pattern)
        {
            var regex = new Regex(pattern);
            var match = regex.Match(input);
            input = input.Replace(match.Value, string.Empty);
            return match.Value;
        }

        public static string GetAndRemove(ref string input, Regex regex)
        {
            var match = regex.Match(input);
            input = input.Replace(match.Value, string.Empty);
            return match.Value;
        }
    }
}