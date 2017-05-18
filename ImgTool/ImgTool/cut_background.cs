using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ImgTool
{
    public partial class cut_background : Form
    {
        FileInfo[] files;
        bool areaSwitch = true;
        int areaCount = 0;
        int areaIndex = 0;
        Dictionary<int, int> areaDic = new Dictionary<int, int>();
        int listenerIndex = 0;

        public cut_background()
        {
            InitializeComponent();

        }


        //just do it
        private void justdoit_Click(object sender, EventArgs e)
        {
            Desktop();
        }
        //select directory
        private void selectdirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath.ToString();
                DirectoryInfo folder = new DirectoryInfo(path);
                FileInfo[] files = folder.GetFiles();
                files = filter(files);

                UpdateNamegoAction(files);


                folder = new DirectoryInfo(path);
                files = folder.GetFiles();
                files = filter(files);

                goAction(files);
            }
        }
        //select files
        private void selectfile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] fileNames = openFileDialog.FileNames;
                goAction(fileNames);
            }
        }
        void Desktop()
        {
            //win7
            //string path = "C:\\Users\\Administrator\\Desktop\\images\\";
            //System.IO.Path.m

            //win8
            string path = txt_url.Text;

            path = System.IO.Path.GetFullPath("images\\");

            txt_url.Text = path;

            DirectoryInfo folder = new DirectoryInfo(path);
            files = folder.GetFiles();
            files = filter(files);
            files = sort(files);

            UpdateNamegoAction(files);


            folder = new DirectoryInfo(path);
            files = folder.GetFiles();
            files = filter(files);
            files = sort(files);


            areaCount = files.Length;
            loadDataGridView();

            goAction(files);
        }
        void UpdateNamegoAction(FileInfo[] files)
        {
            try
            {
                lbl_stauts.ForeColor = Color.Red;
                lbl_stauts.Text = "status";
                for (int i = 0; i < files.Length; i++)
                {
                    FileInfo f = files[i];
                    string newName = (i + 1) + "" + f.Extension;
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
        FileInfo[] sort(FileInfo[] files)
        {
            FileInfo[] new_files = (FileInfo[])files.Clone();
            for (int i = 0; i < files.Length; i++)
            {
                for (int j = 0; j < files.Length; j++)
                {
                    if (files[j].Name.Substring(0, files[j].Name.IndexOf('.')) == (i + 1).ToString())
                    {
                        new_files[i] = files[j];
                        continue;
                    }
                }
            }

            return new_files;
        }

        FileInfo[] filter(FileInfo[] files)
        {
            FileInfo[] new_files = new FileInfo[files.Length];
            int num = 0;
            for (int i = 0; i < files.Length; i++)
            {
                if (".jpg,.JPG,.png,.PNG,.bmp,.BMP".IndexOf(files[i].Extension) < 0)
                {
                    List<FileInfo> list = new_files.ToList();
                    list.RemoveAt(list.Count - 1);
                    new_files = list.ToArray();
                    continue;
                }
                new_files[num] = files[i];
                num++;
            }

            return new_files;
        }
        void loadDataGridView()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", Type.GetType("System.Int32"));
            DataRow row;
            for (int i = 0; i < areaCount; i++)
            {
                row = dt.NewRow();
                row["ID"] = (i + 1);
                dt.Rows.Add(row);
            }
            dgv_list.DataSource = dt;
        }
        void goAction(FileInfo[] files)
        {
            listenerIndex = 0;
            areaCount = files.Length;
            try
            {
                lbl_stauts.ForeColor = Color.Red;
                lbl_stauts.Text = "status";

                var result = "";

                if (!cbxType.Checked)
                {
                    result += "<div>\r\n";
                    for (int i = 0; i < files.Length; i++)
                    {
                        FileInfo f = files[i];
                        Bitmap bm = new Bitmap(f.FullName);
                        result += txt1.Text + f.Name + txt2.Text + bm.Height + txt3.Text;

                        #region area link
                        if (areaSwitch)
                        {
                            if (areaDic.Keys.Contains((i + 1)))
                            {
                                int linkCount = areaDic[(i + 1)];
                                result += "\r\n";
                                result += "<div style=\"margin: 0px auto;width: " + txt_pageWidth.Text + "px;position: relative; height: 100%; \">";
                                result += "\r\n";
                                switch (linkCount)
                                {
                                    case 1:
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\" " + getListener();
                                        result += "style=\"background: none; left: 0%; top: 0%; width: 100%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        break;
                                    case 2:
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\" " + getListener();
                                        result += "style=\"background: none; left: 0%; top: 0%; width: 50%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        result += "\r\n";
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\"" + getListener();
                                        result += "style=\"background: none; left:50%; top: 0%; width: 50%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        break;
                                    case 3:
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\" " + getListener();
                                        result += "style=\"background: none; left: 0%; top: 0%; width: 33%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        result += "\r\n";
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\" " + getListener();
                                        result += "style=\"background: none; left:33%; top: 0%; width: 33%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        result += "\r\n";
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\" " + getListener();
                                        result += "style=\"background: none; left:66%; top: 0%; width: 33%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        break;
                                    case 4:
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\"" + getListener();
                                        result += "style=\"background: none; left: 0%; top: 0%; width: 25%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        result += "\r\n";
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\" " + getListener();
                                        result += "style=\"background: none; left:25%; top: 0%; width: 25%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        result += "\r\n";
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\" " + getListener();
                                        result += "style=\"background: none; left:50%; top: 0%; width: 25%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        result += "\r\n";
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\"";
                                        result += "style=\"background: none; left:75%; top: 0%; width: 25%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        break;
                                    case 5:
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\" " + getListener();
                                        result += "style=\"background: none; left: 0%; top: 0%; width: 20%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        result += "\r\n";
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\" ";
                                        result += "style=\"background: none; left:20%; top: 0%; width: 20%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        result += "\r\n";
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\" " + getListener();
                                        result += "style=\"background: none; left:40%; top: 0%; width: 20%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        result += "\r\n";
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\" " + getListener();
                                        result += "style=\"background: none; left:60%; top: 0%; width: 20%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        result += "\r\n";
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\" " + getListener();
                                        result += "style=\"background: none; left:80%; top: 0%; width: 20%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        break;
                                }
                                result += "\r\n";
                                result += "</div>";
                            }
                        }
                        #endregion

                        result += "\r\n";
                        result += txt4.Text;
                        result += "\r\n";
                    }
                    result += "</div>";
                }
                else
                {
                    txt1.Text = "<div style=\"width:100%;position:relative;\">";
                    txt2.Text = "<img src=\"images/";
                    txt3.Text = "\" style=\"border:0px;display:block;width:100%;\" /></div>";

                    result += "<div style=\"margin:0px auto;max-width:640px;width:100%;\">\r\n";
                    for (int i = 0; i < files.Length; i++)
                    {
                        FileInfo f = files[i];
                        Bitmap bm = new Bitmap(f.FullName);
                        result += txt1.Text;

                        #region area link
                        if (areaSwitch)
                        {
                            if (areaDic.Keys.Contains((i + 1)))
                            {
                                int linkCount = areaDic[(i + 1)];
                                result += "\r\n";
                                switch (linkCount)
                                {
                                    case 1:
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\" " + getListener();
                                        result += "style=\"background: none; left: 0%; top: 0%; width: 100%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        break;
                                    case 2:
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\" " + getListener();
                                        result += "style=\"background: none; left: 0%; top: 0%; width: 50%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        result += "\r\n";
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\"" + getListener();
                                        result += "style=\"background: none; left:50%; top: 0%; width: 50%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        break;
                                    case 3:
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\" " + getListener();
                                        result += "style=\"background: none; left: 0%; top: 0%; width: 33%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        result += "\r\n";
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\" " + getListener();
                                        result += "style=\"background: none; left:33%; top: 0%; width: 33%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        result += "\r\n";
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\" " + getListener();
                                        result += "style=\"background: none; left:66%; top: 0%; width: 33%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        break;
                                    case 4:
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\"" + getListener();
                                        result += "style=\"background: none; left: 0%; top: 0%; width: 25%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        result += "\r\n";
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\" " + getListener();
                                        result += "style=\"background: none; left:25%; top: 0%; width: 25%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        result += "\r\n";
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\" " + getListener();
                                        result += "style=\"background: none; left:50%; top: 0%; width: 25%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        result += "\r\n";
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\"";
                                        result += "style=\"background: none; left:75%; top: 0%; width: 25%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        break;
                                    case 5:
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\" " + getListener();
                                        result += "style=\"background: none; left: 0%; top: 0%; width: 20%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        result += "\r\n";
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\" ";
                                        result += "style=\"background: none; left:20%; top: 0%; width: 20%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        result += "\r\n";
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\" " + getListener();
                                        result += "style=\"background: none; left:40%; top: 0%; width: 20%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        result += "\r\n";
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\" " + getListener();
                                        result += "style=\"background: none; left:60%; top: 0%; width: 20%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        result += "\r\n";
                                        result += "<a href=\"11111\" title=\"\" target=\"_blank\" " + getListener();
                                        result += "style=\"background: none; left:80%; top: 0%; width: 20%; height: 100%; display: block; position: absolute; cursor: pointer;\"></a>";
                                        break;
                                }
                            }
                        }
                        #endregion

                        result += txt2.Text + f.Name + txt3.Text + "\r\n";
                    }
                    result += "</div>";
                }
                lbl_stauts.Text = "success!";
                lbl_stauts.ForeColor = Color.Green;
                txt_result.Text = result;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }

        void goAction(string[] fileNames)
        {
            areaCount = fileNames.Length;
            try
            {
                lbl_stauts.ForeColor = Color.Red;
                lbl_stauts.Text = "status";

                var result = "";
                for (int i = 0; i < fileNames.Length; i++)
                {
                    Bitmap bm = new Bitmap(fileNames[i]);
                    result += txt1.Text + fileNames[i].Substring(fileNames[i].LastIndexOf("\\") + 1) + txt2.Text + bm.Height + "" + txt3.Text + "\r\n";
                }
                lbl_stauts.Text = "success!";
                lbl_stauts.ForeColor = Color.Green;
                txt_result.Text = result;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }
        string getListener()
        {
            string result = "";
            if (cbx_listener.Checked)
            {
                string type = cbxType.Checked ? "手机端" : "PC端";
                result = " onclick=\"_maq.push(['customClick','" + type + "','u_" + txt_listener_tag.Text + "','ThinkPad_u_" + txt_listener_tag.Text + "_activity_" + (++listenerIndex) + "',''])\"";
            }
            return result;
        }

        private void dgv_list_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            //判断相应的列
            if (dgv.CurrentCell.GetType().Name == "DataGridViewComboBoxCell" && dgv.CurrentCell.RowIndex != -1)
            {
                areaIndex = Convert.ToInt32(dgv.Rows[Convert.ToInt32(dgv.CurrentCell.RowIndex)].Cells["ID"].Value);
                //给这个DataGridViewComboBoxCell加上下拉事件
                (e.Control as ComboBox).SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);

            }
        }
        public void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combox = sender as ComboBox;
            //这里比较重要
            combox.Leave += new EventHandler(combox_Leave);
            try
            {
                //在这里就可以做值是否改变判断
                if (combox.SelectedItem != null)
                {
                    if (areaDic.ContainsKey(areaIndex))
                        areaDic[areaIndex] = Convert.ToInt32(combox.Text);
                    else
                        areaDic.Add(areaIndex, Convert.ToInt32(combox.Text));

                    goAction(files);
                }
                Thread.Sleep(100);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void combox_Leave(object sender, EventArgs e)
        {
            ComboBox combox = sender as ComboBox;
            //做完处理，须撤销动态事件
            combox.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
        }

        private void btn_copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txt_result.Text);
        }

        private void cut_background_Load(object sender, EventArgs e)
        {

            string path = System.IO.Path.GetFullPath("images\\");
            txt_url.Text = path;
        }

    }
}
