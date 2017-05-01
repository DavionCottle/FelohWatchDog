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
using System.Configuration;

namespace SimulationDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime lastfilefound = DateTime.Now;
            using (System.IO.StreamWriter filepath = new StreamWriter(ConfigurationManager.AppSettings["InOutReadFile"]))
            {
                filepath.WriteLine(lastfilefound.ToString());
            }
        }
    }
}
