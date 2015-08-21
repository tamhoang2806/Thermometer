using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using thermometer_test.Utils;

namespace thermometer_test
{
    public partial class Form1 : Form
    {
        Thermometer thermometer;
        Tuple<List<Temperature>, string> fileData;
        public Form1()
        {
            InitializeComponent();
        }

        private void openInputFile_Click(object sender, EventArgs e)
        {
            Stream inputFileStream;
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                    if ((inputFileStream = openFileDialog1.OpenFile()) != null)
                    {
                        InputHandler ih = new InputHandler();
                        fileData = ih.getFileContent(inputFileStream);
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Cannot open the file", "Cannot open the file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            // create list of temperatures from file data
            if (!handleFileData())
            {
                return;
            }

            // prepare threshold and fluctuation objs
            if (!prepareThresholdFluctuation())
            {
                return;
            }

            // prepare temperature direction
            prepareTemperatureDirection();

            List<string> output = thermometer.processTemperaturesData();
            OutputHandler oh = new OutputHandler();
            oh.printOutResult(output, resultTextBox);

        }

        /*
         * Get the temperature data from text box and radio buttons
         * Convert to the right unit and return temperature data
         */
        private Temperature setTemperatureData(TextBox textbox, bool isCelsius, bool isFluctuation)
        {
            string textboxText = textbox.Text;
            if (string.IsNullOrWhiteSpace(textboxText))
            {
                return null;
            }

            decimal temperatureNumber;
            try
            {
                temperatureNumber = decimal.Parse(textboxText);
            }
            catch (FormatException)
            {
                MessageBox.Show("Text box value needs to be a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            decimal temperature = Math.Round(temperatureNumber, 2);
            if (isFluctuation)
            {
                if (temperature == 0)
                {
                    MessageBox.Show("Fluctuation value needs to be non zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                temperature = Math.Abs(temperature);
            }
            string unit = isCelsius ? "c" : "f";
            return new Temperature(temperature, unit);
        }

        /*
         * Create list of temperatures and set main unit for thermometer object
         */
        private bool handleFileData()
        {
            if (fileData == null)
            {
                MessageBox.Show("No input data", "No input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            thermometer = new Thermometer();
            thermometer.setTemperatures(fileData.Item1);
            thermometer.setMainUnit(fileData.Item2);
            return true;
        }

        /*
         * Prepare threshold and fluctuation objects with correct unit data
         */
        private bool prepareThresholdFluctuation()
        {
            Temperature threshold = setTemperatureData(tempThreshold, celsiusRadioBtn2.Checked, false);
            if (threshold == null)
            {
                MessageBox.Show("Threshold is not set", "No threshold", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            thermometer.setThreshold(threshold);
            Temperature fluctuation = setTemperatureData(tempFluctuation, celsiusRadioBtn1.Checked, true);
            if (fluctuation != null)
            {
                thermometer.setFluctuation(fluctuation);
            }
            return true;
        }

        private void prepareTemperatureDirection()
        {
            int direction = 0;
            if (aboveRadioBtn.Checked)
            {
                direction = 1;
            }
            else if (belowRadioBtn.Checked)
            {
                direction = -1;
            }

            thermometer.setDirection(direction);
        }
    }
}
