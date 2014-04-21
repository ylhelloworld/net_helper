using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WinCode
{
    public partial class FrmThread : Form
    {
        Thread _thread = null;//定义线程  
        delegate void SetLabelText(string str);//定义委托，用来完成线程的赋值  

        public FrmThread()
        {
            InitializeComponent();
        }
        /// <summary>  
        /// 作为线程，不断地变换label中的值  
        /// </summary>  
        private void setNum()
        {
            for (int i = 1; i < 10; ++i)
            {
                //这么调用会失败，产生错误“线程间操作无效”  
                //this.label1.Text = i.ToString();  

                //需要用委托调用  
                SetLabelText st = new SetLabelText(setLabel);
                //用invoke 方法来达到线程间操作的目的  
                this.Invoke(st, i.ToString());
                Thread.Sleep(500);
            }
        }
        /// <summary>  
        /// 加载窗体，开始线程  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        private void FrmThread_Load(object sender, EventArgs e)
        {
            _thread = new Thread(new ThreadStart(setNum));
            _thread.Start();
        }

        /// <summary>  
        /// 窗体关闭，要结束线程  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        private void FrmThread_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_thread.IsAlive)
            {
                _thread.Abort();

            }
        }
        /// <summary>  
        /// 为label 赋值  
        /// </summary>  
        /// <param name="str"></param>  
        private void setLabel(string str)
        {
            this.label1.Text = str;
        } 
    }  
}
