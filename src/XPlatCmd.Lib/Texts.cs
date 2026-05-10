namespace XPlatCmd.Lib
{
    public static class Texts
    {
        public static string? TrimOrNull(this string txt)
        {
            return string.IsNullOrWhiteSpace(txt) ? null : txt.Trim();
        }
    }
}