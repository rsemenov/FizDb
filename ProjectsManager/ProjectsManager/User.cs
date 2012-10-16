namespace ProjectsManager
{
    public class User
    {
        public string Login { get; set; }
        public UserType UserType { get; set; }
    }

    public enum UserType
    {
        Admin = 0,
        User = 1
    }
}