#include <iostream>
#include <windows.h>
#include <fstream>
#include <cstdlib>
#include <iomanip>
#define N 10000
using namespace std;
class bank
{
public:
	char id[20];
	char pass[20];
	int ifm_num;
	int lost_money;
	int ppp;
	SYSTEMTIME syss;
	bank();
};
bank id[N];
int n, dq;
bank::bank()
{
	
}
void display1();
void displa2();
void main1(int ns);
void main2(int ns);
void loadnum();
void loadid();
void addid();
void inputid();
void saveid();
void savenum();
void login();
void in_Yuan();
void printmoney();
void out_Yuan();
void print_list();
void jisuan();
int isrun(int n);//判断是否为闰年 
bool cmp(string a, string b);   //判断字符串大小
string sum(string a, string b); //加法运算
string sub(string a, string b); //减法运算
//void test1();

int main()
{
	while (1)
	{
		display1();
	}
}
bool cmp(string a, string b)
{
	//判断a，b 两个字符串大小如果a大返回true
	if (a.size() > b.size())
		return true;
	if (a.size() < b.size())
		return false;
	for (int i = 0; i < a.size(); i++)
	{
		if (a[i] == b[i])
			continue;
		else if (a[i] > b[i])
			return true;
		else
			return false;
	}
	return false;    //当a == b时;
}

string sum(string a, string b)
{
	//计算位数如果a小交换两个值
	if (a.size() < b.size())
	{//三段式
		string t;
		t = a;
		a = b;
		b = t;
	}
	int len;//用来记录a、b的长度差
	len = a.size() - b.size();
	for (int i = 0; i < len; i++)         //给小的字符串不断加零使得两个字符串长度相同
		b = '0' + b;
	bool flag = false; //用来当满十进一的 进位 1
	int tmp;
	string ans;
	for (int i = a.size() - 1; i >= 0; i--)
	{
		tmp = (a[i] - '0') + (b[i] - '0') + flag;//对每一位使其先从字符数组变成数字数组
		if (tmp > 9)                           //然后进行单个下标中数字的加减法
		{
			tmp -= 10;          //位数超过10之后减十位留个位
			flag = true;
		}
		else
			flag = false;       //当相加之后不超过十 使得flag等于0
		ans = (char)(tmp + '0') + ans;
	}
	if (flag)            //看计算结果是否有进位当flag = true时候执行
		ans = '1' + ans;
	return ans;     //返回加法结果
}


