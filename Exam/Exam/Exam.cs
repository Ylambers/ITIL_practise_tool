using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Exam
{
    public class Exam
    {
        public List<Question> Questions;
        private readonly Random _random = new Random();

        public Exam()
        {
            Questions = new List<Question>();
            PopulateList();
        }

        /// <summary>
        /// Function that is called for question iteration
        /// </summary>
        public void TakeExam()
        {
            var length = Questions.Count;
            var random = RandomNumber(length);

            Console.WriteLine(Questions[random].AskedQuestion);
            foreach (var choice in Questions[random].Choices)
            {
                Console.WriteLine(choice.AvailableChoice);
            }

            Console.ReadLine();
            Console.WriteLine(Questions[random].CorrectAnswer);
        }

        /// <summary>
        /// Get random number
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        private int RandomNumber(int max)
        {
            int number;
            number = _random.Next(1, max);

            return number;
        }

        /// <summary>
        /// Populates list for iteration
        /// </summary>
        private void PopulateList()
        {
            try
            {
                var filename = "/questions.txt"; // LIB with the questions

                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName; // GETS PARRENT DIRECTORY OF PROJECT

                using (StreamReader sr = new StreamReader(projectDirectory + filename)) // LOAD questions 
                {
                    string line;
                    bool foundQuestion = false;

                    Question q = new Question();

                    while ((line = sr.ReadLine()) != null) // READ QUESTIONS
                    {
                        if (line.Contains("?")) // FIND asked QUESTION
                        {
                            q.AskedQuestion += " " + line;
                            foundQuestion = true;
                        }

                        if (!foundQuestion) // ADDS question to object
                        {
                            q.AskedQuestion += line;
                        }

                        // FIND ANWSERS
                        if (line.Contains("A.") || line.Contains("B.") || line.Contains("C.") || line.Contains("D."))
                        {
                            q.Choices.Add(new Choice(line));
                        }

                        // FIND CORRECT ANWSER
                        if (line.Contains("Correct"))
                        {
                            q.CorrectAnswer = line;
                            Questions.Add(q);

                            foundQuestion = false;

                            q = new Question(); // MAKES NEW QUESTION
                        }
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
