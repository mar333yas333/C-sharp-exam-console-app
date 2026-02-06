class Student_Views
{
    public static void Main_Menu(){
        string title = $"welcome student {User.Current_User.Email}";
        string [] options=[
            "my subjects",
            "history",
            
            "log out"
        ];
        int choice = Arrow_Menu.arrow_meth(title,options,5);
        switch(choice){
            case 0:
                Subject.Show_My_Subjects();
                break;
            case 1:
                Student_Views.Show_History();
                break;
            
            case 2:
                Log_Views.Home_Page();
                break;
        }
    }
    public static void Show_History(){
        Console.Clear();
        Arrow_Menu.Title_Me("Exam History",6);

        if(User.Current_User.history.Count == 0){
            Console.WriteLine("No exams attended yet.");
        }
        else{
            for(int i = 0; i < User.Current_User.history.Count; i++){
                Console.WriteLine($"{i + 1}. {User.Current_User.history[i]}");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to go back...");
        Console.ReadKey();
    }

}