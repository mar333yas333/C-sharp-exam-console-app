class View
{
    public static void Home_Page(){
        string title = "CIS.edu";
        string [] options =[
            "Sign Up",
            "Log in",
        ];
        int choice =Arrow_Menu.arrow_meth(title,options,6);
        switch(choice){
            case 0:
                User_Signup();
                break;
            case 1:
                User_Login();
                break;
        }
    }
    public static void User_Login(){
        bool logged = false;
        while (!logged)
        {
            Arrow_Menu.Title_Me("Log in",7);
            string Email = User.Field_Email();
            string Password=User.Field_Password();
            AUS_User(ref Email,ref Password);
            logged= User.User_Auth_Log(Email,Password);
        }
    }

    public static void User_Signup(){
        bool signed =false;
        while(!signed)
        {
            Arrow_Menu.Title_Me("Log in",7);
            string Email = User.Field_Email();
            string Password=User.Field_Password();
            AUS_User(ref Email,ref Password);

            signed= User.User_Auth_Sign(Email,Password);
        }
    }
    public static void AUS_User(ref string email,ref string password){
        bool loop = true;
        string title = "Do you want to change any of the user information?";
        string [] options=[
            "Email",
            "Password",
            "No,Thanks",
        ];
        while(loop)
        {
            int choice=Arrow_Menu.arrow_meth(title,options,6);
            switch (choice)
            {
                case 0:
                    email =User.Field_Email();
                    break;
                case 1:
                    password=User.Field_Password();
                    break;
                case 2:
                    return;
            }
        }
    }
}