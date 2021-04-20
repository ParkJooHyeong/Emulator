using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clibrary;

namespace Emulator
{
    public partial class Virtual_Equipment : Form
    {
        public Virtual_Equipment()
        {
            InitializeComponent();
        }
        iniFile ini;

        private void Form1_Load(object sender, EventArgs e)
        {
            ini =new iniFile(".\\Emulator.ini");
            tbEqcode.Text = ini.GetString("Equipment", "Code", "00001");        //장비 코드 5
            tbEqModel.Text = ini.GetString("Equipment", "Model", "      ");     //장비 모델 6
            tbEqLine.Text = ini.GetString("Equipment", "Line", "00001");        //라인 번호 5
            tbEqBatt.Text = ini.GetString("Equipment", "Battery", "00001");     //배터리 잔량 5
            tbEqState.Text = ini.GetString("Equipment", "State", "0");           //현재 상태 1
            tbEqCount.Text = ini.GetString("Equipment", "Count", "00000");           //사용 횟수 5 

            tbEqCelsius.Text = ini.GetString("Environment", "Temperature", "0000");   //온도 4
            tbEqHumi.Text = ini.GetString("Environment", "Humidity", "0000");         //습도 4
            tbEqWind.Text = ini.GetString("Environment", "Wind_Speed", "0000");       //풍속 4
            tbEqAtmos.Text = ini.GetString("Environment", "Atmosphere", "0000");      //대기 1
            tbEqOz.Text = ini.GetString("Environment", "Ozone", "0000");              //오존 4
            tbEqTotal.Text = ini.GetString("Environment", "Total", "0000");           //종합 4 : total 48bytes

            dtStart.Value = new DateTime(long.Parse(ini.GetString("Operation", "Start_Time", "0")));
            dtEnd.Value = new DateTime(long.Parse(ini.GetString("Operation", "End_Time", "0")));
            tbInterval.Text = ini.GetString("Operation", "Interval", "5");

            sb_IP.Text = ini.GetString("Connection", "IP", "0.0.0.0");
            sb_Port.Text = ini.GetString("Connection", "Port", "8080");
            
            int x1, x2, y1, y2;
            x1 = int.Parse(ini.GetString("Form", "LocationX", "0"));
            y1 = int.Parse(ini.GetString("Form", "LocationY", "0"));
            this.Location = new Point(x1, y1);
            x2 = int.Parse(ini.GetString("Form", "SizeX", "500"));
            y2 = int.Parse(ini.GetString("Form", "SizeY", "500"));
            this.Size = new Size(x2, y2);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.WriteString("Equipment", "Code", tbEqcode.Text);        //장비 코드 5
            ini.WriteString("Equipment", "Model", tbEqModel.Text);     //장비 모델 6
            ini.WriteString("Equipment", "Line", tbEqLine.Text);        //라인 번호 5
            ini.WriteString("Equipment", "Battery", tbEqBatt.Text);     //배터리 잔량 5
            ini.WriteString("Equipment", "State", tbEqState.Text);           //현재 상태 1
            ini.WriteString("Equipment", "Count", tbEqCount.Text);           //사용 횟수 5

            ini.WriteString("Environment", "Temperature", tbEqCelsius.Text);   //온도 4
            ini.WriteString("Environment", "Humidity", tbEqHumi.Text);         //습도 4
            ini.WriteString("Environment", "Wind_Speed", tbEqWind.Text);       //풍속 4
            ini.WriteString("Environment", "Atmosphere", tbEqAtmos.Text);      //대기 1
            ini.WriteString("Environment", "Ozone", tbEqOz.Text);              //오존 4
            ini.WriteString("Environment", "Total", tbEqTotal.Text);           //종합 4 : total 48bytes

            ini.WriteString("Operation", "Start_Time", dtStart.Value.Ticks.ToString());
            ini.WriteString("Operation", "End_Time", dtEnd.Value.Ticks.ToString());
            ini.WriteString("Operation", "Interval", tbInterval.Text);

            ini.WriteString("Connection", "IP", sb_IP.Text);
            ini.WriteString("Connection", "Port", sb_Port.Text);

            ini.WriteString("Form", "LocationX", this.Location.X.ToString());
            ini.WriteString("Form", "LocationY", this.Location.Y.ToString());
            ini.WriteString("Form", "SizeX", this.Size.Width.ToString());
            ini.WriteString("Form", "SizeY", this.Size.Height.ToString());
        }

        Socket socket = null;
        Thread readThread = null;
        private void menuStart_Click(object sender, EventArgs e)    // 서버와 처음 연결할 때.
        {
            try
            {
                if (socket != null) socket.Close();
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(sb_IP.Text, int.Parse(sb_Port.Text));   //socket을 서버와 연결.

                sbStatus.Text = "Connection Success";
                sbStatus.BackColor = Color.Blue;

                if (readThread != null) readThread.Abort();   
                readThread = new Thread(ReadProcess);   // Thread 생성.
                readThread.Start();
            }
            catch (Exception)
            {
                sbStatus.Text = "Connection Failed";
                sbStatus.BackColor = Color.Red;
            }

        }

        void ReadProcess()  //서버로 부터 값을 받아올 Thread
        {

        }
    }
}
