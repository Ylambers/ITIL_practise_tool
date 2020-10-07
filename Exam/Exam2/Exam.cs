using Exam2.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
        /// Setup the exam by creating the questions and answers
        /// </summary>
        private void SetupExan()
        {
            using Stream? questionsFile = EmbeddedResourceUtility.GetEmbeddedResourceStream("Exam2.questions.txt");
            if(questionsFile != null)
            {
                using StreamReader reader = new StreamReader(questionsFile);
                var questionsString = reader.ReadToEnd();
                var questionsAndAnswers = questionsString.Split(new string[] { "QUESTION ", "--" }, StringSplitOptions.RemoveEmptyEntries);

                foreach(var question in questionsAndAnswers)
                {
                    var items = question.Split(new string[] { "A.", "B.", "C.", "D.", "Correct Answer:" }, StringSplitOptions.RemoveEmptyEntries);

                    if(items.Length >= 5) // Questions and answers always contain over 5 items
                    {
                        _questionAndAnswers.Add(new QuestionAndAnswer(items[0], items[1], items[2], items[3], items[4], items.ElementAtOrDefault(5) ?? ""));
                    }
                }
            }
        }
    }
}
