using DbConnection.Resources;

namespace DbConnection.Tools.ResourceTools
{
    public static class VisitorResourceTools
    {
        public static void CleaningVisitorResource(VisitorResource visitorResourceToClean)
        {
            visitorResourceToClean.FirstName = visitorResourceToClean.FirstName.Trim();
            visitorResourceToClean.LastName = visitorResourceToClean.LastName.Trim();
            visitorResourceToClean.Email = visitorResourceToClean.Email.ToLowerTrim();
        }
    }
}
