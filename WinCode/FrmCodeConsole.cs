using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Reflection;
using System.Globalization;
using Microsoft.CSharp;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Threading;

namespace WinCode
{
    public partial class FrmCodeConsole : Form
    {
        public FrmCodeConsole()
        {
            InitializeComponent();
        }
        public string run_code(string code)
        {
            StringBuilder sb = new StringBuilder();

            // 1.CSharpCodePrivoder
            CSharpCodeProvider provider = new CSharpCodeProvider();

            // 2.ICodeComplier
            ICodeCompiler compiler = provider.CreateCompiler();

            // 3.CompilerParameters
            CompilerParameters parameters = new CompilerParameters();

            parameters.ReferencedAssemblies.Add("mscorlib.dll");
            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add("System.Data.dll");
            parameters.ReferencedAssemblies.Add("System.Xml.dll");
            parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");

            parameters.ReferencedAssemblies.Add("WinCode.exe");
            parameters.ReferencedAssemblies.Add("HtmlAgilityPack.dll");
            parameters.ReferencedAssemblies.Add("MongoDB.Bson.dll");
            parameters.ReferencedAssemblies.Add("MongoDB.Driver.dll");
            parameters.GenerateExecutable = false;
            parameters.GenerateInMemory = true;

            // 4.CompilerResults
            CompilerResults result = compiler.CompileAssemblyFromSource(parameters, get_code(code));

            if (result.Errors.HasErrors)
            {
                sb.AppendLine("编译出错,错误信息如下：");
                sb.AppendLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
                foreach (CompilerError error in result.Errors)
                {
                    sb.AppendLine(error.ErrorText);
                }
                sb.AppendLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
            }
            else
            {
                try
                {
                    // reflactor and exete the method
                    Assembly assembly = result.CompiledAssembly;
                    object obj_code = assembly.CreateInstance("Code");
                    MethodInfo method = obj_code.GetType().GetMethod("OutPut");
                    string str_restul = Convert.ToString(method.Invoke(obj_code, null));
                    if (str_restul == "no input data")
                    {
                        sb.AppendLine("Please input C# code!");
                    }
                    else
                    {
                        sb.AppendLine("执行成功,执行结果如下：");
                        sb.AppendLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
                        sb.AppendLine(str_restul);
                        sb.AppendLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
                    }
                }
                catch (Exception error)
                {
                    sb.AppendLine(error.ToString());
                }
            }
            return sb.ToString();

        }

        public string get_code(string code)
        {
            if (string.IsNullOrEmpty(code)) code = "msg=\"no input data\";";
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.Data.SqlClient;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Text.RegularExpressions;");
            sb.AppendLine("using System.Collections;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.IO;");
            sb.AppendLine("using System.Net;");
            sb.AppendLine("using System.Threading;");
            sb.AppendLine("using MongoDB.Bson;");
            sb.AppendLine("using HtmlAgilityPack;");
            sb.AppendLine("using WinCode;");
            sb.AppendLine("    public class Code");
            sb.AppendLine("    {");
            sb.AppendLine("        public string msg=\"\";");
            sb.AppendLine("        public string OutPut()");
            sb.AppendLine("        {");
            sb.AppendLine("             string new_line=Environment.NewLine;");
            sb.AppendLine("             msg=\"\";");
            sb.AppendLine(code);
            sb.AppendLine("             return msg;");
            sb.AppendLine("        }");
            sb.AppendLine("        public void write(object para)");
            sb.AppendLine("        {");
            sb.AppendLine("             msg=msg+para.ToString();");  
            sb.AppendLine("        }");
            sb.AppendLine("        public void write_line(object para)");
            sb.AppendLine("        {");
            sb.AppendLine("             msg=msg+Environment.NewLine+para.ToString();");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            return sb.ToString();

        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            this.txt_result.Text = run_code(this.txt_code.Text);
        }
        private void txt_code_KeyDown(object sender, KeyEventArgs e)
        {
             
            if (e.Control && (e.KeyCode == Keys.F5))
            {
                this.txt_result.Text = run_code(this.txt_code.Text);
            }
            if (e.Control && (e.KeyCode == Keys.F6))
            {
                FrmCodeCollection frm = new FrmCodeCollection();
                frm.father = this;
                frm.Show();
            } 
            if (e.Control && (e.KeyCode == Keys.F7))
            {
                this.txt_result.Text = ""; 
            } 
            if (e.Control && (e.KeyCode == Keys.F8))
            {
                this.txt_code.Text = "";
            }
        }
        private void btn_clear_code_Click(object sender, EventArgs e)
        {
            this.txt_code.Text = "";
        }

        private void btn_clear_result_Click(object sender, EventArgs e)
        {
            this.txt_result.Text = ""; 
        }

        private void btn_save_code_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_code.Text))
            {
                MessageBox.Show("No code to save!!!");
                return;
            }
            string sql = "insert into code (date,tag,code) values('{0}','{1}','{2}')";
            sql = string.Format(sql, DateTime.Now.ToString(), this.txt_tag.Text, this.txt_code.Text);
            SQLServerHelper.exe_sql(sql);
        }

        private void btn_get_code_Click(object sender, EventArgs e)
        {
            FrmCodeCollection frm = new FrmCodeCollection();
            frm.father = this;
            frm.Show();
        }
        public void set_code(string code)
        {
            this.txt_code.Text = code;
        }

    }
}
