using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata04
{
    public abstract class DataProcessor
    {
        private Func<string, string[]> lineProcessor;
        private Func<string[], string> dataEvaluator;

        public DataProcessor(Func<string, string[]> lineProcessor, Func<string[], string> dataEvaluator)
        {
            this.lineProcessor = lineProcessor;
            this.dataEvaluator = dataEvaluator;
        }

        public List<string[]> ParseDataFile(string dataPath)
        {
            List<string[]> inputData = new List<string[]>();

            using (StreamReader reader = new StreamReader(dataPath))
            {
                string inputLine = null;
                while ((inputLine = reader.ReadLine()) != null)
                {
                    if (!inputLine.Trim().Equals(string.Empty))
                    {
                        inputData.Add(lineProcessor(inputLine));
                    }
                }
            }

            return inputData;
        }

        public string EvaluateData(List<string[]> inputData)
        {
            string result = null;

            foreach (var dataRow in inputData)
            {
                result = dataEvaluator(dataRow);
            }

            return result;
        }
    }
}
