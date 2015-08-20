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
        public int direction;
        public Thermometer()
        {
            temperatures = new List<Temperature>();
            direction = 0;
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

        public List<string> processTemperaturesData()
        {
            bool fromCtoF = isConvertedFromCtoF();
            bool isfluctuated = false;
            List<string> output = new List<string>();
            for (int i = 0; i < temperatures.Count; i++)
            {
                decimal temperature = temperatures[i].getDegree();
                string outputString = "Threshold reached at line number" + temperatures[i].getLineNumber().ToString();
                string temperatureUnit = temperatures[i].getUnit();
                if (!checkUnit(temperatureUnit))
                {
                    // convert the temperature to the main unit
                    temperature = temperatures[i].convertSetTemperature(fromCtoF);
                }

                decimal thresholdTemperature = threshold.getDegree();

                if (temperature == thresholdTemperature)
                {
                    if (i == 0)
                    {
                        output.Add(outputString);
                        continue;
                    }
                    decimal previousTemperature = temperatures[i - 1].getDegree();
                    decimal diff = previousTemperature - temperature;
                    decimal absDiff = Math.Abs(diff);
                    if (direction == 0 || (diff * direction > 0))
                    {
                        if (fluctuation == null)
                        {
                            output.Add(outputString);
                            continue;
                        }
                        decimal fluctuationDegree = fluctuation.getDegree();

                        if (absDiff <= fluctuationDegree)
                        {
                            if (!isfluctuated)
                            {
                                output.Add(outputString);
                                isfluctuated = true;
                            }
                        }
                        else
                        {
                            isfluctuated = false;
                        }
                    }

                }
            }
            return output;
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
                return false;
            }
            return true;
        }

        public void setThreshold(Temperature threshold)
        {
            this.threshold = threshold;
        }

        public void setFluctuation(Temperature fluctuation)
        {
            this.fluctuation = fluctuation;
        }

        public void setDirection(int direction)
        {
            this.direction = direction;
        }
    }
}
