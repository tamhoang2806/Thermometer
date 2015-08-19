using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thermometer_test.Utils
{
    class Thermometer
    {
        public List<Temperature> temperatures;
        public string mainUnit;
        public Temperature threshold;
        public Temperature fluctuation;
        public Thermometer()
        {
            temperatures = new List<Temperature>();
            threshold = new Temperature();
            fluctuation = new Temperature();
        }

        public void setTemperatures(List<Temperature> temperatures)
        {
            this.temperatures = temperatures;
        }

        public List<Temperature> getTemperatures()
        {
            return temperatures;
        }

        public void setMainUnit(string mainUnit)
        {
            this.mainUnit = mainUnit;
        }

        public void processTemperaturesData()
        {
            bool fromCtoF = isConvertedFromCtoF();
            for (int i = 0; i < temperatures.Count; i++)
            {
                string temperatureUnit = temperatures[i].getUnit();
                if (checkUnit(temperatureUnit))
                {
                    // convert the temperature to the main unit
                    temperatures[i].convertSetTemperature(fromCtoF);
                    temperatures[i].setUnit(mainUnit);
                }
                float temperature = temperatures[i].getDegree();


                System.Diagnostics.Debug.WriteLine(temperatures[i].getDegree());
                System.Diagnostics.Debug.WriteLine(temperatures[i].getUnit());
            }
            System.Diagnostics.Debug.WriteLine(mainUnit);
        }

        public void updateCorrectThreshold()
        {
            if (!checkUnit(threshold.getUnit()))
            {
                bool fromCtoF = isConvertedFromCtoF();
                threshold.convertSetTemperature(fromCtoF);
                threshold.setUnit(mainUnit);
            }
        }

        public void updateCorrectFluctuation()
        {
            if (!checkUnit(fluctuation.getUnit()))
            {
                bool fromCtoF = isConvertedFromCtoF();
                fluctuation.convertSetTemperature(fromCtoF);
                fluctuation.setUnit(mainUnit);
            }
        }

        public bool checkUnit(string unit)
        {
            return String.Equals(mainUnit, unit, StringComparison.OrdinalIgnoreCase);
        }

        public bool isConvertedFromCtoF()
        {
            if (String.Equals(mainUnit, "C", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        public void setThreshold(Temperature threshold)
        {
            this.threshold = threshold;
        }

        public void setFluctuation(Temperature fluctuation)
        {
            this.fluctuation = fluctuation;
        }
    }
}
