namespace Mari.Contracts.Common;

public static partial class Routes
{
    public static class Server
    {
        public const string Prefix = "/api";
        public const string OAuthCallbackPath = "/authorization-code/callback";
        public const string FallbackFile = "index.html";
        public const string ErrorController = "/error";
        public const string AuthenticationController = $"{Prefix}/auth";
        public const string ReleaseController = $"{Prefix}/release";
    }
}
