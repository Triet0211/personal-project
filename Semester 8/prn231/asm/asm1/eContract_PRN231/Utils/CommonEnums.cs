using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class CommonEnums
    {
        public static class STATUS_CODE
        {
            public static readonly int OK = 200;
            public static readonly int AUTH_FAILED = 403;
            public static readonly int BAD_REQUEST = 400;
            public static readonly int NOT_FOUND = 404;
            public static readonly int SERVER_ERROR = 500;
        }

        public static class ROLE
        {
            public const string HR = "HR";
            public const string NONE = "NONE";
            public const string ADMIN = "ADMIN";
        }
    }
}
