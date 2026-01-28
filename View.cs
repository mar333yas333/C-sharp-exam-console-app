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
        string prompt_email = "Enter Email : ";
        string prompt_email = "Enter Password : ";
        string email=Input_Handler(prompt_email);
        string password=Input_Handler(prompt_password);
    }
    public static void User_Signup(){
    
    }
    public static void AUS_User(string email,string password)
    {
        
    }
}