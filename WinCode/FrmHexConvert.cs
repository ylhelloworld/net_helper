using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 
    public partial class FrmHexConvert : Form
    {
        public FrmHexConvert()
        {
            InitializeComponent();
        }

        private void btn_convert_Click(object sender, EventArgs e)
        {
            this.txt_to.Text = "";
            char[] values = this.txt_from.Text.ToCharArray();
            foreach (char letter in values)
            {
                // Get the integral value of the character.
                int value = Convert.ToInt32(letter);
                // Convert the decimal value to a hexadecimal value in string form.
                string hexOutput = String.Format("{0:X}", value);
                this.txt_to.Text += hexOutput;
            }
        }
    } 
