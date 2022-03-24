namespace Forum.Web.Infrastructure
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class User
        {
            public const string Login = Base + "/user/login";

            public const string Register = Base + "/user/register";
        }
    }
}
