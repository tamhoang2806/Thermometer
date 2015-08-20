using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thermometer_test.Utils
{
    class Temperature
    {
        public decimal temperatureDegree;
        public string temperatureUnit;
        public int lineNumber;
        public Temperature()
        {
        }
        public Temperature(decimal temperatureDegree, string temperatureUnit)
        {
            this.temperatureDegree = temperatureDegree;
            this.temperatureUnit = temperatureUnit;
            lineNumber = 0;
        }

        public decimal getDegree()
        {
            return temperatureDegree;
        }

        public string getUnit()
        {
            return temperatureUnit;
        }
        public void setUnit(string unit)
        {
            this.temperatureUnit = unit;
        }

        public decimal convertSetTemperature(bool cToF)
        {
            decimal temperature;
            if (cToF)
            {
                temperature = CelsiustoFahrenheit(temperatureDegree);
            }
            else
            {
                temperature = FahrenheittoCelsius(temperatureDegree);
            }
            temperature = Math.Round(temperature, 2);
            return temperature;
        }

        public void setLineNumber(int lineNumber)
        {
            this.lineNumber = lineNumber;
        }

        public int getLineNumber()
        {
            return this.lineNumber;
        }
        /*
        *  Convert Celsius to Fahrenheit 
        */
        public decimal CelsiustoFahrenheit(decimal celsiusDegree)
        {
            decimal fahrenheitDegree = (celsiusDegree * 1.8M) + 32.0M;
            return fahrenheitDegree;
        }

        /*
         *  Convert Fahrenheit to Celsius 
         */
        public decimal FahrenheittoCelsius(decimal fahrenheitDegree)
        {
            decimal celsiusDegree = (fahrenheitDegree - 32.0M) / 1.8M;
            return celsiusDegree;
        }

    }
}
