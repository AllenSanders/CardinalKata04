using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata04
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataPath = null;
            List<string[]> inputData = new List<string[]>();

            Console.WriteLine("Let's MUNGE some data!!");
            Console.WriteLine("****************************************************************");

            DataProcessor processor = null;

            try
            {
                dataPath = GetPathToFile();
                switch (GetProcessingSelection())
                {
                    case "w":
                        processor = new WeatherProcessor();
                        break;
                    case "f":
                        processor = new FootballProcessor();
                        break;
                }
                inputData = processor.ParseDataFile(dataPath);
                Console.WriteLine(processor.EvaluateData(inputData));
            }
            catch (Exception e)
            {
                // TODO: Log something "tech-y" here to help IT troubleshoot root cause
                Console.WriteLine("Error encountered while trying to process input data - please contact IT for assistance");
            }
        }

        private static string GetPathToFile()
        {
            string dataPath = null;
            bool inputIsInvalid = false;

            do
            {
                Console.Write("Please provide full path to source data: ");
                dataPath = Console.ReadLine();
                if (inputIsInvalid = !File.Exists(dataPath))
                {
                    Console.WriteLine("Please specify a valid path!");
                }
            } while (inputIsInvalid);

            return dataPath;
        }

        private static string GetProcessingSelection()
        {
            string selection = null;
            bool inputIsInvalid = false;

            do
            {
                Console.WriteLine("Please type of processing:");
                Console.WriteLine("(W)eather Processing");
                Console.WriteLine("(F)ootball Processing");
                Console.Write("Please enter 'W' or 'F': ");
                selection = Console.ReadLine();
                if (inputIsInvalid = (selection.ToLower() != "w" && selection.ToLower() != "f"))
                {
                    Console.WriteLine("Please enter 'W' or 'F'!");
                }
            } while (inputIsInvalid);

            return selection.ToLower();
        }
    }
}
