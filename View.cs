class View
{
    public static void Home_Page(){
        string title = "CIS.edu";
        string [] options ={
            "Sign Up",
            "Log in",
        } 
    }
    public static void User_Login(){
        string title =Arrow_Menu.Title_Me("Log in",7);
        string Email = Field_Email();
        string Password=Field_Password();
        bool usure = AUS_User();
        bool logged= User.User_Auth(Email,Password)
    }
    public static void User_Signup(){
    
    }
    public static void AUS_User(string email,string password){
        if(!Users.Any(u => u.Email == email &&u.Password == password))
        {
            System.Console.WriteLine("invalid login information ... \n please,try again");
        }
        else {
            User.current_User_Index=;
        }
    }
}