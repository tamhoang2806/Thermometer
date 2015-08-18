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
                        ih.getFileContent(inputFileStream);
                    }
                }
                catch (IOException)
                {
                }
            }
        }
    }
}
