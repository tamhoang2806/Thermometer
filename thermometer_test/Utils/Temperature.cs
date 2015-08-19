using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thermometer_test.Utils
{
    class Temperature
    {
        public float temperatureDegree;
        public string temperatureUnit;
        public Temperature()
        {
        }
        public Temperature(float temperatureDegree, string temperatureUnit)
        {
            this.temperatureDegree = temperatureDegree;
            this.temperatureUnit = temperatureUnit;
        }

        public float getDegree()
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

        public void convertSetTemperature(bool cToF)
        {
            float temperature;
            if (cToF)
            {
                temperature = UnitsConversion.CelsiustoFahrenheit(temperatureDegree);
            }
            else
            {
                temperature = UnitsConversion.FahrenheittoCelsius(temperatureDegree);
            }
            this.temperatureDegree = temperature;
        }


    }
}
