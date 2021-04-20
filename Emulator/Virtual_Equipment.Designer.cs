
namespace Emulator
{
    partial class Virtual_Equipment
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExitProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.edditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbInterval = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbEqCelsius = new System.Windows.Forms.TextBox();
            this.tbEqTotal = new System.Windows.Forms.TextBox();
            this.tbEqHumi = new System.Windows.Forms.TextBox();
            this.tbEqAtmos = new System.Windows.Forms.TextBox();
            this.tbEqWind = new System.Windows.Forms.TextBox();
            this.tbEqOz = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbEqcode = new System.Windows.Forms.TextBox();
            this.tbEqCount = new System.Windows.Forms.TextBox();
            this.tbEqModel = new System.Windows.Forms.TextBox();
            this.tbEqState = new System.Windows.Forms.TextBox();
            this.tbEqLine = new System.Windows.Forms.TextBox();
            this.tbEqBatt = new System.Windows.Forms.TextBox();
            this.tbMonitor = new System.Windows.Forms.TextBox();
            this.sb_IP = new System.Windows.Forms.ToolStripStatusLabel();
            this.sb_Port = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.edditToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.configToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(613, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStart,
            this.menuStop,
            this.toolStripMenuItem1,
            this.menuExitProgram});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // menuStart
            // 
            this.menuStart.Name = "menuStart";
            this.menuStart.Size = new System.Drawing.Size(143, 22);
            this.menuStart.Text = "Start";
            this.menuStart.Click += new System.EventHandler(this.menuStart_Click);
            // 
            // menuStop
            // 
            this.menuStop.Name = "menuStop";
            this.menuStop.Size = new System.Drawing.Size(143, 22);
            this.menuStop.Text = "Stop";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(140, 6);
            // 
            // menuExitProgram
            // 
            this.menuExitProgram.Name = "menuExitProgram";
            this.menuExitProgram.Size = new System.Drawing.Size(143, 22);
            this.menuExitProgram.Text = "Exit Program";
            // 
            // edditToolStripMenuItem
            // 
            this.edditToolStripMenuItem.Name = "edditToolStripMenuItem";
            this.edditToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.edditToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sb_IP,
            this.sb_Port,
            this.sbStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 431);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(613, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbMonitor);
            this.splitContainer1.Size = new System.Drawing.Size(613, 407);
            this.splitContainer1.SplitterDistance = 303;
            this.splitContainer1.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.tbInterval);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.dtEnd);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.dtStart);
            this.groupBox3.Location = new System.Drawing.Point(12, 287);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(288, 105);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "실행 정보";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(154, 81);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 12);
            this.label16.TabIndex = 19;
            this.label16.Text = "seconds";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 81);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 12);
            this.label15.TabIndex = 18;
            this.label15.Text = "시간 간격";
            // 
            // tbInterval
            // 
            this.tbInterval.Location = new System.Drawing.Point(75, 78);
            this.tbInterval.Name = "tbInterval";
            this.tbInterval.Size = new System.Drawing.Size(73, 21);
            this.tbInterval.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 12);
            this.label14.TabIndex = 9;
            this.label14.Text = "종료 시간";
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(76, 47);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(200, 21);
            this.dtEnd.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "시작 시간";
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(75, 20);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(200, 21);
            this.dtStart.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.tbEqCelsius);
            this.groupBox2.Controls.Add(this.tbEqTotal);
            this.groupBox2.Controls.Add(this.tbEqHumi);
            this.groupBox2.Controls.Add(this.tbEqAtmos);
            this.groupBox2.Controls.Add(this.tbEqWind);
            this.groupBox2.Controls.Add(this.tbEqOz);
            this.groupBox2.Location = new System.Drawing.Point(12, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 115);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "환경 정보";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(208, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 12);
            this.label8.TabIndex = 23;
            this.label8.Text = "종합(4)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(208, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 12);
            this.label9.TabIndex = 22;
            this.label9.Text = "오존(4)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(208, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 12);
            this.label10.TabIndex = 21;
            this.label10.Text = "습도(4)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(30, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "대기(1)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(30, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 12);
            this.label12.TabIndex = 19;
            this.label12.Text = "풍속(4)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(30, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 12);
            this.label13.TabIndex = 18;
            this.label13.Text = "온도(4)";
            // 
            // tbEqCelsius
            // 
            this.tbEqCelsius.Location = new System.Drawing.Point(76, 20);
            this.tbEqCelsius.Name = "tbEqCelsius";
            this.tbEqCelsius.Size = new System.Drawing.Size(59, 21);
            this.tbEqCelsius.TabIndex = 12;
            // 
            // tbEqTotal
            // 
            this.tbEqTotal.Location = new System.Drawing.Point(141, 74);
            this.tbEqTotal.Name = "tbEqTotal";
            this.tbEqTotal.Size = new System.Drawing.Size(59, 21);
            this.tbEqTotal.TabIndex = 17;
            // 
            // tbEqHumi
            // 
            this.tbEqHumi.Location = new System.Drawing.Point(141, 20);
            this.tbEqHumi.Name = "tbEqHumi";
            this.tbEqHumi.Size = new System.Drawing.Size(59, 21);
            this.tbEqHumi.TabIndex = 13;
            // 
            // tbEqAtmos
            // 
            this.tbEqAtmos.Location = new System.Drawing.Point(76, 74);
            this.tbEqAtmos.Name = "tbEqAtmos";
            this.tbEqAtmos.Size = new System.Drawing.Size(59, 21);
            this.tbEqAtmos.TabIndex = 16;
            // 
            // tbEqWind
            // 
            this.tbEqWind.Location = new System.Drawing.Point(76, 47);
            this.tbEqWind.Name = "tbEqWind";
            this.tbEqWind.Size = new System.Drawing.Size(59, 21);
            this.tbEqWind.TabIndex = 14;
            // 
            // tbEqOz
            // 
            this.tbEqOz.Location = new System.Drawing.Point(141, 47);
            this.tbEqOz.Name = "tbEqOz";
            this.tbEqOz.Size = new System.Drawing.Size(59, 21);
            this.tbEqOz.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbEqcode);
            this.groupBox1.Controls.Add(this.tbEqCount);
            this.groupBox1.Controls.Add(this.tbEqModel);
            this.groupBox1.Controls.Add(this.tbEqState);
            this.groupBox1.Controls.Add(this.tbEqLine);
            this.groupBox1.Controls.Add(this.tbEqBatt);
            this.groupBox1.Location = new System.Drawing.Point(12, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 122);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "장비상태 정보";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "가동 회수(5)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(208, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "Battery[V](5)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "장비 모델(6)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "가동 여부(1)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Line No.(5)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "장비 코드(5)";
            // 
            // tbEqcode
            // 
            this.tbEqcode.Location = new System.Drawing.Point(76, 29);
            this.tbEqcode.Name = "tbEqcode";
            this.tbEqcode.Size = new System.Drawing.Size(59, 21);
            this.tbEqcode.TabIndex = 0;
            // 
            // tbEqCount
            // 
            this.tbEqCount.Location = new System.Drawing.Point(141, 83);
            this.tbEqCount.Name = "tbEqCount";
            this.tbEqCount.Size = new System.Drawing.Size(59, 21);
            this.tbEqCount.TabIndex = 5;
            // 
            // tbEqModel
            // 
            this.tbEqModel.Location = new System.Drawing.Point(141, 29);
            this.tbEqModel.Name = "tbEqModel";
            this.tbEqModel.Size = new System.Drawing.Size(59, 21);
            this.tbEqModel.TabIndex = 1;
            // 
            // tbEqState
            // 
            this.tbEqState.Location = new System.Drawing.Point(76, 83);
            this.tbEqState.Name = "tbEqState";
            this.tbEqState.Size = new System.Drawing.Size(59, 21);
            this.tbEqState.TabIndex = 4;
            // 
            // tbEqLine
            // 
            this.tbEqLine.Location = new System.Drawing.Point(76, 56);
            this.tbEqLine.Name = "tbEqLine";
            this.tbEqLine.Size = new System.Drawing.Size(59, 21);
            this.tbEqLine.TabIndex = 2;
            // 
            // tbEqBatt
            // 
            this.tbEqBatt.Location = new System.Drawing.Point(141, 56);
            this.tbEqBatt.Name = "tbEqBatt";
            this.tbEqBatt.Size = new System.Drawing.Size(59, 21);
            this.tbEqBatt.TabIndex = 3;
            // 
            // tbMonitor
            // 
            this.tbMonitor.Location = new System.Drawing.Point(3, 0);
            this.tbMonitor.Multiline = true;
            this.tbMonitor.Name = "tbMonitor";
            this.tbMonitor.Size = new System.Drawing.Size(301, 404);
            this.tbMonitor.TabIndex = 0;
            // 
            // sb_IP
            // 
            this.sb_IP.AutoSize = false;
            this.sb_IP.Name = "sb_IP";
            this.sb_IP.Size = new System.Drawing.Size(100, 17);
            // 
            // sb_Port
            // 
            this.sb_Port.AutoSize = false;
            this.sb_Port.Name = "sb_Port";
            this.sb_Port.Size = new System.Drawing.Size(50, 17);
            // 
            // sbStatus
            // 
            this.sbStatus.AutoSize = false;
            this.sbStatus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.sbStatus.Name = "sbStatus";
            this.sbStatus.Size = new System.Drawing.Size(121, 17);
            // 
            // Virtual_Equipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 453);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Virtual_Equipment";
            this.Text = "Virtual Equipment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuStart;
        private System.Windows.Forms.ToolStripMenuItem menuStop;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuExitProgram;
        private System.Windows.Forms.ToolStripMenuItem edditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbInterval;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbEqCelsius;
        private System.Windows.Forms.TextBox tbEqTotal;
        private System.Windows.Forms.TextBox tbEqHumi;
        private System.Windows.Forms.TextBox tbEqAtmos;
        private System.Windows.Forms.TextBox tbEqWind;
        private System.Windows.Forms.TextBox tbEqOz;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbEqcode;
        private System.Windows.Forms.TextBox tbEqCount;
        private System.Windows.Forms.TextBox tbEqModel;
        private System.Windows.Forms.TextBox tbEqState;
        private System.Windows.Forms.TextBox tbEqLine;
        private System.Windows.Forms.TextBox tbEqBatt;
        private System.Windows.Forms.TextBox tbMonitor;
        private System.Windows.Forms.ToolStripStatusLabel sb_IP;
        private System.Windows.Forms.ToolStripStatusLabel sb_Port;
        private System.Windows.Forms.ToolStripStatusLabel sbStatus;
    }
}

