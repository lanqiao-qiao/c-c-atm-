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
using System.Security;

namespace lan银行atm系统
{
    public partial class Form2 : Form
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
        bank[] ID = new bank[10001];//=c++:struct bank ID[10000];
        string a, b,nn;
        int n,dq;
        public Form2()
        {
            InitializeComponent();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
            string strYMD = currentTime.ToString("d");
            string strT = currentTime.ToString("t");
            FileStream path0 = new FileStream("D:\\1\\lan1.txt", FileMode.Open, FileAccess.Read);
            StreamReader s0 = new StreamReader(path0);
            for(int i=0;i<n;i++)
            {
                ID[i].id = s0.ReadLine();
                ID[i].pass = s0.ReadLine();
                ID[i].Yuan = s0.ReadLine();
                ID[i].ifm_num = s0.ReadLine();
                ID[i].time = s0.ReadLine();
                ID[i].life = s0.ReadLine();
            }
            s0.Close();
            a = textBox1.Text;
            b = textBox2.Text;
            for(int i=0;i<n;i++)
            {
                if(a==ID[i].id)
                {
                    MessageBox.Show("账户名已存在!");
                    return;
                }
            }
            if(a.Length<9||a.Length>13)
            {
                MessageBox.Show("账户长度不符合要求!");
                return;
            }
            int pa = 0, pb = 0, pc = 0;
            for(int i=0;i<b.Length;i++)
            {
                if ((b[i] >= 'a' && b[i] <= 'z') || (b[i] >= 'S' && b[i] <= 'Z'))
                    pa = 1;
                if ((b[i] >= '0') && (b[i] <= '9'))
                    pb = 1;
                if (b[i] == '_')
                    pc = 1;
            }
            if(pa==0||pb==0||pc==0)
            {
                MessageBox.Show("密码必须包含字母数字下划线!");
                return;
            }
            if(b[b.Length-3]!='@')
            {
                MessageBox.Show("倒数第三位必须为'@'!");
                return;
            }
            ID[n].id = a;
            ID[n].pass = b;
            ID[n].Yuan = "0";
            ID[n].ifm_num = "0";
            ID[n].life = "0";
            ID[n].time = strYMD + " " + strT;
            dq = n;
            string dq_str = dq.ToString();
            string dq_load = "D:\\1\\dq.txt";
            File.WriteAllText(dq_load, dq_str);
            n++;
            //textBox3.Text = a + b+'0';
            FileStream path = new FileStream("D:\\1\\lan1.txt", FileMode.Append, FileAccess.Write);
            StreamWriter s1 = new StreamWriter(path);
            s1.WriteLine(a);
            s1.WriteLine(b);
            s1.WriteLine("0");
            s1.WriteLine("0");
            s1.WriteLine(ID[dq].time);
            s1.WriteLine("0");
            s1.Flush();
            s1.Close();
            /*FileStream path2 = new FileStream("D:\\lan1.txt", FileMode.Open, FileAccess.Read);
            StreamReader s2 = new StreamReader(path2);
            string c = s2.ReadLine();
            textBox3.Text = c;*/
            MessageBox.Show("您已注册成功");
            string ps = "D:\\1\\lan1num.txt";
            //string ps1 = "D:\\1\\lannum.txt";

            string aa= "D:\\1\\" + a + ".txt";
            //File.CreateText(aa);
            File.AppendAllText(aa, "");
            nn = n.ToString();
            File.WriteAllText(ps, nn);
          
            Form4 fm4 = new Form4();
            fm4.Show();
            this.Hide();
        }

        private string ToString(int n)
        {
            throw new NotImplementedException();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.SendToBack();
            FileStream path1 = new FileStream("D:\\1\\lan1num.txt", FileMode.Open, FileAccess.Read);
            StreamReader s1 = new StreamReader(path1);
            nn = s1.ReadLine();
            if (nn == null)
                n = 0;
            else
                n = int.Parse(nn);
            s1.Close();
        }
        
        
    }
}
