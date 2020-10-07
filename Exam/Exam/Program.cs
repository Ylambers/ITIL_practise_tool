using System;
using System.Collections.Generic;
using System.IO;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            Header.Message();

            Exam e = new Exam();

            var exit = Console.ReadLine();
            do
            {
                Console.Clear();
                e.TakeExam();

                if (Console.ReadLine() == "exit")
                {
                    exit = null;
                }
            } while (exit != null);
            
        }
    }
}
