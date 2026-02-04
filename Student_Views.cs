class Student_Views
{
    public static void Main_Menu(){
        string title = $"welcome student {User.Current_User.Email}";
        string [] options=[
            "my subjects",
            "history",
            "my info",
            "log out"
        ];
        int choice = Arrow_Menu.arrow_meth(title,options,5);
        switch(choice){
            case 0:
                Subject.Show_My_Subjects();
                break;
/*          case 1:
                Student_Views.Show_History();
                break;
            case 2:
                Student_Show_Current_Degree();
                break;*/
            case 3:
                Log_Views.Home_Page();
                break;
        }
    }

}