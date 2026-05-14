using System.Collections.Generic;

namespace api.utility
{
    public static class SD
    {
        // Cookie
        public static readonly string IdentityAppCookie = "SerkanToy";

        public const string NameRegex = "^[a-zA-Z]*$";
        public const string EmailRegex = "^.+@[^\\.].*\\.[a-z]{2,}$";

        // Application rules
        public const int RequiredPasswordLength = 6;
        public const int MaxFailedAccessAttempts = 3;
        public const int DefaultLockoutTimeSpanInDays = 1;
        public const int DefaultDaysToLock = 5;


        // Application roles
        public const string AdminRole = "admin";
        public const string UserRole = "normaluser";
        public const string TechnicalUserRole = "technicaluser";
        public const string ManagerUserRole = "manageruser";
        public const string PresidentUserRole = "presidentuser";
        public static readonly List<string> Roles = new List<string> { AdminRole, UserRole, TechnicalUserRole, ManagerUserRole, PresidentUserRole };
    }
}
