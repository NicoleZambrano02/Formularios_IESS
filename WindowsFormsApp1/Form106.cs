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
    public partial class Form106 : Form
    {
        Comprobaciones c = new Comprobaciones();
        public Form106()
        {
            InitializeComponent();
            Cargar();
        }

        private void Id()
        {
            LblId.Text = Ingresos.id;
        }

        private void Cargar()
        {
            Id();
            DataSet2TableAdapters.CONTRIBUYENTETableAdapter s = new DataSet2TableAdapters.CONTRIBUYENTETableAdapter();
            DataSet2.CONTRIBUYENTEDataTable rw = s.GetContri(Convert.ToInt32(LblId.Text));
            DataSet2.CONTRIBUYENTERow row = (DataSet2.CONTRIBUYENTERow)rw.Rows[0];           
            TxtRazon.Text = (row.RazonSocial_Contr.ToString());
            txtRuc.Text = (row.RUC_Contr.ToString());
            textBox4.Text = "#467829D982";
            textBox5.Text = (row.SaldoTrib_Contr.ToString());        
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloLetras(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloLetras(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloLetras(e);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataSet2TableAdapters.F106TableAdapter s = new DataSet2TableAdapters.F106TableAdapter();
            
            try
            {
                s.InsertPago(textBox7.Text.Trim(), textBox1.Text.Trim(), textBox3.Text.Trim(), textBox2.Text.Trim(), textBox6.Text.Trim(), decimal.Parse(textBox10.Text.Trim()), Convert.ToInt32(LblId.Text.Trim()));
                MessageBox.Show("Pago Efectuado");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal pago;
            pago = decimal.Parse(textBox5.Text) + decimal.Parse(textBox8.Text) + decimal.Parse(textBox9.Text);
            textBox10.Text = pago.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Consulta c = new Consulta();
            c.Show();
           
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
