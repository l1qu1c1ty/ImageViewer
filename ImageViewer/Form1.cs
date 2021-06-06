using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
        }

        int i = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                i++;
                if (i == imageList1.Images.Count)
                {
                    i = 0;
                }
                pictureBox1.Image = imageList1.Images[i];
            }
            catch {}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                i--;
                if (i < 0)
                    i = 0;
                pictureBox1.Image = imageList1.Images[i];
            }

            catch {}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            file.Filter = "Media File(*.jpg,*.png,*.jpeg)|*.jpg;*.png;*.jpeg";
            file.Multiselect = true;
            file.InitialDirectory = Application.StartupPath;
            file.Title = "Select File";

            if (file.ShowDialog(this) == DialogResult.OK)
            {
                for (int i = 0; i < file.FileNames.Count(); i++)
                {
                    imageList1.Images.Add(Image.FromFile(file.FileNames[i]));
                }
                button1.Enabled = true;
                button2.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = imageList1.Images[i];
                i++;
                if (i == imageList1.Images.Count)
                {
                    i = 0;
                    timer1.Stop();
                }
            }
            catch {}  
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }       
    }
}