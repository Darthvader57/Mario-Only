namespace Mario_Version_3_Part_2._5
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
            this.menuPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.startbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.menuPanel.Controls.Add(this.button2);
            this.menuPanel.Controls.Add(this.startbtn);
            this.menuPanel.Controls.Add(this.label1);
            this.menuPanel.Location = new System.Drawing.Point(1, 1);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(800, 450);
            this.menuPanel.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(292, 153);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 56);
            this.button2.TabIndex = 2;
            this.button2.Text = "Quit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // startbtn
            // 
            this.startbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startbtn.Location = new System.Drawing.Point(292, 73);
            this.startbtn.Name = "startbtn";
            this.startbtn.Size = new System.Drawing.Size(163, 57);
            this.startbtn.TabIndex = 1;
            this.startbtn.Text = "Start";
            this.startbtn.UseVisualStyleBackColor = true;
            this.startbtn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(255, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Platform Game";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 436);
            this.Controls.Add(this.menuPanel);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyisDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyisUp);
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button startbtn;
        private System.Windows.Forms.Label label1;
    }
}

