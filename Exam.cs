public class Exam
{   
    public static int ids=0;
    public int id; 
    public int Subject_id;
    public string Subject_name;
    public string Exam_type;
    public string Exam_Year;
    public string Exam_Name;
    public double Total_Mark=0;
    public List<Question> Questions_Of_Exam = new List<Question>();
    
    public Exam(int subject_id, string subject_name,string exam_name, string exam_type)
    {
        id = ++ids;
        Subject_id = subject_id;
        Subject_name = subject_name;
        Exam_Name = exam_name;
        Exam_type = exam_type;
    }

    public void recalculate_T_M(Exam e)
    {
        e.Total_Mark=0;
        foreach (Question q in Questions_Of_Exam)
        {
            e.Total_Mark+=q.Fmark;
        }
    }

    public void Add_Question(Question q)
    {
        Questions_Of_Exam.Add(q);
        Total_Mark += q.Fmark;
    }

    public void Remove_Question(int index,Exam e)
    {
        e.Questions_Of_Exam.RemoveAt(index);
        recalculate_T_M(e);
    
    }
    public void Edit_Question(int index,Exam e)
    {
        Question q=Questions_Of_Exam[index];
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
    public static void Attend_Exam(int index){
        
    }
}