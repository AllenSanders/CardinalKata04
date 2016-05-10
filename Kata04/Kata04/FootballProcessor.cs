using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata04
{
    public class FootballProcessor : DataProcessor
    {
        private static string teamName = null;
        private static int minDiff = int.MaxValue;

        private static string[] ProcessRowOfFootball(string inputLine)
        {
            string[] rawDataRow = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return (rawDataRow.Length == 10) ? new string[] { rawDataRow[1], rawDataRow[6], rawDataRow[8] } : 
                new string[] { string.Empty, string.Empty, string.Empty };
        }

        private static string CheckMinimumGoalsDiff(string[] dataRow)
        {
            int forGoals = 0;
            int againstGoals = 0;

            if (int.TryParse(dataRow[1], out forGoals) && int.TryParse(dataRow[2], out againstGoals))
            {
                int rowDiff = Math.Abs(forGoals - againstGoals);
                if (rowDiff < minDiff)
                {
                    teamName = dataRow[0];
                    minDiff = rowDiff;
                }
            }

            return $"{teamName} had the smallest difference in For/Against goals at {minDiff}";
        }

        public FootballProcessor() : base(ProcessRowOfFootball, CheckMinimumGoalsDiff)
        { }
    }
}
