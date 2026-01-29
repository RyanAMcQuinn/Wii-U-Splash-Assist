namespace Wii_U_Splash_Assist
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupBox1 = new GroupBox();
            button3 = new Button();
            textBox3 = new TextBox();
            label3 = new Label();
            button2 = new Button();
            textBox2 = new TextBox();
            label2 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            button4 = new Button();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(329, 198);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // button3
            // 
            button3.Location = new Point(235, 145);
            button3.Name = "button3";
            button3.Size = new Size(51, 23);
            button3.TabIndex = 7;
            button3.Text = "...";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(22, 146);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(207, 23);
            textBox3.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 128);
            label3.Name = "label3";
            label3.Size = new Size(203, 15);
            label3.TabIndex = 5;
            label3.Text = "Root.rpx File (Pulled from US System)";
            // 
            // button2
            // 
            button2.Location = new Point(235, 92);
            button2.Name = "button2";
            button2.Size = new Size(51, 23);
            button2.TabIndex = 4;
            button2.Text = "...";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(22, 93);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(207, 23);
            textBox2.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 75);
            label2.Name = "label2";
            label2.Size = new Size(186, 15);
            label2.TabIndex = 3;
            label2.Text = "Sound File (Wav - 48KHZ - Stereo)";
            // 
            // button1
            // 
            button1.Location = new Point(235, 40);
            button1.Name = "button1";
            button1.Size = new Size(51, 23);
            button1.TabIndex = 2;
            button1.Text = "...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(22, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(207, 23);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 22);
            label1.Name = "label1";
            label1.Size = new Size(273, 15);
            label1.TabIndex = 0;
            label1.Text = "Image File (TGA - Top, Left - No RLE Compression)";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(6, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(248, 179);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // axWindowsMediaPlayer1
            // 
            axWindowsMediaPlayer1.Enabled = true;
            axWindowsMediaPlayer1.Location = new Point(12, 216);
            axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            axWindowsMediaPlayer1.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer1.OcxState");
            axWindowsMediaPlayer1.Size = new Size(329, 47);
            axWindowsMediaPlayer1.TabIndex = 2;
            // 
            // button4
            // 
            button4.Location = new Point(141, 269);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 3;
            button4.Text = "Go";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(pictureBox1);
            groupBox2.Location = new Point(347, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(260, 198);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(619, 312);
            Controls.Add(groupBox2);
            Controls.Add(button4);
            Controls.Add(axWindowsMediaPlayer1);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(635, 351);
            MinimumSize = new Size(635, 351);
            Name = "Form1";
            Text = "Wii U Splash Assist";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button button3;
        private TextBox textBox3;
        private Label label3;
        private Button button2;
        private TextBox textBox2;
        private Label label2;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private PictureBox pictureBox1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private Button button4;
        private GroupBox groupBox2;
    }
}
