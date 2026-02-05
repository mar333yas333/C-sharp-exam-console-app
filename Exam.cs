public class Exam{   
    public static int ids=0;
    public int id; 
    public string Exam_Type;
    public string Exam_Name;
    public string Status_In_String;
    public bool Avaliable;
//    public int Subject_Id;
//    public string Subject_Name;
//    public string Exam_Year;
//    public string Exam_Author;
    public double Total_Mark=0;
    public List<Question> Questions_Of_Exam = new List<Question>();
    
    public static void Make_Exam_Menu(int Subject_index){
        string title="Making Exam > Choose exam type";
        string exam_type="not assigned";
        string exam_name="not assigned";
        bool avaliable;
        string []options=[
            "practical (mcq only)",
            "final (mcq + true or false)",
            "Custome (Accept all Supported kinds of questions)"
        ];
        int choice_type=Arrow_Menu.arrow_meth(title,options,4);
        switch(choice_type){
            case 0:
                exam_type="practical";
                break;
            case 1:
                exam_type="final";
                break;
        }

        Arrow_Menu.Title_Me("Making Exam",7);
        string Add_Exam_Name_Prompt="Enter Exam Name : ";
        exam_name=Input_Handler.Read_Non_Empty_String(Add_Exam_Name_Prompt);
        Make_Exam(Subject_index,exam_type,exam_name,avaliable=false);
        Subject.Proffesor_Show_Subject_Exams(Subject_index);

    }
    public static void Make_Exam(int Subject_index, string exam_type,string exam_name,bool avaliable){
        Exam e=new Exam();
        e.id = ++ids;
        e.Exam_Type = exam_type;
        e.Exam_Name = exam_name;
        e.Avaliable = avaliable;
        e.Status_In_String = "(Not Avaliable)";
    //    e.Subject_Id = subject_id;
    //    e.Subject_Name = subject_name;
    //    e.Exam_Year =exam_year;
    //    e.Exam_Author = exam_author;
        Subject.Subjects[Subject_index].Subject_Exam.Add(e);
    }

    public static void recalculate_T_M(Exam e){
        e.Total_Mark=0;
        foreach (Question q in e.Questions_Of_Exam)
        {
            e.Total_Mark+=q.Fmark;
        }
    }

    public static void Add_Question(Question q,Exam e){
        
        e.Questions_Of_Exam.Add(q);
        e.Total_Mark += q.Fmark;
    }

    public static void Remove_Question(int index,Exam e){
        e.Questions_Of_Exam.RemoveAt(index);
        recalculate_T_M(e);
    
    }
    public static void Edit_Question(int index,Exam e){
        Question q=e.Questions_Of_Exam[index];
        string title ="what to edit";
        string[] options=
        {
            "Title",
            "Question text",
            "Answer",
            "Mark",
        };
        int choice=Arrow_Menu.arrow_meth(title,options,8);
        if(choice==0)
        {
            q.Title=Question.Edit_Title(q.Title);
        }
        else if(choice==1)
        {
            q.Question_Text=Question.Edit_Question_Text(q.Question_Text);
        }
        else if(choice==2)
        {
            Question.Edit_Answer(q.Answer);
        }
        else if(choice==3)
        {
            q.Fmark=Question.Edit_Fmark(q.Fmark);
            recalculate_T_M(e);
        }
    }
    public static void Attend_Exam(Exam e){
        
    }
    public static void Make_Edit_Exam(Exam e,int Subject_index){
        string title=$"Editing {e.Exam_Type} Exam {e.Exam_Name} > {e.Total_Mark}";
        string[]options=[
            "name",
            "Questions",
            $"status {e.Status_In_String}",
            "back"
        ];
        int choice_Editing_Exam=Arrow_Menu.arrow_meth(title,options,6);
        switch(choice_Editing_Exam){
            case 0:
                Exam.Edit_Exam_Name(e,Subject_index);
                break;
            case 1:
                Exam.Choose_Question_To_Edit(e,Subject_index);
                break;
            case 2:
                if(!e.Avaliable){
                    e.Avaliable=true;
                    e.Status_In_String="(Avaliable)";
                    Make_Edit_Exam(e,Subject_index);
                    break;
                }
                else if(e.Avaliable){
                    e.Avaliable=false;
                    e.Status_In_String="(Not Avaliable)";
                    Make_Edit_Exam(e,Subject_index);
                    break;
                }
                
                break;
            case 3:
                Subject.Proffesor_Show_Subject_Exams(Subject_index);
                break;
        }
    }
    public static void Edit_Exam_Name(Exam e,int Subject_index){
        Arrow_Menu.Title_Me("Editing exam Name",6);
        e.Exam_Name=Input_Handler.Read_Non_Empty_String("Enter Exam Name : ");
        Make_Edit_Exam(e,Subject_index);
    }
    public static void Choose_Question_To_Edit(Exam e,int Subject_index){
        string title="Question";
        string[] options=new string[e.Questions_Of_Exam.Count()+2];
        options[e.Questions_Of_Exam.Count()]="Add Question";
        options[e.Questions_Of_Exam.Count()+1]="Back";
        int i=0;
        foreach(Question q in e.Questions_Of_Exam)
        {
            options[i]=q.Title;
            i++;
        }
        i=0;
        int choice_Question=Arrow_Menu.arrow_meth(title,options,8);
        if (choice_Question== e.Questions_Of_Exam.Count()+1){
            Exam.Make_Edit_Exam(e,Subject_index);
        }
        else if (choice_Question== e.Questions_Of_Exam.Count()){
            Exam.Make_Question(e);
            Choose_Question_To_Edit(e,Subject_index);
        }
        else{
            Exam.Edit_Question(choice_Question,e);
            Choose_Question_To_Edit(e,Subject_index);
        }
    }
    public static void Make_Question(Exam e){
        Arrow_Menu.Title_Me("Making a question",5);
        string title = Input_Handler.Read_Non_Empty_String("Enter Question Title : ");
        string question= Input_Handler.Read_Non_Empty_String("Enter Question Text : ");
        int n_of_choices= Input_Handler.ReadInt("Enter the number of the choices : ");
        double fmark = Input_Handler.Read_Double("Enter the Mark of the question : ");
        Answer a = new Answer(n_of_choices);
        Answer.Edit_All_Choices(a);
        Question q = new Question(title,question,fmark,a);
        e.Questions_Of_Exam.Add(q);
        recalculate_T_M(e);
    }
}