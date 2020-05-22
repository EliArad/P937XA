namespace P9374ATesterApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.zg = new ZedGraph.ZedGraphControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connect2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbChannel = new System.Windows.Forms.ComboBox();
            this.btnMeasure = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFormat = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTriggerSource = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTriggerMode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStartFrequency = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStopFrequency = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSpanFrequency = new System.Windows.Forms.TextBox();
            this.btnStartFrequency = new System.Windows.Forms.Button();
            this.btnStopFrequency = new System.Windows.Forms.Button();
            this.btnSpanFrequency = new System.Windows.Forms.Button();
            this.btnCenterFrequency = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCenterFrequency = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNumberOfPoints = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbMeasurement = new System.Windows.Forms.ComboBox();
            this.btnActivateMarker = new System.Windows.Forms.Button();
            this.cmbMarkers = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lblMarkerCount = new System.Windows.Forms.Label();
            this.chkEnableMarker = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMarkerValue = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtVnaState = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.cmbMarkerSearch = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.btnMarkerStimulus = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMarkerStimulus = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.calibarteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fastCalibrateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // zg
            // 
            this.zg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zg.Location = new System.Drawing.Point(-1, 203);
            this.zg.Name = "zg";
            this.zg.ScrollGrace = 0D;
            this.zg.ScrollMaxX = 0D;
            this.zg.ScrollMaxY = 0D;
            this.zg.ScrollMaxY2 = 0D;
            this.zg.ScrollMinX = 0D;
            this.zg.ScrollMinY = 0D;
            this.zg.ScrollMinY2 = 0D;
            this.zg.Size = new System.Drawing.Size(1088, 427);
            this.zg.TabIndex = 0;
            this.zg.UseExtendedPrintDialog = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionToolStripMenuItem,
            this.calibarteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.connect2ToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionToolStripMenuItem.Text = "Option";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // connect2ToolStripMenuItem
            // 
            this.connect2ToolStripMenuItem.Name = "connect2ToolStripMenuItem";
            this.connect2ToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.connect2ToolStripMenuItem.Text = "Connect 2";
            this.connect2ToolStripMenuItem.Click += new System.EventHandler(this.connect2ToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // cmbChannel
            // 
            this.cmbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChannel.FormattingEnabled = true;
            this.cmbChannel.Items.AddRange(new object[] {
            "CHANNEL1",
            "CHANNEL2",
            "CHANNEL3"});
            this.cmbChannel.Location = new System.Drawing.Point(27, 53);
            this.cmbChannel.Name = "cmbChannel";
            this.cmbChannel.Size = new System.Drawing.Size(121, 21);
            this.cmbChannel.TabIndex = 2;
            this.cmbChannel.SelectedIndexChanged += new System.EventHandler(this.cmbChannel_SelectedIndexChanged);
            // 
            // btnMeasure
            // 
            this.btnMeasure.Location = new System.Drawing.Point(180, 51);
            this.btnMeasure.Name = "btnMeasure";
            this.btnMeasure.Size = new System.Drawing.Size(75, 72);
            this.btnMeasure.TabIndex = 3;
            this.btnMeasure.Text = "Measure";
            this.btnMeasure.UseVisualStyleBackColor = true;
            this.btnMeasure.Click += new System.EventHandler(this.btnMeasure_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Channel";
            // 
            // cmbFormat
            // 
            this.cmbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormat.FormattingEnabled = true;
            this.cmbFormat.Location = new System.Drawing.Point(307, 51);
            this.cmbFormat.Name = "cmbFormat";
            this.cmbFormat.Size = new System.Drawing.Size(234, 21);
            this.cmbFormat.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Format";
            // 
            // cmbTriggerSource
            // 
            this.cmbTriggerSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTriggerSource.FormattingEnabled = true;
            this.cmbTriggerSource.Location = new System.Drawing.Point(581, 50);
            this.cmbTriggerSource.Name = "cmbTriggerSource";
            this.cmbTriggerSource.Size = new System.Drawing.Size(183, 21);
            this.cmbTriggerSource.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(578, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Trigger Source";
            // 
            // cmbTriggerMode
            // 
            this.cmbTriggerMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTriggerMode.FormattingEnabled = true;
            this.cmbTriggerMode.Location = new System.Drawing.Point(790, 50);
            this.cmbTriggerMode.Name = "cmbTriggerMode";
            this.cmbTriggerMode.Size = new System.Drawing.Size(247, 21);
            this.cmbTriggerMode.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(787, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Trigger Mode";
            // 
            // txtStartFrequency
            // 
            this.txtStartFrequency.Location = new System.Drawing.Point(48, 152);
            this.txtStartFrequency.Name = "txtStartFrequency";
            this.txtStartFrequency.Size = new System.Drawing.Size(100, 20);
            this.txtStartFrequency.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Start Frequency";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(232, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Stop Frequency";
            // 
            // txtStopFrequency
            // 
            this.txtStopFrequency.Location = new System.Drawing.Point(235, 152);
            this.txtStopFrequency.Name = "txtStopFrequency";
            this.txtStopFrequency.Size = new System.Drawing.Size(100, 20);
            this.txtStopFrequency.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(407, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Span Frequency";
            // 
            // txtSpanFrequency
            // 
            this.txtSpanFrequency.Location = new System.Drawing.Point(410, 152);
            this.txtSpanFrequency.Name = "txtSpanFrequency";
            this.txtSpanFrequency.Size = new System.Drawing.Size(100, 20);
            this.txtSpanFrequency.TabIndex = 15;
            // 
            // btnStartFrequency
            // 
            this.btnStartFrequency.Location = new System.Drawing.Point(154, 151);
            this.btnStartFrequency.Name = "btnStartFrequency";
            this.btnStartFrequency.Size = new System.Drawing.Size(55, 23);
            this.btnStartFrequency.TabIndex = 17;
            this.btnStartFrequency.Text = "Set";
            this.btnStartFrequency.UseVisualStyleBackColor = true;
            this.btnStartFrequency.Click += new System.EventHandler(this.btnStartFrequency_Click);
            // 
            // btnStopFrequency
            // 
            this.btnStopFrequency.Location = new System.Drawing.Point(341, 150);
            this.btnStopFrequency.Name = "btnStopFrequency";
            this.btnStopFrequency.Size = new System.Drawing.Size(55, 23);
            this.btnStopFrequency.TabIndex = 18;
            this.btnStopFrequency.Text = "Set";
            this.btnStopFrequency.UseVisualStyleBackColor = true;
            this.btnStopFrequency.Click += new System.EventHandler(this.btnStopFrequency_Click);
            // 
            // btnSpanFrequency
            // 
            this.btnSpanFrequency.Location = new System.Drawing.Point(525, 152);
            this.btnSpanFrequency.Name = "btnSpanFrequency";
            this.btnSpanFrequency.Size = new System.Drawing.Size(55, 23);
            this.btnSpanFrequency.TabIndex = 19;
            this.btnSpanFrequency.Text = "Set";
            this.btnSpanFrequency.UseVisualStyleBackColor = true;
            this.btnSpanFrequency.Click += new System.EventHandler(this.btnSpanFrequency_Click);
            // 
            // btnCenterFrequency
            // 
            this.btnCenterFrequency.Location = new System.Drawing.Point(720, 155);
            this.btnCenterFrequency.Name = "btnCenterFrequency";
            this.btnCenterFrequency.Size = new System.Drawing.Size(55, 23);
            this.btnCenterFrequency.TabIndex = 22;
            this.btnCenterFrequency.Text = "Set";
            this.btnCenterFrequency.UseVisualStyleBackColor = true;
            this.btnCenterFrequency.Click += new System.EventHandler(this.btnCenterFrequency_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(602, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Center Frequency";
            // 
            // txtCenterFrequency
            // 
            this.txtCenterFrequency.Location = new System.Drawing.Point(605, 155);
            this.txtCenterFrequency.Name = "txtCenterFrequency";
            this.txtCenterFrequency.Size = new System.Drawing.Size(100, 20);
            this.txtCenterFrequency.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(905, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(787, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Number of Points";
            // 
            // txtNumberOfPoints
            // 
            this.txtNumberOfPoints.Location = new System.Drawing.Point(790, 157);
            this.txtNumberOfPoints.Name = "txtNumberOfPoints";
            this.txtNumberOfPoints.Size = new System.Drawing.Size(100, 20);
            this.txtNumberOfPoints.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Measurement";
            // 
            // cmbMeasurement
            // 
            this.cmbMeasurement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMeasurement.FormattingEnabled = true;
            this.cmbMeasurement.Items.AddRange(new object[] {
            "LIKE_CHANNEL",
            "MEASUREMENT1",
            "MEASUREMENT2"});
            this.cmbMeasurement.Location = new System.Drawing.Point(30, 102);
            this.cmbMeasurement.Name = "cmbMeasurement";
            this.cmbMeasurement.Size = new System.Drawing.Size(121, 21);
            this.cmbMeasurement.TabIndex = 26;
            // 
            // btnActivateMarker
            // 
            this.btnActivateMarker.Location = new System.Drawing.Point(1136, 230);
            this.btnActivateMarker.Name = "btnActivateMarker";
            this.btnActivateMarker.Size = new System.Drawing.Size(121, 23);
            this.btnActivateMarker.TabIndex = 28;
            this.btnActivateMarker.Text = "Activate Marker";
            this.btnActivateMarker.UseVisualStyleBackColor = true;
            this.btnActivateMarker.Click += new System.EventHandler(this.btnActivateMarker_Click);
            // 
            // cmbMarkers
            // 
            this.cmbMarkers.FormattingEnabled = true;
            this.cmbMarkers.Items.AddRange(new object[] {
            "MARKER 1",
            "MARKER 2",
            "MARKER 3",
            "MARKER 4"});
            this.cmbMarkers.Location = new System.Drawing.Point(1136, 203);
            this.cmbMarkers.Name = "cmbMarkers";
            this.cmbMarkers.Size = new System.Drawing.Size(121, 21);
            this.cmbMarkers.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1133, 187);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Marker";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1136, 340);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 23);
            this.button2.TabIndex = 31;
            this.button2.Text = "Marker Count";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblMarkerCount
            // 
            this.lblMarkerCount.AutoSize = true;
            this.lblMarkerCount.Location = new System.Drawing.Point(1263, 346);
            this.lblMarkerCount.Name = "lblMarkerCount";
            this.lblMarkerCount.Size = new System.Drawing.Size(13, 13);
            this.lblMarkerCount.TabIndex = 32;
            this.lblMarkerCount.Text = "0";
            // 
            // chkEnableMarker
            // 
            this.chkEnableMarker.AutoSize = true;
            this.chkEnableMarker.Location = new System.Drawing.Point(1136, 285);
            this.chkEnableMarker.Name = "chkEnableMarker";
            this.chkEnableMarker.Size = new System.Drawing.Size(95, 17);
            this.chkEnableMarker.TabIndex = 33;
            this.chkEnableMarker.Text = "Enable Marker";
            this.chkEnableMarker.UseVisualStyleBackColor = true;
            this.chkEnableMarker.CheckedChanged += new System.EventHandler(this.chkEnableMarker_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1242, 448);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(55, 23);
            this.button3.TabIndex = 36;
            this.button3.Text = "Get Value";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1133, 434);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Marker Value";
            // 
            // txtMarkerValue
            // 
            this.txtMarkerValue.Location = new System.Drawing.Point(1136, 450);
            this.txtMarkerValue.Name = "txtMarkerValue";
            this.txtMarkerValue.Size = new System.Drawing.Size(100, 20);
            this.txtMarkerValue.TabIndex = 34;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1100, 38);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 13);
            this.label13.TabIndex = 38;
            this.label13.Text = "Recall state for intialize";
            // 
            // txtVnaState
            // 
            this.txtVnaState.Location = new System.Drawing.Point(1103, 54);
            this.txtVnaState.Name = "txtVnaState";
            this.txtVnaState.Size = new System.Drawing.Size(154, 20);
            this.txtVnaState.TabIndex = 37;
            this.txtVnaState.Text = "c:\\vna_chip_base.sta";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1242, 515);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(55, 23);
            this.button4.TabIndex = 41;
            this.button4.Text = "Get Value";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1133, 501);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(103, 13);
            this.label14.TabIndex = 40;
            this.label14.Text = "Bandwidth threshold";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1136, 517);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 39;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1136, 550);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(121, 23);
            this.button5.TabIndex = 42;
            this.button5.Text = "Names";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1266, 550);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(92, 23);
            this.button6.TabIndex = 43;
            this.button6.Text = "Get Peak Ex";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // cmbMarkerSearch
            // 
            this.cmbMarkerSearch.FormattingEnabled = true;
            this.cmbMarkerSearch.Location = new System.Drawing.Point(1136, 597);
            this.cmbMarkerSearch.Name = "cmbMarkerSearch";
            this.cmbMarkerSearch.Size = new System.Drawing.Size(161, 21);
            this.cmbMarkerSearch.TabIndex = 44;
            this.cmbMarkerSearch.SelectedIndexChanged += new System.EventHandler(this.cmbMarkerSearch_SelectedIndexChanged);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(1234, 258);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(124, 23);
            this.button7.TabIndex = 45;
            this.button7.Text = "Read marker value";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(1303, 311);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(55, 23);
            this.button8.TabIndex = 46;
            this.button8.Text = "Get Value";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // btnMarkerStimulus
            // 
            this.btnMarkerStimulus.Location = new System.Drawing.Point(1242, 394);
            this.btnMarkerStimulus.Name = "btnMarkerStimulus";
            this.btnMarkerStimulus.Size = new System.Drawing.Size(89, 23);
            this.btnMarkerStimulus.TabIndex = 49;
            this.btnMarkerStimulus.Text = "Set frequency";
            this.btnMarkerStimulus.UseVisualStyleBackColor = true;
            this.btnMarkerStimulus.Click += new System.EventHandler(this.btnMarkerStimulus_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1133, 380);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 13);
            this.label15.TabIndex = 48;
            this.label15.Text = "Stimulus (frequency)";
            // 
            // txtMarkerStimulus
            // 
            this.txtMarkerStimulus.Location = new System.Drawing.Point(1136, 396);
            this.txtMarkerStimulus.Name = "txtMarkerStimulus";
            this.txtMarkerStimulus.Size = new System.Drawing.Size(100, 20);
            this.txtMarkerStimulus.TabIndex = 47;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(1126, 100);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(121, 23);
            this.button9.TabIndex = 50;
            this.button9.Text = "Auto Scale";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(1266, 53);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(55, 23);
            this.button10.TabIndex = 51;
            this.button10.Text = "Recall";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1133, 581);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 13);
            this.label16.TabIndex = 52;
            this.label16.Text = "Marker Search";
            // 
            // calibarteToolStripMenuItem
            // 
            this.calibarteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fastCalibrateToolStripMenuItem});
            this.calibarteToolStripMenuItem.Name = "calibarteToolStripMenuItem";
            this.calibarteToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.calibarteToolStripMenuItem.Text = "Calibarte";
            // 
            // fastCalibrateToolStripMenuItem
            // 
            this.fastCalibrateToolStripMenuItem.Name = "fastCalibrateToolStripMenuItem";
            this.fastCalibrateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fastCalibrateToolStripMenuItem.Text = "Fast Calibrate";
            this.fastCalibrateToolStripMenuItem.Click += new System.EventHandler(this.fastCalibrateToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 626);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.btnMarkerStimulus);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtMarkerStimulus);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.cmbMarkerSearch);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtVnaState);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtMarkerValue);
            this.Controls.Add(this.chkEnableMarker);
            this.Controls.Add(this.lblMarkerCount);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbMarkers);
            this.Controls.Add(this.btnActivateMarker);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbMeasurement);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNumberOfPoints);
            this.Controls.Add(this.btnCenterFrequency);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCenterFrequency);
            this.Controls.Add(this.btnSpanFrequency);
            this.Controls.Add(this.btnStopFrequency);
            this.Controls.Add(this.btnStartFrequency);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSpanFrequency);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtStopFrequency);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtStartFrequency);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbTriggerMode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTriggerSource);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFormat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMeasure);
            this.Controls.Add(this.cmbChannel);
            this.Controls.Add(this.zg);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "P937XA Tester App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zg;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbChannel;
        private System.Windows.Forms.Button btnMeasure;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFormat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTriggerSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTriggerMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStartFrequency;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStopFrequency;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSpanFrequency;
        private System.Windows.Forms.Button btnStartFrequency;
        private System.Windows.Forms.Button btnStopFrequency;
        private System.Windows.Forms.Button btnSpanFrequency;
        private System.Windows.Forms.Button btnCenterFrequency;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCenterFrequency;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNumberOfPoints;
        private System.Windows.Forms.ToolStripMenuItem connect2ToolStripMenuItem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbMeasurement;
        private System.Windows.Forms.Button btnActivateMarker;
        private System.Windows.Forms.ComboBox cmbMarkers;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblMarkerCount;
        private System.Windows.Forms.CheckBox chkEnableMarker;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMarkerValue;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtVnaState;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ComboBox cmbMarkerSearch;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button btnMarkerStimulus;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtMarkerStimulus;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ToolStripMenuItem calibarteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fastCalibrateToolStripMenuItem;
    }
}

