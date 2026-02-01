class Subject
{
    public static List<Subject> Subjects = new List<Subject>();
    public static int ids = 0;
    public int Id;
    public string Subject_Name;
    List <Exam> Subject_Exam = new List <Exam>();

    public Subject(string subject_name)
    {
        Id= ++ids;
        Subject_Name= subject_name;
        Subjects.Add(this);
    }
    public void Add_Exam()
    {
        string title = "making Exam";
        string [] options=[
            "Exam"
        ];
        int choice = Arrow_Menu.arrow_meth(title,options,7);
    }
}