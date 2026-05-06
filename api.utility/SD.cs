using System;
using System.Collections.Generic;
using System.Text;

namespace api.utility
{
    public static class SD
    {
        public const string NameRegex = "^[a-zA-Z]*$";
        public const string EmailRegex = "^.+@[^\\.].*\\.[a-z]{2,}$";

        // Application rules
        public const int RequiredPasswordLength = 6;
        public const int MaxFailedAccessAttempts = 3;
        public const int DefaultLockoutTimeSpanInDays = 1;
        public const int DefaultDaysToLock = 5;
    }
}
