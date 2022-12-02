using System.Text.RegularExpressions;

namespace Lion.AbpSuite.Extensions;

public static class StringExtensions
{
    public static bool IsPlaceholder(this string text)
    {
        var pattern = @"^\{\w}$";
        return Regex.IsMatch(text, pattern);
    }

    public static bool IsContainPlaceholder(this string text)
    {
        if (text.IsNullOrWhiteSpace()) return false;
        if (text.Contains("{") && text.Contains("}")) return true;
        return false;
    }

    public static string ReplacePlaceholder(this string text)
    {
        if (text.IsContainPlaceholder())
        {
            return text.Replace("{", "{{").Replace("}", "}}");
        }

        return text;
    }
}