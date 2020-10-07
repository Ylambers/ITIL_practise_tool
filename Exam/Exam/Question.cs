using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{
    public class Question
    {
        public string AskedQuestion { get; set; }

        public List<Choice> Choices = new List<Choice>();

        public string CorrectAnswer { get; set; }

    }
}
