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
            Header.message();

            Questions = new List<Question>();
            populateList();
        }


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


        private int RandomNumber(int max)
        {
            int number;
            number = _random.Next(1, max);

            return number;
        }

        private void populateList()
        {
            try
            {
                var filename = "/questions.txt";

                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

                using (StreamReader sr = new StreamReader(projectDirectory + filename))
                {
                    string line;
                    bool foundQuestion = false;

                    Question q = new Question();

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains("?"))
                        {
                            q.AskedQuestion += " " + line;
                            foundQuestion = true;
                        }

                        if (!foundQuestion)
                        {
                            q.AskedQuestion += line;
                        }


                        if (line.Contains("A.") || line.Contains("B.") || line.Contains("C.") || line.Contains("D."))
                        {
                            q.Choices.Add(new Choice(line));
                        }


                        if (line.Contains("Correct"))
                        {
                            q.CorrectAnswer = line;
                            Questions.Add(q);

                            foundQuestion = false;

                            q = new Question();
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
