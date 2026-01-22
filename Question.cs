public class Question
{
    static int ids=0;
    public int id ;
    public string Title;
    public string Question_Text;
    public Answer Answer;
    public double Fmark;

    public Question(
        string title,string question,double fmark,
        string correct_answer,string[] all_choices)
    {
        id = ++ids;
        Title=title;
        Question_Text= question;
        Answer=new Answer(correct_answer,all_choices);
        Fmark=fmark;
    }
}