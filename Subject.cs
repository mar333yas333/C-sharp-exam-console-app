class Subject{
    public static List<Subject> Subjects = new List<Subject>();
    public static int ids = 0;
    public int Id;
    public string Subject_Name;
    public string Subject_Author;
    public List <Exam> Subject_Exam = new List <Exam>();

    public Subject(string subject_name){
        Id= ++ids;
        Subject_Name= subject_name;
        Subject_Author= User.Current_User.Email;
        Subjects.Add(this);
    }
/*
    public static void Add_Exam(){
        string title = "making Exam";
        string [] options=[
            "Exam"
        ];
        int choice = Arrow_Menu.arrow_meth(title,options,7);
    }
*/
    public static void Show_My_Subjects(){
        string title="My Subjects";
        int ADV = 1;
        if(User.Current_User.Type=="proffesor"){
            ADV = 2;
        }
        int i = 0;
        string[] options=new string[Subjects.Count+ADV];
        foreach(Subject S in Subjects)
        {
            options[i]=$"{S.Subject_Name} by {S.Subject_Author}";
            i++;
        }
        i=0;
        options[Subject.Subjects.Count]="Back";
        if(User.Current_User.Type=="proffesor"){
            options[Subject.Subjects.Count]="Add Subject";
            options[Subject.Subjects.Count+1]="Back";
        }
        int choice_Subjects = Arrow_Menu.arrow_meth(title,options,7);
        
        if(User.Current_User.Type=="student"){
            if (choice_Subjects==Subject.Subjects.Count){
                Student_Views.Main_Menu();
            }
            else{
                Show_Subject_Exams(choice_Subjects);
            }
        }
        else if(User.Current_User.Type=="proffesor"){
            if (choice_Subjects==Subject.Subjects.Count+1){
                Proffesor_Views.Main_Menu();
            }
            else if(choice_Subjects==Subject.Subjects.Count){
                string name= Input_Handler.Read_Non_Empty_String("Enter subject name : ");
                Subject.Add_Subject(name);
                Subject.Show_My_Subjects();
            }
            else{
                if(Subjects[choice_Subjects].Subject_Author==User.Current_User.Email){
                    Proffesor_Show_Subject_Exams(choice_Subjects);
                }
                else{
                    Input_Handler.Print_Error("Stop trying to edit a subject thats not yours");
                    Thread.Sleep(2300);
                    Show_My_Subjects();
                }
            }
        }
    }
 
    public static void Show_Subject_Exams(int Subject_index){
        string title="Exams avaliable";
        string[] options=new string[Subjects[Subject_index].Subject_Exam.Count()+1];
        options[Subjects[Subject_index].Subject_Exam.Count()]="Back";
        int i=0;
        foreach(Exam E in Subjects[Subject_index].Subject_Exam)
        {
            options[i] = $"{E.Exam_Name} {E.Status_In_String}";
            i++;
        }
        i=0;
        int choice_Exam=Arrow_Menu.arrow_meth(title,options,8);
        if (choice_Exam== Subjects[Subject_index].Subject_Exam.Count()){
            Subject.Show_My_Subjects();
        }
        else{
            if(User.Current_User.Type=="student"){
                if(Subjects[Subject_index].Subject_Exam[choice_Exam].Avaliable){
                    Exam.Attend_Exam(Subjects[Subject_index].Subject_Exam[choice_Exam]);
                }
                else if(!Subjects[Subject_index].Subject_Exam[choice_Exam].Avaliable){
                    Input_Handler.Print_Error("Exam not avaliable choose an avaliable one");
                    Thread.Sleep(3000);
                    Show_Subject_Exams(Subject_index);
                }
            }
        }
    }
    public static void Proffesor_Show_Subject_Exams(int Subject_index){
        string title="Exams avaliable";
        string[] options=new string[Subjects[Subject_index].Subject_Exam.Count()+2];
        options[Subjects[Subject_index].Subject_Exam.Count()]="Add Exam";
        options[Subjects[Subject_index].Subject_Exam.Count()+1]="Back";
        int i=0;
        foreach(Exam E in Subjects[Subject_index].Subject_Exam)
        {
            options[i]=E.Exam_Name;
            i++;
        }
        i=0;
        int choice_Exam=Arrow_Menu.arrow_meth(title,options,8);
        if (choice_Exam== Subjects[Subject_index].Subject_Exam.Count()+1){
            Subject.Show_My_Subjects();
        }
        else if (choice_Exam== Subjects[Subject_index].Subject_Exam.Count()){
            Exam.Make_Exam_Menu(Subject_index);
        }
        else{
            Exam.Make_Edit_Exam(Subjects[Subject_index].Subject_Exam[choice_Exam],Subject_index);
        }
    }
    public static void Add_Subject(string name){
        Subject S=new Subject(name);
    }
}