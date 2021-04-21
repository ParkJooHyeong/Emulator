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
//using Clibrary;
using jsLibrary;

namespace Emulator
{
    public partial class Virtual_Equipment : Form
    {
        public Virtual_Equipment()
        {
            InitializeComponent();
        }
        iniFile ini;
        Socket socket = null;
        Thread readThread = null;

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

            sb_IP.Text = ini.GetString("Connection", "IP", "127.0.0.1");
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
            if (readThread != null) readThread.Abort();
            ini.SetString("Equipment", "Code", tbEqcode.Text);        //장비 코드 5
            ini.SetString("Equipment", "Model", tbEqModel.Text);     //장비 모델 6
            ini.SetString("Equipment", "Line", tbEqLine.Text);        //라인 번호 5
            ini.SetString("Equipment", "Battery", tbEqBatt.Text);     //배터리 잔량 5
            ini.SetString("Equipment", "State", tbEqState.Text);           //현재 상태 1
            ini.SetString("Equipment", "Count", tbEqCount.Text);           //사용 횟수 5

            ini.SetString("Environment", "Temperature", tbEqCelsius.Text);   //온도 4
            ini.SetString("Environment", "Humidity", tbEqHumi.Text);         //습도 4
            ini.SetString("Environment", "Wind_Speed", tbEqWind.Text);       //풍속 4
            ini.SetString("Environment", "Atmosphere", tbEqAtmos.Text);      //대기 1
            ini.SetString("Environment", "Ozone", tbEqOz.Text);              //오존 4
            ini.SetString("Environment", "Total", tbEqTotal.Text);           //종합 4 : total 48bytes

            ini.SetString("Operation", "Start_Time", dtStart.Value.Ticks.ToString());
            ini.SetString("Operation", "End_Time", dtEnd.Value.Ticks.ToString());
            ini.SetString("Operation", "Interval", tbInterval.Text);

            ini.SetString("Connection", "IP", sb_IP.Text);
            ini.SetString("Connection", "Port", sb_Port.Text);

            ini.SetString("Form", "LocationX", this.Location.X.ToString());
            ini.SetString("Form", "LocationY", this.Location.Y.ToString());
            ini.SetString("Form", "SizeX", this.Size.Width.ToString());
            ini.SetString("Form", "SizeY", this.Size.Height.ToString());
        }

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

                timerInterval.Interval = int.Parse(tbInterval.Text) * 1000; // 주기적으로 인터럽트 생성
                timerInterval.Start();
                
            }
            catch (Exception)
            {
                sbStatus.Text = "Connection Failed";
                sbStatus.BackColor = Color.Red;
            }

        }
        delegate void CallBack_AddText(string str);
        
        private void sb_IP_Click(object sender, EventArgs e)
        {
            string str = jslib.GetInput("IP Address");
            if (str != "")
            {
                sb_IP.Text = str;
            }
        }

        private void sb_Port_Click(object sender, EventArgs e)
        {
            string str = jslib.GetInput("Port");
            if (str != "")
            {
                sb_Port.Text = str;
            }
        }
        void AddText(string str)
        {
            if (tbMonitor.InvokeRequired)
            {
                CallBack_AddText cb = new CallBack_AddText(AddText);
                Invoke(cb, new object[] { str });

            }
            else
            {
                tbMonitor.AppendText(str);
            }

        }
        bool IsAlive(Socket sc) // Socket이 유효한지 판별.
        {
            if (sc == null) return false;
            if (sc.Connected == false) return false;
            if (sc.Poll(1000, SelectMode.SelectRead) && sc.Available > 0) return false;

            try
            {
                sc.Send(new byte[1], 0, SocketFlags.OutOfBand); //제대로 연결되있는지 확인하기 위한 전송 메소드 실행.
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        void ReadProcess()  //서버로 부터 값을 받아올 Thread
        {
            Socket th_socket = socket;
            while (true)
            {
                th_socket = socket;
                if (IsAlive(th_socket)&&th_socket.Available>0)
                {
                    byte[] bArr = new byte[th_socket.Available];
                    th_socket.Receive(bArr);
                    string time = DateTime.Now.ToString("HH:mm:ss");
                    AddText($"[{time}] : {Encoding.Default.GetString(bArr)} + \r\n");
                }
                Thread.Sleep(100);
            }
        }
        char STX = '\u0002';    // Unicode
        char ETX = '\u0003';    // Unicode
        private void timerInterval_Tick(object sender, EventArgs e)
        {
            timerInterval.Stop();

            //string str = STX+tbEqcode.Text + tbEqModel.Text + tbEqLine.Text + tbEqBatt.Text + tbEqState.Text + tbEqCount.Text
            //    + tbEqCelsius.Text + tbEqHumi.Text + tbEqWind.Text + tbEqOz.Text + tbEqAtmos.Text + tbEqTotal.Text+ETX;

            // Packet 생성, 보간 문자여열을 활용.
            string str = $"{STX}{tbEqcode.Text,5}{tbEqModel.Text,6}{tbEqLine.Text,5}{float.Parse(tbEqBatt.Text),5:F2}{tbEqState.Text,1}" +
                $"{int.Parse(tbEqCount.Text):D5}{int.Parse(tbEqCelsius.Text):D4}{int.Parse(tbEqHumi.Text):D4}{int.Parse(tbEqWind.Text):D4}" +
                $"{int.Parse(tbEqOz.Text):D4}{int.Parse(tbEqAtmos.Text):D1}{int.Parse(tbEqTotal.Text):D4}{ETX}";

            byte[] bArr = Encoding.Default.GetBytes(str);
            if (IsAlive(socket))
            {
                socket.Send(bArr);
                tbEqCount.Text = (int.Parse(tbEqCount.Text)+1).ToString();
            }
            // Generate Packet : front-->[02]STX, rear-->[03]ETX
            
            timerInterval.Start();
        }

        private void menuStop_Click(object sender, EventArgs e)
        {
            timerInterval.Stop();
            if (readThread != null) { readThread.Abort(); readThread = null; }

            if (socket != null) { socket.Close(); socket = null; } 
        }
    }
}
