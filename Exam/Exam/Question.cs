using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{
    public class Question
    {
        public Question()
        {
            choices =  new List<Choice>();
        }

        public string askedQuestion { get; set; }

        public List<Choice> choices;

        public string correctAnswer { get; set; }

    }
}
