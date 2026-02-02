class Subject{
    public static List<Subject> Subjects = new List<Subject>();
    public static int ids = 0;
    public int Id;
    public string Subject_Name;
    List <Exam> Subject_Exam = new List <Exam>();

    public Subject(string subject_name){
        Id= ++ids;
        Subject_Name= subject_name;
        Subjects.Add(this);
    }
    public static void Add_Exam(){
        string title = "making Exam";
        string [] options=[
            "Exam"
        ];
        int choice = Arrow_Menu.arrow_meth(title,options,7);
    }
    public static void Show_My_Subjects(){
        string title="My Subjects";
        int i = 0;
        string[] options=new string[Subjects.Count+1];
        foreach(Subject S in Subjects)
        {
            options[i]=S.Subject_Name;
            i++;
        }
        i=0;
        options[Subject.Subjects.Count]="Back";
        int choice = Arrow_Menu.arrow_meth(title,options,7);
        
        if (choice==Subject.Subjects.Count)
        {
            Student_Views.Main_Menu();
        }
        else{
            Show_Subject_Exams(choice);
        }
    }
    public static void Show_Subject_Exams(int index){
    title="Exams avaliable";
    string[Subjects[index].Subject_Exam.Count()] options=
        string[] options=new string[Subjects.Count+1];
        foreach(Subject S in Subjects)
        {
            options[i]=S.Subject_Name;
            i++;
        }
        i=0;
    }
}