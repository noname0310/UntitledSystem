namespace UntitleSystem
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.rebootTitle = new System.Windows.Forms.Label();
            this.shutdownTitle = new System.Windows.Forms.Label();
            this.Rebootstatinfo = new System.Windows.Forms.Label();
            this.ShutdownStatInfo = new System.Windows.Forms.Label();
            this.EventUpdatetimer = new System.Windows.Forms.Timer(this.components);
            this.updatestattitle = new System.Windows.Forms.Label();
            this.updatestat = new System.Windows.Forms.Label();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuOnTrayMode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LinkApply = new System.Windows.Forms.Button();
            this.LinktextBox = new System.Windows.Forms.TextBox();
            this.infolabel = new System.Windows.Forms.Label();
            this.Filelocationtitle = new System.Windows.Forms.Label();
            this.correntfilelocation = new System.Windows.Forms.Label();
            this.broserbutton = new System.Windows.Forms.Button();
            this.SetdatafileopenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.consoleRichTextbox = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AutoServerResetcheckBox = new System.Windows.Forms.CheckBox();
            this.StartonbackgroundcheckBox = new System.Windows.Forms.CheckBox();
            this.AutoServerUpdatecheckBox = new System.Windows.Forms.CheckBox();
            this.DataStatusGroupbox = new System.Windows.Forms.GroupBox();
            this.VerstatInfo = new System.Windows.Forms.Label();
            this.VerstatTitle = new System.Windows.Forms.Label();
            this.SetdatafilegroupBox = new System.Windows.Forms.GroupBox();
            this.resetCalendar = new System.Windows.Forms.MonthCalendar();
            this.AutoResetSchedule = new System.Windows.Forms.GroupBox();
            this.RemoveAllbutton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStripOnTestMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.serverUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DefaultUpdateToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServerQuitToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteResetFilesToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ResetDisplayUpdatetoolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RunUpdateProcessToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oxideDownloadToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oxideDownloadCancelToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RunServerToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DefaultResetToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServerQuitOnResetToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteResetFilesOnResetToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ResetDisplayUpdatetoolStripItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.RunServerOnResetToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ResetDateListBox = new System.Windows.Forms.CheckedListBox();
            this.removebutton = new System.Windows.Forms.Button();
            this.updateProgressbar = new System.Windows.Forms.ProgressBar();
            this.AutoResetFilesgroup = new System.Windows.Forms.GroupBox();
            this.ResetLinktextBox = new System.Windows.Forms.TextBox();
            this.ResetFileBrowseButton = new System.Windows.Forms.Button();
            this.ResetFileslistView = new System.Windows.Forms.ListView();
            this.checkbox = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileLink = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ResetFileRemoveButton = new System.Windows.Forms.Button();
            this.ResetFileAddButton = new System.Windows.Forms.Button();
            this.SetServerRunFilegroupBox = new System.Windows.Forms.GroupBox();
            this.CorrentBatchFileLocationlabel = new System.Windows.Forms.Label();
            this.FileLocationTitlelabel = new System.Windows.Forms.Label();
            this.SetServerRunFilebutton = new System.Windows.Forms.Button();
            this.ResetFileLinktextBox = new System.Windows.Forms.TextBox();
            this.RunFileBrowseButton = new System.Windows.Forms.Button();
            this.SetResetFilesopenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SetServerRunFileopenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.DownloadTimeoutTimer = new System.Windows.Forms.Timer(this.components);
            this.contextMenuOnTrayMode.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.DataStatusGroupbox.SuspendLayout();
            this.SetdatafilegroupBox.SuspendLayout();
            this.AutoResetSchedule.SuspendLayout();
            this.contextMenuStripOnTestMenu.SuspendLayout();
            this.AutoResetFilesgroup.SuspendLayout();
            this.SetServerRunFilegroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // rebootTitle
            // 
            this.rebootTitle.AutoSize = true;
            this.rebootTitle.Location = new System.Drawing.Point(6, 17);
            this.rebootTitle.Name = "rebootTitle";
            this.rebootTitle.Size = new System.Drawing.Size(73, 12);
            this.rebootTitle.TabIndex = 0;
            this.rebootTitle.Text = "Reboot Stat:";
            // 
            // shutdownTitle
            // 
            this.shutdownTitle.AutoSize = true;
            this.shutdownTitle.Location = new System.Drawing.Point(6, 29);
            this.shutdownTitle.Name = "shutdownTitle";
            this.shutdownTitle.Size = new System.Drawing.Size(90, 12);
            this.shutdownTitle.TabIndex = 1;
            this.shutdownTitle.Text = "Shutdown Stat:";
            // 
            // Rebootstatinfo
            // 
            this.Rebootstatinfo.AutoSize = true;
            this.Rebootstatinfo.Location = new System.Drawing.Point(123, 17);
            this.Rebootstatinfo.Name = "Rebootstatinfo";
            this.Rebootstatinfo.Size = new System.Drawing.Size(28, 12);
            this.Rebootstatinfo.TabIndex = 2;
            this.Rebootstatinfo.Text = "N/A";
            // 
            // ShutdownStatInfo
            // 
            this.ShutdownStatInfo.AutoSize = true;
            this.ShutdownStatInfo.Location = new System.Drawing.Point(123, 29);
            this.ShutdownStatInfo.Name = "ShutdownStatInfo";
            this.ShutdownStatInfo.Size = new System.Drawing.Size(28, 12);
            this.ShutdownStatInfo.TabIndex = 3;
            this.ShutdownStatInfo.Text = "N/A";
            // 
            // EventUpdatetimer
            // 
            this.EventUpdatetimer.Interval = 2000;
            this.EventUpdatetimer.Tick += new System.EventHandler(this.EventUpdatetimer_Tick);
            // 
            // updatestattitle
            // 
            this.updatestattitle.AutoSize = true;
            this.updatestattitle.Location = new System.Drawing.Point(6, 51);
            this.updatestattitle.Name = "updatestattitle";
            this.updatestattitle.Size = new System.Drawing.Size(73, 12);
            this.updatestattitle.TabIndex = 4;
            this.updatestattitle.Text = "Update Stat:";
            // 
            // updatestat
            // 
            this.updatestat.AutoSize = true;
            this.updatestat.Location = new System.Drawing.Point(123, 51);
            this.updatestat.Name = "updatestat";
            this.updatestat.Size = new System.Drawing.Size(28, 12);
            this.updatestat.TabIndex = 5;
            this.updatestat.Text = "N/A";
            // 
            // TrayIcon
            // 
            this.TrayIcon.ContextMenuStrip = this.contextMenuOnTrayMode;
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "UntitleSystem";
            this.TrayIcon.Visible = true;
            this.TrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseDoubleClick);
            // 
            // contextMenuOnTrayMode
            // 
            this.contextMenuOnTrayMode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.contextMenuOnTrayMode.Name = "contextMenuStrip1";
            this.contextMenuOnTrayMode.Size = new System.Drawing.Size(102, 48);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.openToolStripMenuItem.Text = "open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenForm);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.quitToolStripMenuItem.Text = "quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.FormClose);
            // 
            // LinkApply
            // 
            this.LinkApply.Location = new System.Drawing.Point(389, 32);
            this.LinkApply.Name = "LinkApply";
            this.LinkApply.Size = new System.Drawing.Size(75, 23);
            this.LinkApply.TabIndex = 6;
            this.LinkApply.Text = "set";
            this.LinkApply.UseVisualStyleBackColor = true;
            this.LinkApply.Click += new System.EventHandler(this.LinkApply_Click);
            // 
            // LinktextBox
            // 
            this.LinktextBox.Location = new System.Drawing.Point(39, 34);
            this.LinktextBox.Name = "LinktextBox";
            this.LinktextBox.Size = new System.Drawing.Size(344, 21);
            this.LinktextBox.TabIndex = 7;
            this.LinktextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LinktextBox_KeyDown);
            // 
            // infolabel
            // 
            this.infolabel.AutoSize = true;
            this.infolabel.Location = new System.Drawing.Point(6, 17);
            this.infolabel.Name = "infolabel";
            this.infolabel.Size = new System.Drawing.Size(155, 12);
            this.infolabel.TabIndex = 8;
            this.infolabel.Text = "Plese enter file path below";
            // 
            // Filelocationtitle
            // 
            this.Filelocationtitle.AutoSize = true;
            this.Filelocationtitle.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Filelocationtitle.Location = new System.Drawing.Point(6, 57);
            this.Filelocationtitle.Name = "Filelocationtitle";
            this.Filelocationtitle.Size = new System.Drawing.Size(77, 12);
            this.Filelocationtitle.TabIndex = 9;
            this.Filelocationtitle.Text = "FileLocation:";
            // 
            // correntfilelocation
            // 
            this.correntfilelocation.AutoSize = true;
            this.correntfilelocation.ForeColor = System.Drawing.SystemColors.GrayText;
            this.correntfilelocation.Location = new System.Drawing.Point(100, 57);
            this.correntfilelocation.Name = "correntfilelocation";
            this.correntfilelocation.Size = new System.Drawing.Size(24, 12);
            this.correntfilelocation.TabIndex = 10;
            this.correntfilelocation.Text = "link";
            // 
            // broserbutton
            // 
            this.broserbutton.Location = new System.Drawing.Point(8, 32);
            this.broserbutton.Name = "broserbutton";
            this.broserbutton.Size = new System.Drawing.Size(25, 23);
            this.broserbutton.TabIndex = 11;
            this.broserbutton.Text = "...";
            this.broserbutton.UseVisualStyleBackColor = true;
            this.broserbutton.Click += new System.EventHandler(this.broserbutton_Click);
            // 
            // SetdatafileopenFileDialog
            // 
            this.SetdatafileopenFileDialog.Filter = "json flie (*.json*)|*.json*|모든 파일 (*.*)|*.*";
            this.SetdatafileopenFileDialog.InitialDirectory = "C:";
            this.SetdatafileopenFileDialog.Title = "SetDataFile";
            // 
            // consoleRichTextbox
            // 
            this.consoleRichTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.consoleRichTextbox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.consoleRichTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.consoleRichTextbox.Location = new System.Drawing.Point(12, 173);
            this.consoleRichTextbox.Name = "consoleRichTextbox";
            this.consoleRichTextbox.ReadOnly = true;
            this.consoleRichTextbox.Size = new System.Drawing.Size(470, 127);
            this.consoleRichTextbox.TabIndex = 12;
            this.consoleRichTextbox.Text = "";
            this.consoleRichTextbox.TextChanged += new System.EventHandler(this.consoleRichTextbox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AutoServerResetcheckBox);
            this.groupBox1.Controls.Add(this.StartonbackgroundcheckBox);
            this.groupBox1.Controls.Add(this.AutoServerUpdatecheckBox);
            this.groupBox1.Location = new System.Drawing.Point(342, 92);
            this.groupBox1.MinimumSize = new System.Drawing.Size(140, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 75);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FunctionSetting";
            // 
            // AutoServerResetcheckBox
            // 
            this.AutoServerResetcheckBox.AutoSize = true;
            this.AutoServerResetcheckBox.Location = new System.Drawing.Point(6, 17);
            this.AutoServerResetcheckBox.Name = "AutoServerResetcheckBox";
            this.AutoServerResetcheckBox.Size = new System.Drawing.Size(117, 16);
            this.AutoServerResetcheckBox.TabIndex = 3;
            this.AutoServerResetcheckBox.Text = "AutoServerReset";
            this.AutoServerResetcheckBox.UseVisualStyleBackColor = true;
            this.AutoServerResetcheckBox.Click += new System.EventHandler(this.AutoServerResetcheckBox_Click);
            // 
            // StartonbackgroundcheckBox
            // 
            this.StartonbackgroundcheckBox.AutoSize = true;
            this.StartonbackgroundcheckBox.Location = new System.Drawing.Point(6, 53);
            this.StartonbackgroundcheckBox.Name = "StartonbackgroundcheckBox";
            this.StartonbackgroundcheckBox.Size = new System.Drawing.Size(132, 16);
            this.StartonbackgroundcheckBox.TabIndex = 2;
            this.StartonbackgroundcheckBox.Text = "StartOnBackground";
            this.StartonbackgroundcheckBox.UseVisualStyleBackColor = true;
            this.StartonbackgroundcheckBox.Click += new System.EventHandler(this.StartonbackgroundcheckBox_Click);
            // 
            // AutoServerUpdatecheckBox
            // 
            this.AutoServerUpdatecheckBox.AutoSize = true;
            this.AutoServerUpdatecheckBox.Location = new System.Drawing.Point(6, 35);
            this.AutoServerUpdatecheckBox.Name = "AutoServerUpdatecheckBox";
            this.AutoServerUpdatecheckBox.Size = new System.Drawing.Size(124, 16);
            this.AutoServerUpdatecheckBox.TabIndex = 1;
            this.AutoServerUpdatecheckBox.Text = "AutoServerUpdate";
            this.AutoServerUpdatecheckBox.UseVisualStyleBackColor = true;
            this.AutoServerUpdatecheckBox.Click += new System.EventHandler(this.AutoServerUpdatecheckBox_Click);
            // 
            // DataStatusGroupbox
            // 
            this.DataStatusGroupbox.BackColor = System.Drawing.SystemColors.Control;
            this.DataStatusGroupbox.Controls.Add(this.VerstatInfo);
            this.DataStatusGroupbox.Controls.Add(this.VerstatTitle);
            this.DataStatusGroupbox.Controls.Add(this.rebootTitle);
            this.DataStatusGroupbox.Controls.Add(this.Rebootstatinfo);
            this.DataStatusGroupbox.Controls.Add(this.shutdownTitle);
            this.DataStatusGroupbox.Controls.Add(this.ShutdownStatInfo);
            this.DataStatusGroupbox.Controls.Add(this.updatestattitle);
            this.DataStatusGroupbox.Controls.Add(this.updatestat);
            this.DataStatusGroupbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DataStatusGroupbox.Location = new System.Drawing.Point(12, 92);
            this.DataStatusGroupbox.MinimumSize = new System.Drawing.Size(324, 75);
            this.DataStatusGroupbox.Name = "DataStatusGroupbox";
            this.DataStatusGroupbox.Size = new System.Drawing.Size(324, 75);
            this.DataStatusGroupbox.TabIndex = 14;
            this.DataStatusGroupbox.TabStop = false;
            this.DataStatusGroupbox.Text = "DataStatus";
            // 
            // VerstatInfo
            // 
            this.VerstatInfo.AutoSize = true;
            this.VerstatInfo.Location = new System.Drawing.Point(268, 16);
            this.VerstatInfo.Name = "VerstatInfo";
            this.VerstatInfo.Size = new System.Drawing.Size(28, 12);
            this.VerstatInfo.TabIndex = 7;
            this.VerstatInfo.Text = "N/A";
            // 
            // VerstatTitle
            // 
            this.VerstatTitle.AutoSize = true;
            this.VerstatTitle.Location = new System.Drawing.Point(176, 16);
            this.VerstatTitle.Name = "VerstatTitle";
            this.VerstatTitle.Size = new System.Drawing.Size(53, 12);
            this.VerstatTitle.TabIndex = 6;
            this.VerstatTitle.Text = "Ver Stat:";
            // 
            // SetdatafilegroupBox
            // 
            this.SetdatafilegroupBox.Controls.Add(this.infolabel);
            this.SetdatafilegroupBox.Controls.Add(this.broserbutton);
            this.SetdatafilegroupBox.Controls.Add(this.LinktextBox);
            this.SetdatafilegroupBox.Controls.Add(this.LinkApply);
            this.SetdatafilegroupBox.Controls.Add(this.Filelocationtitle);
            this.SetdatafilegroupBox.Controls.Add(this.correntfilelocation);
            this.SetdatafilegroupBox.Location = new System.Drawing.Point(12, 12);
            this.SetdatafilegroupBox.MinimumSize = new System.Drawing.Size(470, 74);
            this.SetdatafilegroupBox.Name = "SetdatafilegroupBox";
            this.SetdatafilegroupBox.Size = new System.Drawing.Size(470, 74);
            this.SetdatafilegroupBox.TabIndex = 15;
            this.SetdatafilegroupBox.TabStop = false;
            this.SetdatafilegroupBox.Text = "SetDataFile";
            // 
            // resetCalendar
            // 
            this.resetCalendar.Location = new System.Drawing.Point(12, 21);
            this.resetCalendar.MaxSelectionCount = 1;
            this.resetCalendar.Name = "resetCalendar";
            this.resetCalendar.ShowTodayCircle = false;
            this.resetCalendar.TabIndex = 16;
            this.resetCalendar.TabStop = false;
            this.resetCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.resetCalendar_DateSelected);
            // 
            // AutoResetSchedule
            // 
            this.AutoResetSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AutoResetSchedule.Controls.Add(this.RemoveAllbutton);
            this.AutoResetSchedule.Controls.Add(this.button1);
            this.AutoResetSchedule.Controls.Add(this.ResetDateListBox);
            this.AutoResetSchedule.Controls.Add(this.removebutton);
            this.AutoResetSchedule.Controls.Add(this.resetCalendar);
            this.AutoResetSchedule.Location = new System.Drawing.Point(878, 12);
            this.AutoResetSchedule.MinimumSize = new System.Drawing.Size(244, 317);
            this.AutoResetSchedule.Name = "AutoResetSchedule";
            this.AutoResetSchedule.Size = new System.Drawing.Size(244, 317);
            this.AutoResetSchedule.TabIndex = 17;
            this.AutoResetSchedule.TabStop = false;
            this.AutoResetSchedule.Text = "AutoResetSchedule";
            // 
            // RemoveAllbutton
            // 
            this.RemoveAllbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveAllbutton.Location = new System.Drawing.Point(93, 288);
            this.RemoveAllbutton.Name = "RemoveAllbutton";
            this.RemoveAllbutton.Size = new System.Drawing.Size(75, 23);
            this.RemoveAllbutton.TabIndex = 21;
            this.RemoveAllbutton.Text = "removeall";
            this.RemoveAllbutton.UseVisualStyleBackColor = true;
            this.RemoveAllbutton.Click += new System.EventHandler(this.RemoveAllbutton_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.ContextMenuStrip = this.contextMenuStripOnTestMenu;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.button1.Location = new System.Drawing.Point(180, 288);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "TestMenu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStripOnTestMenu
            // 
            this.contextMenuStripOnTestMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverUpdateToolStripMenuItem,
            this.serverResetToolStripMenuItem});
            this.contextMenuStripOnTestMenu.Name = "contextMenuStripOnTestMenu";
            this.contextMenuStripOnTestMenu.Size = new System.Drawing.Size(146, 48);
            // 
            // serverUpdateToolStripMenuItem
            // 
            this.serverUpdateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DefaultUpdateToolStripItem,
            this.ServerQuitToolStripItem,
            this.DeleteResetFilesToolStripItem,
            this.ResetDisplayUpdatetoolStripItem,
            this.RunUpdateProcessToolStripItem,
            this.RunServerToolStripItem});
            this.serverUpdateToolStripMenuItem.Name = "serverUpdateToolStripMenuItem";
            this.serverUpdateToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.serverUpdateToolStripMenuItem.Text = "ServerUpdate";
            // 
            // DefaultUpdateToolStripItem
            // 
            this.DefaultUpdateToolStripItem.Name = "DefaultUpdateToolStripItem";
            this.DefaultUpdateToolStripItem.Size = new System.Drawing.Size(179, 22);
            this.DefaultUpdateToolStripItem.Text = "DefaultUpdate";
            this.DefaultUpdateToolStripItem.Click += new System.EventHandler(this.DefaultUpdateToolStripItem_Click);
            // 
            // ServerQuitToolStripItem
            // 
            this.ServerQuitToolStripItem.Name = "ServerQuitToolStripItem";
            this.ServerQuitToolStripItem.Size = new System.Drawing.Size(179, 22);
            this.ServerQuitToolStripItem.Text = "ServerQuit";
            this.ServerQuitToolStripItem.Click += new System.EventHandler(this.ServerQuitToolStripItem_Click);
            // 
            // DeleteResetFilesToolStripItem
            // 
            this.DeleteResetFilesToolStripItem.Name = "DeleteResetFilesToolStripItem";
            this.DeleteResetFilesToolStripItem.Size = new System.Drawing.Size(179, 22);
            this.DeleteResetFilesToolStripItem.Text = "DeleteResetFiles";
            this.DeleteResetFilesToolStripItem.Click += new System.EventHandler(this.DeleteResetFilesToolStripItem_Click);
            // 
            // ResetDisplayUpdatetoolStripItem
            // 
            this.ResetDisplayUpdatetoolStripItem.Name = "ResetDisplayUpdatetoolStripItem";
            this.ResetDisplayUpdatetoolStripItem.Size = new System.Drawing.Size(179, 22);
            this.ResetDisplayUpdatetoolStripItem.Text = "ResetDisplayUpdate";
            this.ResetDisplayUpdatetoolStripItem.Click += new System.EventHandler(this.ResetDisplayUpdatetoolStripItem_Click);
            // 
            // RunUpdateProcessToolStripItem
            // 
            this.RunUpdateProcessToolStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oxideDownloadToolStripItem,
            this.oxideDownloadCancelToolStripItem});
            this.RunUpdateProcessToolStripItem.Name = "RunUpdateProcessToolStripItem";
            this.RunUpdateProcessToolStripItem.Size = new System.Drawing.Size(179, 22);
            this.RunUpdateProcessToolStripItem.Text = "RunUpdateProcess";
            this.RunUpdateProcessToolStripItem.Click += new System.EventHandler(this.RunUpdateProcessToolStripItem_Click);
            // 
            // oxideDownloadToolStripItem
            // 
            this.oxideDownloadToolStripItem.Name = "oxideDownloadToolStripItem";
            this.oxideDownloadToolStripItem.Size = new System.Drawing.Size(196, 22);
            this.oxideDownloadToolStripItem.Text = "OxideDownload";
            this.oxideDownloadToolStripItem.Click += new System.EventHandler(this.oxideDownloadToolStripItem_Click);
            // 
            // oxideDownloadCancelToolStripItem
            // 
            this.oxideDownloadCancelToolStripItem.Name = "oxideDownloadCancelToolStripItem";
            this.oxideDownloadCancelToolStripItem.Size = new System.Drawing.Size(196, 22);
            this.oxideDownloadCancelToolStripItem.Text = "OxideDownloadCancel";
            this.oxideDownloadCancelToolStripItem.Click += new System.EventHandler(this.oxideDownloadCancelToolStripItem_Click);
            // 
            // RunServerToolStripItem
            // 
            this.RunServerToolStripItem.Name = "RunServerToolStripItem";
            this.RunServerToolStripItem.Size = new System.Drawing.Size(179, 22);
            this.RunServerToolStripItem.Text = "RunServer";
            this.RunServerToolStripItem.Click += new System.EventHandler(this.RunServerToolStripItem_Click);
            // 
            // serverResetToolStripMenuItem
            // 
            this.serverResetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DefaultResetToolStripItem,
            this.ServerQuitOnResetToolStripItem,
            this.DeleteResetFilesOnResetToolStripItem,
            this.ResetDisplayUpdatetoolStripItem1,
            this.RunServerOnResetToolStripItem});
            this.serverResetToolStripMenuItem.Name = "serverResetToolStripMenuItem";
            this.serverResetToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.serverResetToolStripMenuItem.Text = "ServerReset";
            // 
            // DefaultResetToolStripItem
            // 
            this.DefaultResetToolStripItem.Name = "DefaultResetToolStripItem";
            this.DefaultResetToolStripItem.Size = new System.Drawing.Size(179, 22);
            this.DefaultResetToolStripItem.Text = "DefaultReset";
            this.DefaultResetToolStripItem.Click += new System.EventHandler(this.DefaultResetToolStripItem_Click);
            // 
            // ServerQuitOnResetToolStripItem
            // 
            this.ServerQuitOnResetToolStripItem.Name = "ServerQuitOnResetToolStripItem";
            this.ServerQuitOnResetToolStripItem.Size = new System.Drawing.Size(179, 22);
            this.ServerQuitOnResetToolStripItem.Text = "ServerQuit";
            this.ServerQuitOnResetToolStripItem.Click += new System.EventHandler(this.ServerQuitOnResetToolStripItem_Click);
            // 
            // DeleteResetFilesOnResetToolStripItem
            // 
            this.DeleteResetFilesOnResetToolStripItem.Name = "DeleteResetFilesOnResetToolStripItem";
            this.DeleteResetFilesOnResetToolStripItem.Size = new System.Drawing.Size(179, 22);
            this.DeleteResetFilesOnResetToolStripItem.Text = "DeleteResetFiles";
            this.DeleteResetFilesOnResetToolStripItem.Click += new System.EventHandler(this.DeleteResetFilesOnResetToolStripItem_Click);
            // 
            // ResetDisplayUpdatetoolStripItem1
            // 
            this.ResetDisplayUpdatetoolStripItem1.Name = "ResetDisplayUpdatetoolStripItem1";
            this.ResetDisplayUpdatetoolStripItem1.Size = new System.Drawing.Size(179, 22);
            this.ResetDisplayUpdatetoolStripItem1.Text = "ResetDisplayUpdate";
            this.ResetDisplayUpdatetoolStripItem1.Click += new System.EventHandler(this.ResetDisplayUpdatetoolStripItem1_Click);
            // 
            // RunServerOnResetToolStripItem
            // 
            this.RunServerOnResetToolStripItem.Name = "RunServerOnResetToolStripItem";
            this.RunServerOnResetToolStripItem.Size = new System.Drawing.Size(179, 22);
            this.RunServerOnResetToolStripItem.Text = "RunServer";
            this.RunServerOnResetToolStripItem.Click += new System.EventHandler(this.RunServerOnResetToolStripItem_Click);
            // 
            // ResetDateListBox
            // 
            this.ResetDateListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetDateListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ResetDateListBox.FormattingEnabled = true;
            this.ResetDateListBox.Location = new System.Drawing.Point(12, 195);
            this.ResetDateListBox.MinimumSize = new System.Drawing.Size(220, 82);
            this.ResetDateListBox.Name = "ResetDateListBox";
            this.ResetDateListBox.Size = new System.Drawing.Size(220, 82);
            this.ResetDateListBox.TabIndex = 19;
            // 
            // removebutton
            // 
            this.removebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removebutton.Location = new System.Drawing.Point(12, 288);
            this.removebutton.Name = "removebutton";
            this.removebutton.Size = new System.Drawing.Size(75, 23);
            this.removebutton.TabIndex = 18;
            this.removebutton.Text = "remove";
            this.removebutton.UseVisualStyleBackColor = true;
            this.removebutton.Click += new System.EventHandler(this.removebutton_Click);
            // 
            // updateProgressbar
            // 
            this.updateProgressbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.updateProgressbar.Location = new System.Drawing.Point(12, 306);
            this.updateProgressbar.Name = "updateProgressbar";
            this.updateProgressbar.Size = new System.Drawing.Size(468, 23);
            this.updateProgressbar.TabIndex = 18;
            // 
            // AutoResetFilesgroup
            // 
            this.AutoResetFilesgroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AutoResetFilesgroup.Controls.Add(this.ResetLinktextBox);
            this.AutoResetFilesgroup.Controls.Add(this.ResetFileBrowseButton);
            this.AutoResetFilesgroup.Controls.Add(this.ResetFileslistView);
            this.AutoResetFilesgroup.Controls.Add(this.ResetFileRemoveButton);
            this.AutoResetFilesgroup.Controls.Add(this.ResetFileAddButton);
            this.AutoResetFilesgroup.Location = new System.Drawing.Point(488, 12);
            this.AutoResetFilesgroup.MinimumSize = new System.Drawing.Size(384, 249);
            this.AutoResetFilesgroup.Name = "AutoResetFilesgroup";
            this.AutoResetFilesgroup.Size = new System.Drawing.Size(384, 249);
            this.AutoResetFilesgroup.TabIndex = 19;
            this.AutoResetFilesgroup.TabStop = false;
            this.AutoResetFilesgroup.Text = "AutoResetFiles";
            // 
            // ResetLinktextBox
            // 
            this.ResetLinktextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetLinktextBox.Location = new System.Drawing.Point(37, 221);
            this.ResetLinktextBox.MinimumSize = new System.Drawing.Size(179, 21);
            this.ResetLinktextBox.Name = "ResetLinktextBox";
            this.ResetLinktextBox.Size = new System.Drawing.Size(179, 21);
            this.ResetLinktextBox.TabIndex = 5;
            this.ResetLinktextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ResetLinktextBox_KeyDown);
            // 
            // ResetFileBrowseButton
            // 
            this.ResetFileBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ResetFileBrowseButton.Location = new System.Drawing.Point(6, 219);
            this.ResetFileBrowseButton.Name = "ResetFileBrowseButton";
            this.ResetFileBrowseButton.Size = new System.Drawing.Size(25, 23);
            this.ResetFileBrowseButton.TabIndex = 4;
            this.ResetFileBrowseButton.Text = "...";
            this.ResetFileBrowseButton.UseVisualStyleBackColor = true;
            this.ResetFileBrowseButton.Click += new System.EventHandler(this.ResetFileBrowseButton_Click);
            // 
            // ResetFileslistView
            // 
            this.ResetFileslistView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetFileslistView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ResetFileslistView.CheckBoxes = true;
            this.ResetFileslistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.checkbox,
            this.FileName,
            this.FileLink});
            this.ResetFileslistView.GridLines = true;
            this.ResetFileslistView.Location = new System.Drawing.Point(6, 21);
            this.ResetFileslistView.MinimumSize = new System.Drawing.Size(372, 192);
            this.ResetFileslistView.Name = "ResetFileslistView";
            this.ResetFileslistView.OwnerDraw = true;
            this.ResetFileslistView.Size = new System.Drawing.Size(372, 192);
            this.ResetFileslistView.TabIndex = 3;
            this.ResetFileslistView.UseCompatibleStateImageBehavior = false;
            this.ResetFileslistView.View = System.Windows.Forms.View.Details;
            this.ResetFileslistView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ResetFileslistView_ColumnClick);
            this.ResetFileslistView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ResetFileslistView_DrawColumnHeader);
            this.ResetFileslistView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ResetFileslistView_DrawItem);
            this.ResetFileslistView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ResetFileslistView_DrawSubItem);
            // 
            // checkbox
            // 
            this.checkbox.Text = "";
            this.checkbox.Width = 25;
            // 
            // FileName
            // 
            this.FileName.Text = "FileName";
            this.FileName.Width = 240;
            // 
            // FileLink
            // 
            this.FileLink.Text = "Location";
            this.FileLink.Width = 1000;
            // 
            // ResetFileRemoveButton
            // 
            this.ResetFileRemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetFileRemoveButton.Location = new System.Drawing.Point(303, 219);
            this.ResetFileRemoveButton.Name = "ResetFileRemoveButton";
            this.ResetFileRemoveButton.Size = new System.Drawing.Size(75, 23);
            this.ResetFileRemoveButton.TabIndex = 2;
            this.ResetFileRemoveButton.Text = "remove";
            this.ResetFileRemoveButton.UseVisualStyleBackColor = true;
            this.ResetFileRemoveButton.Click += new System.EventHandler(this.ResetFileRemoveButton_Click);
            // 
            // ResetFileAddButton
            // 
            this.ResetFileAddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetFileAddButton.Location = new System.Drawing.Point(222, 219);
            this.ResetFileAddButton.Name = "ResetFileAddButton";
            this.ResetFileAddButton.Size = new System.Drawing.Size(75, 23);
            this.ResetFileAddButton.TabIndex = 1;
            this.ResetFileAddButton.Text = "add";
            this.ResetFileAddButton.UseVisualStyleBackColor = true;
            this.ResetFileAddButton.Click += new System.EventHandler(this.ResetFileAddButton_Click);
            // 
            // SetServerRunFilegroupBox
            // 
            this.SetServerRunFilegroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SetServerRunFilegroupBox.Controls.Add(this.CorrentBatchFileLocationlabel);
            this.SetServerRunFilegroupBox.Controls.Add(this.FileLocationTitlelabel);
            this.SetServerRunFilegroupBox.Controls.Add(this.SetServerRunFilebutton);
            this.SetServerRunFilegroupBox.Controls.Add(this.ResetFileLinktextBox);
            this.SetServerRunFilegroupBox.Controls.Add(this.RunFileBrowseButton);
            this.SetServerRunFilegroupBox.Location = new System.Drawing.Point(488, 267);
            this.SetServerRunFilegroupBox.MinimumSize = new System.Drawing.Size(384, 62);
            this.SetServerRunFilegroupBox.Name = "SetServerRunFilegroupBox";
            this.SetServerRunFilegroupBox.Size = new System.Drawing.Size(384, 62);
            this.SetServerRunFilegroupBox.TabIndex = 6;
            this.SetServerRunFilegroupBox.TabStop = false;
            this.SetServerRunFilegroupBox.Text = "SetServerRunFile";
            // 
            // CorrentBatchFileLocationlabel
            // 
            this.CorrentBatchFileLocationlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CorrentBatchFileLocationlabel.AutoSize = true;
            this.CorrentBatchFileLocationlabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.CorrentBatchFileLocationlabel.Location = new System.Drawing.Point(97, 46);
            this.CorrentBatchFileLocationlabel.Name = "CorrentBatchFileLocationlabel";
            this.CorrentBatchFileLocationlabel.Size = new System.Drawing.Size(24, 12);
            this.CorrentBatchFileLocationlabel.TabIndex = 4;
            this.CorrentBatchFileLocationlabel.Text = "link";
            // 
            // FileLocationTitlelabel
            // 
            this.FileLocationTitlelabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FileLocationTitlelabel.AutoSize = true;
            this.FileLocationTitlelabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.FileLocationTitlelabel.Location = new System.Drawing.Point(4, 46);
            this.FileLocationTitlelabel.Name = "FileLocationTitlelabel";
            this.FileLocationTitlelabel.Size = new System.Drawing.Size(77, 12);
            this.FileLocationTitlelabel.TabIndex = 3;
            this.FileLocationTitlelabel.Text = "FileLocation:";
            // 
            // SetServerRunFilebutton
            // 
            this.SetServerRunFilebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SetServerRunFilebutton.Location = new System.Drawing.Point(303, 20);
            this.SetServerRunFilebutton.Name = "SetServerRunFilebutton";
            this.SetServerRunFilebutton.Size = new System.Drawing.Size(75, 23);
            this.SetServerRunFilebutton.TabIndex = 2;
            this.SetServerRunFilebutton.Text = "set";
            this.SetServerRunFilebutton.UseVisualStyleBackColor = true;
            this.SetServerRunFilebutton.Click += new System.EventHandler(this.SetServerRunFilebutton_Click);
            // 
            // ResetFileLinktextBox
            // 
            this.ResetFileLinktextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetFileLinktextBox.Location = new System.Drawing.Point(37, 22);
            this.ResetFileLinktextBox.MinimumSize = new System.Drawing.Size(260, 21);
            this.ResetFileLinktextBox.Name = "ResetFileLinktextBox";
            this.ResetFileLinktextBox.Size = new System.Drawing.Size(260, 21);
            this.ResetFileLinktextBox.TabIndex = 1;
            this.ResetFileLinktextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ResetFileLinktextBox_KeyDown);
            // 
            // RunFileBrowseButton
            // 
            this.RunFileBrowseButton.Location = new System.Drawing.Point(6, 20);
            this.RunFileBrowseButton.Name = "RunFileBrowseButton";
            this.RunFileBrowseButton.Size = new System.Drawing.Size(25, 23);
            this.RunFileBrowseButton.TabIndex = 0;
            this.RunFileBrowseButton.Text = "...";
            this.RunFileBrowseButton.UseVisualStyleBackColor = true;
            this.RunFileBrowseButton.Click += new System.EventHandler(this.RunFileBrowseButton_Click);
            // 
            // SetResetFilesopenFileDialog
            // 
            this.SetResetFilesopenFileDialog.Filter = "json flie (*.json*)|*.json*|database flie (*.db*)|*.db*|map flie (*.map*)|*.map*|" +
    "sav flie (*.sav*)|*.sav*|모든 파일 (*.*)|*.*";
            this.SetResetFilesopenFileDialog.InitialDirectory = "C:";
            this.SetResetFilesopenFileDialog.Title = "SetResetFile";
            // 
            // SetServerRunFileopenFileDialog
            // 
            this.SetServerRunFileopenFileDialog.Filter = "batch flie (*.bat*)|*.bat*|모든 파일 (*.*)|*.*";
            this.SetServerRunFileopenFileDialog.InitialDirectory = "C:";
            this.SetServerRunFileopenFileDialog.Title = "SetServerRunFIle";
            // 
            // DownloadTimeoutTimer
            // 
            this.DownloadTimeoutTimer.Interval = 1000;
            this.DownloadTimeoutTimer.Tick += new System.EventHandler(this.DownloadTimeoutTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 341);
            this.Controls.Add(this.AutoResetSchedule);
            this.Controls.Add(this.SetServerRunFilegroupBox);
            this.Controls.Add(this.AutoResetFilesgroup);
            this.Controls.Add(this.updateProgressbar);
            this.Controls.Add(this.DataStatusGroupbox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.consoleRichTextbox);
            this.Controls.Add(this.SetdatafilegroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1150, 379);
            this.Name = "MainForm";
            this.Text = "UntitleSystem";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuOnTrayMode.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.DataStatusGroupbox.ResumeLayout(false);
            this.DataStatusGroupbox.PerformLayout();
            this.SetdatafilegroupBox.ResumeLayout(false);
            this.SetdatafilegroupBox.PerformLayout();
            this.AutoResetSchedule.ResumeLayout(false);
            this.contextMenuStripOnTestMenu.ResumeLayout(false);
            this.AutoResetFilesgroup.ResumeLayout(false);
            this.AutoResetFilesgroup.PerformLayout();
            this.SetServerRunFilegroupBox.ResumeLayout(false);
            this.SetServerRunFilegroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label rebootTitle;
        private System.Windows.Forms.Label shutdownTitle;
        private System.Windows.Forms.Label Rebootstatinfo;
        private System.Windows.Forms.Label ShutdownStatInfo;
        private System.Windows.Forms.Timer EventUpdatetimer;
        private System.Windows.Forms.Label updatestattitle;
        private System.Windows.Forms.Label updatestat;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuOnTrayMode;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Button LinkApply;
        private System.Windows.Forms.TextBox LinktextBox;
        private System.Windows.Forms.Label infolabel;
        private System.Windows.Forms.Label Filelocationtitle;
        private System.Windows.Forms.Label correntfilelocation;
        private System.Windows.Forms.Button broserbutton;
        private System.Windows.Forms.OpenFileDialog SetdatafileopenFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox StartonbackgroundcheckBox;
        private System.Windows.Forms.CheckBox AutoServerUpdatecheckBox;
        private System.Windows.Forms.GroupBox DataStatusGroupbox;
        private System.Windows.Forms.GroupBox SetdatafilegroupBox;
        private System.Windows.Forms.Label VerstatInfo;
        private System.Windows.Forms.Label VerstatTitle;
        private System.Windows.Forms.MonthCalendar resetCalendar;
        private System.Windows.Forms.CheckBox AutoServerResetcheckBox;
        private System.Windows.Forms.GroupBox AutoResetSchedule;
        private System.Windows.Forms.CheckedListBox ResetDateListBox;
        private System.Windows.Forms.Button removebutton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar updateProgressbar;
        private System.Windows.Forms.GroupBox AutoResetFilesgroup;
        private System.Windows.Forms.Button ResetFileRemoveButton;
        private System.Windows.Forms.Button ResetFileAddButton;
        private System.Windows.Forms.ListView ResetFileslistView;
        private System.Windows.Forms.ColumnHeader checkbox;
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.ColumnHeader FileLink;
        private System.Windows.Forms.TextBox ResetLinktextBox;
        private System.Windows.Forms.Button ResetFileBrowseButton;
        private System.Windows.Forms.GroupBox SetServerRunFilegroupBox;
        private System.Windows.Forms.Button RunFileBrowseButton;
        private System.Windows.Forms.OpenFileDialog SetResetFilesopenFileDialog;
        private System.Windows.Forms.OpenFileDialog SetServerRunFileopenFileDialog;
        private System.Windows.Forms.Label CorrentBatchFileLocationlabel;
        private System.Windows.Forms.Label FileLocationTitlelabel;
        private System.Windows.Forms.Button SetServerRunFilebutton;
        private System.Windows.Forms.TextBox ResetFileLinktextBox;
        private System.Windows.Forms.Button RemoveAllbutton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripOnTestMenu;
        private System.Windows.Forms.ToolStripMenuItem serverUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverResetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DefaultUpdateToolStripItem;
        private System.Windows.Forms.ToolStripMenuItem ServerQuitToolStripItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteResetFilesToolStripItem;
        private System.Windows.Forms.ToolStripMenuItem RunUpdateProcessToolStripItem;
        private System.Windows.Forms.ToolStripMenuItem RunServerToolStripItem;
        private System.Windows.Forms.ToolStripMenuItem ServerQuitOnResetToolStripItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteResetFilesOnResetToolStripItem;
        private System.Windows.Forms.ToolStripMenuItem RunServerOnResetToolStripItem;
        private System.Windows.Forms.ToolStripMenuItem DefaultResetToolStripItem;
        private System.Windows.Forms.ToolStripMenuItem oxideDownloadToolStripItem;
        private System.Windows.Forms.ToolStripMenuItem oxideDownloadCancelToolStripItem;
        private System.Windows.Forms.Timer DownloadTimeoutTimer;
        private System.Windows.Forms.ToolStripMenuItem ResetDisplayUpdatetoolStripItem;
        private System.Windows.Forms.ToolStripMenuItem ResetDisplayUpdatetoolStripItem1;
        private System.Windows.Forms.RichTextBox consoleRichTextbox;
    }
}

