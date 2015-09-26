namespace Take_A_Bow
{
    partial class TABA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TABA));
            this.lnkSource = new System.Windows.Forms.LinkLabel();
            this.cmdStartStop = new System.Windows.Forms.Button();
            this.TABTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lnkSource
            // 
            this.lnkSource.AutoSize = true;
            this.lnkSource.Location = new System.Drawing.Point(12, 166);
            this.lnkSource.Name = "lnkSource";
            this.lnkSource.Size = new System.Drawing.Size(115, 13);
            this.lnkSource.TabIndex = 0;
            this.lnkSource.TabStop = true;
            this.lnkSource.Text = "Adam Frank: Performer";
            this.lnkSource.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSource_LinkClicked);
            // 
            // cmdStartStop
            // 
            this.cmdStartStop.Location = new System.Drawing.Point(160, 166);
            this.cmdStartStop.Name = "cmdStartStop";
            this.cmdStartStop.Size = new System.Drawing.Size(112, 40);
            this.cmdStartStop.TabIndex = 1;
            this.cmdStartStop.Text = "Stop Sensor";
            this.cmdStartStop.UseVisualStyleBackColor = true;
            this.cmdStartStop.Click += new System.EventHandler(this.cmdStartStop_Click);
            // 
            // TABTrayIcon
            // 
            this.TABTrayIcon.BalloonTipText = "Take A Bow";
            this.TABTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TABTrayIcon.Icon")));
            this.TABTrayIcon.Text = "Take A Bow";
            this.TABTrayIcon.Visible = true;
            this.TABTrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TAQBTrayIcon_MouseDoubleClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(260, 139);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // TABA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 212);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cmdStartStop);
            this.Controls.Add(this.lnkSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TABA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Take A Bow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TABA_FormClosing);
            this.Load += new System.EventHandler(this.TABA_Load);
            this.SizeChanged += new System.EventHandler(this.TABA_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkSource;
        private System.Windows.Forms.Button cmdStartStop;
        private System.Windows.Forms.NotifyIcon TABTrayIcon;
        private System.Windows.Forms.TextBox textBox1;
    }
}

