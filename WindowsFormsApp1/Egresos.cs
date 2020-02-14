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
    public partial class Egresos : Form
    {
        Comprobaciones c = new Comprobaciones();
        public Egresos()
        {
            InitializeComponent();
        }

        public static string id;
        //public static decimal imp=1;

        private void CargarId()
        {
            LblId.Text = Ingresos.id;
            LblTotalIngreso.Text = Ingresos.totaling;            
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            id = LblId.Text;            
            ImpuestoRenta impuesto = new ImpuestoRenta();
            impuesto.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarId();
            DataSet2TableAdapters.GASTOSTableAdapter ta = new DataSet2TableAdapters.GASTOSTableAdapter();
            decimal total;
            total = decimal.Parse(textBox1.Text) + decimal.Parse(textBox2.Text) + decimal.Parse(textBox3.Text) + decimal.Parse(textBox4.Text) + decimal.Parse(textBox5.Text) + decimal.Parse(textBox6.Text) + decimal.Parse(textBox7.Text) + decimal.Parse(textBox8.Text) + decimal.Parse(textBox9.Text) + decimal.Parse(textBox10.Text) + decimal.Parse(textBox11.Text);
            MessageBox.Show("Gastos Guardados");
            LblTotal.Text = "Gastos Totales= $" + total.ToString();
            ta.InsertGastos(Convert.ToInt32(LblId.Text),total);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }
    }
}
