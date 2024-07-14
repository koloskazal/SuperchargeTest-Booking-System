using DbConnection.Resources;

namespace DbConnection.Tools.ResourceTools
{
    public static class UserResourceTools
    {
        public static void CleaningUserResource(UserResource userResource)
        {
            userResource.FirstName = userResource.FirstName.Trim();
            userResource.LastName = userResource.LastName.Trim();
            userResource.Email = userResource.Email.ToLowerTrim();
        }
    }
}
