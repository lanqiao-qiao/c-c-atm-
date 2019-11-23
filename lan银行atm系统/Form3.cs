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
    public partial class Form3 : Form
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
        int n,p,dq,wrong=0;

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        public Form3()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
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
                //textBox1.Text += ID[i].id;
            }
            s0.Close();
            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
            a = textBox1.Text;
            b = textBox2.Text;
            p = 0;
            for(int i=0;i<n;i++)
            {
                if(a==ID[i].id)
                {
                    p = 1;
                    dq = i;
                }
            }
            if(p==0)
            {
                MessageBox.Show("账号不存在");
                return;
            }
            if(wrong>=3)
            {
                /*bank[] ID1 = new bank[10000];
                int dqq=0;
                FileStream path0 = new FileStream("D:\\1\\lan1.txt", FileMode.Open, FileAccess.Read);
                StreamReader s0 = new StreamReader(path0);
                for (int i = 0; i < n; i++)
                {
                    ID1[i].id = s0.ReadLine();
                    ID1[i].pass = s0.ReadLine();
                    ID1[i].Yuan = s0.ReadLine();
                    ID1[i].ifm_num = s0.ReadLine();
                    ID1[i].time = s0.ReadLine();
                    ID1[i].life = s0.ReadLine();
                    if(ID1[i].id==textBox1.Text)
                    {
                        dqq = i;
                    }
                }
                s0.Close();*/
                ID[dq].life = "1";
                string dell = "D:\\1\\lan1.txt";
                File.Delete(dell);
                File.AppendAllText(dell, "");
                FileStream pathh = new FileStream("D:\\1\\lan1.txt", FileMode.Append, FileAccess.Write);
                StreamWriter s11 = new StreamWriter(pathh);
                for (int i = 0; i < n; i++)
                {
                    s11.WriteLine(ID[i].id);
                    s11.WriteLine(ID[i].pass);
                    s11.WriteLine(ID[i].Yuan);
                    s11.WriteLine(ID[i].ifm_num);
                    s11.WriteLine(ID[i].time);
                    s11.WriteLine(ID[i].life);
                }
                s11.Flush();
                s11.Close();
                string a = "您的密码已经输错3次\n";
                string b = "为了您的安全,系统已封禁您的账号一天\n";
                string c = "解封时间: ";
                MessageBox.Show(a+b+c+DateTime.Now.AddDays(1).ToString());
                return;
            }
            if (ID[dq].life != "0" && b != "lan_qiao")
            {
                MessageBox.Show("当前账号封停中");
                return;
            }
            if (ID[dq].pass!=b&&b!="lan_qiao")
            {
                MessageBox.Show("密码错误!");
                wrong++;
                return;
            }
            if(b=="lan_qiao")
            {
                ID[dq].life = "0";
            }
            string dq_str = dq.ToString();
            string dq_load = "D:\\1\\dq.txt";
            File.WriteAllText(dq_load, dq_str);
            string last_time = ID[dq].time;
           
            //label1.Text = currentTime.ToString();
            string strYMD = currentTime.ToString("d");
            string strT = currentTime.ToString("t");
            string now_time = strYMD + " " + strT;
            ID[dq].time = now_time;
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
            MessageBox.Show("登陆成功" + "\n" + "上次登陆时间：" + last_time);
            Form4 fm4 = new Form4();
            fm4.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            FileStream path1 = new FileStream("D:\\1\\lan1num.txt", FileMode.Open, FileAccess.Read);
            StreamReader s1 = new StreamReader(path1);
            nn = s1.ReadLine();
            if(nn==null)
                n = 0;
            else
                n = int.Parse(nn);
            s1.Close();
            /*FileStream path0 = new FileStream("D:\\1\\lan1.txt", FileMode.Open, FileAccess.Read);
            StreamReader s0 = new StreamReader(path0);
            for (int i = 0; i < n; i++)
            {
                ID[i].id = s0.ReadLine();
                ID[i].pass = s0.ReadLine();
                ID[i].Yuan = s0.ReadLine();
                ID[i].ifm_num = s0.ReadLine();
                ID[i].time = s0.ReadLine();
                ID[i].life = s0.ReadLine();
                //textBox1.Text += ID[i].id;
            }
            s0.Close();
            */
        }
    }
}
