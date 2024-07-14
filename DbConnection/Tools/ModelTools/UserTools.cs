using DbConnection.db.Supercharge.Model;

namespace DbConnection.Tools.ModelTools
{
    public static class UserTools
    {
        public static string GetFullName(User user)
        {
            if (user == null)
            {
                return string.Empty;
            }
            string result = $"{user.FirstName} {user.LastName}";
            return result;
        }
    }
}
