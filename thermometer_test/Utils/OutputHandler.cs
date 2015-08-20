using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thermometer_test.Utils
{
    class OutputHandler
    {
        public OutputHandler()
        {
        }

        public void printOutResult(List<string> resultStrings, TextBox textbox)
        {
            foreach (string resultString in resultStrings)
            {
                textbox.AppendText(resultString + Environment.NewLine);
            }
        }
    }
}