string sub(string a, string b)
{
	bool f = false;
	if (a[0] != '-' && a.size() >= b.size())   // a不是负数并且a大于等于b
		f = true;     //代表减法结果的正负
	if (a[0] == '-' && a.size() <= b.size())// a是负数并且a小于等于b
		f = true;

	if (a[0] == '-')
	{
		string temp1;
		temp1 = a;
		a = b;
		b = temp1;
	}

	if (a.size() + 1 < b.size())   //少位减多位一位的情况
	{
		string temp2;//经典三段式交换二者的值
		temp2 = a;
		a = b.substr(1, b.size());  //除去符号位后复制到最后一位的值，赋值给a
		b = temp2;
	}
	// 同位数相减
	if (a.size() + 1 == b.size() && !cmp(a, b.substr(1, b.size())))  //!cmp(a, b.substr(1, b.size())) 的值为0
	{
		string temp3;
		temp3 = a;
		a = b.substr(1, b.size());
		b = temp3;
	}

	if (b[0] == '-')
		b = b.substr(1, b.size());
	//这时a, b都没有负号，且a是较大的那个， b是较小的那个
	int Len = a.size() - b.size();
	for (int i = 0; i < Len; i++)
		b = '0' + b;              //给小的字符串不断加零使得两个字符串长度相同
	bool flag = false;    //借位位
	int tp;
	string ans;
	for (int i = a.size() - 1; i >= 0; i--)
	{
		tp = a[i] - b[i] - flag;
		if (tp < 0)
		{
			tp += 10;       //高位向低位借w位
			flag = true;
		}
		else                //不借！！！！
			flag = false;
		ans = (char)(tp + '0') + ans;
	}
	if (f)
		return ans;
	else
		return '-' + ans;
}
void display1()
{
	system("cls");
	cout << "*****欢迎使用龙龙银行ATM取款机*****" << endl;
	cout << "-----------------------------------" << endl;
	cout << "请选择对应的功能 :" << endl;
	cout << "→1:用户注册" << endl;
	cout << "→2:用户登录" << endl;
	cout << "→3:退出系统" << endl;
	int n1;
	cin >> n1;
	main1(n1);
}
void display2()
{
	Sleep(100);
	system("cls");
	cout << "请选择您要执行的操作" << endl;
	cout << "1:存储现金" << endl;
	cout << "2:取出现金" << endl;
	cout << "3:收支明细" << endl;
	cout << "4:查询余额" << endl;
	cout << "5:临时计算" << endl;
	cout << "6:退出至登录" << endl; 
	int n2;
	cin >> n2;
	main2(n2);
}
void jisuan()
{
	string num1, num2;
	cout << "please input two numbers:" << endl;
	cin >> num1 >> num2;
	string answer;
	if (num1[0] == '-' && num2[0] != '-' || num1[0] != '-' && num2[0] == '-')//判断是否为a正b负，或者a负b正
		answer = sub(num1, num2);

	else if (num1[0] == num2[0] && num2[0] == '-')      //如果都是负数的话
		answer = '-' + sum(num1.substr(1, num1.size()), num2.substr(1, num2.size()));
	//num1，和num2从第二位开始复制复制到最后
	//不管只进行数字的加减不管符号位 ，计算完后添加符号'-'；
	else
		answer = sum(num1, num2);  //否则进行加法运算

	cout << "The final answer is:\n" << answer << endl;
	system("pause");
	display2();
}
void test2()
{
	cout << "等待完善" << endl;
	system("pause");
	display2();
	exit(0);
}
void main1(int ns)
{
	loadnum();
	loadid();
	switch (ns)
	{
	case 1:
		addid();
		break;
	case 2:
		login();
		break;
	case 3:
		cout << "退出成功！" << endl;
		exit(0);
	default:
		cout << "请正确输入！" << endl;
		system("pause");
	}
}
void loadnum()
{
	ifstream numin("num.txt", ios::in);
	if (!numin)
	{
		cout << "系统出现故障，错误代码:ERR001" << endl;
		exit(1);
	}
	char NUM[10];
	numin.getline(NUM, 10);
	n = atoi(NUM);
}
void loadid()
{
	ifstream in("f1.dat", ios::binary);
	if (!in)
	{
		cout << "系统出现故障，错误代码:ERR002" << endl;
		exit(1);
	}
	int i = 0;


	for (int i = 0; i < n; i++)
	{
		in.read((char*)& id[i], sizeof(bank));
	}

}
void addid()
{
	int i = 0;
	inputid();
	saveid();
	savenum();
	cout << "注册成功";
	cout << endl;
	system("pause");
	Sleep(1000);

	system("cls");
	display1();
}
void inputid()
{
	char a[20], b[20];
A:int aa;
	system("cls");
	cout << "输入您要注册的账号" << endl;
	
	B:cin >> a;
	
	for (int i = 0; i < n; i++)
	{
		
		if(strlen(a)<10||strlen(a)>13)
      	{
			cout<<"账号密码必须在十位到十三位之间！！\n请从新输入"<<endl;
				goto B;
	    } 
		if (strcmp(id[i].id, a) == 0)
		{
			cout << "已有同名账号，请重试" << endl;
			Sleep(1000);

			goto A;
		}
	}
	cout << "输入您要使用的密码" << endl;
	C:cin >> b;
	int a1=0,b1=0,c1=0,d1=0;
	int len=strlen(b);
	for(int i=0;i<len;i++)
	{
		
		if(b[i]>='0'&&b[i]<='9')
			a1=1;
		if(b[i]>='a'&&b[i]<='z'||b[i]>='A'&&b[i]<='Z')
			b1=1;
		if(b[i]=='_')
			c1=1;
		if(b[len-3]=='@')
			d1=1;
	}
	if(a1!=1||b1!=1||c1!=1||d1!=1)
	{
		cout<<"密码必须包括字母数字下划线，且倒数第三位为@,请从新输入"<<endl; 
		goto C;
	 } 
	
	strcpy(id[n].id, a);
	strcpy(id[n].pass, b);
	id[n].lost_money = 0;
	id[n].ifm_num = 0;
	char ss[20] = ".txt", sss[20];
	strcpy(sss, id[n].id);
	strcat(sss, ss);
	ofstream fout(sss, ios::out | ios::app);

	dq = n;
	n++;
}
void saveid()
{
	ofstream out("f1.dat", ios::binary);
	if (!out)
	{
		cout << "系统出现故障，错误代码:ERR003" << endl;
		exit(1);
	}
	for (int i = 0; i < n; i++)
	{
		out.write((char*)& id[i], sizeof(bank));
	}
	out.close();
}
void savenum()
{
	ofstream numout("num.txt", ios::out);
	if (!numout)
	{
		cout << "系统出现故障，错误代码:ERR004" << endl;
		exit(1);
	}
	numout.clear();

	numout << n;
}
int isrun(int n)
{
	if(n%400==0||n%4==0&&n%100!=0)
		return 1;
	else
		return 0; 
}
void login()
{
	int cishu = 0;
	char a[20], b[20];
	cout << "请输入账号" << endl;
	cin >> a;
	cout << "请输入密码" << endl;
RRR:cin >> b;
  	SYSTEMTIME sys;
	GetLocalTime(&sys);
	int p = 0, pi;
	for (int i = 0; i < n; i++)
	{
		if (strcmp(a, id[i].id) == 0)
		{
			p = 1;
			pi = i;
			break;
		}
	}
TTT:if(id[pi].ppp==0)
	{
		if (p == 0)
		{
			cout << "账号不存在" << endl;
			system("pause");
			return;
		}
		else
		{
			if (strcmp(id[pi].pass, b) != 0)
			{
				cout << "密码错误,请从新输入" << endl;
				cishu++;
				if(cishu<3)
					goto RRR;
				else
				{
					id[pi].ppp = 1;
					saveid();
					cout << "连续三次输错密码，您的账户已被冻结一天！" << endl;
					//cout<<"当前ppp的值为："<<id[pi].ppp<<endl;//
					id[pi].syss.wYear=sys.wYear;
					id[pi].syss.wMonth=sys.wMonth;
					id[pi].syss.wDay=sys.wDay;
					id[pi].syss.wHour=sys.wHour;
					id[pi].syss.wMinute=sys.wMinute;
					id[pi].syss.wSecond=sys.wSecond;
					saveid();
				}
				system("pause");
				return;
			}
			else
			{
				dq = pi;
				cout << "登录成功" << endl;
				display2();
			}
		}
	}
	else
	{
		int seconds,second1,second2;
		int dayy=0,day1=0,day2=0,xx=0,xxx=0;
		int day11[20]={31,29,31,30,31,30,31,31,30,31,30,31};
		int day22[20]={31,28,31,30,31,30,31,31,30,31,30,31};
		second1 = sys.wHour*3600+sys.wMinute*60+sys.wSecond;
		second2 = 24*3600-(id[pi].syss.wHour*3600+id[pi].syss.wMinute*60+id[pi].syss.wSecond);
		if(sys.wMonth==1&&sys.wDay==1&&id[pi].syss.wMonth==12&&id[pi].syss.wDay==31)
		{
			seconds=second1+second2;xxx=1;
		}
		if((sys.wYear!=id[pi].syss.wYear&&xxx!=1)||(sys.wMonth-id[pi].syss.wMonth>1&&sys.wYear==id[pi].syss.wYear))
			xx=1;
		if(xx==1)
		{
			id[pi].ppp=0;
			saveid();
			goto TTT;
		}
		else
		{
			if(sys.wMonth!=id[pi].syss.wMonth)
			{
				day1=sys.wDay-1;
				int x;
				x=isrun(id[pi].syss.wYear);
				if(x==1)
					day2=day11[id[pi].syss.wMonth-1]-id[pi].syss.wDay;
				else
					day2=day22[id[pi].syss.wMonth-1]-id[pi].syss.wDay;
				dayy=day1+day2;
			}
			else if(sys.wYear==id[pi].syss.wYear&&sys.wMonth==id[pi].syss.wMonth)
				dayy=sys.wDay-id[pi].syss.wDay-1;
			seconds=dayy*24*3600;
		}
		if(seconds>=24*3600)
		{
			id[pi].ppp=0;
			saveid();
			goto TTT;
		}
		else
		{
			cout<<"您的账号已被冻结"<<endl;
			system("pause");
			display1();
		}
	}
}
void main2(int ns)
{
	switch (ns)
	{
	case 1:
		in_Yuan();
		break;
	case 2:
		out_Yuan();
		break;
	case 3:
		print_list();
		break;
	case 4:
		printmoney();
		break;
	case 5:
		jisuan();
	case 6:
		display1();
	default:
		cout << "请正确输入！" << endl;
	}
}
void in_Yuan()
{
	cout << "请输入要存取的金额" << endl;
	int n3;
	cin >> n3;
	id[dq].lost_money += n3;
	char s[30], ss[30] = ".txt";
	strcpy(s, id[dq].id);
	strcat(s, ss);
	SYSTEMTIME sys;
	GetLocalTime(&sys);
	char sss[80];
	sprintf(sss, "%4d/%02d/%02d %02d:%02d:%02d", sys.wYear, sys.wMonth, sys.wDay, sys.wHour, sys.wMinute, sys.wSecond);

	ofstream txtout(s, ios::app);
	txtout << "存钱   " << n3 << "元     " << id[dq].lost_money << "元     " << sss << '\n';
	txtout.close();
	cout << "存取成功!" << endl;
	id[dq].ifm_num++;
	saveid();
	system("pause");
	display2();
}
void printmoney()
{
	cout << "您当前余额:" << id[dq].lost_money << endl;
	system("pause");
	display2();
}
void out_Yuan()
{
	cout << "请选择您取出的金额" << endl;
	cout << "1: 100" << endl;
	cout << "2: 200" << endl;
	cout << "3: 300" << endl;
	cout << "4: 400" << endl;
	cout << "5: 500" << endl;
	cout << "6: 1000" << endl;
	cout << "7: 输入其他金额" << endl;
	cout << "0: 返回上一层" << endl;
	int n4, n5;
	cin >> n4;
	if (n4 == 1)
		n5 = 100;
	if (n4 == 2)
		n5 = 200;
	if (n4 == 3)
		n5 = 300;
	if (n4 == 4)
		n5 = 400;
	if (n4 == 5)
		n5 = 500;
	if (n4 == 6)
		n5 = 1000;
	if (n4 == 7)
	{
		cout << "请输入金额" << endl;
		cin >> n5;
	}
	if (n4 == 0)
		display2();
	int n6 = id[dq].lost_money;
	if (n5 > n6)
	{
		cout << "余额不足" << endl;
		system("pause");
		display2();
	}
	id[dq].lost_money -= n5;
	SYSTEMTIME sys;
	GetLocalTime(&sys);
	char sss[80], s[50], ss[50] = ".txt";
	strcpy(s, id[dq].id);
	strcat(s, ss);
	sprintf(sss, "%4d/%02d/%02d %02d:%02d:%02d", sys.wYear, sys.wMonth, sys.wDay, sys.wHour, sys.wMinute, sys.wSecond);
	ofstream txtout(s, ios::app);
	txtout << "取钱   " << n5 << "元     " << id[dq].lost_money << "元     " << sss << '\n';
	cout << "取钱成功!" << endl;
	id[dq].ifm_num++;
	saveid();
	system("pause");
	display2();
}
void print_list()
{
	char sss[80], s[50], str[100], ss[50] = ".txt";
	char cch[N][100],cch1[N][100],cch2[N][100],cch3[N][100],cch4[N][100],t[100];
	int dqhead = 0, dqlast,last,p=0,q=0;
	strcpy(s, id[dq].id);
	strcat(s, ss);
	ifstream in(s, ios::in);
	for (int i = 0; i < id[dq].ifm_num; i++)
	{
		in.getline(str, 100);
		strcpy(cch[i], str);
	}
	/*for(int i=0;i<id[dq].ifm_num;i++)
	{
		int nn=0,k=0;
		for(int j=0;j<id[dq].ifm_num;j++)
		{
			if(cch[i][j]!=' ')
			{
				nn=j;break;
			}
		}
		for(int j=nn;cch[i][j]!=' ';j++)
			t[k++]=cch[i][j];
		strcpy(cch1[i],t);
		k=0;nn+=3;
		for(int j=nn;cch[i][j]!=' ';j++)
			t[k++]=cch[i][j];
		strcpy(cch2[i],t);
		k=0;nn+=5;
		for(int j=nn;cch[i][j]!=' ';j++)
			t[k++]=cch[i][j];
		strcpy(cch3[i],t);
		k=0;nn+=5;
		for(int j=nn;cch[i][j]!=' '&&cch[i][j+1]!=' ';j++)
			t[k++]=cch[i][j];
		strcpy(cch4[i],t);
	}*/
	while (1)
	{
		dqlast = dqhead + 4;
		system("cls");
		for (int i = dqhead; i <= dqlast; i++)
			cout << setw(5) << cch[i] << endl;
		/*for (int i = dqhead; i <= dqlast; i++)
		{
			cout << setw(5) << cch1[i] << endl;
			cout << setw(20) << cch2[i] << endl;
			cout << setw(20) << cch3[i] << endl;
			cout << setw(50) << cch4[i] << endl;
		}*/
		int zl;
		if(dqlast==4&&dqlast>id[dq].ifm_num-1)
		{
			cout << "按3退出查询明细" << endl;
			cin >> zl;
			system("pause");
			system("cls");
			if (zl != 3)
				cout << "已经是最后一页了！" << endl;
			else
				display2();
		}
		if (dqlast == 4)
		{
			cout << "按2翻到下一页" << endl;
			cout << "按3退出查询明细" << endl;
			cin >> zl;
			system("pause");
			system("cls");
			if (zl == 1)
				cout << "已经是第一页了！" << endl;
			else if (zl == 2)
				dqhead += 5;
			else
				display2();
		}
		else if (dqlast == id[dq].ifm_num - 1 || (dqlast+1 - id[dq].ifm_num < 5 && dqlast+1 - id[dq].ifm_num>0))
		{
			cout << "按1翻到上一页" << endl;
			cout << "按3退出查询明细" << endl;
			cin >> zl;
			system("pause");
			system("cls");
			if (zl == 2)
			{
				cout << "已经是最后一页了！" << endl;
				p=1;
			}
			else if (zl == 1 && p == 0)
				dqhead -= 5;
			else
				display2();
		}
		else
		{
			cout << "按1翻到上一页" << endl;
			cout << "按2翻到下一页" << endl;
			cout << "按3退出查询明细" << endl;
			cin >> zl;
			system("pause");
			system("cls");
			if (zl == 1)
				dqhead -= 5;
			else if (zl == 2)
				dqhead += 5;
			else
				display2();
		}
	}
}
