using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using EasyHook;

namespace WinCode
{
    public partial class FrmHook : Form
    {
        public FrmHook()
        {  
            InitializeComponent();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            //IntPtr定义
            IntPtr HWND_BROADCAST = new IntPtr(0xffff);
            IntPtr HWND_TOP = new IntPtr(0);
            IntPtr HWND_BOTTOM = new IntPtr(1);
            IntPtr HWND_TOPMOST = new IntPtr(-1);
            IntPtr HWND_NOTOPMOST = new IntPtr(-2);
            IntPtr HWND_MESSAGE = new IntPtr(-3);

            //Process process = Process.Start(this.txt_path.Text);
            WriteTextBox();  
        }
        public void WriteTextBox()
        {
            string txt = "Hello Hook!";
            //获得窗体句柄
            IntPtr winHwnd = WinAPIHelper.FindWindow("WindowsForms10.Window.8.app.0.378734a", "MyWindow");
            //获得窗体上TextBox句柄
            IntPtr txtHwnd = WinAPIHelper.FindWindowEx(winHwnd, IntPtr.Zero, "WindowsForms10.EDIT.app.0.378734a", "");
            //向TextBox中写入内容
            WinAPIHelper.BringWindowToTop(winHwnd);
            IntPtr result = WinAPIHelper.SendMessage(txtHwnd, 0x000C, (IntPtr)txt.Length, txt);
            IntPtr result1 = WinAPIHelper.SendMessage(txtHwnd, 0x000C, (IntPtr)0, txt);   
        }

        private void btn_key_Click(object sender, EventArgs e)
        {
            //更改大小写
            WinAPIHelper.keybd_event(20, 0, 0, 0); 
        }

        private void btn_file_Click(object sender, EventArgs e)
        {
            File.Open("c:/test.txt", FileMode.OpenOrCreate);
        }
    }
}
