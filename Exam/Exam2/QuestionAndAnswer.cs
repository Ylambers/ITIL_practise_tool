using System;
using System.Collections.Generic;
using System.Text;

namespace Exam2
{
    /// <summary>
    /// Defines a class that represents an question with the answers
    /// </summary>
    public class QuestionAndAnswer
    {
        /// <summary>
        /// Gets or Sets the question
        /// </summary>
        public string Question { get; private set; }

        /// <summary>
        /// Gets or Sets answer A
        /// </summary>
        public string AnswerA { get; private set; }

        /// <summary>
        /// Gets or Sets answer B
        /// </summary>
        public string AnswerB { get; private set; }

        /// <summary>
        /// Gets or Sets answer C
        /// </summary>
        public string AnswerC { get; private set; }

        /// <summary>
        /// Gets or Sets answer D
        /// </summary>
        public string AnswerD { get; private set; }

        /// <summary>
        /// Gets or Sets the correct answer
        /// </summary>
        public string CorrectAnswer { get; private set; }

        /// <summary>
        /// Create an instance of <see cref="QuestionAndAnswer"/>
        /// </summary>
        /// <param name="question">The question asked</param>
        /// <param name="a">Answer of option A</param>
        /// <param name="b">Answer of option B</param>
        /// <param name="c">Answer of option C</param>
        /// <param name="d">Answer of option D</param>
        /// <param name="answer">The correct option</param>
        public QuestionAndAnswer(string question, string a, string b, string c, string d, string answer = "")
        {
            Question = question;
            AnswerA = $"A: {a}";
            AnswerB = $"B: {b}";
            AnswerC = $"C: {c}";
            AnswerD = $"D: {d}";
            CorrectAnswer = $"Correct Answer: {answer}";
        }
    }
}
