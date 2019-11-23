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
    public partial class Form4 : Form
    {
        public struct bank
        {
            public string id;
            public string pass;
            public string Yuan;
            public string ifm_num;
            public string time;
            public string life;
        }
        bank[] ID = new bank[10000];//=c++:struct bank ID[10000];
        string a, b, nn;
        int n, dq;

        private void Button4_Click(object sender, EventArgs e)
        {
            FileStream path0 = new FileStream("D:\\1\\lan1.txt", FileMode.Open, FileAccess.Read);
            StreamReader s0 = new StreamReader(path0);
            for (int i = 0; i < n; i++)
            {
                ID[i].id = s0.ReadLine();
                ID[i].pass = s0.ReadLine();
                ID[i].Yuan = s0.ReadLine();
                ID[i].ifm_num = s0.ReadLine();
                ID[i].time = s0.ReadLine();
                ID[i].life = s0.ReadLine();
            }
            s0.Close();
            string ifmm = "您当前的余额: " + ID[dq].Yuan + " 元。";
            MessageBox.Show(ifmm);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form6 fm6 = new Form6();
            fm6.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form7 fm7 = new Form7();
            fm7.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Form10 frm10 = new Form10();
            frm10.Show();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Form4()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form5 fm5 = new Form5();
            fm5.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            pictureBox1.SendToBack();
            FileStream path2 = new FileStream("D:\\1\\lan1num.txt", FileMode.Open, FileAccess.Read);
            StreamReader s2 = new StreamReader(path2);
            nn = s2.ReadLine();
            n = int.Parse(nn);
            s2.Close();
            FileStream path0 = new FileStream("D:\\1\\lan1.txt", FileMode.Open, FileAccess.Read);
            StreamReader s0 = new StreamReader(path0);
            for (int i = 0; i < n; i++)
            {
                ID[i].id = s0.ReadLine();
                ID[i].pass = s0.ReadLine();
                ID[i].Yuan = s0.ReadLine();
                ID[i].ifm_num = s0.ReadLine();
                ID[i].time = s0.ReadLine();
                ID[i].life = s0.ReadLine();
            }
            //textBox2.Text = ID[0].Yuan;
            s0.Close();
            FileStream path1 = new FileStream("D:\\1\\dq.txt", FileMode.Open, FileAccess.Read);
            StreamReader s1 = new StreamReader(path1);
            nn = s1.ReadLine();
            dq = int.Parse(nn);
            s1.Close();
        }
    }
}
