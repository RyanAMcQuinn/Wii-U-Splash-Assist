namespace Wii_U_Splash_Assist
{
    using Pfim;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.IO.Compression;

    public partial class Form1 : Form
    {
        byte[] fileData;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //

                //
                OpenFileDialog ImageBox = new OpenFileDialog();
                ImageBox.Title = "Choose your image file...";
                ImageBox.Filter = "TGA Image (*.tga)|*.tga|All Files (*.*)|*.*";
                ImageBox.FilterIndex = 0;
                ImageBox.ShowDialog();
                textBox1.Text = ImageBox.FileName;
                //pictureBox1.ImageLocation = ImageBox.FileName;
                
                using (var image = Pfim.Pfimage.FromFile(ImageBox.FileName))
                {
                    // Convert to a format that System.Drawing.Bitmap can use (e.g., Rgba32)
                    
                    var format = image.Format switch
                    {
                        
                        ImageFormat.Rgba32 => System.Drawing.Imaging.PixelFormat.Format32bppArgb,
                        ImageFormat.Rgb24 => System.Drawing.Imaging.PixelFormat.Format24bppRgb,
                        _ => throw new System.NotSupportedException("Unsupported pixel format")
                    };

                    
                    // Create the Bitmap
                    Bitmap bitmap = new Bitmap(image.Width, image.Height, format);

                    // Lock the bits and copy the raw data
                    var bits = bitmap.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                                              System.Drawing.Imaging.ImageLockMode.WriteOnly, format);
                    System.Runtime.InteropServices.Marshal.Copy(image.Data, 0, bits.Scan0, image.DataLen);
                    bitmap.UnlockBits(bits);

                    // Display the image in a PictureBox control (assuming one named 'pictureBox1' exists)
                    pictureBox1.Image = bitmap;
                    
                    pictureBox1.SizeMode = (PictureBoxSizeMode.Zoom);
                    pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    //
                    using (var sourceStream = new FileStream(textBox1.Text, FileMode.Open, FileAccess.Read))
                    {
                        using (var destinationStream = new FileStream("tempimg.z", FileMode.Create, FileAccess.Write))
                        {
                            // Create the ZLibStream in Compression mode, wrapping the destination stream.
                            // Data written to the ZLibStream will be compressed and written to the destinationStream.
                            using (var zlibStream = new ZLibStream(destinationStream, CompressionLevel.SmallestSize))
                            {
                                // Copy the bytes from the source file stream to the compressing stream.
                                sourceStream.CopyTo(zlibStream);
                            }
                        }
                    }
                    //
                }
                //
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("You must either have Defuse or isfshax installed in order to modify system files! " + Environment.NewLine + "We take no responsability for any damage done by using this software. Proceed at your own risk!","**WARNING**",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog ImageBox = new OpenFileDialog();
                ImageBox.Title = "Choose your sound file...";
                ImageBox.Filter = "48khz Wav file (*.wav)|*.wav|All Files (*.*)|*.*";
                ImageBox.FilterIndex = 0;
                ImageBox.ShowDialog();
                textBox2.Text = ImageBox.FileName;
                axWindowsMediaPlayer1.URL = textBox2.Text;
                //wav2btsnd.jar -in "48khz stereo .wav"
                //open cmd process, writeline arguments
                Process w2b = new Process();
                w2b.StartInfo.CreateNoWindow = true;
                w2b.StartInfo.UseShellExecute = false;
                w2b.StartInfo.FileName = "wav2btsnd.exe";
                w2b.StartInfo.Arguments = "-jar wav2btsnd.jar -in " + '"' + textBox2.Text + '"';
                //w2b.StartInfo.RedirectStandardInput = true;
                w2b.Start();
                
                w2b.WaitForExit();
                //
                using (var sourceStream = new FileStream("bootsound.btsnd", FileMode.Open, FileAccess.Read))
                {
                    using (var destinationStream = new FileStream("tempsnd.z", FileMode.Create, FileAccess.Write))
                    {
                        // Create the ZLibStream in Compression mode, wrapping the destination stream.
                        // Data written to the ZLibStream will be compressed and written to the destinationStream.
                        using (var zlibStream = new ZLibStream(destinationStream, CompressionLevel.SmallestSize))
                        {
                            // Copy the bytes from the source file stream to the compressing stream.
                            sourceStream.CopyTo(zlibStream);
                        }
                    }
                }
                //
                MessageBox.Show("Sound file converted correctly!","Complete.",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string output;
                string input;
                OpenFileDialog ImageBox = new OpenFileDialog();
                ImageBox.Title = "Choose your Root.rpx file...";
                ImageBox.Filter = "Root.rpx file (*.rpx)|*.rpx|All Files (*.*)|*.*";
                ImageBox.FilterIndex = 0;
                ImageBox.ShowDialog();
                textBox3.Text = ImageBox.FileName;
                Process deComp = new Process();
                //deComp.StartInfo.Arguments = "wiiurpxtool.exe -d root.rpx root.drpx";
                deComp.StartInfo.CreateNoWindow = true;
                deComp.StartInfo.UseShellExecute = false;
                deComp.StartInfo.FileName = "cmd.exe";
                deComp.StartInfo.RedirectStandardInput = true;
                deComp.Start();
                deComp.StandardInput.WriteLine("wiiurpxtool.exe -d root.rpx root.drpx");
                deComp.StandardInput.WriteLine("exit");
                deComp.WaitForExit();
                System.Threading.Thread.Sleep(2000);
                DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo f in files)
                {
                    if (f.Name.Contains("root.drpx"))
                    {
                        MessageBox.Show("Root.rpx decompressed.");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //Put tempimg.z into byte array calculate size + check if too big (151066 bytes max)
                FileToByteArray("tempimg.z");
                if (fileData.Length > 151050)
                {
                    MessageBox.Show("Image file too large, Using only 16 unique colors is strongly recommended!");
                    return;
                }
                else
                {
                    //copy zlib files via byte array into root.drpx with padding (FF FF 00 00)
                    FileStream streamI = File.Open("root.drpx", FileMode.Open, FileAccess.ReadWrite);
                    streamI.Seek(0x176BA0, SeekOrigin.Begin);
                    streamI.Write(fileData);
                    streamI.WriteByte(0xFF);
                    streamI.WriteByte(0xFF);
                    streamI.WriteByte(0x00);
                    streamI.WriteByte(0x00);
                    streamI.Close();
                }
                //Put tempsnd.z into byte array calculate size + check if too big (1529603 bytes max)
                FileToByteArray("tempsnd.z");
                if (fileData.Length > 1529590)
                {
                    MessageBox.Show("Sound file too large, keep it 8 seconds or less!");
                    return;
                }
                else
                {
                    //copy zlib files via byte array into root.drpx with padding (FF FF 00 00)
                    FileStream streamS = File.Open("root.drpx", FileMode.Open, FileAccess.ReadWrite);
                    streamS.Seek(0x514, SeekOrigin.Begin);
                    streamS.Write(fileData);
                    streamS.WriteByte(0xFF);
                    streamS.WriteByte(0xFF);
                    streamS.WriteByte(0x00);
                    streamS.WriteByte(0x00);
                    streamS.Close();
                }


                //Repack root.dprx into root.rpx with "wiiurpxtool.exe -c root.drpx root.rpx"
                Process Comp = new Process();
                Comp.StartInfo.CreateNoWindow = true;
                Comp.StartInfo.UseShellExecute = false;
                Comp.StartInfo.FileName = "cmd.exe";
                Comp.StartInfo.RedirectStandardInput = true;
                Comp.Start();
                Comp.StandardInput.WriteLine("wiiurpxtool.exe -c root.drpx root.rpx");
                Comp.StandardInput.WriteLine("exit");
                Comp.WaitForExit();
                MessageBox.Show("Process complete.Now just Ftp transfer the root.rpx file to your system.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
        public byte[] FileToByteArray(string fileName)
        {


            using (FileStream fs = File.OpenRead(fileName))
            {
                using (BinaryReader binaryReader = new BinaryReader(fs))
                {
                    fileData = binaryReader.ReadBytes((int)fs.Length);
                }
            }
            return fileData;
        }
        public void ConvertRgbToBgr(byte[] pixelData)
        {
            // Assume pixelData is BGR or RGB interleaved (3 bytes: R, G, B)
            for (int i = 0; i < pixelData.Length; i += 3)
            {
                byte temp = pixelData[i];       // R
                pixelData[i] = pixelData[i + 2]; // B -> R
                pixelData[i + 2] = temp;        // R -> B
            }
        }

    }
}
