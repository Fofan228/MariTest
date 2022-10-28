namespace Mari.Contracts.Common;

public static partial class Routes
{
    public static class Server
    {
        public const string Prefix = "/api";
        public const string ErrorController = "/error";
        public const string AuthorizationController = "/auth";
        public const string TestController = $"{Server.Prefix}/test";
        public const string OAuthCallbackPath = "/authorization-code/callback";
    }
}
