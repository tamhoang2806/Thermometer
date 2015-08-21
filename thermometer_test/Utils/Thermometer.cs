using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thermometer_test.Utils
{
    class Thermometer
    {
        private List<Temperature> temperatures;
        private string mainUnit;
        private Temperature threshold;
        private Temperature fluctuation;
        private int direction;
        public Thermometer()
        {
            temperatures = new List<Temperature>();
            direction = 0;
        }

        /*
         * Set the temperate list
         */
        public void setTemperatures(List<Temperature> temperatures)
        {
            this.temperatures = temperatures;
        }

        /*
         * Get the temperature list
         */
        public List<Temperature> getTemperatures()
        {
            return temperatures;
        }

        /*
         * Set main Unit
         */
        public void setMainUnit(string mainUnit)
        {
            this.mainUnit = mainUnit;
        }

        /*
         * Get main Unit
         */
        public string getMainUnit()
        {
            return mainUnit;
        }

        /*
         * Process Temperature Data and return the list of output strings
         */
        public List<string> processTemperaturesData()
        {
            bool fromCtoF = isConvertedFromCtoF();
            bool isfluctuated = false;
            List<string> output = new List<string>();
            for (int i = 0; i < temperatures.Count; i++)
            {
                string outputString = "Threshold reached at line number " + temperatures[i].getLineNumber().ToString();
                temperatures[i] = getCorrectCovertedData(temperatures[i]);
                decimal currTemperature = temperatures[i].getDegree();
                // get the treshold temperature
                decimal thresholdTemperature = threshold.getDegree();
                // if the current temperature is the same with the threshold temperature
                if (currTemperature == thresholdTemperature)
                {
                    if (i == 0 && direction == 0)
                    {
                        output.Add(outputString);
                        continue;
                    }
                    decimal previousTemperature = temperatures[i - 1].getDegree();
                    decimal diff = previousTemperature - currTemperature;

                    // if direction is 0 or we have right direction
                    if (direction == 0 || (diff * direction > 0))
                    {
                        if (fluctuation == null)
                        {
                            output.Add(outputString);
                            continue;
                        }
                        decimal absDiff = Math.Abs(diff);
                        decimal fluctuationDegree = fluctuation.getDegree();
                        bool ispreviFluc = absDiff <= fluctuationDegree;
                        bool isafterFluc = false;
                        if (i < temperatures.Count - 1)
                        {
                            temperatures[i + 1] = getCorrectCovertedData(temperatures[i + 1]);
                            decimal afterAbsDiff = Math.Abs(temperatures[i + 1].getDegree() - currTemperature);
                            isafterFluc = afterAbsDiff <= fluctuationDegree;
                        }
                        // if the absolute difference between the previous one and the current one is less than fluctuation
                        if (ispreviFluc || isafterFluc)
                        {
                            if (!isfluctuated)
                            {
                                output.Add(outputString);
                                isfluctuated = true;
                            }
                            continue;
                        }
                        else
                        {
                            output.Add(outputString);
                            isfluctuated = false;
                        }
                    }

                }
            }
            return output;
        }

        /*
         * Update the data of temperate to have same unit and converted degree associated with the unit
         */
        private Temperature getCorrectCovertedData(Temperature temperature)
        {
            if (!checkUnit(temperature.getUnit()))
            {
                bool fromCtoF = isConvertedFromCtoF();
                decimal newTemperature = temperature.convertTemperature(fromCtoF);
                temperature.setDegree(newTemperature);
                temperature.setUnit(mainUnit);
            }
            return temperature;
        }

        /*
         * Check if the unit is the same with main unit
         */
        private bool checkUnit(string unit)
        {
            return String.Equals(mainUnit, unit, StringComparison.OrdinalIgnoreCase);
        }

        private bool isConvertedFromCtoF()
        {
            if (String.Equals(mainUnit, "C", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            return true;
        }

        public void setThreshold(Temperature threshold)
        {
            this.threshold = getCorrectCovertedData(threshold);
        }

        public void setFluctuation(Temperature fluctuation)
        {
            this.fluctuation = getCorrectCovertedData(fluctuation);
        }

        public void setDirection(int direction)
        {
            this.direction = direction;
        }
    }
}
