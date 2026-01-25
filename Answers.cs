public class Answer
{
    static int ids =0;
    int id;
    string Correct_Answer;
    string[] All_Choices;
    
    public Answer(string correct_answer,string[] all_choices)
    {
        id = ++ids;
        Correct_Answer = correct_answer;
        All_Choices = (string[])all_choices.Clone();
    }
    public void Edit_All_Choices(Answer a)
    {   
        Arrow_Menu.Title_Me("Enter All Choices",8);
        for(int i=0;i<a.Length();i++)
        {   
            char x='a'+i;
            title=$"{x}. ";
            a.All_Choices.[i]=Input_Handler.Read_Non_Empty_String(title);
        }
        Console.Clear();
        a.Correct_Answer=Answer.Edit_Correct_Answer(Answer a);
    }
    public string Edit_Correct_Answer(Answer a)
    {
        int choice=Arrow_Menu.arrow_meth("Choose The Answer Of The Question",a.All_Choices);
        return All_Choices.[choice]
    }
}