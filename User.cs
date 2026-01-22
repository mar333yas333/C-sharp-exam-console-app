public class User
{
    static int ids=0;
    public static List<User> Users = new List<User>();
    public List<string> history = new List<string>();
    public int id;
    public string Username;
    public string Password;
    public string Type;
    public int Year;
    public User(string username,string password,string type,int year)
    {
        id = ++ids;
        Username = username;
        Password = password;
        Type = type;
        Year = year;

        Users.Add(this);
    }
}