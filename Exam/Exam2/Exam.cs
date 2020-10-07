using Exam2.Extensions;
using Exam2.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Exam2
{
    /// <summary>
    /// Defines a class that presents an exam
    /// </summary>
    public class Exam
    {
        /// <summary>
        /// <see cref="List{T}"/> containing all questions and answers used in the exam
        /// </summary>
        private readonly List<QuestionAndAnswer> _questionAndAnswers = new List<QuestionAndAnswer>();

        /// <summary>
        /// Create a new instance of <see cref="Exam"/>
        /// </summary>
        public Exam()
        {
            SetupExan();
        }

        /// <summary>
        /// Starts the exam
        /// </summary>
        public void StartExam()
        {
            Console.WriteLine("Starting the exam, would you like the question to be shuffled? (y/n)");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                _questionAndAnswers.Shuffle();
            }
            Console.WriteLine("Press Escape at any time to exit");

            foreach (var questionAndAnswer in _questionAndAnswers)
            {
                Console.WriteLine("\r\n\r\n");
                Console.WriteLine($"{questionAndAnswer.Question} \r\n {questionAndAnswer.AnswerA} \r\n {questionAndAnswer.AnswerB} \r\n {questionAndAnswer.AnswerC} \r\n {questionAndAnswer.AnswerD}");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
                Console.WriteLine(questionAndAnswer.CorrectAnswer);
            }
        }

        /// <summary>
        /// Setup the exam by creating the questions and answers
        /// </summary>
        private void SetupExan()
        {
            using var questionsFile = EmbeddedResourceUtility.GetEmbeddedResourceStream("Exam2.questions.txt");
            if (questionsFile != null)
            {
                using var reader = new StreamReader(questionsFile);
                var questionsString = reader.ReadToEnd();
                questionsString = Regex.Replace(questionsString, @"\r\n?|\n", " ");
                var questionsAndAnswers = questionsString.Split(new string[] { "QUESTION ", "--" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var question in questionsAndAnswers)
                {
                    var items = question.Split(new string[] { "A.", "B.", "C.", "D.", "Correct Answer:" }, StringSplitOptions.RemoveEmptyEntries);

                    if (items.Length >= 5) // Questions and answers always contain over 5 items
                    {
                        _questionAndAnswers.Add(new QuestionAndAnswer(items[0], items[1], items[2], items[3], items[4], items.ElementAtOrDefault(5) ?? ""));
                    }
                }
            }
        }
    }
}
