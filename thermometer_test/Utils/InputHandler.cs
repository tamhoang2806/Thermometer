using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace thermometer_test.Utils
{
    class InputHandler
    {
        public List<float> getFileContent(Stream inputFileStream)
        {
            StreamReader inputReader = new StreamReader(inputFileStream);
            List<float> degrees = new List<float>();
            while (!inputReader.EndOfStream)
            {
                string inputLine = inputReader.ReadLine();
                if (!string.IsNullOrEmpty(inputLine))
                {
                    Tuple<float, string> processedContent = processFileContent(inputLine);
                    string unit = processedContent.Item2;

                    if (String.Equals(unit, "C", StringComparison.OrdinalIgnoreCase) == true 
                        || String.Equals(unit, "F", StringComparison.OrdinalIgnoreCase) == true)
                    {
                        degrees.Add(processedContent.Item1);
                    }
                }
            }
            System.Diagnostics.Debug.Write(degrees);
            return degrees;
        }

        private Tuple<float,string> processFileContent(string fileContentLine)
        {
            string[] splittedWords = System.Text.RegularExpressions.Regex.Split(fileContentLine, @"\s{1,}");
            float degree = float.Parse(splittedWords[0]);
            string unit = splittedWords[1];

            return new Tuple<float, string>(degree, unit);
        }
    }
}
