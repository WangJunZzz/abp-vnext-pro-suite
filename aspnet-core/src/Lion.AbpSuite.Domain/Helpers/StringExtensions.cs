namespace Lion.AbpSuite.Helpers;

public static class StringExtensions
{
    public static bool IsPlaceholder(this string text)
    {
        if (text.StartsWith("{") && text.EndsWith("}"))
        {
            return true;
        }

        return false;
    }
}