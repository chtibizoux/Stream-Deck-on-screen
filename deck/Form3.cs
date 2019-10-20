using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deck
{
    public partial class Form3 : Form
    {
        public Form2 form2;
        int i;
        bool icon, url;
        public Form3(string path,int i, bool icon)
        {
            InitializeComponent();
            this.i = i;
            this.icon = icon;
            textBox1.Text = path;
            form2 = (Form2)ParentForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (url == true)
            {
                form2.form3_OnClosed(i, icon);
                Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                url = true;
            }
            else
            {
                url = false;
            }
        }
    }
}
