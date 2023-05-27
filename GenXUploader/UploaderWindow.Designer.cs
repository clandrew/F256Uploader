namespace FoenixIDE.UI
{
    partial class UploaderWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploaderWindow));
            this.ConnectButton = new System.Windows.Forms.Button();
            this.COMPortComboBox = new System.Windows.Forms.ComboBox();
            this.BrowseFileButton = new System.Windows.Forms.Button();
            this.FileNameTextBox = new System.Windows.Forms.TextBox();
            this.FileSizeLabel = new System.Windows.Forms.Label();
            this.FileSizeResultLabel = new System.Windows.Forms.Label();
            this.DestinationAddressLabel = new System.Windows.Forms.Label();
            this.SendBinaryButton = new System.Windows.Forms.Button();
            this.C256DestAddress = new System.Windows.Forms.TextBox();
            this.DollarSignLabel = new System.Windows.Forms.Label();
            this.UploadProgressBar = new System.Windows.Forms.ProgressBar();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.SendFileRadio = new System.Windows.Forms.RadioButton();
            this.BlockSendRadio = new System.Windows.Forms.RadioButton();
            this.EmuSrcAddress = new System.Windows.Forms.TextBox();
            this.EmuSourceAddressLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EmuSrcSize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FetchRadio = new System.Windows.Forms.RadioButton();
            this.C256SrcSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.C256SrcAddress = new System.Windows.Forms.TextBox();
            this.C256SrcAddressLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DebugModeCheckbox = new System.Windows.Forms.CheckBox();
            this.ReflashCheckbox = new System.Windows.Forms.CheckBox();
            this.CountdownLabel = new System.Windows.Forms.Label();
            this.hideLabelTimer = new System.Windows.Forms.Timer(this.components);
            this.FlashBlock = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BootMethod = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ConnectButton
            // 
            this.ConnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectButton.Location = new System.Drawing.Point(20, 15);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(114, 44);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // COMPortComboBox
            // 
            this.COMPortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.COMPortComboBox.Location = new System.Drawing.Point(155, 20);
            this.COMPortComboBox.Name = "COMPortComboBox";
            this.COMPortComboBox.Size = new System.Drawing.Size(78, 24);
            this.COMPortComboBox.TabIndex = 1;
            // 
            // BrowseFileButton
            // 
            this.BrowseFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseFileButton.Location = new System.Drawing.Point(584, 107);
            this.BrowseFileButton.Name = "BrowseFileButton";
            this.BrowseFileButton.Size = new System.Drawing.Size(32, 24);
            this.BrowseFileButton.TabIndex = 2;
            this.BrowseFileButton.Text = "...";
            this.BrowseFileButton.UseVisualStyleBackColor = true;
            this.BrowseFileButton.Click += new System.EventHandler(this.BrowseFileButton_Click);
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.Location = new System.Drawing.Point(145, 109);
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.ReadOnly = true;
            this.FileNameTextBox.Size = new System.Drawing.Size(433, 22);
            this.FileNameTextBox.TabIndex = 3;
            // 
            // FileSizeLabel
            // 
            this.FileSizeLabel.AutoSize = true;
            this.FileSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileSizeLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FileSizeLabel.Location = new System.Drawing.Point(488, 90);
            this.FileSizeLabel.Name = "FileSizeLabel";
            this.FileSizeLabel.Size = new System.Drawing.Size(59, 13);
            this.FileSizeLabel.TabIndex = 4;
            this.FileSizeLabel.Text = "File Size:";
            // 
            // FileSizeResultLabel
            // 
            this.FileSizeResultLabel.AutoSize = true;
            this.FileSizeResultLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FileSizeResultLabel.Location = new System.Drawing.Point(553, 88);
            this.FileSizeResultLabel.Name = "FileSizeResultLabel";
            this.FileSizeResultLabel.Size = new System.Drawing.Size(61, 16);
            this.FileSizeResultLabel.TabIndex = 5;
            this.FileSizeResultLabel.Text = "$00:0000";
            // 
            // DestinationAddressLabel
            // 
            this.DestinationAddressLabel.AutoSize = true;
            this.DestinationAddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DestinationAddressLabel.ForeColor = System.Drawing.Color.White;
            this.DestinationAddressLabel.Location = new System.Drawing.Point(235, 177);
            this.DestinationAddressLabel.Name = "DestinationAddressLabel";
            this.DestinationAddressLabel.Size = new System.Drawing.Size(106, 16);
            this.DestinationAddressLabel.TabIndex = 6;
            this.DestinationAddressLabel.Text = "Dest Address:";
            this.DestinationAddressLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SendBinaryButton
            // 
            this.SendBinaryButton.Enabled = false;
            this.SendBinaryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendBinaryButton.Location = new System.Drawing.Point(525, 15);
            this.SendBinaryButton.Name = "SendBinaryButton";
            this.SendBinaryButton.Size = new System.Drawing.Size(99, 29);
            this.SendBinaryButton.TabIndex = 7;
            this.SendBinaryButton.Text = "Send Binary";
            this.SendBinaryButton.UseVisualStyleBackColor = true;
            this.SendBinaryButton.Click += new System.EventHandler(this.SendBinaryButton_Click);
            // 
            // C256DestAddress
            // 
            this.C256DestAddress.Enabled = false;
            this.C256DestAddress.Location = new System.Drawing.Point(363, 177);
            this.C256DestAddress.MaxLength = 9;
            this.C256DestAddress.Name = "C256DestAddress";
            this.C256DestAddress.Size = new System.Drawing.Size(93, 22);
            this.C256DestAddress.TabIndex = 8;
            this.C256DestAddress.Text = "0000:0000";
            this.C256DestAddress.TextChanged += new System.EventHandler(this.AddressTextBox_TextChanged);
            this.C256DestAddress.Leave += new System.EventHandler(this.BlockAddressTextBox_Leave);
            // 
            // DollarSignLabel
            // 
            this.DollarSignLabel.AutoSize = true;
            this.DollarSignLabel.ForeColor = System.Drawing.Color.White;
            this.DollarSignLabel.Location = new System.Drawing.Point(347, 180);
            this.DollarSignLabel.Name = "DollarSignLabel";
            this.DollarSignLabel.Size = new System.Drawing.Size(15, 16);
            this.DollarSignLabel.TabIndex = 9;
            this.DollarSignLabel.Text = "$";
            // 
            // UploadProgressBar
            // 
            this.UploadProgressBar.Location = new System.Drawing.Point(8, 247);
            this.UploadProgressBar.Name = "UploadProgressBar";
            this.UploadProgressBar.Size = new System.Drawing.Size(612, 29);
            this.UploadProgressBar.Step = 1;
            this.UploadProgressBar.TabIndex = 10;
            this.UploadProgressBar.Value = 100;
            this.UploadProgressBar.Visible = false;
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisconnectButton.Location = new System.Drawing.Point(20, 15);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(114, 44);
            this.DisconnectButton.TabIndex = 11;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Visible = false;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // SendFileRadio
            // 
            this.SendFileRadio.AutoSize = true;
            this.SendFileRadio.Checked = true;
            this.SendFileRadio.ForeColor = System.Drawing.Color.White;
            this.SendFileRadio.Location = new System.Drawing.Point(12, 109);
            this.SendFileRadio.Name = "SendFileRadio";
            this.SendFileRadio.Size = new System.Drawing.Size(87, 20);
            this.SendFileRadio.TabIndex = 12;
            this.SendFileRadio.TabStop = true;
            this.SendFileRadio.Text = "Send File";
            this.SendFileRadio.UseVisualStyleBackColor = true;
            this.SendFileRadio.CheckedChanged += new System.EventHandler(this.SendFileRadio_CheckedChanged);
            // 
            // BlockSendRadio
            // 
            this.BlockSendRadio.AutoSize = true;
            this.BlockSendRadio.Enabled = false;
            this.BlockSendRadio.ForeColor = System.Drawing.Color.White;
            this.BlockSendRadio.Location = new System.Drawing.Point(20, 149);
            this.BlockSendRadio.Name = "BlockSendRadio";
            this.BlockSendRadio.Size = new System.Drawing.Size(153, 20);
            this.BlockSendRadio.TabIndex = 13;
            this.BlockSendRadio.Text = "Send Memory Block";
            this.BlockSendRadio.UseVisualStyleBackColor = true;
            this.BlockSendRadio.CheckedChanged += new System.EventHandler(this.SendFileRadio_CheckedChanged);
            // 
            // EmuSrcAddress
            // 
            this.EmuSrcAddress.Enabled = false;
            this.EmuSrcAddress.Location = new System.Drawing.Point(363, 149);
            this.EmuSrcAddress.MaxLength = 9;
            this.EmuSrcAddress.Name = "EmuSrcAddress";
            this.EmuSrcAddress.Size = new System.Drawing.Size(93, 22);
            this.EmuSrcAddress.TabIndex = 15;
            this.EmuSrcAddress.Text = "0000:0000";
            this.EmuSrcAddress.TextChanged += new System.EventHandler(this.AddressTextBox_TextChanged);
            this.EmuSrcAddress.Leave += new System.EventHandler(this.BlockAddressTextBox_Leave);
            // 
            // EmuSourceAddressLabel
            // 
            this.EmuSourceAddressLabel.AutoSize = true;
            this.EmuSourceAddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmuSourceAddressLabel.ForeColor = System.Drawing.Color.White;
            this.EmuSourceAddressLabel.Location = new System.Drawing.Point(210, 152);
            this.EmuSourceAddressLabel.Name = "EmuSourceAddressLabel";
            this.EmuSourceAddressLabel.Size = new System.Drawing.Size(131, 16);
            this.EmuSourceAddressLabel.TabIndex = 14;
            this.EmuSourceAddressLabel.Text = "Emu Src Address:";
            this.EmuSourceAddressLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(347, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "$";
            // 
            // EmuSrcSize
            // 
            this.EmuSrcSize.Enabled = false;
            this.EmuSrcSize.Location = new System.Drawing.Point(525, 149);
            this.EmuSrcSize.MaxLength = 9;
            this.EmuSrcSize.Name = "EmuSrcSize";
            this.EmuSrcSize.Size = new System.Drawing.Size(93, 22);
            this.EmuSrcSize.TabIndex = 18;
            this.EmuSrcSize.Text = "0000:0000";
            this.EmuSrcSize.TextChanged += new System.EventHandler(this.AddressTextBox_TextChanged);
            this.EmuSrcSize.Leave += new System.EventHandler(this.BlockAddressTextBox_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(464, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Size:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(509, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "$";
            // 
            // FetchRadio
            // 
            this.FetchRadio.AutoSize = true;
            this.FetchRadio.Enabled = false;
            this.FetchRadio.ForeColor = System.Drawing.Color.White;
            this.FetchRadio.Location = new System.Drawing.Point(18, 211);
            this.FetchRadio.Name = "FetchRadio";
            this.FetchRadio.Size = new System.Drawing.Size(155, 20);
            this.FetchRadio.TabIndex = 20;
            this.FetchRadio.Text = "Fetch Memory Block";
            this.FetchRadio.UseVisualStyleBackColor = true;
            this.FetchRadio.CheckedChanged += new System.EventHandler(this.SendFileRadio_CheckedChanged);
            // 
            // C256SrcSize
            // 
            this.C256SrcSize.Enabled = false;
            this.C256SrcSize.Location = new System.Drawing.Point(524, 205);
            this.C256SrcSize.MaxLength = 9;
            this.C256SrcSize.Name = "C256SrcSize";
            this.C256SrcSize.Size = new System.Drawing.Size(93, 22);
            this.C256SrcSize.TabIndex = 25;
            this.C256SrcSize.Text = "0000:0000";
            this.C256SrcSize.TextChanged += new System.EventHandler(this.AddressTextBox_TextChanged);
            this.C256SrcSize.Leave += new System.EventHandler(this.BlockAddressTextBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(464, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Size:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(509, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "$";
            // 
            // C256SrcAddress
            // 
            this.C256SrcAddress.Enabled = false;
            this.C256SrcAddress.Location = new System.Drawing.Point(363, 205);
            this.C256SrcAddress.MaxLength = 9;
            this.C256SrcAddress.Name = "C256SrcAddress";
            this.C256SrcAddress.Size = new System.Drawing.Size(93, 22);
            this.C256SrcAddress.TabIndex = 22;
            this.C256SrcAddress.Text = "0000:0000";
            this.C256SrcAddress.TextChanged += new System.EventHandler(this.AddressTextBox_TextChanged);
            this.C256SrcAddress.Leave += new System.EventHandler(this.BlockAddressTextBox_Leave);
            // 
            // C256SrcAddressLabel
            // 
            this.C256SrcAddressLabel.AutoSize = true;
            this.C256SrcAddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.C256SrcAddressLabel.ForeColor = System.Drawing.Color.White;
            this.C256SrcAddressLabel.Location = new System.Drawing.Point(244, 211);
            this.C256SrcAddressLabel.Name = "C256SrcAddressLabel";
            this.C256SrcAddressLabel.Size = new System.Drawing.Size(97, 16);
            this.C256SrcAddressLabel.TabIndex = 21;
            this.C256SrcAddressLabel.Text = "Src Address:";
            this.C256SrcAddressLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(347, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 16);
            this.label7.TabIndex = 23;
            this.label7.Text = "$";
            // 
            // DebugModeCheckbox
            // 
            this.DebugModeCheckbox.AutoSize = true;
            this.DebugModeCheckbox.Checked = true;
            this.DebugModeCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DebugModeCheckbox.ForeColor = System.Drawing.Color.White;
            this.DebugModeCheckbox.Location = new System.Drawing.Point(20, 177);
            this.DebugModeCheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.DebugModeCheckbox.Name = "DebugModeCheckbox";
            this.DebugModeCheckbox.Size = new System.Drawing.Size(107, 20);
            this.DebugModeCheckbox.TabIndex = 27;
            this.DebugModeCheckbox.Text = "Debug Mode";
            this.DebugModeCheckbox.UseVisualStyleBackColor = true;
            // 
            // ReflashCheckbox
            // 
            this.ReflashCheckbox.AutoSize = true;
            this.ReflashCheckbox.BackColor = System.Drawing.Color.Thistle;
            this.ReflashCheckbox.Enabled = false;
            this.ReflashCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReflashCheckbox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReflashCheckbox.ForeColor = System.Drawing.Color.Black;
            this.ReflashCheckbox.Location = new System.Drawing.Point(155, 63);
            this.ReflashCheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.ReflashCheckbox.Name = "ReflashCheckbox";
            this.ReflashCheckbox.Size = new System.Drawing.Size(67, 23);
            this.ReflashCheckbox.TabIndex = 28;
            this.ReflashCheckbox.Text = "Flash";
            this.ReflashCheckbox.UseVisualStyleBackColor = false;
            this.ReflashCheckbox.CheckedChanged += new System.EventHandler(this.SendFileRadio_CheckedChanged);
            // 
            // CountdownLabel
            // 
            this.CountdownLabel.BackColor = System.Drawing.Color.LightSeaGreen;
            this.CountdownLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountdownLabel.ForeColor = System.Drawing.Color.White;
            this.CountdownLabel.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.CountdownLabel.Location = new System.Drawing.Point(13, 251);
            this.CountdownLabel.Name = "CountdownLabel";
            this.CountdownLabel.Size = new System.Drawing.Size(601, 20);
            this.CountdownLabel.TabIndex = 29;
            this.CountdownLabel.Text = "Erasing Flash";
            this.CountdownLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CountdownLabel.Visible = false;
            // 
            // hideLabelTimer
            // 
            this.hideLabelTimer.Interval = 5000;
            this.hideLabelTimer.Tick += new System.EventHandler(this.hideLabelTimer_Tick);
            // 
            // FlashBlock
            // 
            this.FlashBlock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FlashBlock.Font = new System.Drawing.Font("Agency FB", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlashBlock.Items.AddRange(new object[] {
            "$00 - $00000-$01FFF",
            "$01 - $02000-$03FFF",
            "$02 - $04000-$05FFF",
            "$03 - $06000-$07FFF",
            "$04 - $08000-$09FFF",
            "$05 - $0A000-$0BFFF",
            "$06 - $0C000-$0DFFF",
            "$07 - $0E000-$0FFFF",
            "$08 - $10000-$11FFF",
            "$09 - $12000-$13FFF",
            "$0A - $14000-$15FFF",
            "$0B - $16000-$17FFF",
            "$0C - $18000-$19FFF",
            "$0D - $1A000-$1BFFF",
            "$0E - $1C000-$1DFFF",
            "$0F - $1E000-$1FFFF",
            "$10 - $20000-$20FFF",
            "$11 - $22000-$23FFF",
            "$12 - $24000-$25FFF",
            "$13 - $26000-$27FFF",
            "$14 - $28000-$29FFF",
            "$15 - $2A000-$2BFFF",
            "$16 - $2C000-$2DFFF",
            "$17 - $2E000-$2FFFF",
            "$18 - $30000-$31FFF",
            "$19 - $32000-$33FFF",
            "$1A - $34000-$35FFF",
            "$1B - $36000-$37FFF",
            "$1C - $38000-$39FFF",
            "$1D - $3A000-$3BFFF",
            "$1E - $3C000-$3DFFF",
            "$1F - $3E000-$3FFFF",
            "$20 - $40000-$41FFF",
            "$21 - $42000-$43FFF",
            "$22 - $44000-$45FFF",
            "$23 - $46000-$47FFF",
            "$24 - $48000-$49FFF",
            "$25 - $4A000-$4BFFF",
            "$26 - $4C000-$4DFFF",
            "$27 - $4E000-$4FFFF",
            "$28 - $50000-$51FFF",
            "$29 - $52000-$53FFF",
            "$2A - $54000-$55FFF",
            "$2B - $56000-$57FFF",
            "$2C - $58000-$59FFF",
            "$2D - $5A000-$5BFFF",
            "$2E - $5C000-$5DFFF",
            "$2F - $5E000-$5FFFF",
            "$30 - $60000-$60FFF",
            "$31 - $62000-$63FFF",
            "$32 - $64000-$65FFF",
            "$33 - $66000-$67FFF",
            "$34 - $68000-$69FFF",
            "$35 - $6A000-$6BFFF",
            "$36 - $6C000-$6DFFF",
            "$37 - $6E000-$6FFFF",
            "$38 - $70000-$71FFF",
            "$39 - $72000-$73FFF",
            "$3A - $74000-$75FFF",
            "$3B - $76000-$77FFF",
            "$3C - $78000-$79FFF",
            "$3D - $7A000-$7BFFF",
            "$3E - $7C000-$7DFFF",
            "$3F - $7E000-$7FFFF <BOOT>"});
            this.FlashBlock.Location = new System.Drawing.Point(363, 17);
            this.FlashBlock.Name = "FlashBlock";
            this.FlashBlock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FlashBlock.Size = new System.Drawing.Size(156, 25);
            this.FlashBlock.TabIndex = 30;
            this.FlashBlock.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(250, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.TabIndex = 31;
            this.label6.Text = "Flash Block:";
            // 
            // BootMethod
            // 
            this.BootMethod.DropDownWidth = 140;
            this.BootMethod.Enabled = false;
            this.BootMethod.Font = new System.Drawing.Font("Agency FB", 9.75F, System.Drawing.FontStyle.Bold);
            this.BootMethod.FormattingEnabled = true;
            this.BootMethod.Items.AddRange(new object[] {
            "Boot From FLASH",
            "Boot From RAM"});
            this.BootMethod.Location = new System.Drawing.Point(373, 50);
            this.BootMethod.Name = "BootMethod";
            this.BootMethod.Size = new System.Drawing.Size(146, 25);
            this.BootMethod.TabIndex = 32;
            this.BootMethod.Text = "Boot From FLASH";
            this.BootMethod.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedBootMethod);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(250, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 20);
            this.label8.TabIndex = 33;
            this.label8.Text = "Boot Method:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.label9.Location = new System.Drawing.Point(9, 279);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(170, 16);
            this.label9.TabIndex = 34;
            this.label9.Text = "Rev: 0.0.1 - Nov 14th_2022";
            // 
            // UploaderWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Purple;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(629, 303);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.BootMethod);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.FlashBlock);
            this.Controls.Add(this.CountdownLabel);
            this.Controls.Add(this.ReflashCheckbox);
            this.Controls.Add(this.DebugModeCheckbox);
            this.Controls.Add(this.C256DestAddress);
            this.Controls.Add(this.C256SrcAddress);
            this.Controls.Add(this.EmuSrcAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DollarSignLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.C256SrcSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.C256SrcAddressLabel);
            this.Controls.Add(this.FetchRadio);
            this.Controls.Add(this.EmuSrcSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EmuSourceAddressLabel);
            this.Controls.Add(this.BlockSendRadio);
            this.Controls.Add(this.SendFileRadio);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.UploadProgressBar);
            this.Controls.Add(this.SendBinaryButton);
            this.Controls.Add(this.DestinationAddressLabel);
            this.Controls.Add(this.FileSizeResultLabel);
            this.Controls.Add(this.FileSizeLabel);
            this.Controls.Add(this.FileNameTextBox);
            this.Controls.Add(this.BrowseFileButton);
            this.Controls.Add(this.COMPortComboBox);
            this.Controls.Add(this.ConnectButton);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UploaderWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "F256 Uploader";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UploaderWindow_FormClosed);
            this.Load += new System.EventHandler(this.UploaderWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UploaderWindow_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.ComboBox COMPortComboBox;
        private System.Windows.Forms.Button BrowseFileButton;
        private System.Windows.Forms.TextBox FileNameTextBox;
        private System.Windows.Forms.Label FileSizeLabel;
        private System.Windows.Forms.Label FileSizeResultLabel;
        private System.Windows.Forms.Label DestinationAddressLabel;
        private System.Windows.Forms.Button SendBinaryButton;
        private System.Windows.Forms.TextBox C256DestAddress;
        private System.Windows.Forms.Label DollarSignLabel;
        private System.Windows.Forms.ProgressBar UploadProgressBar;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.RadioButton SendFileRadio;
        private System.Windows.Forms.RadioButton BlockSendRadio;
        private System.Windows.Forms.TextBox EmuSrcAddress;
        private System.Windows.Forms.Label EmuSourceAddressLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EmuSrcSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton FetchRadio;
        private System.Windows.Forms.TextBox C256SrcSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox C256SrcAddress;
        private System.Windows.Forms.Label C256SrcAddressLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox DebugModeCheckbox;
        private System.Windows.Forms.CheckBox ReflashCheckbox;
        private System.Windows.Forms.Label CountdownLabel;
        private System.Windows.Forms.Timer hideLabelTimer;
        private System.Windows.Forms.ComboBox FlashBlock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox BootMethod;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}