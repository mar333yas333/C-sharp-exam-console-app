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
        Answer a)
    {
        id = ++ids;
        Title=title;
        Question_Text= question;
        Answer=a;
        Fmark=fmark;
    }
    public static string Edit_Title(string title)
    {
        
            Arrow_Menu.Title_Me("Editing Title",8);
            title=Input_Handler.Read_Non_Empty_String($"  Old Title : {title}/n  New Title : ");
            return title;  
        
    }
    public static string Edit_Question_Text(string question_text)
    {
        
        
            Arrow_Menu.Title_Me("Edititng Question Text",8);
            question_text=Input_Handler.Read_Non_Empty_String($"  Old Text : {question_text}/n  New Text : ");
            return question_text;
        
    }

    public static void Edit_Answer(Answer a)
    {
        Arrow_Menu.Title_Me("Editing answer of the question",8);
        Answer.Edit_All_Choices(a);
    }

    public static double Edit_Fmark(double fmark)
    {
        
            Arrow_Menu.Title_Me("Editing Mark of the question",8);
            fmark=Input_Handler.Read_Double($"  Old Mark : {fmark}/n  New Mark : ");
            return fmark;
        
    }
}