using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ImgTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] fileNames = openFileDialog.FileNames;
                for (int i = 0; i < fileNames.Length; i++)
                {
                    FileInfo f = new FileInfo(fileNames[i]);
                    string newName = (i + 1) + f.Extension;
                    int index = fileNames[i].IndexOf(f.Name);
                    File.Move(fileNames[i], fileNames[i].Remove(index) + newName);
                    string newName_m = (i + 1) + "_min" + f.Extension;
                    File.Copy(fileNames[i].
                        Remove(index) + newName, fileNames[i].Remove(index) + newName_m, true);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int w = Convert.ToInt32(textBox1.Text);
                int h = Convert.ToInt32(textBox2.Text);
                string[] fileNames = openFileDialog.FileNames;
                for (int i = 0; i < fileNames.Length; i++)
                {
                    FileInfo f = new FileInfo(fileNames[i]);
                    int index = fileNames[i].IndexOf(f.Name);

                    string newName = (i + 1) + f.Extension;
                    string newUrl = fileNames[i].Remove(index) + newName;


                    File.Move(fileNames[i], fileNames[i].Remove(index) + newName);
                    string newName_m = (i + 1) + "_min" + f.Extension;
                    string newUrl_m = fileNames[i].Remove(index) + newName_m;


                    //File.Copy(fileNames[i].Remove(index) + newName, newUrl, true);
                    if (File.Exists(newUrl_m))
                    {
                        File.Delete(newUrl_m);
                    }
                    else
                    {
                        Bitmap bm = new Bitmap(newUrl);
                        if (bm.Width > w && bm.Height > h)
                        {
                            if (bm.Width > bm.Height)
                            {
                                int ww = Convert.ToInt32(bm.Width * h / bm.Height);
                                int hh = h;
                                //Graphics g= System.Drawing.Graphics.FromImage(bm);
                                //g.Save();
                                Bitmap bm1 = new Bitmap(bm, ww, hh);
                                bm1.Save(newUrl_m, ImageFormat.Jpeg);
                            }
                            else
                            {
                                int ww = w;
                                int hh = Convert.ToInt32(bm.Height * w / bm.Width);
                                Bitmap bm1 = new Bitmap(bm, ww, hh);
                                bm1.Save(newUrl_m, ImageFormat.Jpeg);
                            }
                        }
                    }
                }
                MessageBox.Show("success");
            }
        }
        //固定宽度
        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int w = Convert.ToInt32(textBox1.Text);
                int h = Convert.ToInt32(textBox2.Text);
                string[] fileNames = openFileDialog.FileNames;
                for (int i = 0; i < fileNames.Length; i++)
                {
                    FileInfo f = new FileInfo(fileNames[i]);
                    int index = fileNames[i].IndexOf(f.Name);

                    string newName = (i + 1) + f.Extension;
                    string newUrl = fileNames[i].Remove(index) + newName;

                    File.Move(fileNames[i], fileNames[i].Remove(index) + newName);
                    string newName_m = (i + 1) + "_" + w + f.Extension;
                    string newUrl_m = fileNames[i].Remove(index) + newName_m;


                    //File.Copy(fileNames[i].Remove(index) + newName, newUrl, true);
                    if (File.Exists(newUrl_m))
                    {
                        File.Delete(newUrl_m);
                    }
                    else
                    {
                        Bitmap bm = new Bitmap(newUrl);
                        if (bm.Width > w && bm.Height > h)
                        {
                            int ww = w;
                            int hh = Convert.ToInt32(bm.Height * w / bm.Width);
                            Bitmap bm1 = new Bitmap(bm, ww, hh);
                            bm1.Save(newUrl_m, ImageFormat.Jpeg);
                        }
                    }
                }
                MessageBox.Show("success");
            }
        }
        //share自动
        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] fileNames = openFileDialog.FileNames;
                for (int i = 0; i < fileNames.Length; i++)
                {
                    FileInfo f = new FileInfo(fileNames[i]);
                    string newName = (i + 1) + ".jpg";
                    int index = fileNames[i].IndexOf(f.Name);
                    File.Move(fileNames[i], fileNames[i].Remove(index) + newName);
                    string newName_m = (i + 1) + "_min.jpg";
                    string newName_230 = (i + 1) + "_230.jpg";

                    //File.Copy(fileNames[i].Remove(index) + newName, fileNames[i].Remove(index) + newName_m, true);
                    //File.Copy(fileNames[i].Remove(index) + newName, fileNames[i].Remove(index) + newName_230, true);



                    if (File.Exists(fileNames[i].Remove(index) + newName_m))
                    {
                        File.Delete(fileNames[i].Remove(index) + newName_m);
                    }
                    else
                    {
                        string sss = fileNames[i].Remove(index) + newName;
                        Bitmap bm = new Bitmap(fileNames[i].Remove(index) + newName);
                        int ww = 128;
                        int hh = Convert.ToInt32(bm.Height * 128 / bm.Width);
                        Bitmap bm1 = new Bitmap(bm, ww, hh);
                        bm1.Save(fileNames[i].Remove(index) + newName_m, ImageFormat.Jpeg);
                    }

                    if (File.Exists(fileNames[i].Remove(index) + newName_230))
                    {
                        File.Delete(fileNames[i].Remove(index) + newName_230);
                    }
                    else
                    {
                        Bitmap bm = new Bitmap(fileNames[i].Remove(index) + newName);
                        int ww = 230;
                        int hh = Convert.ToInt32(bm.Height * 230 / bm.Width);
                        Bitmap bm1 = new Bitmap(bm, ww, hh);
                        bm1.Save(fileNames[i].Remove(index) + newName_230, ImageFormat.Jpeg);
                    }

                }
                MessageBox.Show("success");
            }
        }

    }
}
