using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Consulta : Form
    {
        public Consulta()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Consulta_Load(object sender, EventArgs e)
        {
            DataSet2TableAdapters.Datos_AlmacenadosTableAdapter s = new DataSet2TableAdapters.Datos_AlmacenadosTableAdapter();
            DataSet2.Datos_AlmacenadosDataTable rw = s.GetDatos();
            dataGridView1.DataSource = rw;
        }
    }
}
