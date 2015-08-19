using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thermometer_test.Utils
{
    public class UnitsConversion
    {

        /*
         *  Convert Celsius to Fahrenheit 
         */
        public static float CelsiustoFahrenheit(float celsiusDegree)
        {
            float fahrenheitDegree = (celsiusDegree * 1.8f) + 32.0f;
            return fahrenheitDegree;
        }

        /*
         *  Convert Fahrenheit to Celsius 
         */
        public static float FahrenheittoCelsius(float fahrenheitDegree)
        {
            float celsiusDegree = (fahrenheitDegree - 32.0f) / 1.8f;
            return celsiusDegree;
        }

    }
}
