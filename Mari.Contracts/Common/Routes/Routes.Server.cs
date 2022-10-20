namespace Mari.Contracts.Common;

public static partial class Routes
{
    public static class Server
    {
        public const string Prefix = "/api";
        public const string Error = "/error";
        public const string TestController = $"{Server.Prefix}/test";
    }
}