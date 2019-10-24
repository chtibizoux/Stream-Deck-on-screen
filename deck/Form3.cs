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
        bool url;
        string path;
        public Form3(string path, int i)
        {
            InitializeComponent();
            this.i = i;
            this.path = path;
            textBox1.Text = path;
            if (textBox1.Text != "" && (textBox1.Text.Contains("http://") || textBox1.Text.Contains("https://")) && textBox1.Text.Contains("."))
            {
                label1.Text = "the url is good";
                url = true;
            }
            else
            {
                label1.Text = "it's a bad url(the URL must contain 'https://' or 'http://' and a minimum of one point)";
                url = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (url == true)
            {
                form2.form3_OnClosed(i,path);
                Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && (textBox1.Text.Contains("http://") || textBox1.Text.Contains("https://")) && textBox1.Text.Contains("."))
            {
                path = textBox1.Text;
                label1.Text = "the url is good";
                url = true;
            }
            else
            {
                label1.Text = "it's a bad url(the URL must contain \"https://\" or \"http://\" and a minimum of one point)";
                url = false;
            }
        }
    }
}
