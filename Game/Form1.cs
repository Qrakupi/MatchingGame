using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Game
{
    public partial class Form1 : Form
    {
        private char[] symbols;
        private Control[] labels = new Control[16];
        private Control prevClicked;
        private Form2 resultBoard = new Form2();
        private int count;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labels = new Control[16]{ label1, label2,label3,label4,label5,label6,label7,label8,
                label9,label10,label11,label12,label13,label14,label15,label16 };
        }
        private void startPreparation()
        {
            textBox1.Enabled = false;
            button1.Enabled = false;
            symbols = new char[16];
            count = 0;
            labels.ToList().ForEach(x=>x.Text="");
            Random randomGenerator = new Random();
            char symbolToAdd;
            int indexToAdd;

            for (int i = 0; i < 8; i++)
            {
                symbolToAdd = (char)randomGenerator.Next(97, 122);
                if (!symbols.Contains(symbolToAdd))
                {
                    for (int b = 0; b < 2; b++)
                    {
                        indexToAdd = randomGenerator.Next(0, 16);
                        if (symbols[indexToAdd] == 0)
                        {
                            symbols[indexToAdd] = symbolToAdd;
                        }
                        else
                        {
                            b--;
                        }
                    }
                }
                else
                {
                    i--;
                }
            }
            timer1.Start();
        }
        
        private void checkForEquall(Control element)
        {
            int index = element.TabIndex;
            if (prevClicked == null)
            {
                prevClicked = element;
                element.Text = symbols[index].ToString();
                element.Enabled = false;
            }
            else
            {
                element.Text = symbols[index].ToString();
                WaitTwoSec();
                foreach (Control label in labels)
                {
                    label.Enabled = true;
                }
                if (!prevClicked.Text.Equals(symbols[index].ToString()))
                {
                    prevClicked.Text = null;
                    element.Text = null;
                    prevClicked.Enabled = true;
                    prevClicked = null;
                }
                else
                {
                    symbols = symbols.Select(x => {
                        if (symbols[index] == x)
                        {
                            return ' ';
                        }
                        else {
                            return x;
                        }
                    }).ToArray(); 
                    element.Enabled = false;
                    prevClicked.Enabled = false;
                    prevClicked = null;
                    if (CheckIfEmpty())
                    {
                        timer1.Stop();
                        textBox1.Enabled = true;
                        button1.Enabled = true;
                    }
                }
            }
        }
        private bool CheckIfEmpty()
        {
            foreach(char symbol in symbols)
            {
                if (symbol != ' ')
                {
                    return false;
                }
            }
            return true;
        }
        private void WaitTwoSec()
        {
            foreach (Control label in labels)
            {
                label.Enabled = false;
            }
            Thread.Sleep(1000);
            count += 10;
            foreach (Control label in labels)
            {
                label.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            label19.Text = string.Format("{0:0.0}", (count / 10d));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resultBoard.AddResult(textBox1.Text, count);
            resultBoard.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            startPreparation();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            checkForEquall(label1);
        }
        private void label2_Click(object sender, EventArgs e)
        {
            checkForEquall(label2);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            checkForEquall(label3);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            checkForEquall(label4);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            checkForEquall(label5);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            checkForEquall(label6);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            checkForEquall(label7);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            checkForEquall(label8);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            checkForEquall(label9);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            checkForEquall(label10);
        }

        private void label11_Click(object sender, EventArgs e)
        {
            checkForEquall(label11);
        }

        private void label12_Click(object sender, EventArgs e)
        {
            checkForEquall(label12);
        }

        private void label13_Click(object sender, EventArgs e)
        {
            checkForEquall(label13);
        }

        private void label14_Click(object sender, EventArgs e)
        {
            checkForEquall(label14);
        }

        private void label15_Click(object sender, EventArgs e)
        {
            checkForEquall(label15);
        }

        private void label16_Click(object sender, EventArgs e)
        {
            checkForEquall(label16);
        }

    }
}
