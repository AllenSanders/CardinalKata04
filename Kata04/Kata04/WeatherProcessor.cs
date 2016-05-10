using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata04
{
    public class WeatherProcessor
    {
        public static List<string[]> ParseDataFile(string dataPath)
        {
            List<string[]> inputData = new List<string[]>();

            using (StreamReader reader = new StreamReader(dataPath))
            {
                string inputLine = null;
                while ((inputLine = reader.ReadLine()) != null)
                {
                    if (!inputLine.Trim().Equals(string.Empty))
                    {
                        string[] rawDataRow = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        // TODO: Evaluate assumptions about structure of data - what if first three data values not always populated?
                        inputData.Add(rawDataRow.Take(3).ToArray());
                    }
                }
            }

            return inputData;
        }

        public static string EvaluateData(List<string[]> inputData)
        {
            int minDayNumber = int.MinValue;
            double minSpread = double.MaxValue;

            foreach (var dataRow in inputData)
            {
                int dayNumber = 0;
                double maxTemp = 0.0;
                double minTemp = 0.0;
                double rowSpread = double.MaxValue;
                if (int.TryParse(dataRow[0], out dayNumber))
                {
                    // TODO: Evaluate assumptions about presence of * at end of highest/lowest temps
                    dataRow[1] = dataRow[1].TrimEnd('*');
                    dataRow[2] = dataRow[2].TrimEnd('*');
                    if (double.TryParse(dataRow[1], out maxTemp) && double.TryParse(dataRow[2], out minTemp))
                    {
                        rowSpread = maxTemp - minTemp;
                        if (rowSpread < minSpread)
                        {
                            minDayNumber = dayNumber;
                            minSpread = rowSpread;
                        }
                    }
                }
            }

            return $"Day #{minDayNumber} had the smallest temperature spread at {minSpread:F2}";
        }
    }
}
