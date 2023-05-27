﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace FoenixIDE.UI
{
    public partial class UploaderWindow : Form
    {
        public static byte TxLRC = 0;
        public static byte RxLRC = 0;
        public static byte Stat0 = 0;
        public static byte Stat1 = 0;
        public static byte LRC = 0;
        public static int FlashBlockSelected = 0;
        public static byte Memory_Boot_Method = 0;
        public static string[] ports;

        SerialPort serial = new SerialPort();
        private Queue<byte> recievedData = new Queue<byte>();

        public UploaderWindow()
        {
            InitializeComponent();

            serial.BaudRate = 6000000;
            serial.Handshake = System.IO.Ports.Handshake.None;
            serial.Parity = Parity.None;
            serial.DataBits = 8;
            serial.StopBits = StopBits.One;
            serial.ReadTimeout = 2000;
            serial.WriteTimeout = 2000;
            //serial.RtsEnable = true;
            //serial.DtrEnable = true;
            ports = SerialPort.GetPortNames();  // Save the Ports Name in a String Array
            // 
            Console.WriteLine("Available Ports:");
            // Save the Ports Name in the Items list of the ComboBox
            foreach (string s in SerialPort.GetPortNames())
            {
                COMPortComboBox.Items.Add(s);

                Console.WriteLine("   {0}", s);
            }
            if (COMPortComboBox.Items.Count == 0)
            {
                COMPortComboBox.Items.Add("-----");
            }
            COMPortComboBox.SelectedItem = COMPortComboBox.Items[0];
        }

        private int GetTransmissionSize()
        {
            int transmissionSize = -1;
            if (SendFileRadio.Checked)
            {
                GetFileLength(FileNameTextBox.Text);
                transmissionSize = Convert.ToInt32(FileSizeResultLabel.Text.Replace("$", "").Replace(":", ""), 16);
            }
            else if (BlockSendRadio.Checked)
            {
                transmissionSize = Convert.ToInt32(EmuSrcSize.Text.Replace("$", "").Replace(":", ""), 16);
            }
            else
            {
                transmissionSize = Convert.ToInt32(C256SrcSize.Text.Replace("$", "").Replace(":", ""), 16);
            }
            return transmissionSize;
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                serial.PortName = COMPortComboBox.Items[COMPortComboBox.SelectedIndex].ToString();
                serial.Open();
                // Enable all the button if the serial Port turns out to be the good one.
                BrowseFileButton.Enabled = SendFileRadio.Checked;

                SendBinaryButton.Enabled = GetTransmissionSize() > 0;
                COMPortComboBox.Enabled = false;
                ConnectButton.Visible = false;
                DisconnectButton.Visible = true;
                BootMethod.Enabled = true;

                Console.WriteLine("Serial Port Connected: " + ports[COMPortComboBox.SelectedIndex]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Serial Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            serial.Close();
            ConnectButton.Visible = true;
            DisconnectButton.Visible = false;
            COMPortComboBox.Enabled = true;
            SendBinaryButton.Enabled = false;
            BootMethod.Enabled = false;
        }

        private void UploaderWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            DisconnectButton_Click(null, null);
        }

        private long GetFileLength(String filename)
        {
            long flen = 0;
            // Display the file length in hex
            if (filename != null && filename.Length > 0)
            {
                if (Path.GetExtension(filename).ToUpper().Equals(".BIN"))
                {
                    FileInfo f = new FileInfo(filename);
                    flen = f.Length;
                }
                else
                {
                    // We're loading a HEX file, so only consider the lines that are record type 00
                    string[] lines = System.IO.File.ReadAllLines(filename);
                    foreach (string l in lines)
                    {
                        if (l.StartsWith(":"))
                        {
                            string mark = l.Substring(0, 1);
                            string reclen = l.Substring(1, 2);
                            string offset = l.Substring(3, 4);
                            string rectype = l.Substring(7, 2);

                            if (rectype.Equals("00"))
                            {
                                flen += Convert.ToInt32(reclen, 16);
                            }
                        }
                    }
                }
            }
            String hexSize = flen.ToString("X6");
            FileSizeResultLabel.Text = "$" + hexSize.Substring(0, 2) + ":" + hexSize.Substring(2);
            return flen;
        }

        /*
         * Let the user select a file from the file system and display it in a text box.
         */
        private void BrowseFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog
            {
                DefaultExt = ".bin",
                Filter = "Binary documents|*.bin",
                Title = "Upload to the GenX"
            };

            // Load content of file in a TextBlock
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                string extension = Path.GetExtension(openFileDlg.FileName);
                // Display the file name
                FileNameTextBox.Text = openFileDlg.FileName;
                C256DestAddress.Enabled = extension.ToUpper().Equals(".BIN");
                ReflashCheckbox.Enabled = extension.ToUpper().Equals(".BIN");
                // Display the file length
                long flen = GetFileLength(openFileDlg.FileName);

                SendBinaryButton.Enabled = (flen != -1) && !ConnectButton.Visible;
            }
        }

        /**
         * This method fires whenever the radio buttons are changed.
         */
        private void SendFileRadio_CheckedChanged(object sender, EventArgs e)
        {
            FileNameTextBox.Enabled = SendFileRadio.Checked;
            BrowseFileButton.Enabled = SendFileRadio.Checked;

            int transmissionSize = GetTransmissionSize();
            EmuSrcSize.Enabled = BlockSendRadio.Checked;
            EmuSrcAddress.Enabled = BlockSendRadio.Checked;
            if (FileNameTextBox.Text.Length == 0 || BlockSendRadio.Checked)
            {
                C256DestAddress.Enabled = (transmissionSize > 0 || BlockSendRadio.Checked);
            }
            else
            {
                string extension = Path.GetExtension(FileNameTextBox.Text).ToUpper();
                C256DestAddress.Enabled = (transmissionSize > 0 || BlockSendRadio.Checked) && (extension.Equals(".BIN") || ReflashCheckbox.Checked);
            }


            C256SrcSize.Enabled = FetchRadio.Checked;
            C256SrcAddress.Enabled = FetchRadio.Checked;

            SendBinaryButton.Enabled = (transmissionSize > 0) && !ConnectButton.Visible;
            SendBinaryButton.Text = FetchRadio.Checked ? "Fetch from F256" : "Send Binary";
        }

        private void SendBinaryButton_Click(object sender, EventArgs e)
        {
            SendBinaryButton.Enabled = false;
            DisconnectButton.Enabled = false;
            hideLabelTimer_Tick(null, null);
            int transmissionSize = GetTransmissionSize();
            UploadProgressBar.Maximum = transmissionSize;
            UploadProgressBar.Value = 0;
            UploadProgressBar.Visible = true;

            if (SendFileRadio.Checked)
            {
                if (serial.IsOpen)
                {
                    // Get into Debug mode (Reset the CPU and keep it in that state and Gavin will take control of the bus)
                    if (DebugModeCheckbox.Checked)
                    {
                        GetFnxInDebugMode();
                    }

                    if (Path.GetExtension(FileNameTextBox.Text).ToUpper().Equals(".BIN"))
                    {
                        // Read the bytes and put them in the buffer
                        byte[] DataBuffer = System.IO.File.ReadAllBytes(FileNameTextBox.Text);
                        int FnxAddressPtr = int.Parse(C256DestAddress.Text.Replace(":", ""), System.Globalization.NumberStyles.AllowHexSpecifier);
                        Console.WriteLine("Starting Address: " + FnxAddressPtr);
                        Console.WriteLine("File Size: " + transmissionSize);
                        SendData(DataBuffer, FnxAddressPtr, transmissionSize);
                    }

                    if (ReflashCheckbox.Checked && MessageBox.Show("Are you sure you want to reflash your F256 System?", "Reflash", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        CountdownLabel.Visible = true;
                        this.Update();

                        
                        //EraseFlash();
                        // The flash sectors are 4K Size, but the Combolist is in 8K Boundary
                        EraseFlashSector( (byte) (FlashBlockSelected * 2));    // Erase 1st Sector of 4K
                        EraseFlashSector( (byte) ((FlashBlockSelected * 2 ) + 1)); // Erase 2nd Sector of 4K
                        FlashSelectSector( (byte) (FlashBlockSelected * 2));     // Same here, this will set the address Sector of the Flash we want use
                        System.Console.WriteLine((FlashBlockSelected * 2).ToString());
                        
                        int SrcFlashAddress = Convert.ToInt32(C256DestAddress.Text.Replace(":", ""), 16);
                        ProgramFlash(SrcFlashAddress);
                        CountdownLabel.Visible = false;
                    }
                    if (DebugModeCheckbox.Checked)
                    {
                        // The Loading of the File is Done, Reset the FNX and Get out of Debug Mode
                        ExitFnxDebugMode();
                    }
                    HideProgressBarAfter5Seconds("Transfer Done! System Reset!");
                }
            }

        }

        private void HideProgressBarAfter5Seconds(string message)
        {
            UploadProgressBar.Visible = false;
            CountdownLabel.Visible = true;
            CountdownLabel.Text = message;
            hideLabelTimer.Enabled = true;
            SendBinaryButton.Enabled = true;
            DisconnectButton.Enabled = true;
        }

        private void hideLabelTimer_Tick(object sender, EventArgs e)
        {
            hideLabelTimer.Enabled = false;
            CountdownLabel.Visible = false;
            CountdownLabel.Text = "";
        }


        private byte Checksum(byte[] buffer, int length)
        {
            byte checksum = 0x55;
            for (int i = 1; i < length; i++)
            {
                checksum ^= buffer[i];
            }
            return checksum;
        }

        private void EraseFlash()
        {
            CountdownLabel.Text = "Erasing Flash";
            this.Update();
            byte[] commandBuffer = new byte[8];
            commandBuffer[0] = 0x55;   // Header
            commandBuffer[1] = 0x11;   // Reset Flash
            commandBuffer[2] = 0x00;
            commandBuffer[3] = 0x00;
            commandBuffer[4] = 0x00;
            commandBuffer[5] = 0x00;
            commandBuffer[6] = 0x00;
            commandBuffer[7] = Checksum(commandBuffer, 7);
            SendMessage(commandBuffer, null, 2000);    // 32000 = 32 Sec, I need 32ms
        }

        private void EraseFlashSector( byte Sector )
        {
            CountdownLabel.Text = "Erasing Flash Sector";
            this.Update();
            byte[] commandBuffer = new byte[8];
            commandBuffer[0] = 0x55;   // Header
            commandBuffer[1] = 0x12;   // Reset Flash
            commandBuffer[2] = Sector;  // Select Flash Sector
            commandBuffer[3] = 0x00;
            commandBuffer[4] = 0x00;
            commandBuffer[5] = 0x00;
            commandBuffer[6] = 0x00;
            commandBuffer[7] = Checksum(commandBuffer, 7);
            SendMessage(commandBuffer, null, 1000);    // 32000 = 32 Sec, I need 32ms
        }


        private void FlashSelectSector(byte Sector)
        {
            CountdownLabel.Text = "Select Flash Sector";
            this.Update();
            byte[] commandBuffer = new byte[8];
            commandBuffer[0] = 0x55;   // Header
            commandBuffer[1] = 0x13;   // Select Flash Sector
            commandBuffer[2] = Sector;  // Select Flash Sector
            commandBuffer[3] = 0x00;
            commandBuffer[4] = 0x00;
            commandBuffer[5] = 0x00;
            commandBuffer[6] = 0x00;
            commandBuffer[7] = Checksum(commandBuffer, 7);
            SendMessage(commandBuffer, null, 1000);    // 32000 = 32 Sec, I need 32ms
        }

        private void ProgramFlash(int address)
        {
            CountdownLabel.Text = "Programming Flash";
            this.Update();
            byte[] commandBuffer = new byte[8];
            commandBuffer[0] = 0x55;   // Header
            commandBuffer[1] = 0x10;   // Program Flash
            commandBuffer[2] = (byte)((address & 0xFF_0000) >> 16);
            commandBuffer[3] = (byte)((address & 0x00_FF00) >> 8);
            commandBuffer[4] = (byte)(address & 0x00_00FF);
            commandBuffer[5] = 0x00;
            commandBuffer[6] = 0x00;
            commandBuffer[7] = Checksum(commandBuffer, 7);
            //SendMessage(commandBuffer, null, 20000); // THis is with very big delay
            SendMessage(commandBuffer, null, 1000);
        }

        private void SendData(byte[] buffer, int startAddress, int size)
        {
            try
            {
                if (serial.IsOpen)
                {
                    // Now's let's transfer the code
                    if (size <= 1024)
                    {
                        // DataBuffer = The buffer where the loaded Binary File resides
                        // FnxAddressPtr = Pointer where to put the Data in the Fnx
                        // i = Pointer Inside the data buffer
                        // Size_Of_File = Size of the Payload we want to transfer which ought to be smaller than 8192
                        PreparePacket2Write(buffer, startAddress, 0, size);
                        UploadProgressBar.Increment(size);
                    }
                    else
                    {
                        int BufferSize = 1024;
                        int Loop = size / BufferSize;
                        int offset = startAddress;
                        for (int j = 0; j < Loop; j++)
                        {
                            PreparePacket2Write(buffer, offset, j * BufferSize, BufferSize);
                            offset += BufferSize;   // Advance the Pointer to the next location where to write Data in the Foenix
                            UploadProgressBar.Increment(BufferSize);
                        }
                        BufferSize = (size % BufferSize);
                        if (BufferSize > 0)
                        {
                            PreparePacket2Write(buffer, offset, size - BufferSize, BufferSize);
                            UploadProgressBar.Increment(BufferSize);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Send Binary Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool FetchData(byte[] buffer, int startAddress, int size, bool debugMode)
        {
            bool success = false;
            byte[] partialBuffer;

            try
            {
                if (serial.IsOpen)
                {
                    if (debugMode)
                    {
                        GetFnxInDebugMode();
                    }

                    if (size < 1024)
                    {
                        partialBuffer = PreparePacket2Read(startAddress, size);
                        Array.Copy(partialBuffer, 0, buffer, 0, size);
                        UploadProgressBar.Increment(size);
                    }
                    else
                    {
                        int BufferSize = 1024;
                        int Loop = size / BufferSize;

                        for (int j = 0; j < Loop; j++)
                        {
                            partialBuffer = PreparePacket2Read(startAddress, BufferSize);
                            Array.Copy(partialBuffer, 0, buffer, j * BufferSize, BufferSize);
                            partialBuffer = null;
                            startAddress += BufferSize;   // Advance the Pointer to the next location where to write Data in the Foenix
                            UploadProgressBar.Increment(BufferSize);
                        }
                        BufferSize = (size % BufferSize);
                        if (BufferSize > 0)
                        {
                            partialBuffer = PreparePacket2Read(startAddress, BufferSize);
                            Array.Copy(partialBuffer, 0, buffer, size - BufferSize, BufferSize);
                            UploadProgressBar.Increment(BufferSize);
                        }
                    }

                    if (debugMode)
                    {
                        ExitFnxDebugMode();
                    }
                    success = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fetch Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return success;
        }

        private void AddressTextBox_TextChanged(object sender, EventArgs e)
        {
            int uploadSize = GetTransmissionSize();
            SendBinaryButton.Enabled = uploadSize > 0 && !ConnectButton.Visible;
        }

        private void BlockAddressTextBox_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string item = tb.Text.Replace(":", "");
            if (item.Length > 0)
            {
                int n = Convert.ToInt32(item, 16);
                String value = n.ToString("X6");
                tb.Text = value.Substring(0, 2) + ":" + value.Substring(2);
            }
        }

        public void GetFnx2BootFromRAMorFLASH( byte Selection )
        {
            byte[] commandBuffer = new byte[8];
            commandBuffer[0] = 0x55;   // Header
            if (Selection == 1)
                commandBuffer[1] = 0x90;   // GetFNX To Boot From RAM
            else
                commandBuffer[1] = 0x91;   // GetFNX To Boot From FLASH
            commandBuffer[2] = 0x00;
            commandBuffer[3] = 0x00;
            commandBuffer[4] = 0x00;
            commandBuffer[5] = 0x00;
            commandBuffer[6] = 0x00;
            commandBuffer[7] = Checksum(commandBuffer, 7);
            SendMessage(commandBuffer, null);
        }


        public void GetFnxInDebugMode()
        {
            byte[] commandBuffer = new byte[8];
            commandBuffer[0] = 0x55;   // Header
            commandBuffer[1] = 0x80;   // GetFNXinDebugMode
            commandBuffer[2] = 0x00;
            commandBuffer[3] = 0x00;
            commandBuffer[4] = 0x00;
            commandBuffer[5] = 0x00;
            commandBuffer[6] = 0x00;
            commandBuffer[7] = Checksum(commandBuffer, 7);
            SendMessage(commandBuffer, null);
        }

        public void ExitFnxDebugMode()
        {
            byte[] commandBuffer = new byte[8];
            commandBuffer[0] = 0x55;   // Header
            commandBuffer[1] = 0x81;   // ExitFNXinDebugMode
            commandBuffer[2] = 0x00;
            commandBuffer[3] = 0x00;
            commandBuffer[4] = 0x00;
            commandBuffer[5] = 0x00;
            commandBuffer[6] = 0x00;
            commandBuffer[7] = Checksum(commandBuffer, 7);
            SendMessage(commandBuffer, null);
        }

        /*
        CMD = 0x00 Read Memory Block
        CMD = 0x01 Write Memory Block
        CMD = 0x0E GetFNXinDebugMode - Stop Processor and put Bus in Tri-State - That needs to be done before any transaction.
        CMD = 0x0F 
         */
        public void PreparePacket2Write(byte[] buffer, int FNXMemPointer, int FilePointer, int Size)
        {
            // Maximum transmission size is 8192
            if (Size > 8192)
                Size = 8192;

            byte[] commandBuffer = new byte[8 + Size];
            commandBuffer[0] = 0x55;   // Header
            commandBuffer[1] = 0x01;   // Write 2 Memory
            commandBuffer[2] = (byte)((FNXMemPointer >> 16) & 0xFF); // (H)24Bit Addy - Where to Store the Data
            commandBuffer[3] = (byte)((FNXMemPointer >> 8) & 0xFF);  // (M)24Bit Addy - Where to Store the Data
            commandBuffer[4] = (byte)(FNXMemPointer & 0xFF);         // (L)24Bit Addy - Where to Store the Data
            commandBuffer[5] = (byte)((Size >> 8) & 0xFF);           // (H)16Bit Size - How many bytes to Store (Max 8Kbytes for now)
            commandBuffer[6] = (byte)(Size & 0xFF);                  // (L)16Bit Size - How many bytes to Store (Max 8Kbytes for now)
            Array.Copy(buffer, FilePointer, commandBuffer, 7, Size);

            TxProcessLRC(commandBuffer);
            Console.WriteLine("Transmit Data LRC:" + TxLRC);
            //commandBuffer[Size + 7] = TxLRC;

            SendMessage(commandBuffer, null);   // Tx the requested Payload Size (Plus Header and LRC), No Payload to be received aside of the Status.
        }

        public byte[] PreparePacket2Read(int address, int size)
        {
            if (size > 0)
            {
                byte[] commandBuffer = new byte[8];
                commandBuffer[0] = 0x55;   // Header
                commandBuffer[1] = 0x00;   // Command READ Memory
                commandBuffer[2] = (byte)(address >> 16); // Address Hi
                commandBuffer[3] = (byte)(address >> 8); // Address Med
                commandBuffer[4] = (byte)(address & 0xFF); //Address Lo
                commandBuffer[5] = (byte)(size >> 8); //Size HI
                commandBuffer[6] = (byte)(size & 0xFF); //Size LO
                commandBuffer[7] = Checksum(commandBuffer, 7);

                byte[] partialBuffer = new byte[size];
                SendMessage(commandBuffer, partialBuffer);
                return partialBuffer;
            }
            return null;
        }

        public void SendMessage(byte[] command, byte[] data, int delay = 0)
        {
            //            int dwStartTime = System.Environment.TickCount;
            byte byte_buffer;
            Stopwatch stopWatch = new Stopwatch();
            serial.Write(command, 0, command.Length);

            Stat0 = 0;
            Stat1 = 0;
            LRC = 0;

            if (delay > 2000)
            {
                serial.ReadTimeout = delay;
            }
            if (delay > 0)
            {
                long StartTime = System.DateTimeOffset.Now.ToUnixTimeMilliseconds();
                int roundTime = delay / 1000;
                string label = CountdownLabel.Text;
                do
                {
                    CountdownLabel.Text = label + " - " + roundTime + "s";
                    this.Update();
                    Thread.Sleep(1000);
                    roundTime--;
                }
                while (System.DateTimeOffset.Now.ToUnixTimeMilliseconds() - StartTime < delay);
                CountdownLabel.Text = label + " - Done!";
            }

            stopWatch.Start();
            do
            {
                byte_buffer = (byte)serial.ReadByte();
            }
            while (byte_buffer != 0xAA);
            stopWatch.Stop();
            TimeSpan tsReady = stopWatch.Elapsed;
            if (delay > 2000)
            {
                serial.ReadTimeout = 2000;
            }

            // reset the stop watch
            stopWatch.Reset();
            stopWatch.Start();
            if (byte_buffer == 0xAA)
            {
                Stat0 = (byte)serial.ReadByte();
                Stat1 = (byte)serial.ReadByte();
                if (data != null)
                {
                    serial.Read(data, 0, data.Length);
                }
                LRC = (byte)serial.ReadByte();
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine("Ready: " + tsReady.Milliseconds + ", Receive Data LRC:" + RxLRC + ", Time: " + ts.Milliseconds + "ms");
            RxProcessLRC(data);
        }

        public int TxProcessLRC(byte[] buffer)
        {
            int i;
            TxLRC = 0;
            for (i = 0; i < buffer.Length; i++)
                TxLRC = (byte)(TxLRC ^ buffer[i]);
            return TxLRC;
        }

        public int RxProcessLRC(byte[] data)
        {
            int i;
            RxLRC = 0xAA;
            RxLRC = (byte)(RxLRC ^ Stat0);
            RxLRC = (byte)(RxLRC ^ Stat1);
            if (data != null)
            {
                for (i = 0; i < data.Length; i++)
                    RxLRC = (byte)(RxLRC ^ data[i]);
            }
            RxLRC = (byte)(RxLRC ^ LRC);
            return RxLRC;
        }

        private void UploaderWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void UploaderWindow_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            FlashBlockSelected = cmb.SelectedIndex;
        }

        private void comboBox_SelectedBootMethod(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            Memory_Boot_Method = (byte) cmb.SelectedIndex;
                GetFnx2BootFromRAMorFLASH(Memory_Boot_Method);

        }
    }
}
