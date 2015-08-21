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
        public InputHandler()
        {
        }

        /*
         * Get file content and produce the list of temperatures and main unit
         */
        public Tuple<List<Temperature>, string> getFileContent(Stream inputFileStream)
        {
            List<Temperature> temperatures = new List<Temperature>();
            int celsiusUnits = 0;
            int fahrenheitUnits = 0;
            StreamReader inputReader = new StreamReader(inputFileStream);
            int lineNumber = 0;
            while (!inputReader.EndOfStream)
            {
                lineNumber++;
                string inputLine = inputReader.ReadLine();
                if (!string.IsNullOrEmpty(inputLine))
                {
                    Temperature temperature = processFileContent(inputLine);
                    string unit = temperature.getUnit();
                    bool isCelsius = String.Equals(unit, "C", StringComparison.OrdinalIgnoreCase);
                    bool isFahrenheit = String.Equals(unit, "F", StringComparison.OrdinalIgnoreCase);
                    if (isCelsius || isFahrenheit)
                    {
                        temperatures.Add(temperature);
                        celsiusUnits += isCelsius ? 1 : 0;
                        fahrenheitUnits += isFahrenheit ? 1 : 0;
                    }
                    temperature.setLineNumber(lineNumber);
                }
            }
            string mainUnit;
            if (celsiusUnits >= fahrenheitUnits)
            {
                mainUnit = "c";
            }
            else
            {
                mainUnit = "f";
            }
            return new Tuple<List<Temperature>, string>(temperatures, mainUnit);
        }
        
        /*
         * Split up the temperature and unit
         */
        private Temperature processFileContent(string fileContentLine)
        {
            string[] splittedWords = System.Text.RegularExpressions.Regex.Split(fileContentLine, @"\s{1,}");
            string unit = splittedWords[1].Trim().ToLower();

            decimal temperature = Math.Round(decimal.Parse(splittedWords[0]), 2);
            return new Temperature(temperature, unit);
        }
    }
}
