using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form2 : Form
    {
        private SortedDictionary<int, string> topResults = new SortedDictionary<int, string>();
        private Control[] labels = new Control[20];
        public Form2()
        {
            InitializeComponent();
            labels = new Control[20]{label1,label2,label3,label4,label5,label6,label7,label8,label9,label10,
            label11,label12,label13,label14,label15,label16,label17,label18,label19,label20};
        }
        public void AddResult(string name, int time)
        {
            topResults.Add(time, name);
            ReprintResults();
        }
        public void ReprintResults()
        {
            int labelCounter = 0;
            foreach (KeyValuePair<int, string> result in topResults)
            {
                labels[labelCounter].Text = result.Value;
                labelCounter++;
                labels[labelCounter].Text = (result.Key).ToString();
                labelCounter++;
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
