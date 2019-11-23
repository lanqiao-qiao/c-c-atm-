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
    public partial class Form5 : Form
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

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("输入信息不能为空!");
                return;
            }
            string money = textBox1.Text;
            int mon = int.Parse(money);
            int sum = int.Parse(ID[dq].Yuan);
            sum += mon;
            ID[dq].Yuan=sum.ToString();
            int num = int.Parse(ID[dq].ifm_num);
            num++;
            ID[dq].ifm_num = num.ToString();
            string del = "D:\\1\\lan1.txt";
            File.Delete(del);
            File.AppendAllText(del,"");
            FileStream path = new FileStream("D:\\1\\lan1.txt", FileMode.Append, FileAccess.Write);
            StreamWriter s1 = new StreamWriter(path);
            for(int i=0;i<n;i++)
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
            string ifm1 = "存钱 ";
            string ifm2 = money;
            ifm2 += "¥"; 
            int l = 12;
            int l2 = ifm2.Length;
            l = l - l2;
            for(int i=0;i<l;i++)
            {
                ifm2 += " ";
            }
            string ifm3 = ID[dq].Yuan;
            l = 12;
            int l3 = ifm3.Length;
            l = l - l3;
            ifm3 += "¥";
            for(int i=0;i<l;i++)
            {
                ifm3 += " ";
            }
            string ifm4 = strYMD;
            string ifm5 = strT;
            string ifm = ifm1 + " " + ifm2 + ifm3 + ifm4 +" "+ ifm5+"\n";
            File.AppendAllText("D:\\1\\"+ID[dq].id + ".txt", ifm);
            //textBox2.Text = ifm;
            MessageBox.Show("存取成功!");
            this.Hide();

        }

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
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
