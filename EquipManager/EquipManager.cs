using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        string connectionStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\박주형\Desktop\KOSTA\Emulator\EquipDB.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection sqlconn = new SqlConnection();
        SqlCommand sqlcomd = new SqlCommand();

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
                tbMonitor.Text+=str;
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
                    //if (IsAlive(lsock) == false) continue;
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
            string str = Encoding.Default.GetString(arr);
            string Code = str.Substring(1,5);
            string Model = str.Substring(6,6);
            string Line=str.Substring(12,5);
            string Batt= str.Substring(17,5);
            string State= str.Substring(22,1);
            string Count= str.Substring(23,5);
            string Temp= str.Substring(28, 4);
            string Humi= str.Substring(32,4);
            string Wind= str.Substring(36,4);
            string Ozone= str.Substring(40,4);
            string Atmos=str.Substring(44,1);
            string Total= str.Substring(45,4);
            string Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            AddText(ss.RemoteEndPoint.ToString()+"> ");
            jslib.WriteLog(str);
            AddText(str+"\r\n");

            Console.WriteLine(Code);
            string sql;
            sql = $"select count(*) from EqStatus where Code={Code}";
            DataTable dt = (DataTable)RunSql(sql);
            int n= dt.Rows[0].Field<int>(0);
            if (n == 0)
            {
                sql = $"insert into EqStatus values ({Code},'{Model}','{Line}','{Batt}','{State}','{Count}','{Temp}','{Humi}','{Wind}','{Ozone}','{Atmos}','{Total}','{Time}')";
            }
            else
            {
                sql = $"update EqStatus set Model='{Model}', Line = '{Line}',Battery = '{Batt}', State='{State}',Count='{Count}',Temp='{Temp}'," +
                    $"Humi='{Humi}',Wind='{Wind}',Ozone='{Ozone}',Atmos='{Atmos}',Total='{Total}',Time='{Time}' where Code={Code} select top 1 * from EqStatus where Code='{Code}' order by Time desc ";
            }
            RunSql(sql);

            // GridView 출력
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM EqStatus", sqlconn);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            GridView(ds);
            
            
        }
        delegate void CallBackGridView(DataTable dt);
        void GridView(DataTable dt)
        {
            if (gridTable.InvokeRequired)
            {
                CallBackGridView cb = new CallBackGridView(GridView);
                Invoke(cb, dt);
            }
            else
            {
                gridTable.DataSource = dt;
                tModel.Text = dt.Rows[0][1].ToString();
                tLine.Text = dt.Rows[0][2].ToString();
                tBatt.Text = dt.Rows[0][3].ToString();
                tState.Text = dt.Rows[0][4].ToString();
                tCount.Text = dt.Rows[0][5].ToString();
                tTemp.Text = dt.Rows[0][6].ToString();
                tHumi.Text = dt.Rows[0][7].ToString();
                tWind.Text = dt.Rows[0][8].ToString();
                tOzone.Text = dt.Rows[0][9].ToString();
                tAtmos.Text = dt.Rows[0][10].ToString();
            }
        }
        object RunSql(string sql) // op= 0 -> return nothing, op=1 -> return object
        {
            sqlcomd.CommandText=sql;
            if (jslib.GetToken(0, sql.Trim(), ' ').ToUpper() == "SELECT")
            {
                SqlDataReader sr = sqlcomd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sr);
                sr.Close();
                return dt;
            }
            else
            {
                return sqlcomd.ExecuteNonQuery();      // insert, update, delete, create etc..조회결과가 없은 SQL문 처리
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
            connectionStr = ini.GetString("Database", "ConnectionString", @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\박주형\Desktop\KOSTA\Emulator\EquipDB.mdf;Integrated Security=True;Connect Timeout=30");

            tabControl1.SelectedIndex = int.Parse(ini.GetString("Form", "TabIndex", "1"));
            sqlconn.ConnectionString = connectionStr;
            sqlconn.Open();
            sqlcomd.Connection = sqlconn;
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM EqStatus", sqlconn);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            GridView(ds);
            int cnum = ds.Rows.Count;
            Control[] BTN = new Control[cnum];
            for (int i = 0; i < cnum; i++)
            {
                BTN[i] = new Button();
                BTN[i].Text = $"Code : {i+1}";
                // BTM[i].Click+=Select_Code;
                flpanel.Controls.Add(BTN[i]);
            }
        }

        private void EquipManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.SetString("Connection", "Port", tbPort.Text);

            ini.SetString("Form", "LocationX", this.Location.X.ToString());
            ini.SetString("Form", "LocationY", this.Location.Y.ToString());
            ini.SetString("Form", "SizeX", this.Size.Width.ToString());
            ini.SetString("Form", "SizeY", this.Size.Height.ToString());

            ini.SetString("Form", "TabIndex", $"{ tabControl1.SelectedIndex}");

            ini.SetString("Database", "ConnectionString", connectionStr);

            if (serverThread != null) serverThread.Abort();
            if (readThread != null) readThread.Abort();

        }
    }
}
