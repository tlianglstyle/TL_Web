using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImgTool
{
    public partial class cut_seting : Form
    {
        public cut_seting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Desktop();
        }

        private void lbl_stauts_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] fileNames = openFileDialog.FileNames;
                goAction(fileNames);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath.ToString();
                DirectoryInfo folder = new DirectoryInfo(path);
                FileInfo[] files = folder.GetFiles();
                goAction(files);
            }
        }
        void Desktop()
        {
            string path = "C:\\Users\\Administrator\\Desktop\\images\\";
            DirectoryInfo folder = new DirectoryInfo(path);
            FileInfo[] files = folder.GetFiles();
            goAction(files);
        }
        void goAction(FileInfo[] files)
        {
            try
            {
                lbl_stauts.ForeColor = Color.Red;
                lbl_stauts.Text = "status";
                for (int i = 0; i < files.Length; i++)
                {
                    FileInfo f = files[i];
                    string newName = txt1.Text + (i + 1) + "" + txt2.Text + f.Extension;
                    int index = f.FullName.IndexOf(f.Name);
                    File.Move(f.FullName, f.FullName.Remove(index) + newName);
                }
                lbl_stauts.Text = "success!";
                lbl_stauts.ForeColor = Color.Green;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }
        void goAction(string[] fileNames)
        {
            try
            {
                lbl_stauts.ForeColor = Color.Red;
                lbl_stauts.Text = "status";
                for (int i = 0; i < fileNames.Length; i++)
                {
                    FileInfo f = new FileInfo(fileNames[i]);
                    string newName = txt1.Text + (i + 1) + "" + txt2.Text + f.Extension;
                    int index = fileNames[i].IndexOf(f.Name);
                    File.Move(fileNames[i],  fileNames[i].Remove(index)  + newName);
                }
                lbl_stauts.Text = "success!";
                lbl_stauts.ForeColor = Color.Green;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }

        private void cut_seting_Load(object sender, EventArgs e)
        {

        }
    }
}
