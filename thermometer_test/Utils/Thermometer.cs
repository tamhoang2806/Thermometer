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
            bool[] fluctuationData = getFluctuationData();
            List<string> outputList = new List<string>();
            Dictionary<int, string> fluctuationMap = getFluctuationMap(fluctuationData);
            Dictionary<string, bool> outputMap = new Dictionary<string, bool>();
            for (int i = 0; i < temperatures.Count; i++)
            {
                string outputString = "Threshold reached at line number " + temperatures[i].getLineNumber().ToString();
                decimal currTemperature = temperatures[i].getDegree();
                // get the treshold temperature
                decimal thresholdTemperature = threshold.getDegree();
                // if the current temperature is the same with the threshold temperature
                if (currTemperature == thresholdTemperature)
                {
                    if (i == 0 && direction != 0)
                    {
                        // if this is the first item matched threshold but we have a direction, lets skip
                        continue;
                    }

                    decimal previousTemperature;
                    if (i == 0)
                    {
                        previousTemperature = 0;
                    }
                    else
                    {
                        previousTemperature = temperatures[i - 1].getDegree();
                    }
                    decimal diff = previousTemperature - currTemperature;

                    // if direction is 0 or we have right direction
                    if (direction == 0 || (diff * direction > 0))
                    {
                        // check if it is in fluctuation range
                        // no good to go
                        if (!fluctuationData[i])
                        {
                            outputList.Add(outputString);
                            continue;
                        }
                        else
                        {
                            // yes check if output already have the range
                            string mapKey = fluctuationMap[i];
                            if (!outputMap.ContainsKey(mapKey))
                            {
                                outputList.Add(outputString);
                                outputMap.Add(mapKey, true);
                                continue;
                            }

                        }
                    }

                }
            }
            return outputList;
        }

        /*
         * Get the fluctuation data array.
         */
        private bool[] getFluctuationData()
        {
            bool[] fluctuationData = new bool[temperatures.Count];
            for (int i = 0; i < temperatures.Count; i++)
            {
                temperatures[i] = getCorrectCovertedData(temperatures[i]);
                decimal currTemperature = temperatures[i].getDegree();
                // get the treshold temperature
                decimal thresholdTemperature = threshold.getDegree();
                // if the current temperature is the same with the threshold temperature
                if (currTemperature == thresholdTemperature)
                {
                    decimal fluctuationDegree = fluctuation.getDegree();
                    if (i < temperatures.Count - 1)
                    {
                        temperatures[i + 1] = getCorrectCovertedData(temperatures[i + 1]);
                        decimal afterAbsDiff = Math.Abs(temperatures[i + 1].getDegree() - currTemperature);
                        // if the difference with the number behind is below fluctuation degree
                        if (afterAbsDiff <= fluctuationDegree)
                        {
                            if (i < temperatures.Count - 2)
                            {
                                temperatures[i + 2] = getCorrectCovertedData(temperatures[i + 2]);
                                if (temperatures[i + 2].getDegree() == thresholdTemperature)
                                {
                                    fluctuationData[i] = true;
                                    fluctuationData[i + 2] = true;
                                    fluctuationData[i + 1] = true;
                                    continue;
                                }

                            }
                            if (temperatures[i + 1].getDegree() == thresholdTemperature)
                            {
                                fluctuationData[i] = true;
                                fluctuationData[i + 1] = true;
                                continue;
                            }
                        }
                    }
                }
            }
            return fluctuationData;

        }

        /*
         * Get the Dictionary for fluctuation range
         */
        private Dictionary<int, string> getFluctuationMap(bool[] fluctuationData)
        {
            int startRange = 0;
            int endRange = 0;
            int rangeNumber = 0;
            string rangeText;
            Dictionary<int, string> fluctuationMap = new Dictionary<int, string>();
            for (int i = 1; i < fluctuationData.Length; i++)
            {
                // if this is true but the previous one is false, this is the starting point of the fluctuation range
                if (fluctuationData[i])
                {
                    if (!fluctuationData[i - 1])
                    {
                        startRange = i;
                        rangeNumber++;
                    }
                }
                else
                {
                    if (fluctuationData[i - 1])
                    {
                        endRange = i - 1;
                        rangeText = startRange.ToString() + "_" + endRange.ToString();
                        for (int j = startRange; j <= endRange; j++)
                        {
                            // let's add to the map so we know what range the index is in
                            fluctuationMap.Add(j, rangeText);
                        }
                    }
                }
            }
            return fluctuationMap;
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
