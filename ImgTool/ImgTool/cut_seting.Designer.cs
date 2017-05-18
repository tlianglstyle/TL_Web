namespace ImgTool
{
    partial class cut_seting
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
            this.button3 = new System.Windows.Forms.Button();
            this.lbl_stauts = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(41, 217);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(177, 88);
            this.button3.TabIndex = 15;
            this.button3.Text = "select directory\n";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lbl_stauts
            // 
            this.lbl_stauts.AutoSize = true;
            this.lbl_stauts.Location = new System.Drawing.Point(39, 62);
            this.lbl_stauts.Name = "lbl_stauts";
            this.lbl_stauts.Size = new System.Drawing.Size(65, 12);
            this.lbl_stauts.TabIndex = 14;
            this.lbl_stauts.Text = "lbl_stauts";
            this.lbl_stauts.Click += new System.EventHandler(this.lbl_stauts_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(41, 348);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(177, 85);
            this.button2.TabIndex = 13;
            this.button2.Text = "select files";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 83);
            this.button1.TabIndex = 12;
            this.button1.Text = "just do it!(Desktop)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(41, 13);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(72, 21);
            this.txt1.TabIndex = 16;
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(131, 13);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(74, 21);
            this.txt2.TabIndex = 17;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Multiselect = true;
            // 
            // cut_seting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 540);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lbl_stauts);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "cut_seting";
            this.Text = "cut_seting";
            this.Load += new System.EventHandler(this.cut_seting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lbl_stauts;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}