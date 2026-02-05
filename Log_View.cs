class Log_Views{
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
            AUS_User_Log(ref Email,ref Password);
            logged= User.User_Auth_Log(Email,Password);
            User.Set_Current_User();
            Open_My_Acc();
        }
    }

    public static void User_Signup(){
        bool signed =false;
        while(!signed){
            Arrow_Menu.Title_Me("Log in",7);
            string Email = User.Field_Email();
            string Password=User.Field_Password();
            string Type = User.Field_Type();
            AUS_User_Sign(ref Email,ref Password,ref Type);
            signed= User.User_Auth_Sign(Email,Password,Type);
            User.Set_Current_User();
            Open_My_Acc();
        }
    }
    public static void AUS_User_Sign(ref string email,ref string password,ref string type){
        bool loop = true;
        string title = "Do you want to change any of the user information?";
        string [] options=[
            "Email",
            "Password",
            "Type",
            "No,Thanks",
            "Back to main screen",
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
                    type = User.Field_Type();
                    break;
                case 3:
                    loop=!(User.User_Auth_Sign(email,password,type));
                    break;
                case 4:
                    Log_Views.Home_Page();
                    break;
            }
        }
    }
    public static void AUS_User_Log(ref string email,ref string password){
        bool loop = true;
        string title = "Do you want to change any of the user information?";
        string [] options=[
            "Email",
            "Password",
            "No,Thanks",
            "Back to main screen",
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
                    loop=!(User.User_Auth_Log(email,password));
                    break;
                case 3:
                    Log_Views.Home_Page();
                    break;
            }
        }
    }
    public static void Open_My_Acc(){
        if(User.Current_User.Type=="proffesor"){
            Proffesor_Views.Main_Menu();
        }else if(User.Current_User.Type=="student"){
            Student_Views.Main_Menu();
        }
    }
}
