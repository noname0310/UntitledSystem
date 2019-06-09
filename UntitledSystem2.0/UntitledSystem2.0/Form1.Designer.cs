namespace UntitledSystem2._0
{
    partial class UntitledSystemForm
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
            this.SetDataFileLocationGroupBox = new System.Windows.Forms.GroupBox();
            this.SetRunFileGroupBox = new System.Windows.Forms.GroupBox();
            this.SetRunFileBtnBrowse = new System.Windows.Forms.Button();
            this.SetRunFileBtnSet = new System.Windows.Forms.Button();
            this.SetRunFileTextBox = new System.Windows.Forms.TextBox();
            this.SetPluginDataFileGroupBox = new System.Windows.Forms.GroupBox();
            this.SetPluginDatafileBtnBrowse = new System.Windows.Forms.Button();
            this.SetPluginDatafileBtnSet = new System.Windows.Forms.Button();
            this.SetPluginDatafileTextBox = new System.Windows.Forms.TextBox();
            this.DataStatsGroupBox = new System.Windows.Forms.GroupBox();
            this.DataReadStatsLabel = new System.Windows.Forms.Label();
            this.DataReadStatTitleLabel = new System.Windows.Forms.Label();
            this.ConsoleGroupBox = new System.Windows.Forms.GroupBox();
            this.ConsoleRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SetResetFilesGroupBox = new System.Windows.Forms.GroupBox();
            this.ResetScheduleGroupBox = new System.Windows.Forms.GroupBox();
            this.ResetScheduleAddButton = new System.Windows.Forms.Button();
            this.ResetScheduleSizeLabel = new System.Windows.Forms.Label();
            this.ResetScheduleSizeTextBox = new System.Windows.Forms.TextBox();
            this.ResetScheduleSeedTextBox = new System.Windows.Forms.TextBox();
            this.ResetScheduleSeedLabel = new System.Windows.Forms.Label();
            this.ResetScheduleListView = new System.Windows.Forms.ListView();
            this.ResetDayColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MapSeedColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MapSizeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ResetScheduleBtnRemove = new System.Windows.Forms.Button();
            this.ResetScheduleBtnRemoveAll = new System.Windows.Forms.Button();
            this.ResetMonthCalendar = new System.Windows.Forms.MonthCalendar();
            this.QuickUpdateResetGroupBox = new System.Windows.Forms.GroupBox();
            this.QuickUpdateResetServerUpdateRadioButton = new System.Windows.Forms.RadioButton();
            this.QuickUpdateResetRunButton = new System.Windows.Forms.Button();
            this.QuickUpdateResetResetBPRadioButton = new System.Windows.Forms.RadioButton();
            this.QuickUpdateResetResetMapRadioButton = new System.Windows.Forms.RadioButton();
            this.QuickUpdateResetResetDataFilesRadioButton = new System.Windows.Forms.RadioButton();
            this.QuickUpdateResetSizeLabel = new System.Windows.Forms.Label();
            this.QuickUpdateResetSizeTextBox = new System.Windows.Forms.TextBox();
            this.QuickUpdateResetSeedTextBox = new System.Windows.Forms.TextBox();
            this.QuickUpdateResetSeedLabel = new System.Windows.Forms.Label();
            this.QuickUpdateResetRunServerRadioButton = new System.Windows.Forms.RadioButton();
            this.ResetScheduleRunServerRadioButton = new System.Windows.Forms.RadioButton();
            this.ResetScheduleServerUpdateRadioButton = new System.Windows.Forms.RadioButton();
            this.ResetScheduleResetBPRadioButton = new System.Windows.Forms.RadioButton();
            this.ResetScheduleResetMapRadioButton = new System.Windows.Forms.RadioButton();
            this.ResetScheduleResetDataFilesRadioButton = new System.Windows.Forms.RadioButton();
            this.SettingGroupBox = new System.Windows.Forms.GroupBox();
            this.SetDataFileLocationGroupBox.SuspendLayout();
            this.SetRunFileGroupBox.SuspendLayout();
            this.SetPluginDataFileGroupBox.SuspendLayout();
            this.DataStatsGroupBox.SuspendLayout();
            this.ConsoleGroupBox.SuspendLayout();
            this.ResetScheduleGroupBox.SuspendLayout();
            this.QuickUpdateResetGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SetDataFileLocationGroupBox
            // 
            this.SetDataFileLocationGroupBox.Controls.Add(this.SetRunFileGroupBox);
            this.SetDataFileLocationGroupBox.Controls.Add(this.SetPluginDataFileGroupBox);
            this.SetDataFileLocationGroupBox.Location = new System.Drawing.Point(13, 12);
            this.SetDataFileLocationGroupBox.Name = "SetDataFileLocationGroupBox";
            this.SetDataFileLocationGroupBox.Size = new System.Drawing.Size(360, 125);
            this.SetDataFileLocationGroupBox.TabIndex = 0;
            this.SetDataFileLocationGroupBox.TabStop = false;
            this.SetDataFileLocationGroupBox.Text = "SetDataFileLocation";
            // 
            // SetRunFileGroupBox
            // 
            this.SetRunFileGroupBox.Controls.Add(this.SetRunFileBtnBrowse);
            this.SetRunFileGroupBox.Controls.Add(this.SetRunFileBtnSet);
            this.SetRunFileGroupBox.Controls.Add(this.SetRunFileTextBox);
            this.SetRunFileGroupBox.Location = new System.Drawing.Point(6, 71);
            this.SetRunFileGroupBox.Name = "SetRunFileGroupBox";
            this.SetRunFileGroupBox.Size = new System.Drawing.Size(347, 46);
            this.SetRunFileGroupBox.TabIndex = 1;
            this.SetRunFileGroupBox.TabStop = false;
            this.SetRunFileGroupBox.Text = "SetRunFile";
            // 
            // SetRunFileBtnBrowse
            // 
            this.SetRunFileBtnBrowse.Location = new System.Drawing.Point(310, 16);
            this.SetRunFileBtnBrowse.Name = "SetRunFileBtnBrowse";
            this.SetRunFileBtnBrowse.Size = new System.Drawing.Size(31, 22);
            this.SetRunFileBtnBrowse.TabIndex = 3;
            this.SetRunFileBtnBrowse.Text = "...";
            this.SetRunFileBtnBrowse.UseVisualStyleBackColor = true;
            // 
            // SetRunFileBtnSet
            // 
            this.SetRunFileBtnSet.Location = new System.Drawing.Point(239, 16);
            this.SetRunFileBtnSet.Name = "SetRunFileBtnSet";
            this.SetRunFileBtnSet.Size = new System.Drawing.Size(65, 23);
            this.SetRunFileBtnSet.TabIndex = 3;
            this.SetRunFileBtnSet.Text = "set";
            this.SetRunFileBtnSet.UseVisualStyleBackColor = true;
            // 
            // SetRunFileTextBox
            // 
            this.SetRunFileTextBox.Location = new System.Drawing.Point(6, 19);
            this.SetRunFileTextBox.Name = "SetRunFileTextBox";
            this.SetRunFileTextBox.Size = new System.Drawing.Size(227, 20);
            this.SetRunFileTextBox.TabIndex = 1;
            // 
            // SetPluginDataFileGroupBox
            // 
            this.SetPluginDataFileGroupBox.Controls.Add(this.SetPluginDatafileBtnBrowse);
            this.SetPluginDataFileGroupBox.Controls.Add(this.SetPluginDatafileBtnSet);
            this.SetPluginDataFileGroupBox.Controls.Add(this.SetPluginDatafileTextBox);
            this.SetPluginDataFileGroupBox.Location = new System.Drawing.Point(6, 19);
            this.SetPluginDataFileGroupBox.Name = "SetPluginDataFileGroupBox";
            this.SetPluginDataFileGroupBox.Size = new System.Drawing.Size(347, 46);
            this.SetPluginDataFileGroupBox.TabIndex = 0;
            this.SetPluginDataFileGroupBox.TabStop = false;
            this.SetPluginDataFileGroupBox.Text = "SetPluginDataFile";
            // 
            // SetPluginDatafileBtnBrowse
            // 
            this.SetPluginDatafileBtnBrowse.Location = new System.Drawing.Point(310, 16);
            this.SetPluginDatafileBtnBrowse.Name = "SetPluginDatafileBtnBrowse";
            this.SetPluginDatafileBtnBrowse.Size = new System.Drawing.Size(31, 22);
            this.SetPluginDatafileBtnBrowse.TabIndex = 2;
            this.SetPluginDatafileBtnBrowse.Text = "...";
            this.SetPluginDatafileBtnBrowse.UseVisualStyleBackColor = true;
            // 
            // SetPluginDatafileBtnSet
            // 
            this.SetPluginDatafileBtnSet.Location = new System.Drawing.Point(239, 16);
            this.SetPluginDatafileBtnSet.Name = "SetPluginDatafileBtnSet";
            this.SetPluginDatafileBtnSet.Size = new System.Drawing.Size(65, 23);
            this.SetPluginDatafileBtnSet.TabIndex = 1;
            this.SetPluginDatafileBtnSet.Text = "set";
            this.SetPluginDatafileBtnSet.UseVisualStyleBackColor = true;
            // 
            // SetPluginDatafileTextBox
            // 
            this.SetPluginDatafileTextBox.Location = new System.Drawing.Point(6, 19);
            this.SetPluginDatafileTextBox.Name = "SetPluginDatafileTextBox";
            this.SetPluginDatafileTextBox.Size = new System.Drawing.Size(227, 20);
            this.SetPluginDatafileTextBox.TabIndex = 0;
            // 
            // DataStatsGroupBox
            // 
            this.DataStatsGroupBox.Controls.Add(this.DataReadStatsLabel);
            this.DataStatsGroupBox.Controls.Add(this.DataReadStatTitleLabel);
            this.DataStatsGroupBox.Location = new System.Drawing.Point(12, 136);
            this.DataStatsGroupBox.Name = "DataStatsGroupBox";
            this.DataStatsGroupBox.Size = new System.Drawing.Size(360, 185);
            this.DataStatsGroupBox.TabIndex = 1;
            this.DataStatsGroupBox.TabStop = false;
            this.DataStatsGroupBox.Text = "DataStats";
            // 
            // DataReadStatsLabel
            // 
            this.DataReadStatsLabel.AutoSize = true;
            this.DataReadStatsLabel.Location = new System.Drawing.Point(100, 20);
            this.DataReadStatsLabel.Name = "DataReadStatsLabel";
            this.DataReadStatsLabel.Size = new System.Drawing.Size(27, 13);
            this.DataReadStatsLabel.TabIndex = 1;
            this.DataReadStatsLabel.Text = "N/A";
            // 
            // DataReadStatTitleLabel
            // 
            this.DataReadStatTitleLabel.AutoSize = true;
            this.DataReadStatTitleLabel.Location = new System.Drawing.Point(7, 20);
            this.DataReadStatTitleLabel.Name = "DataReadStatTitleLabel";
            this.DataReadStatTitleLabel.Size = new System.Drawing.Size(81, 13);
            this.DataReadStatTitleLabel.TabIndex = 0;
            this.DataReadStatTitleLabel.Text = "DataReadStat :";
            // 
            // ConsoleGroupBox
            // 
            this.ConsoleGroupBox.Controls.Add(this.ConsoleRichTextBox);
            this.ConsoleGroupBox.Location = new System.Drawing.Point(12, 327);
            this.ConsoleGroupBox.Name = "ConsoleGroupBox";
            this.ConsoleGroupBox.Size = new System.Drawing.Size(360, 172);
            this.ConsoleGroupBox.TabIndex = 2;
            this.ConsoleGroupBox.TabStop = false;
            this.ConsoleGroupBox.Text = "Console";
            // 
            // ConsoleRichTextBox
            // 
            this.ConsoleRichTextBox.Location = new System.Drawing.Point(6, 19);
            this.ConsoleRichTextBox.Name = "ConsoleRichTextBox";
            this.ConsoleRichTextBox.Size = new System.Drawing.Size(348, 147);
            this.ConsoleRichTextBox.TabIndex = 0;
            this.ConsoleRichTextBox.Text = "";
            // 
            // SetResetFilesGroupBox
            // 
            this.SetResetFilesGroupBox.Location = new System.Drawing.Point(629, 12);
            this.SetResetFilesGroupBox.Name = "SetResetFilesGroupBox";
            this.SetResetFilesGroupBox.Size = new System.Drawing.Size(343, 377);
            this.SetResetFilesGroupBox.TabIndex = 3;
            this.SetResetFilesGroupBox.TabStop = false;
            this.SetResetFilesGroupBox.Text = "SetResetFiles";
            // 
            // ResetScheduleGroupBox
            // 
            this.ResetScheduleGroupBox.Controls.Add(this.ResetScheduleRunServerRadioButton);
            this.ResetScheduleGroupBox.Controls.Add(this.ResetScheduleServerUpdateRadioButton);
            this.ResetScheduleGroupBox.Controls.Add(this.ResetScheduleResetBPRadioButton);
            this.ResetScheduleGroupBox.Controls.Add(this.ResetScheduleResetMapRadioButton);
            this.ResetScheduleGroupBox.Controls.Add(this.ResetScheduleResetDataFilesRadioButton);
            this.ResetScheduleGroupBox.Controls.Add(this.ResetScheduleAddButton);
            this.ResetScheduleGroupBox.Controls.Add(this.ResetScheduleSizeLabel);
            this.ResetScheduleGroupBox.Controls.Add(this.ResetScheduleSizeTextBox);
            this.ResetScheduleGroupBox.Controls.Add(this.ResetScheduleSeedTextBox);
            this.ResetScheduleGroupBox.Controls.Add(this.ResetScheduleSeedLabel);
            this.ResetScheduleGroupBox.Controls.Add(this.ResetScheduleListView);
            this.ResetScheduleGroupBox.Controls.Add(this.ResetScheduleBtnRemove);
            this.ResetScheduleGroupBox.Controls.Add(this.ResetScheduleBtnRemoveAll);
            this.ResetScheduleGroupBox.Controls.Add(this.ResetMonthCalendar);
            this.ResetScheduleGroupBox.Location = new System.Drawing.Point(379, 12);
            this.ResetScheduleGroupBox.Name = "ResetScheduleGroupBox";
            this.ResetScheduleGroupBox.Size = new System.Drawing.Size(244, 397);
            this.ResetScheduleGroupBox.TabIndex = 4;
            this.ResetScheduleGroupBox.TabStop = false;
            this.ResetScheduleGroupBox.Text = "ResetSchedule";
            // 
            // ResetScheduleAddButton
            // 
            this.ResetScheduleAddButton.Location = new System.Drawing.Point(172, 368);
            this.ResetScheduleAddButton.Name = "ResetScheduleAddButton";
            this.ResetScheduleAddButton.Size = new System.Drawing.Size(60, 23);
            this.ResetScheduleAddButton.TabIndex = 9;
            this.ResetScheduleAddButton.Text = "add";
            this.ResetScheduleAddButton.UseVisualStyleBackColor = true;
            // 
            // ResetScheduleSizeLabel
            // 
            this.ResetScheduleSizeLabel.AutoSize = true;
            this.ResetScheduleSizeLabel.Location = new System.Drawing.Point(115, 255);
            this.ResetScheduleSizeLabel.Name = "ResetScheduleSizeLabel";
            this.ResetScheduleSizeLabel.Size = new System.Drawing.Size(25, 13);
            this.ResetScheduleSizeLabel.TabIndex = 8;
            this.ResetScheduleSizeLabel.Text = "size";
            // 
            // ResetScheduleSizeTextBox
            // 
            this.ResetScheduleSizeTextBox.Location = new System.Drawing.Point(118, 271);
            this.ResetScheduleSizeTextBox.Name = "ResetScheduleSizeTextBox";
            this.ResetScheduleSizeTextBox.Size = new System.Drawing.Size(60, 20);
            this.ResetScheduleSizeTextBox.TabIndex = 7;
            // 
            // ResetScheduleSeedTextBox
            // 
            this.ResetScheduleSeedTextBox.Location = new System.Drawing.Point(12, 271);
            this.ResetScheduleSeedTextBox.Name = "ResetScheduleSeedTextBox";
            this.ResetScheduleSeedTextBox.Size = new System.Drawing.Size(100, 20);
            this.ResetScheduleSeedTextBox.TabIndex = 6;
            // 
            // ResetScheduleSeedLabel
            // 
            this.ResetScheduleSeedLabel.AutoSize = true;
            this.ResetScheduleSeedLabel.Location = new System.Drawing.Point(9, 255);
            this.ResetScheduleSeedLabel.Name = "ResetScheduleSeedLabel";
            this.ResetScheduleSeedLabel.Size = new System.Drawing.Size(30, 13);
            this.ResetScheduleSeedLabel.TabIndex = 5;
            this.ResetScheduleSeedLabel.Text = "seed";
            // 
            // ResetScheduleListView
            // 
            this.ResetScheduleListView.AllowColumnReorder = true;
            this.ResetScheduleListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ResetDayColumn,
            this.MapSeedColumn,
            this.MapSizeColumn});
            this.ResetScheduleListView.Location = new System.Drawing.Point(12, 298);
            this.ResetScheduleListView.Name = "ResetScheduleListView";
            this.ResetScheduleListView.Size = new System.Drawing.Size(220, 64);
            this.ResetScheduleListView.TabIndex = 4;
            this.ResetScheduleListView.UseCompatibleStateImageBehavior = false;
            this.ResetScheduleListView.View = System.Windows.Forms.View.Details;
            // 
            // ResetDayColumn
            // 
            this.ResetDayColumn.Text = "ResetDate";
            this.ResetDayColumn.Width = 90;
            // 
            // MapSeedColumn
            // 
            this.MapSeedColumn.Text = "MapSeed";
            this.MapSeedColumn.Width = 70;
            // 
            // MapSizeColumn
            // 
            this.MapSizeColumn.Text = "MapSize";
            this.MapSizeColumn.Width = 55;
            // 
            // ResetScheduleBtnRemove
            // 
            this.ResetScheduleBtnRemove.Location = new System.Drawing.Point(93, 368);
            this.ResetScheduleBtnRemove.Name = "ResetScheduleBtnRemove";
            this.ResetScheduleBtnRemove.Size = new System.Drawing.Size(60, 23);
            this.ResetScheduleBtnRemove.TabIndex = 3;
            this.ResetScheduleBtnRemove.Text = "remove";
            this.ResetScheduleBtnRemove.UseVisualStyleBackColor = true;
            // 
            // ResetScheduleBtnRemoveAll
            // 
            this.ResetScheduleBtnRemoveAll.Location = new System.Drawing.Point(12, 368);
            this.ResetScheduleBtnRemoveAll.Name = "ResetScheduleBtnRemoveAll";
            this.ResetScheduleBtnRemoveAll.Size = new System.Drawing.Size(75, 23);
            this.ResetScheduleBtnRemoveAll.TabIndex = 2;
            this.ResetScheduleBtnRemoveAll.Text = "removeall";
            this.ResetScheduleBtnRemoveAll.UseVisualStyleBackColor = true;
            // 
            // ResetMonthCalendar
            // 
            this.ResetMonthCalendar.Location = new System.Drawing.Point(12, 25);
            this.ResetMonthCalendar.Name = "ResetMonthCalendar";
            this.ResetMonthCalendar.TabIndex = 0;
            // 
            // QuickUpdateResetGroupBox
            // 
            this.QuickUpdateResetGroupBox.Controls.Add(this.QuickUpdateResetRunServerRadioButton);
            this.QuickUpdateResetGroupBox.Controls.Add(this.QuickUpdateResetServerUpdateRadioButton);
            this.QuickUpdateResetGroupBox.Controls.Add(this.QuickUpdateResetRunButton);
            this.QuickUpdateResetGroupBox.Controls.Add(this.QuickUpdateResetResetBPRadioButton);
            this.QuickUpdateResetGroupBox.Controls.Add(this.QuickUpdateResetResetMapRadioButton);
            this.QuickUpdateResetGroupBox.Controls.Add(this.QuickUpdateResetResetDataFilesRadioButton);
            this.QuickUpdateResetGroupBox.Controls.Add(this.QuickUpdateResetSizeLabel);
            this.QuickUpdateResetGroupBox.Controls.Add(this.QuickUpdateResetSizeTextBox);
            this.QuickUpdateResetGroupBox.Controls.Add(this.QuickUpdateResetSeedTextBox);
            this.QuickUpdateResetGroupBox.Controls.Add(this.QuickUpdateResetSeedLabel);
            this.QuickUpdateResetGroupBox.Location = new System.Drawing.Point(629, 395);
            this.QuickUpdateResetGroupBox.Name = "QuickUpdateResetGroupBox";
            this.QuickUpdateResetGroupBox.Size = new System.Drawing.Size(343, 104);
            this.QuickUpdateResetGroupBox.TabIndex = 5;
            this.QuickUpdateResetGroupBox.TabStop = false;
            this.QuickUpdateResetGroupBox.Text = "QuickUpdate/Reset";
            // 
            // QuickUpdateResetServerUpdateRadioButton
            // 
            this.QuickUpdateResetServerUpdateRadioButton.AutoSize = true;
            this.QuickUpdateResetServerUpdateRadioButton.Location = new System.Drawing.Point(246, 19);
            this.QuickUpdateResetServerUpdateRadioButton.Name = "QuickUpdateResetServerUpdateRadioButton";
            this.QuickUpdateResetServerUpdateRadioButton.Size = new System.Drawing.Size(91, 17);
            this.QuickUpdateResetServerUpdateRadioButton.TabIndex = 8;
            this.QuickUpdateResetServerUpdateRadioButton.TabStop = true;
            this.QuickUpdateResetServerUpdateRadioButton.Text = "ServerUpdate";
            this.QuickUpdateResetServerUpdateRadioButton.UseVisualStyleBackColor = true;
            // 
            // QuickUpdateResetRunButton
            // 
            this.QuickUpdateResetRunButton.Location = new System.Drawing.Point(262, 75);
            this.QuickUpdateResetRunButton.Name = "QuickUpdateResetRunButton";
            this.QuickUpdateResetRunButton.Size = new System.Drawing.Size(75, 23);
            this.QuickUpdateResetRunButton.TabIndex = 7;
            this.QuickUpdateResetRunButton.Text = "run";
            this.QuickUpdateResetRunButton.UseVisualStyleBackColor = true;
            // 
            // QuickUpdateResetResetBPRadioButton
            // 
            this.QuickUpdateResetResetBPRadioButton.AutoSize = true;
            this.QuickUpdateResetResetBPRadioButton.Location = new System.Drawing.Point(109, 19);
            this.QuickUpdateResetResetBPRadioButton.Name = "QuickUpdateResetResetBPRadioButton";
            this.QuickUpdateResetResetBPRadioButton.Size = new System.Drawing.Size(67, 17);
            this.QuickUpdateResetResetBPRadioButton.TabIndex = 6;
            this.QuickUpdateResetResetBPRadioButton.TabStop = true;
            this.QuickUpdateResetResetBPRadioButton.Text = "ResetBP";
            this.QuickUpdateResetResetBPRadioButton.UseVisualStyleBackColor = true;
            // 
            // QuickUpdateResetResetMapRadioButton
            // 
            this.QuickUpdateResetResetMapRadioButton.AutoSize = true;
            this.QuickUpdateResetResetMapRadioButton.Location = new System.Drawing.Point(6, 42);
            this.QuickUpdateResetResetMapRadioButton.Name = "QuickUpdateResetResetMapRadioButton";
            this.QuickUpdateResetResetMapRadioButton.Size = new System.Drawing.Size(74, 17);
            this.QuickUpdateResetResetMapRadioButton.TabIndex = 5;
            this.QuickUpdateResetResetMapRadioButton.TabStop = true;
            this.QuickUpdateResetResetMapRadioButton.Text = "ResetMap";
            this.QuickUpdateResetResetMapRadioButton.UseVisualStyleBackColor = true;
            // 
            // QuickUpdateResetResetDataFilesRadioButton
            // 
            this.QuickUpdateResetResetDataFilesRadioButton.AutoSize = true;
            this.QuickUpdateResetResetDataFilesRadioButton.Location = new System.Drawing.Point(6, 19);
            this.QuickUpdateResetResetDataFilesRadioButton.Name = "QuickUpdateResetResetDataFilesRadioButton";
            this.QuickUpdateResetResetDataFilesRadioButton.Size = new System.Drawing.Size(97, 17);
            this.QuickUpdateResetResetDataFilesRadioButton.TabIndex = 4;
            this.QuickUpdateResetResetDataFilesRadioButton.TabStop = true;
            this.QuickUpdateResetResetDataFilesRadioButton.Text = "ResetDataFiles";
            this.QuickUpdateResetResetDataFilesRadioButton.UseVisualStyleBackColor = true;
            // 
            // QuickUpdateResetSizeLabel
            // 
            this.QuickUpdateResetSizeLabel.AutoSize = true;
            this.QuickUpdateResetSizeLabel.Location = new System.Drawing.Point(109, 62);
            this.QuickUpdateResetSizeLabel.Name = "QuickUpdateResetSizeLabel";
            this.QuickUpdateResetSizeLabel.Size = new System.Drawing.Size(25, 13);
            this.QuickUpdateResetSizeLabel.TabIndex = 3;
            this.QuickUpdateResetSizeLabel.Text = "size";
            // 
            // QuickUpdateResetSizeTextBox
            // 
            this.QuickUpdateResetSizeTextBox.Location = new System.Drawing.Point(112, 78);
            this.QuickUpdateResetSizeTextBox.Name = "QuickUpdateResetSizeTextBox";
            this.QuickUpdateResetSizeTextBox.Size = new System.Drawing.Size(60, 20);
            this.QuickUpdateResetSizeTextBox.TabIndex = 2;
            // 
            // QuickUpdateResetSeedTextBox
            // 
            this.QuickUpdateResetSeedTextBox.Location = new System.Drawing.Point(6, 78);
            this.QuickUpdateResetSeedTextBox.Name = "QuickUpdateResetSeedTextBox";
            this.QuickUpdateResetSeedTextBox.Size = new System.Drawing.Size(100, 20);
            this.QuickUpdateResetSeedTextBox.TabIndex = 1;
            // 
            // QuickUpdateResetSeedLabel
            // 
            this.QuickUpdateResetSeedLabel.AutoSize = true;
            this.QuickUpdateResetSeedLabel.Location = new System.Drawing.Point(3, 62);
            this.QuickUpdateResetSeedLabel.Name = "QuickUpdateResetSeedLabel";
            this.QuickUpdateResetSeedLabel.Size = new System.Drawing.Size(30, 13);
            this.QuickUpdateResetSeedLabel.TabIndex = 0;
            this.QuickUpdateResetSeedLabel.Text = "seed";
            // 
            // QuickUpdateResetRunServerRadioButton
            // 
            this.QuickUpdateResetRunServerRadioButton.AutoSize = true;
            this.QuickUpdateResetRunServerRadioButton.Location = new System.Drawing.Point(246, 42);
            this.QuickUpdateResetRunServerRadioButton.Name = "QuickUpdateResetRunServerRadioButton";
            this.QuickUpdateResetRunServerRadioButton.Size = new System.Drawing.Size(76, 17);
            this.QuickUpdateResetRunServerRadioButton.TabIndex = 9;
            this.QuickUpdateResetRunServerRadioButton.TabStop = true;
            this.QuickUpdateResetRunServerRadioButton.Text = "RunServer";
            this.QuickUpdateResetRunServerRadioButton.UseVisualStyleBackColor = true;
            // 
            // ResetScheduleRunServerRadioButton
            // 
            this.ResetScheduleRunServerRadioButton.AutoSize = true;
            this.ResetScheduleRunServerRadioButton.Location = new System.Drawing.Point(115, 212);
            this.ResetScheduleRunServerRadioButton.Name = "ResetScheduleRunServerRadioButton";
            this.ResetScheduleRunServerRadioButton.Size = new System.Drawing.Size(76, 17);
            this.ResetScheduleRunServerRadioButton.TabIndex = 14;
            this.ResetScheduleRunServerRadioButton.TabStop = true;
            this.ResetScheduleRunServerRadioButton.Text = "RunServer";
            this.ResetScheduleRunServerRadioButton.UseVisualStyleBackColor = true;
            // 
            // ResetScheduleServerUpdateRadioButton
            // 
            this.ResetScheduleServerUpdateRadioButton.AutoSize = true;
            this.ResetScheduleServerUpdateRadioButton.Location = new System.Drawing.Point(115, 189);
            this.ResetScheduleServerUpdateRadioButton.Name = "ResetScheduleServerUpdateRadioButton";
            this.ResetScheduleServerUpdateRadioButton.Size = new System.Drawing.Size(91, 17);
            this.ResetScheduleServerUpdateRadioButton.TabIndex = 13;
            this.ResetScheduleServerUpdateRadioButton.TabStop = true;
            this.ResetScheduleServerUpdateRadioButton.Text = "ServerUpdate";
            this.ResetScheduleServerUpdateRadioButton.UseVisualStyleBackColor = true;
            // 
            // ResetScheduleResetBPRadioButton
            // 
            this.ResetScheduleResetBPRadioButton.AutoSize = true;
            this.ResetScheduleResetBPRadioButton.Location = new System.Drawing.Point(12, 235);
            this.ResetScheduleResetBPRadioButton.Name = "ResetScheduleResetBPRadioButton";
            this.ResetScheduleResetBPRadioButton.Size = new System.Drawing.Size(67, 17);
            this.ResetScheduleResetBPRadioButton.TabIndex = 12;
            this.ResetScheduleResetBPRadioButton.TabStop = true;
            this.ResetScheduleResetBPRadioButton.Text = "ResetBP";
            this.ResetScheduleResetBPRadioButton.UseVisualStyleBackColor = true;
            // 
            // ResetScheduleResetMapRadioButton
            // 
            this.ResetScheduleResetMapRadioButton.AutoSize = true;
            this.ResetScheduleResetMapRadioButton.Location = new System.Drawing.Point(12, 212);
            this.ResetScheduleResetMapRadioButton.Name = "ResetScheduleResetMapRadioButton";
            this.ResetScheduleResetMapRadioButton.Size = new System.Drawing.Size(74, 17);
            this.ResetScheduleResetMapRadioButton.TabIndex = 11;
            this.ResetScheduleResetMapRadioButton.TabStop = true;
            this.ResetScheduleResetMapRadioButton.Text = "ResetMap";
            this.ResetScheduleResetMapRadioButton.UseVisualStyleBackColor = true;
            // 
            // ResetScheduleResetDataFilesRadioButton
            // 
            this.ResetScheduleResetDataFilesRadioButton.AutoSize = true;
            this.ResetScheduleResetDataFilesRadioButton.Location = new System.Drawing.Point(12, 189);
            this.ResetScheduleResetDataFilesRadioButton.Name = "ResetScheduleResetDataFilesRadioButton";
            this.ResetScheduleResetDataFilesRadioButton.Size = new System.Drawing.Size(97, 17);
            this.ResetScheduleResetDataFilesRadioButton.TabIndex = 10;
            this.ResetScheduleResetDataFilesRadioButton.TabStop = true;
            this.ResetScheduleResetDataFilesRadioButton.Text = "ResetDataFiles";
            this.ResetScheduleResetDataFilesRadioButton.UseVisualStyleBackColor = true;
            // 
            // SettingGroupBox
            // 
            this.SettingGroupBox.Location = new System.Drawing.Point(379, 415);
            this.SettingGroupBox.Name = "SettingGroupBox";
            this.SettingGroupBox.Size = new System.Drawing.Size(244, 84);
            this.SettingGroupBox.TabIndex = 6;
            this.SettingGroupBox.TabStop = false;
            this.SettingGroupBox.Text = "Setting";
            // 
            // UntitledSystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 511);
            this.Controls.Add(this.SettingGroupBox);
            this.Controls.Add(this.QuickUpdateResetGroupBox);
            this.Controls.Add(this.ResetScheduleGroupBox);
            this.Controls.Add(this.SetResetFilesGroupBox);
            this.Controls.Add(this.ConsoleGroupBox);
            this.Controls.Add(this.DataStatsGroupBox);
            this.Controls.Add(this.SetDataFileLocationGroupBox);
            this.Name = "UntitledSystemForm";
            this.Text = "UntitledSystem";
            this.SetDataFileLocationGroupBox.ResumeLayout(false);
            this.SetRunFileGroupBox.ResumeLayout(false);
            this.SetRunFileGroupBox.PerformLayout();
            this.SetPluginDataFileGroupBox.ResumeLayout(false);
            this.SetPluginDataFileGroupBox.PerformLayout();
            this.DataStatsGroupBox.ResumeLayout(false);
            this.DataStatsGroupBox.PerformLayout();
            this.ConsoleGroupBox.ResumeLayout(false);
            this.ResetScheduleGroupBox.ResumeLayout(false);
            this.ResetScheduleGroupBox.PerformLayout();
            this.QuickUpdateResetGroupBox.ResumeLayout(false);
            this.QuickUpdateResetGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox SetDataFileLocationGroupBox;
        private System.Windows.Forms.GroupBox DataStatsGroupBox;
        private System.Windows.Forms.GroupBox ConsoleGroupBox;
        private System.Windows.Forms.GroupBox SetResetFilesGroupBox;
        private System.Windows.Forms.GroupBox ResetScheduleGroupBox;
        private System.Windows.Forms.GroupBox SetRunFileGroupBox;
        private System.Windows.Forms.Button SetRunFileBtnBrowse;
        private System.Windows.Forms.Button SetRunFileBtnSet;
        private System.Windows.Forms.TextBox SetRunFileTextBox;
        private System.Windows.Forms.GroupBox SetPluginDataFileGroupBox;
        private System.Windows.Forms.Button SetPluginDatafileBtnBrowse;
        private System.Windows.Forms.Button SetPluginDatafileBtnSet;
        private System.Windows.Forms.TextBox SetPluginDatafileTextBox;
        private System.Windows.Forms.Label DataReadStatsLabel;
        private System.Windows.Forms.Label DataReadStatTitleLabel;
        private System.Windows.Forms.MonthCalendar ResetMonthCalendar;
        private System.Windows.Forms.Button ResetScheduleBtnRemove;
        private System.Windows.Forms.Button ResetScheduleBtnRemoveAll;
        private System.Windows.Forms.RichTextBox ConsoleRichTextBox;
        private System.Windows.Forms.GroupBox QuickUpdateResetGroupBox;
        private System.Windows.Forms.Label QuickUpdateResetSizeLabel;
        private System.Windows.Forms.TextBox QuickUpdateResetSizeTextBox;
        private System.Windows.Forms.TextBox QuickUpdateResetSeedTextBox;
        private System.Windows.Forms.Label QuickUpdateResetSeedLabel;
        private System.Windows.Forms.ListView ResetScheduleListView;
        private System.Windows.Forms.ColumnHeader ResetDayColumn;
        private System.Windows.Forms.ColumnHeader MapSeedColumn;
        private System.Windows.Forms.ColumnHeader MapSizeColumn;
        private System.Windows.Forms.Button ResetScheduleAddButton;
        private System.Windows.Forms.Label ResetScheduleSizeLabel;
        private System.Windows.Forms.TextBox ResetScheduleSizeTextBox;
        private System.Windows.Forms.TextBox ResetScheduleSeedTextBox;
        private System.Windows.Forms.Label ResetScheduleSeedLabel;
        private System.Windows.Forms.RadioButton QuickUpdateResetResetBPRadioButton;
        private System.Windows.Forms.RadioButton QuickUpdateResetResetMapRadioButton;
        private System.Windows.Forms.RadioButton QuickUpdateResetResetDataFilesRadioButton;
        private System.Windows.Forms.RadioButton QuickUpdateResetServerUpdateRadioButton;
        private System.Windows.Forms.Button QuickUpdateResetRunButton;
        private System.Windows.Forms.RadioButton QuickUpdateResetRunServerRadioButton;
        private System.Windows.Forms.RadioButton ResetScheduleRunServerRadioButton;
        private System.Windows.Forms.RadioButton ResetScheduleServerUpdateRadioButton;
        private System.Windows.Forms.RadioButton ResetScheduleResetBPRadioButton;
        private System.Windows.Forms.RadioButton ResetScheduleResetMapRadioButton;
        private System.Windows.Forms.RadioButton ResetScheduleResetDataFilesRadioButton;
        private System.Windows.Forms.GroupBox SettingGroupBox;
    }
}

