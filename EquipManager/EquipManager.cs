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
using jsLibrary;

namespace EquipManager
{
    public partial class EquipManager : Form
    {
        public EquipManager()
        {
            InitializeComponent();
        }

        Socket sock = null;
        TcpListener listener = null;
        Thread serverThread = null;
        Thread readThread = null;
        List<Socket> sock_list = new List<Socket>();
        delegate void CallBackAddText(string str);
        void AddText(string str)
        {
            if (tbMonitor.InvokeRequired)
            {
                CallBackAddText cb = new CallBackAddText(AddText);
                Invoke(cb, new object[] { str });
            }
            else
            {
                tbMonitor.AppendText(str);
            }
        }

        private void menu_Start_Click(object sender, EventArgs e)
        {
            if (listener == null) listener = new TcpListener(int.Parse(tbPort.Text));
            else listener.Stop();
            listener.Start();

            if (serverThread != null) serverThread.Abort();
            serverThread = new Thread(ServerProcess);
            serverThread.Start();

            if (readThread != null) readThread.Abort();
            readThread = new Thread(ReadProcess);
            readThread.Start();

        }
        void ServerProcess()    // Socket들을 기다리는 Thraead.
        {
            while (true)
            {
                if (listener.Pending())
                {
                    Socket sockT = listener.AcceptSocket();
                    sock_list.Add(sockT);
                }
                Thread.Sleep(100);
            }

        }
        void ReadProcess()  //각 통신 정보를 가져올 쓰레드
        {
            while (true)
            {
                for(int i = 0; i < sock_list.Count; i++)
                {
                    Socket lsock = sock_list[i];
                    if (IsAlive(lsock) == false) continue;
                    if (lsock.Available > 0)
                    {
                        byte[] bArr = new byte[lsock.Available];
                        lsock.Receive(bArr);
                        ReadPro(lsock, bArr);
                    }
                }
                Thread.Sleep(100);
            }

        }
        void ReadPro(Socket ss, byte[] arr)
        {
            AddText(ss.RemoteEndPoint.ToString()+"> ");
            AddText(Encoding.Default.GetString(arr)+"\r\n");

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


        iniFile ini = new iniFile(".\\EquipManager.ini");
        private void EquipManager_Load(object sender, EventArgs e)
        {
            tbPort.Text = ini.GetString("Connection", "Port", "8080");

            int x1, x2, y1, y2;
            x1 = int.Parse(ini.GetString("Form", "LocationX", "0"));
            y1 = int.Parse(ini.GetString("Form", "LocationY", "0"));
            this.Location = new Point(x1, y1);
            x2 = int.Parse(ini.GetString("Form", "SizeX", "500"));
            y2 = int.Parse(ini.GetString("Form", "SizeY", "500"));
            this.Size = new Size(x2, y2);

            tabControl1.SelectedIndex = int.Parse(ini.GetString("Form", "TabIndex", "1"));
        }

        private void EquipManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.SetString("Connection", "Port", tbPort.Text);

            ini.SetString("Form", "LocationX", this.Location.X.ToString());
            ini.SetString("Form", "LocationY", this.Location.Y.ToString());
            ini.SetString("Form", "SizeX", this.Size.Width.ToString());
            ini.SetString("Form", "SizeY", this.Size.Height.ToString());

            ini.SetString("Form", "TabIndex", $"{ tabControl1.SelectedIndex}");

            if (serverThread != null) serverThread.Abort();
            if (readThread != null) readThread.Abort();

        }
    }
}
