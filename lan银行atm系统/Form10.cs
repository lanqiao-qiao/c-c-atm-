using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lan银行atm系统
{
    public partial class Form10 : Form
    {
        double a, b;
        bool c;
        string d;
        public Form10()
        {
            InitializeComponent();
        }


        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "2";
            label1.Text += "2";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "3";
            label1.Text += "3";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "4";
            label1.Text += "4";
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "5";
            label1.Text += "5";
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "6";
            label1.Text += "6";
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "7";
            label1.Text += "7";
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "8";
            label1.Text += "8";
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "9";
            label1.Text += "9";
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "0";
            label1.Text += "0";
          
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            c = true;
            b = double.Parse(textBox1.Text);
            d = "+";
            label1.Text += "+";
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            c = true;
            b = double.Parse(textBox1.Text);
            d = "-";
            label1.Text += "-";
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            c = true;
            b = double.Parse(textBox1.Text);
            d = "*";
            label1.Text += "*";
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            c = true;
            b = double.Parse(textBox1.Text);
            d = "/";
            label1.Text += "/";
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            switch (d)
            {
                case "+": a = b + double.Parse(textBox1.Text);
                    break;
                case "-": a = b - double.Parse(textBox1.Text);
                    break;
                case "*": a = b * double.Parse(textBox1.Text);
                    break;
                case "/":
                    if(textBox1.Text=="0")
                    {
                        textBox1.Clear();
                        label1.Text = "";
                        MessageBox.Show("除数不能为零", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        a = b / double.Parse(textBox1.Text);
                    break;
                case "gen":a = Math.Sqrt(double.Parse(textBox1.Text));
                    break;
                case "^":a = Math.Pow(b, double.Parse(textBox1.Text));
                    break;
            }

            textBox1.Text = a + "";
            label1.Text += "= "+ a;
            c = true;
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label1.Text = "";
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            c = true;
            b = double.Parse(textBox1.Text);
            d = "gen";
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += ".";
            label1.Text += ".";
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            //label1.Text += "1";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Right;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否关闭计算器?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            c = true;
            b = double.Parse(textBox1.Text);
            d = "^";
            label1.Text += "^";
        }

        private void Button1_Click(object sender, EventArgs e)//1
        {
            if (c == true)
            {
                textBox1.Text = "";
                label1.Text = "";
                c = false;
            }
            textBox1.Text += "1";
            label1.Text += "1";
        }
    }
}
