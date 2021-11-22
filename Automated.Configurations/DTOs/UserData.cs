namespace Automated.Configurations.DTOs
{
    public class UserData
    {
        public Credentials? Admin { get; set; }

        public Credentials? User { get; set; }

        public class Credentials 
        {
            public string? Email { get; set; }

            public string? Password { get; set; }
        }
    }
}