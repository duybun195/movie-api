namespace movie_basic.Application.Common.Extentions;

public static class FormatExtention
{
    public static string TryFormat(this string format, params object[] args)
    {
        var result = "Invalid";
        try
        {
            result = string.Format(format, args);
            return result;
        }
        catch (FormatException)
        {
            return result;
        }
    }
}

