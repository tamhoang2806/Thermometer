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
        public Form1()
        {
            InitializeComponent();
            thermometer = new Thermometer();
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
                        Tuple<List<Temperature>, string> fileData = ih.getFileContent(inputFileStream);
                        thermometer.setTemperatures(fileData.Item1);
                        thermometer.setMainUnit(fileData.Item2);
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
            Temperature threshold = setTemperatureData(tempThreshold, celsiusRadioBtn2.Checked);
            if (threshold == null)
            {
                MessageBox.Show("Threshold is not set", "No threshold", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            thermometer.setThreshold(threshold);

            Temperature fluctuation = setTemperatureData(tempFluctuation, celsiusRadioBtn1.Checked);
            thermometer.setFluctuation(fluctuation);

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

            //List<Temperature> temperatures = thermometer.getTemperatures();
            //foreach(Temperature temp in temperatures)
            //{
            //    System.Diagnostics.Debug.WriteLine(temp.getDegree() + " " + temp.getUnit() + " " + temp.getLineNumber());

            //}
            System.Diagnostics.Debug.WriteLine(thermometer.mainUnit);

            List<string> output = thermometer.processTemperaturesData();
            OutputHandler oh = new OutputHandler();
            oh.printOutResult(output, resultTextBox);

        }

        private Temperature setTemperatureData(TextBox textbox, bool isCelsius)
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
            } catch(FormatException) {
                MessageBox.Show("Text box value needs to be a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            decimal temperature = Math.Round(temperatureNumber, 2);
            string unit = isCelsius ? "c" : "f";
            return new Temperature(temperature, unit);
        }
    }
}
