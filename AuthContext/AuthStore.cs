namespace JobPortalBackend.AuthContext
{
    public static class AuthStore
    {
        // Key = UserId, Value = (Role, LoginTime)
        public static Dictionary<int, (string Role, DateTime LoginTime)> LoggedInUsers = new();
    }
}