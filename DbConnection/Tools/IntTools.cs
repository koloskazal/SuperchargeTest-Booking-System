namespace DbConnection.Tools
{
    public static class IntTools
    {
        public static int GetId(string stringValue, string errorMessage)
        {
            ArgumentNullException.ThrowIfNull(stringValue);
            if (!int.TryParse(stringValue, out int intValue))
            {
                throw new ArgumentException(errorMessage);
            }
            return intValue;
        }
    }
}
