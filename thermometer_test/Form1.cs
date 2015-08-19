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
                }
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            Temperature threshold = setTemperatureData(tempThreshold, celsiusRadioBtn2.Checked);
            thermometer.setThreshold(threshold);

            Temperature fluctuation = setTemperatureData(tempFluctuation, celsiusRadioBtn1.Checked);
            thermometer.setFluctuation(fluctuation);

            //thermometer.processTemperaturesData();

        }

        private Temperature setTemperatureData(TextBox textbox, bool isCelsius)
        {
            float temperature = float.Parse(textbox.Text);
            string unit = isCelsius ? "c" : "f";
            return new Temperature(temperature, unit);
        }
    }
}
