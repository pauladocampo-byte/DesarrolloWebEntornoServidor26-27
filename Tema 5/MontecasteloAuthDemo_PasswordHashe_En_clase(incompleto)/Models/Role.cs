namespace MontecasteloAuthDemo.Models
{
    public enum Role
    {
        User = 0,
        Admin = 1
    }

    public static class Roles
    {
        public const string User = nameof(User);
        public const string Admin = nameof(Admin);
        public static string[] All => new[] { User, Admin };
    }
}
