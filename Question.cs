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
    public string Edit_Title(string title)
    {
        while(true)
        {
            Arrow_Menu.Title_Me("Editing Title",8);
            title=Input_Handler.Read_Non_Empty_String($"  Old Title : {title}/n  New Title : ");
            return title;  
        }
    }
    public string Edit_Question_Text(string question_text)
    {
        while(true)
        {
            Arrow_Menu.Title_Me("Edititng Question Text",8);
            question_text=Input_Handler.Read_Non_Empty_String($"  Old Title : {title}/n  New Title : ");
            return question_text;
        }
    }
    Public double Edit_Fmark(double fmark)
    {
        while(true)
        {
            Arrow_Menu.Title_Me("Editing Mark of the question",8);
            fmark=Read_Double($"  Old Mark : {fmark}/n  New Mark : ");
            return fmark;
        }
    }
}