using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace WinCode
{
    public partial class FrmHtmlDownloadAll : Form
    {
        public FrmHtmlDownloadAll()
        {
            InitializeComponent();
        }
        private void FrmHtmlDownloadAll_Load(object sender, EventArgs e)
        {
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string[] list = this.txt_data.Text.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in list)
            {
                down_file(item);
                sb.Append("down:" + item + Environment.NewLine);
                this.txt_result.Text = sb.ToString();
                Application.DoEvents();

            } 
        }
        //必须记录是文件或是目录，不然根据名称不能判断是文件或目录
        public void down_file(string path)
        {
            string url = string.Format(this.txt_url.Text, path);

            if (path.IndexOf("[D]") > -1)
            {
                path = path.Replace("[D]", "");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            if (path.IndexOf("[F]") > -1)
            {
                path = path.Replace("[F]", "");
                url = url.Replace("[F]", "");
                string dir = Path.GetDirectoryName(path);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                WebClient client = new WebClient();
                client.DownloadFile(url, path);
            }
        }

        private void txt_result_TextChanged(object sender, EventArgs e)
        {
            this.txt_result.SelectionStart = this.txt_result.TextLength;
            this.txt_result.ScrollToCaret(); 
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            upload_file(this.txt_url.Text, this.txt_file_path.Text); 
        }
        public void upload_file( string url,string path)
        {
            try
            { 
                WebClient client = new WebClient();
                client.UploadFile(url, "PUT", path);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            } 
        } 
        
       public void  create_file_from_string(string file_name,string content)
       {
           FileStream stream = File.Open(file_name, FileMode.OpenOrCreate);
           byte[] data = System.Text.Encoding.Default.GetBytes(content);

           BinaryWriter write = new BinaryWriter(stream);
           write.Write(data);
           write.Close();
       }

       private void txt_result_TextAlignChanged(object sender, EventArgs e)
       {
           this.txt_result.SelectionStart = this.txt_result.TextLength;
           this.txt_result.ScrollToCaret(); 
       }
    }
}
