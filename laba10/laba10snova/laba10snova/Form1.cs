using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba10snova
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BubbleSort.form = this;
        }
       
        int count = 0;
        Context context;
        string path = "";

        public void AddItemsRichTextBox(int first = -1, int second = -1)
        {
            richTextBox1.AppendText("");
            foreach (var item in Context.array)
            {
                if (item == first || item == second)
                {
                    richTextBox1.Text += '[' + Convert.ToString(item) + ']' + " ";
                }
                else
                {
                    richTextBox1.Text += Convert.ToString(item) + " ";
                }
            }
            richTextBox1.Text += "\n";
            count++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Context.array != null)
            {
                if (radioButton1.Checked == true)
                {
                    this.context = new Context(new BubbleSort());
                    context.ExecuteAlgorithm();
                   
                }
                if (radioButton2.Checked == true)
                {
                    this.context = new Context(new Porazrad());
                    context.ExecuteAlgorithm();
                    
                }

            }


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void таблицаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Analys.AnalisSorts.Count > 0)
            {
                Analysis analysis = new Analysis();
                analysis.Show();
            }
            else
            {
                MessageBox.Show("Анализировать нечего");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 Value = new Form2();
            Value.ShowDialog();
            richTextBox1.Clear();
            richTextBox1.Text += "Начальный массив:\n";
            foreach (int i in Context.array) richTextBox1.Text += i + " ";
            richTextBox1.Text += "\n";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
        }
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;

                path = openFileDialog1.FileName;
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    try
                    {
                        string str = sr.ReadToEnd();
                        Context.array = str.Split(' ').Select(i => Convert.ToInt32(i)).ToArray();
                        richTextBox1.Text = "\tИсходный массив\n [";
                        foreach (int i in Context.array)
                            richTextBox1.Text += i + " ";
                        richTextBox1.Text += "]\n";
                    }
                    catch { MessageBox.Show("Ошибка"); }

                }
            }
        }
    private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            return;
        path = saveFileDialog1.FileName;
        System.IO.File.WriteAllText(path, IOFile.content);

    }
    }
}
