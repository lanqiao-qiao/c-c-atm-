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
    public partial class Form6 : Form
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
        string a, b, nn,num_s;
        int n, dq,num=0;

        private void Button4_Click(object sender, EventArgs e)
        {
            num += 400;
            num_s = num.ToString();
            label1.Text = num_s + "¥";
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            num += 500;
            num_s = num.ToString();
            label1.Text = num_s + "¥";
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            num += 1000;
            num_s = num.ToString();
            label1.Text = num_s + "¥";
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            num_s = textBox1.Text;
            num+= int.Parse(num_s);
            num_s = num.ToString();
            label1.Text = num_s + "¥";
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            label1.Text = "0" + "¥";
            textBox1.Text="";
            num = 0;
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            int yuan = int.Parse(ID[dq].Yuan);
            if(yuan<num)
            {
                MessageBox.Show("你的余额不足，请重新输入!");
                return;
            }
            yuan -= num;
            ID[dq].Yuan = yuan.ToString();
            int ifmnum = int.Parse(ID[dq].ifm_num);
            ifmnum++;
            ID[dq].ifm_num = ifmnum.ToString();
            string del = "D:\\1\\lan1.txt";
            File.Delete(del);
            File.AppendAllText(del, "");
            FileStream path = new FileStream("D:\\1\\lan1.txt", FileMode.Append, FileAccess.Write);
            StreamWriter s1 = new StreamWriter(path);
            for (int i = 0; i < n; i++)
            {
                s1.WriteLine(ID[i].id);
                s1.WriteLine(ID[i].pass);
                s1.WriteLine(ID[i].Yuan);
                s1.WriteLine(ID[i].ifm_num);
                s1.WriteLine(ID[i].time);
                s1.WriteLine(ID[i].life);
            }
            s1.Flush();
            s1.Close();

            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
            string strYMD = currentTime.ToString("d");
            string strT = currentTime.ToString("t");
            string ifm1 = "取钱 ";
            string ifm2 = num_s;
            ifm2 += "¥";
            int l = 12;
            int l2 = ifm2.Length;
            l = l - l2;
            for (int i = 0; i < l; i++)
            {
                ifm2 += " ";
            }
            string ifm3 = ID[dq].Yuan;
            l = 12;
            int l3 = ifm3.Length;
            l = l - l3;
            ifm3 += "¥";
            for (int i = 0; i < l; i++)
            {
                ifm3 += " ";
            }
            string ifm4 = strYMD;
            string ifm5 = strT;
            string ifm = ifm1 + " " + ifm2 + ifm3 + ifm4 +" "+ifm5 + "\n";
            File.AppendAllText("D:\\1\\" + ID[dq].id + ".txt", ifm);

            MessageBox.Show("取钱成功，请拿好你的现金，离开柜台遗失概不负责!");
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            num += 300;
            num_s = num.ToString();
            label1.Text = num_s + "¥";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            num += 200;
            num_s = num.ToString();
            label1.Text = num_s+ "¥";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            num += 100;
            num_s = num.ToString();
            label1.Text = num_s + "¥";
        }

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
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
