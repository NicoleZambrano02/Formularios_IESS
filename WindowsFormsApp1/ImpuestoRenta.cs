using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ImpuestoRenta : Form
    {
        public static string id;
        public static decimal total;
        public ImpuestoRenta()
        {
            InitializeComponent();
            CargarDatos();
            CalcularImpuesto();
            IngresarBase();
        }

        public void CargarDatos()
        {
            //total = Egresos.imp;
            LblId.Text = Ingresos.id;
        }

        public void CalcularImpuesto()
        {
            LblImpuesto.Text = Convert.ToString(total);
        }

        public void IngresarBase()
        {
            DataSet2TableAdapters.INGRESOSTableAdapter ta = new DataSet2TableAdapters.INGRESOSTableAdapter();
            DataSet2.INGRESOSDataTable dr = ta.GetValorIng(Convert.ToInt32(LblId.Text));
            DataSet2.INGRESOSRow row = (DataSet2.INGRESOSRow)dr.Rows[0];
            DataSet2TableAdapters.GASTOSTableAdapter ts = new DataSet2TableAdapters.GASTOSTableAdapter();
            DataSet2.GASTOSDataTable dr2 = ts.GetValorGastos(Convert.ToInt32(LblId.Text));
            DataSet2.GASTOSRow r = (DataSet2.GASTOSRow)dr2.Rows[0];
            textBox2.Text = (row.Valor_Ingresos.ToString());
            textBox1.Text = (r.Valor_Gastos.ToString());

            total = decimal.Parse(textBox2.Text) - decimal.Parse(textBox1.Text);
            LblImpuesto.Text = total.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet2TableAdapters.CONTRIBUYENTETableAdapter contri = new DataSet2TableAdapters.CONTRIBUYENTETableAdapter();
            contri.UpdateContribuyente(total, Convert.ToInt32(LblId.Text));
            Form106 f106 = new Form106();
            f106.Show();
            this.Hide();
        }
    }
}
