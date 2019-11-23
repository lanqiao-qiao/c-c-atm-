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
    public partial class Form7 : Form
    {
        int n, dq, num = 0, page, dq_page=1;
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
        string[] str = new string[10000];
        string a, b, nn, num_s;

        private void Button1_Click(object sender, EventArgs e)
        {
            if(dq_page==1)
            {
                MessageBox.Show("已是第一页!");
                return;
            }
            label2.Text = "";
            //textBox1.Clear();
            dq_page--;
            for (int i = (dq_page - 1) * 5; i < dq_page * 5; i++)
            {
                //textBox1.Text += str[i] + Environment.NewLine;
                label2.Text += str[i] + Environment.NewLine;
            }
            label1.Text = "当前 第" + dq_page.ToString() + "页 共" + page.ToString() + "页。";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (dq_page==page)
            {
                MessageBox.Show("已是最后一页!");
                return;
            }
            label2.Text = "";
            dq_page++;
            //textBox1.Clear();
            for (int i = (dq_page - 1) * 5; i < dq_page * 5; i++)
            {
                //textBox1.Text += str[i] + Environment.NewLine;
                label2.Text += str[i] + Environment.NewLine;
            }
            label1.Text = "当前 第" + dq_page.ToString() + "页 共" + page.ToString() + "页。";
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            label2.Text = "";
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

            FileStream path = new FileStream("D:\\1\\"+ID[dq].id+".txt", FileMode.Open, FileAccess.Read);
            StreamReader s = new StreamReader(path);
            for(int i=0;i<int.Parse(ID[dq].ifm_num);i++)
            {
                str[i]= s.ReadLine();
            }
            page = (int.Parse(ID[dq].ifm_num) - 1) / 5+1;
            label1.Text = "当前 第" + dq_page.ToString() + "页 共" + page.ToString() + "页。";
            for(int i=(dq_page-1)*5;i<dq_page*5;i++)
            {
                //textBox1.Text += str[i] + Environment.NewLine;
                label2.Text += str[i] + Environment.NewLine;
            }
            s.Close();
        }
    }
}
