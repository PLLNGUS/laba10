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
    public partial class Analysis : Form
    {
        
            int i = 0;
            public Analysis()
            {
                InitializeComponent();
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.RowCount = Analys.AnalisSorts.Count;
                dataGridView1.ColumnCount = 5;
            }
        
        private void AnalysisForma_Load(object sender, EventArgs e)
        {


            dataGridView1.Columns[0].HeaderText = "Метод сортировки";
            dataGridView1.Columns[1].HeaderText = "Кол-во иттераций";
            dataGridView1.Columns[2].HeaderText = "Кол-во перестановок";
            dataGridView1.Columns[3].HeaderText = "Кол-во элементов";
            dataGridView1.Columns[4].HeaderText = "Время";
            dataGridView1.Update();
            foreach (AnalisSort f in Analys.AnalisSorts)
            {
                dataGridView1.Rows[i].Cells[0].Value = f.name;
                dataGridView1.Rows[i].Cells[1].Value = f.iteration;
                dataGridView1.Rows[i].Cells[2].Value = f.permutation;
                dataGridView1.Rows[i].Cells[3].Value = f.size;
                dataGridView1.Rows[i].Cells[4].Value = f.time;
                i++;
            }

        }


    }
    
    
}
