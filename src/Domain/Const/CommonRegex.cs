namespace movie_basic.Domain.Const;
public static class CommonRegex
{
    public const string Email = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
    public const string CapitalLetters = @"[A-Z]";
    public const string LowercaseLetters = @"[a-z]";
    public const string ContainDigits = @"\d";
    public const string NoSpace = @"^[^£# “”]*$";
    public const string IsDigit = @"^\d+$";
}
