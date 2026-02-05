public class Answer
{
    static int ids =0;
    int id;
    string Correct_Answer;
    string[] All_Choices;
    
    public Answer(int length)
    {
        id = ++ids;
        All_Choices = new string[length];
    }
    public static void Edit_All_Choices(Answer a)
    {   
        Arrow_Menu.Title_Me("Enter All Choices",8);
        for(int i=0;i<a.All_Choices.Length;i++)
        {   
            char x=(char)('a'+i);
            string title=$"{x}. ";
            a.All_Choices[i]=Input_Handler.Read_Non_Empty_String(title);
        }
        Console.Clear();
        a.Correct_Answer=Answer.Edit_Correct_Answer(a);
    }
    public static string Edit_Correct_Answer(Answer a)
    {
        int choice=Arrow_Menu.arrow_meth("Choose The Answer Of The Question",a.All_Choices,7);
        return a.All_Choices[choice];
    }
}