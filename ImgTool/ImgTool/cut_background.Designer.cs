namespace ImgTool
{
    partial class cut_background
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
            this.txt2 = new System.Windows.Forms.TextBox();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.lbl_stauts = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txt_result = new System.Windows.Forms.TextBox();
            this.txt_url = new System.Windows.Forms.TextBox();
            this.txt3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxType = new System.Windows.Forms.CheckBox();
            this.dgv_list = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COUNT = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txt4 = new System.Windows.Forms.TextBox();
            this.txt_pageWidth = new System.Windows.Forms.TextBox();
            this.cbx_listener = new System.Windows.Forms.CheckBox();
            this.btn_copy = new System.Windows.Forms.Button();
            this.txt_listener_tag = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_list)).BeginInit();
            this.SuspendLayout();
            // 
            // txt2
            // 
            this.txt2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt2.Location = new System.Drawing.Point(12, 48);
            this.txt2.Multiline = true;
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(402, 26);
            this.txt2.TabIndex = 23;
            this.txt2.Text = ") top center no-repeat;width:100%;height: ";
            // 
            // txt1
            // 
            this.txt1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt1.Location = new System.Drawing.Point(12, 12);
            this.txt1.Multiline = true;
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(617, 26);
            this.txt1.TabIndex = 22;
            this.txt1.Text = "<div style=\"background: url(images/";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(229, 116);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(195, 43);
            this.button3.TabIndex = 21;
            this.button3.Text = "select directory\n";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.selectdirectory_Click);
            // 
            // lbl_stauts
            // 
            this.lbl_stauts.AutoSize = true;
            this.lbl_stauts.Location = new System.Drawing.Point(705, 18);
            this.lbl_stauts.Name = "lbl_stauts";
            this.lbl_stauts.Size = new System.Drawing.Size(65, 12);
            this.lbl_stauts.TabIndex = 20;
            this.lbl_stauts.Text = "lbl_stauts";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(438, 116);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(191, 43);
            this.button2.TabIndex = 19;
            this.button2.Text = "select files";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.selectfile_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 43);
            this.button1.TabIndex = 18;
            this.button1.Text = "just do it!(Desktop)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.justdoit_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Multiselect = true;
            // 
            // txt_result
            // 
            this.txt_result.Location = new System.Drawing.Point(12, 174);
            this.txt_result.Multiline = true;
            this.txt_result.Name = "txt_result";
            this.txt_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_result.Size = new System.Drawing.Size(617, 510);
            this.txt_result.TabIndex = 24;
            // 
            // txt_url
            // 
            this.txt_url.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_url.Location = new System.Drawing.Point(12, 84);
            this.txt_url.Multiline = true;
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(354, 26);
            this.txt_url.TabIndex = 25;
            // 
            // txt3
            // 
            this.txt3.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt3.Location = new System.Drawing.Point(464, 48);
            this.txt3.Multiline = true;
            this.txt3.Name = "txt3";
            this.txt3.Size = new System.Drawing.Size(63, 26);
            this.txt3.TabIndex = 26;
            this.txt3.Text = "px ;\">";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(647, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 27;
            this.label1.Text = "num";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(435, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "num";
            // 
            // cbxType
            // 
            this.cbxType.AutoSize = true;
            this.cbxType.Location = new System.Drawing.Point(392, 89);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(60, 16);
            this.cbxType.TabIndex = 29;
            this.cbxType.Text = "Mobile";
            this.cbxType.UseVisualStyleBackColor = true;
            // 
            // dgv_list
            // 
            this.dgv_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.COUNT});
            this.dgv_list.Location = new System.Drawing.Point(649, 174);
            this.dgv_list.Name = "dgv_list";
            this.dgv_list.RowTemplate.Height = 23;
            this.dgv_list.Size = new System.Drawing.Size(200, 510);
            this.dgv_list.TabIndex = 30;
            this.dgv_list.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_list_EditingControlShowing);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 50;
            // 
            // COUNT
            // 
            this.COUNT.HeaderText = "COUNT";
            this.COUNT.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.COUNT.Name = "COUNT";
            // 
            // txt4
            // 
            this.txt4.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt4.Location = new System.Drawing.Point(552, 48);
            this.txt4.Multiline = true;
            this.txt4.Name = "txt4";
            this.txt4.Size = new System.Drawing.Size(77, 26);
            this.txt4.TabIndex = 31;
            this.txt4.Text = "</div>";
            // 
            // txt_pageWidth
            // 
            this.txt_pageWidth.Location = new System.Drawing.Point(649, 87);
            this.txt_pageWidth.Name = "txt_pageWidth";
            this.txt_pageWidth.Size = new System.Drawing.Size(83, 21);
            this.txt_pageWidth.TabIndex = 32;
            this.txt_pageWidth.Text = "1000";
            this.txt_pageWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbx_listener
            // 
            this.cbx_listener.AutoSize = true;
            this.cbx_listener.Location = new System.Drawing.Point(462, 89);
            this.cbx_listener.Name = "cbx_listener";
            this.cbx_listener.Size = new System.Drawing.Size(72, 16);
            this.cbx_listener.TabIndex = 33;
            this.cbx_listener.Text = "Listener";
            this.cbx_listener.UseVisualStyleBackColor = true;
            // 
            // btn_copy
            // 
            this.btn_copy.Location = new System.Drawing.Point(649, 116);
            this.btn_copy.Name = "btn_copy";
            this.btn_copy.Size = new System.Drawing.Size(200, 43);
            this.btn_copy.TabIndex = 34;
            this.btn_copy.Text = "copy text";
            this.btn_copy.UseVisualStyleBackColor = true;
            this.btn_copy.Click += new System.EventHandler(this.btn_copy_Click);
            // 
            // txt_listener_tag
            // 
            this.txt_listener_tag.Location = new System.Drawing.Point(540, 87);
            this.txt_listener_tag.Name = "txt_listener_tag";
            this.txt_listener_tag.Size = new System.Drawing.Size(83, 21);
            this.txt_listener_tag.TabIndex = 35;
            this.txt_listener_tag.Text = "TagName";
            this.txt_listener_tag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cut_background
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 696);
            this.Controls.Add(this.txt_listener_tag);
            this.Controls.Add(this.btn_copy);
            this.Controls.Add(this.cbx_listener);
            this.Controls.Add(this.txt_pageWidth);
            this.Controls.Add(this.txt4);
            this.Controls.Add(this.dgv_list);
            this.Controls.Add(this.cbxType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt3);
            this.Controls.Add(this.txt_url);
            this.Controls.Add(this.txt_result);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lbl_stauts);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "cut_background";
            this.Text = "cut_background";
            this.Load += new System.EventHandler(this.cut_background_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_list)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lbl_stauts;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txt_result;
        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.TextBox txt3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbxType;
        private System.Windows.Forms.DataGridView dgv_list;
        private System.Windows.Forms.TextBox txt4;
        private System.Windows.Forms.TextBox txt_pageWidth;
        private System.Windows.Forms.CheckBox cbx_listener;
        private System.Windows.Forms.Button btn_copy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewComboBoxColumn COUNT;
        private System.Windows.Forms.TextBox txt_listener_tag;
    }
}