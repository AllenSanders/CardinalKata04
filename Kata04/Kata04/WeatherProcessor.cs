using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata04
{
    public class WeatherProcessor : DataProcessor
    {
        private static int minDayNumber = int.MinValue;
        private static double minSpread = double.MaxValue;

        private static string[] ProcessRowOfWeather(string inputLine)
        {
            string[] rawDataRow = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            // TODO: Evaluate assumptions about structure of data - what if first three data values not always populated?
            return rawDataRow.Take(3).ToArray();
        }

        private static string CheckMinimumTempSpread(string[] dataRow)
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

            return $"Day #{minDayNumber} had the smallest temperature spread at {minSpread:F2}";
        }

        public WeatherProcessor() : base(ProcessRowOfWeather, CheckMinimumTempSpread)
        { }
    }
}
