public class User
{
    public static int current_User_Index;
    static public int ids=0;
    public static List<User> Users = new List<User>();
    public List<string> history = new List<string>();
    public int id;
    public string Email;
    public string Password;
    public string Type;
    public int Year;
    public User(string email,string password,string type,int year)
    {
        id = ++ids;
        Email = email;
        Password = password;
        Type = type;
        Year = year;

        Users.Add(this);
    }
    public static string Field_Email()
    {
        string prompt_email = "Enter Email : ";
        string email=Input_Handler.Read_Non_Empty_String(prompt_email);
        return email;
    }
    public static string Field_Password()
    {
        string prompt_password = "Enter Password : ";
        string password=Input_Handler.Read_Non_Empty_String(prompt_password);
        return password;
    }
    public static bool User_Auth_Log(string email,string password)
    {
        if(!Users.Any(u => u.Email == email &&u.Password == password)){
            System.Console.WriteLine("invalid login information ... \n please,try again");
            return false;
        }
        else {
            User.current_User_Index=Users.FindIndex(u => u.Email ==email);
            return true;
        }
    }
    public static bool User_Auth_Sign(string email,string type){
        if(Users.Any(u => u.Email == email)){
            System.Console.WriteLine("email already taken please try another ...");
            return false;
        }
        else{
            User.current_User_Index=Users.FindIndex(u => u.Email == email);
            return true;
        }
    }
}