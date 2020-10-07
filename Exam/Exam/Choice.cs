using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{
    public class Choice
    {
        public Choice(string choice)
        {
            AvailableChoice = choice;
        }

        public string AvailableChoice { get; set; }
    }
}
