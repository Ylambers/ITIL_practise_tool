using System;
using System.Collections.Generic;
using System.IO;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Exam e = new Exam();

            var exit = Console.ReadLine();
            do
            {
                Console.Clear();
                e.takeExam();

                if (Console.ReadLine() == "exit")
                {
                    exit = null;
                }
            } while (exit != null);
            
        }
    }
}
