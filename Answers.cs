public class Answer
{
    static int ids =0;
    int id;
    string Correct_answer;
    string[] All_choices;
    
    public Answer(string correct_answer,string[] all_choices)
    {
        id = ++ids;
        Correct_answer = correct_answer;
        All_choices = (string[])all_choices.Clone();
    }
}