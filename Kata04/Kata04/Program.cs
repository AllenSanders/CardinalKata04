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

            try
            {
                dataPath = GetPathToFile();
                inputData = WeatherProcessor.ParseDataFile(dataPath);
                Console.WriteLine(WeatherProcessor.EvaluateData(inputData));
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
    }
}
