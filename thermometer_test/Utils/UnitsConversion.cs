using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thermometer_test.Utils
{
    class UnitsConversion
    {
        /*
         *  Convert Celsius to Fahrenheit 
         */
        public float CelsiustoFahrenheit(float celsiusDegree)
        {
            float fahrenheitDegree = (celsiusDegree * 1.8f) + 32.0f;
            return fahrenheitDegree;
        }

        /*
         *  Convert Fahrenheit to Celsius 
         */
        public float FahrenheittoCelsius(float fahrenheitDegree)
        {
            float celsiusDegree = (fahrenheitDegree - 32.0f)/1.8f;
            return celsiusDegree;
        }
    }
}
