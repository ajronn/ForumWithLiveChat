using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Web.Infrastructure
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public static class User
        {
            public const string Login = Root + "/user/login";
            public const string Register = Root + "/user/register";
            public const string ActivateUser = Root + "/user/activate";
            public const string DeactivateUser = Root + "/user/deactivate";
            public const string ArchiveUser = Root + "/user/archive";
            public const string DearchiveUser = Root + "/user/dearchive";
            public const string UpdateUser = Root + "/user/update";
            public const string ChangePassword = Root + "/user/changepassword";
        }

        public static class Post
        {
            public const string GetList = Root + "/post/list";
            public const string Get = Root + "/post/get";
            public const string Create = Root + "/post/create";
            public const string Update = Root + "/post/update";
            public const string Delete = Root + "/post/delete";
        }

        public static class Thread
        {
            public const string GetList = Root + "/thread/list";
            public const string Get = Root + "/thread/get";
            public const string Create = Root + "/thread/create";
            public const string Update = Root + "/thread/update";
            public const string Delete = Root + "/thread/delete";
        }

        public static class Subsection
        {
            public const string GetList = Root + "/subsection/list";
            public const string Get = Root + "/subsection/get";
            public const string Create = Root + "/subsection/create";
            public const string Update = Root + "/subsection/update";
            public const string Delete = Root + "/subsection/delete";
        }

        public static class Section
        {
            public const string GetList = Root + "/section/list";
            public const string Get = Root + "/section/get";
            public const string Create = Root + "/section/create";
            public const string Update = Root + "/section/update";
            public const string Delete = Root + "/section/delete";
        }
    }
}
