using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thermometer_test.Utils
{
    class Temperature
    {
        private decimal temperatureDegree;
        private string temperatureUnit;
        private int lineNumber;
        public Temperature()
        {
        }

        public Temperature(decimal temperatureDegree, string temperatureUnit)
        {
            this.temperatureDegree = temperatureDegree;
            this.temperatureUnit = temperatureUnit;
            lineNumber = 0;
        }

        /*
         * Get temperature degree
         */
        public decimal getDegree()
        {
            return temperatureDegree;
        }

        /*
         * Set temperature degree
         */
        public void setDegree(decimal degree)
        {
            this.temperatureDegree = degree;
        }

        /*
         * Get temperature unit
         */
        public string getUnit()
        {
            return temperatureUnit;
        }

        /*
         * Set temperature unit
         */
        public void setUnit(string unit)
        {
            this.temperatureUnit = unit;
        }

        /*
         * Set line number
         */
        public void setLineNumber(int lineNumber)
        {
            this.lineNumber = lineNumber;
        }

        /* 
         * Get line number
         */
        public int getLineNumber()
        {
            return this.lineNumber;
        }

        /*
         * Convert the temperature
         * If cToF is true, convert from Celsius to Fahrenheit
         */
        public decimal convertTemperature(bool cToF)
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
