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
        }
    }

}