Okay, let’s make it **bulletproof and simple** for GitHub. The main problem is usually **line breaks and Markdown syntax**. Here’s a version you can safely paste into your `README.md` that won’t “cumble” and is visually clean on GitHub:

````markdown
# CIS.edu Console Exam Application

A C# console-based application for managing subjects, exams, and users (students & professors).  
Professors can create subjects and exams, while students can attend exams with real-time scoring and history tracking.

---

## Installation

1. Install [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) or later.
2. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/C-sharp-exam-console-app.git
````

3. Navigate to the project folder:

   ```bash
   cd C-sharp-exam-console-app
   ```

4. Run the application:

   ```bash
   dotnet run
   ```

---

## Usage

* **Sign Up** or **Log In** to start.
* **Exit** is available at the main menu to safely end the session without closing your environment.
* **Professors** can:

  * Create subjects
  * Add exams (Practical or Final)
  * Add questions (MCQ or True/False)
  * Edit exams and questions
* **Students** can:

  * View subjects
  * Attend available exams
  * See history of attended exams

---

## How to Attend Exams

1. Go to **My Subjects** → select a subject → select an **available exam**.
2. Exam navigation:

   * **Up / Down Arrow:** Move between choices
   * **Left Arrow:** Go to previous question
   * **Right Arrow:** Go to next question
   * **Enter:** Select current choice
   * **Escape:** Exit exam and return to subject menu
3. After finishing all questions:

   * Your **score** is calculated automatically.
   * Correct answers are shown in **green**; incorrect answers in **red**.
   * Exam attempt is saved in your **History** menu.

---

## Features

* Dynamic user creation (student/professor)
* Add subjects and exams at runtime
* Add/edit/remove questions
* Practical (MCQ only) or Final (MCQ + True/False) exams
* Track scores and history per student
* Console-based navigation with arrow keys

---

## Contributing

* Open issues or submit pull requests.
* Keep console output clean and follow coding standards.
* Add descriptive comments for new features.

---
