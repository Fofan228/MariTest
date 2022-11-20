namespace Mari.Contracts.Common.Routes.Server;

public static partial class ServerRoutes
{
    public static class Controllers
    {
        public const string Error = $"/error";
        public const string Authentication = $"{Prefix}/auth";
        public const string Release = $"{Prefix}/release";
    }
}