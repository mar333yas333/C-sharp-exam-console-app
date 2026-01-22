public class Exam
{   
    public static int ids=0;
    public int id; 
    public int Subject_id;
    public string Subject_name;
    public string Exam_type;
    public double Total_Mark=0;
    public List<Question> Questions_Of_Exam = new List<Question>();
    
    public Exam(int subject_id, string subject_name, string exam_type)
    {
        id = ++ids;
        Subject_id = subject_id;
        Subject_name = subject_name;
        Exam_type = exam_type;

    }

    public void Add_Question(Question q)
    {
        questions.Add(q);
        Total_Mark += q.Fmark;
    }

    public void Remove_Question(int index)
    {
        
    }
}