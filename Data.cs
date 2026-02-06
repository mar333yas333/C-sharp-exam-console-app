
public static class Data
{
    public static void Call_Data()
    {
        // Create a professor user first
        User prof = new User("prof@uni.edu", "123", "proffesor");
        User.Current_User = prof; // Required for Subject constructor

        // Create subjects
        Subject subject1 = new Subject("C# Basics");
        Subject subject2 = new Subject("Data Structures");

        // Helper method to create questions
        Question CreateQuestion(string title, string text, double mark, string[] choices, string correct)
        {
            Answer a = new Answer(choices.Length);
            for (int i = 0; i < choices.Length; i++)
                a.All_Choices[i] = choices[i];
            a.Correct_Answer = correct;

            return new Question(title, text, mark, a);
        }

        // C# Basics Exams
        Exam practical1 = new Exam
        {
            Exam_Name = "C# Basics Practical",
            Exam_Type = "practical",
            Avaliable = true,
            Status_In_String = "(Available)"
        };
        practical1.Questions_Of_Exam.Add(CreateQuestion(
            "Question 1",
            "Which of these is a reference type in C#?",
            5,
            new string[] { "Class", "Struct", "Interface" },
            "Class"
        ));
        practical1.Questions_Of_Exam.Add(CreateQuestion(
            "Question 2",
            "Which keyword is used for inheritance in C#?",
            5,
            new string[] { "inherits", "extends", ":", "base" },
            ":"
        ));
        practical1.Questions_Of_Exam.Add(CreateQuestion(
            "Question 3",
            "Which of these is a value type in C#?",
            5,
            new string[] { "Class", "Struct", "Interface" },
            "Struct"
        ));
        practical1.Total_Mark = 15;

        Exam final1 = new Exam
        {
            Exam_Name = "C# Basics Final",
            Exam_Type = "final",
            Avaliable = true,
            Status_In_String = "(Available)"
        };
        final1.Questions_Of_Exam.Add(CreateQuestion(
            "Question 1",
            "Which keyword defines a constant in C#?",
            5,
            new string[] { "const", "readonly", "static" },
            "const"
        ));
        final1.Questions_Of_Exam.Add(CreateQuestion(
            "Question 2",
            "What is the default value of a bool type in C#?",
            5,
            new string[] { "true", "false", "null" },
            "false"
        ));
        final1.Questions_Of_Exam.Add(CreateQuestion(
            "Question 3",
            "Which method is entry point of a C# program?",
            5,
            new string[] { "Start()", "Main()", "Init()" },
            "Main()"
        ));
        final1.Total_Mark = 15;

        // Add exams to subject
        subject1.Subject_Exam.Add(practical1);
        subject1.Subject_Exam.Add(final1);

        // Data Structures Exams
        Exam practical2 = new Exam
        {
            Exam_Name = "Data Structures Practical",
            Exam_Type = "practical",
            Avaliable = true,
            Status_In_String = "(Available)"
        };
        practical2.Questions_Of_Exam.Add(CreateQuestion(
            "Question 1",
            "Which data structure uses FIFO?",
            5,
            new string[] { "Stack", "Queue", "Tree" },
            "Queue"
        ));
        practical2.Questions_Of_Exam.Add(CreateQuestion(
            "Question 2",
            "Which data structure is used in recursion?",
            5,
            new string[] { "Queue", "Stack", "Linked List" },
            "Stack"
        ));
        practical2.Questions_Of_Exam.Add(CreateQuestion(
            "Question 3",
            "Which structure stores elements in nodes with pointers?",
            5,
            new string[] { "Array", "Linked List", "Queue" },
            "Linked List"
        ));
        practical2.Total_Mark = 15;

        Exam final2 = new Exam
        {
            Exam_Name = "Data Structures Final",
            Exam_Type = "final",
            Avaliable = true,
            Status_In_String = "(Available)"
        };
        final2.Questions_Of_Exam.Add(CreateQuestion(
            "Question 1",
            "What is the height of a balanced binary tree with n nodes?",
            5,
            new string[] { "log(n)", "n", "n^2" },
            "log(n)"
        ));
        final2.Questions_Of_Exam.Add(CreateQuestion(
            "Question 2",
            "Which traversal is used in expression evaluation?",
            5,
            new string[] { "Inorder", "Preorder", "Postorder" },
            "Postorder"
        ));
        final2.Questions_Of_Exam.Add(CreateQuestion(
            "Question 3",
            "Which data structure is best for implementing priority queue?",
            5,
            new string[] { "Stack", "Heap", "Queue" },
            "Heap"
        ));
        final2.Total_Mark = 15;

        // Add exams to second subject
        subject2.Subject_Exam.Add(practical2);
        subject2.Subject_Exam.Add(final2);
    }
}
