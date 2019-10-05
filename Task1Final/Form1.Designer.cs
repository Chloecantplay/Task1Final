namespace Task1Final
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
            this.MapBox = new System.Windows.Forms.GroupBox();
            this.Roundlabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.StatsBox = new System.Windows.Forms.RichTextBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // MapBox
            // 
            this.MapBox.Location = new System.Drawing.Point(13, 13);
            this.MapBox.Name = "MapBox";
            this.MapBox.Size = new System.Drawing.Size(571, 425);
            this.MapBox.TabIndex = 0;
            this.MapBox.TabStop = false;
            this.MapBox.Text = "Map";
            // 
            // Roundlabel
            // 
            this.Roundlabel.AutoSize = true;
            this.Roundlabel.Location = new System.Drawing.Point(622, 26);
            this.Roundlabel.Name = "Roundlabel";
            this.Roundlabel.Size = new System.Drawing.Size(0, 17);
            this.Roundlabel.TabIndex = 1;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(609, 74);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(179, 43);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.Location = new System.Drawing.Point(609, 141);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(179, 45);
            this.PauseButton.TabIndex = 3;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // StatsBox
            // 
            this.StatsBox.Location = new System.Drawing.Point(609, 209);
            this.StatsBox.Name = "StatsBox";
            this.StatsBox.Size = new System.Drawing.Size(179, 229);
            this.StatsBox.TabIndex = 4;
            this.StatsBox.Text = "";
            this.StatsBox.TextChanged += new System.EventHandler(this.StatsBox_TextChanged);
            // 
            // Timer
            // 
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 526);
            this.Controls.Add(this.StatsBox);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.Roundlabel);
            this.Controls.Add(this.MapBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Roundlabel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button PauseButton;
        public System.Windows.Forms.RichTextBox StatsBox;
        public System.Windows.Forms.GroupBox MapBox;
        public System.Windows.Forms.Timer Timer;
    }
}

