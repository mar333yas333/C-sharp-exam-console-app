public class Exam{   
    public static int ids=0;
    public int id; 
    public string Exam_Type;
    public string Exam_Name;
    public string Status_In_String;
    public bool Avaliable;
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
            case 3:
                exam_type="custome";
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
    /*public static void Attend_Exam(Exam e,int Subject_index){
        if (e.Questions_Of_Exam.Count == 0){
            Show_Subject_Exams(Subject_Exam);
        }
        int Current_Question=0;
        int Current_Choice=0;

        int[] User_Answers = new int[e.Questions_Of_Exam.Count];
        for (int i = 0; i < User_Answers.Length; i++){
            answers[i] = -1;
        }

        while(true){
            Question q = e.Questions_Of_Exam[Current_Question];

            Console.Clear();
            string title = $"Exam: {e.Exam_Name} | Question {currentQuestion + 1}/{e.Questions_Of_Exam.Count}";
            Arrow_Menu.Title_Me(title, 6);
            Console.WriteLine(q.Question_Text);
            Console.WriteLine();

            for (int i = 0; i < q.Answer.Choices.Length; i++){
                if (i == currentChoice){
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"> {q.Answer.Choices[i]}");
                    Console.ResetColor();
                }
                else{
                    Console.WriteLine($"  {q.Answer.Choices[i]}");
                }
            }

            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow && currentChoice > 0){
                currentChoice--;
            }
            else if (key == ConsoleKey.DownArrow && currentChoice < q.Answer.Choices.Length - 1){
                currentChoice++;
            }
            else if (key == ConsoleKey.LeftArrow){
                if (currentQuestion > 0){
                    currentQuestion--;
                    currentChoice = answers[currentQuestion] == -1 ? 0 : answers[currentQuestion];
                }
            }
            else if (key == ConsoleKey.Enter){
                answers[currentQuestion] = currentChoice;
            }
            else if (key == ConsoleKey.Escape){
                Show_Subject_Exams(Subject_index);
            }
            bool finished = true;
            foreach (int a in answers){
                if (a == -1){
                    finished = false;
                    break;
                }
            }
            if (finished){
                break;
            }

            double score = 0;
            for(int i = 0; i < e.Questions_Of_Exam.Count; i++){
                Question q = e.Questions_Of_Exam[i];
                if (answers[i] == q.Answer.Correct_Index){
                    score += q.Fmark;
                }
            }

            int correctCount = 0;

            for (int i = 0; i < e.Questions_Of_Exam.Count; i++)
            {
                Question q = e.Questions_Of_Exam[i];
                if (answers[i] == q.Answer.Correct_Index)
                {
                    correctCount++;
                }
            }

            Arrow_Menu.Title_Me("Exam Result", 6);

            if (e.Exam_Type != "practical")
            {
                Console.WriteLine($"Score: {score} / {e.Total_Mark}");
            }

            Console.WriteLine($"Correct answers: {correctCount} / {e.Questions_Of_Exam.Count}");
            Console.WriteLine();

            for (int i = 0; i < e.Questions_Of_Exam.Count; i++)
            {
                Question q = e.Questions_Of_Exam[i];

                Console.WriteLine($"Q{i + 1}");
                Console.WriteLine(q.Question_Text);

                for (int j = 0; j < q.Answer.Choices.Length; j++)
                {
                    if (j == answers[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"{(char)('a' + j)}. {q.Answer.Choices[j]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"{(char)('a' + j)}. {q.Answer.Choices[j]}");
                    }
                }

                bool correct = answers[i] == q.Answer.Correct_Index;

                if (correct)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.Red;

                int c = q.Answer.Correct_Index;
                Console.WriteLine($"Correct answer: {(char)('a' + c)}. {q.Answer.Choices[c]}");
                Console.ResetColor();

                Console.WriteLine();
            }

            string historyEntry;

            if (e.Exam_Type == "practical")
            {
                historyEntry = $"Attended Exam {e.Exam_Name}";
            }
            else
            {
                historyEntry = $"Attended Exam {e.Exam_Name} and got {score}/{e.Total_Mark}";
            }

            User.Current_User.history.Add(historyEntry);
            
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
    }*/
    public static void Attend_Exam(Exam e,int Subject_index){
        if (e.Questions_Of_Exam.Count == 0){
            Subject.Show_Subject_Exams(Subject_index);
            return;
        }

        int Current_Question = 0;
        int Current_Choice = 0;

        int[] User_Answers = new int[e.Questions_Of_Exam.Count];
        for (int i = 0; i < User_Answers.Length; i++){
            User_Answers[i] = -1;
        }

        while(true){
            Question q = e.Questions_Of_Exam[Current_Question];

            Console.Clear();
            string title = $"Exam: {e.Exam_Name} | Question {Current_Question + 1}/{e.Questions_Of_Exam.Count}";
            Arrow_Menu.Title_Me(title,6);
            Console.WriteLine(q.Question_Text);
            Console.WriteLine();

            for (int i = 0; i < q.Answer.All_Choices.Length; i++){
                string prefix = "  ";

                if (i == Current_Choice){
                    prefix = "> ";
                }

                if (User_Answers[Current_Question] == i){
                    prefix += "# ";
                }
                else{
                    prefix += "  ";
                }

                if (i == Current_Choice){
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{prefix}{q.Answer.All_Choices[i]}");
                    Console.ResetColor();
                }
                else{
                    Console.WriteLine($"{prefix}{q.Answer.All_Choices[i]}");
                }
            }


            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow && Current_Choice > 0){
                Current_Choice--;
            }
            else if (key == ConsoleKey.DownArrow && Current_Choice < q.Answer.All_Choices.Length - 1){
                Current_Choice++;
            }
            else if (key == ConsoleKey.LeftArrow){
                if (Current_Question > 0){
                    Current_Question--;
                    Current_Choice = User_Answers[Current_Question] == -1 ? 0 : User_Answers[Current_Question];
                }
            }
            else if (key == ConsoleKey.RightArrow){
                if (Current_Question < e.Questions_Of_Exam.Count - 1){
                    Current_Question++;
                    Current_Choice = User_Answers[Current_Question] == -1 ? 0 : User_Answers[Current_Question];
                }
            }
            else if (key == ConsoleKey.Enter){
                User_Answers[Current_Question] = Current_Choice;
            }
            else if (key == ConsoleKey.Escape){
                Subject.Show_Subject_Exams(Subject_index);
                return;
            }

            bool finished = true;
            foreach (int a in User_Answers){
                if (a == -1){
                    finished = false;
                    break;
                }
            }
            if (finished){
                break;
            }
        }

        double score = 0;
        int correctCount = 0;

        for(int i = 0; i < e.Questions_Of_Exam.Count; i++){
            Question q = e.Questions_Of_Exam[i];
            int ansIndex = User_Answers[i];

            if (ansIndex != -1){
                string chosen = q.Answer.All_Choices[ansIndex];
                if (chosen == q.Answer.Correct_Answer){
                    score += q.Fmark;
                    correctCount++;
                }
            }
        }

        Console.Clear();
        Arrow_Menu.Title_Me("Exam Result",6);

        if (e.Exam_Type != "practical"){
            Console.WriteLine($"Score: {score} / {e.Total_Mark}");
        }

        Console.WriteLine($"Correct answers: {correctCount} / {e.Questions_Of_Exam.Count}");
        Console.WriteLine();

        for (int i = 0; i < e.Questions_Of_Exam.Count; i++){
            Question q = e.Questions_Of_Exam[i];

            Console.WriteLine($"Q{i + 1}");
            Console.WriteLine(q.Question_Text);

            for (int j = 0; j < q.Answer.All_Choices.Length; j++){
                if (j == User_Answers[i]){
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{(char)('a' + j)}. {q.Answer.All_Choices[j]}");
                    Console.ResetColor();
                }
                else{
                    Console.WriteLine($"{(char)('a' + j)}. {q.Answer.All_Choices[j]}");
                }
            }

            bool correct = false;
            int ansIndex = User_Answers[i];

            if (ansIndex != -1){
                string chosen = q.Answer.All_Choices[ansIndex];
                correct = chosen == q.Answer.Correct_Answer;
            }

            if (correct)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"Correct answer: {q.Answer.Correct_Answer}");
            Console.ResetColor();

            Console.WriteLine();
        }

        string historyEntry;

        if (e.Exam_Type == "practical"){
            historyEntry = $"Attended Exam {e.Exam_Name} of Subject {Subject.Subjects[Subject_index].Subject_Name}";
        }
        else{
            historyEntry = $"Attended Exam {e.Exam_Name} of Subject {Subject.Subjects[Subject_index].Subject_Name} and got {score}/{e.Total_Mark}";
        }

        User.Current_User.history.Add(historyEntry);

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

        Subject.Show_Subject_Exams(Subject_index);
    }


    public static void Make_Edit_Exam(Exam e,int Subject_index){
        string title=$"Editing {e.Exam_Type} Exam {e.Exam_Name} > {e.Total_Mark}";
        string[]options=[
            "name",
            "Questions",
            $"status {e.Status_In_String}",
            "remove exam",
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
                Subject.Subjects[Subject_index].Subject_Exam.Remove(e);
                Subject.Proffesor_Show_Subject_Exams(Subject_index);
                break;
            case 4:
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