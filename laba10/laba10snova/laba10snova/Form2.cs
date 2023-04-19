using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba10snova
{
    public partial class Form2 : Form
    {
        int bruh = 0;
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            bruh = trackBar1.Value;
            label1.Text = bruh.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Context.array = new int[bruh];
            for (int i = 0; i < bruh; i++)
                Context.array[i] = rnd.Next(0, 1000);
            this.Close();
        }
    }
}
