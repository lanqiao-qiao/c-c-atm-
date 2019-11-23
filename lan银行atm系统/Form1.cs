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

namespace lan银行atm系统
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form2 fm2 = new Form2();
            fm2.Show();
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form3 fm3 = new Form3();
            fm3.Show();
            this.Hide(); ;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string directory = "D:\\1";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            string a = "D:\\1\\lan1.txt";
            string b = "D:\\1\\dq.txt";
            string c = "D:\\1\\lan1num.txt";
            File.AppendAllText(a, "");
            File.AppendAllText(b, "");
            File.AppendAllText(c, "");
        }
    }
}
