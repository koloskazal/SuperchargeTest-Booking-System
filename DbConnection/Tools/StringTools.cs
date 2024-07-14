namespace DbConnection.Tools
{
    public static class StringTools
    {
        //Define a static extension class for the string type which gives back the string trimmed and in lower case.
        public static string ToLowerTrim(this string str)
        {
            return str.Trim().ToLower();
        }
    }
}
