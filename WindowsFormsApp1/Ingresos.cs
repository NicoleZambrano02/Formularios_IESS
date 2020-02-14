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
    public partial class Ingresos : Form
    {
        Comprobaciones c = new Comprobaciones();
        public Ingresos()
        {
            InitializeComponent();
        }

        public static String id;
        public static String totaling;
        private void Ingresos_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {
            id = LblId.Text;
            totaling = LblTotal.Text;
            Egresos egr = new Egresos();
            egr.Show();
            this.Hide();
        }

        private void IngresosTotales()
        {
            
            SqlConnection sqlcon = new SqlConnection(@"Data Source=FZAMBRANO-OPER;Initial Catalog=FORM102A;Integrated Security=True");
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();

                String query = "SELECT Id_Contr FROM CONTRIBUYENTE WHERE RUC_Contr = @ruc";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@ruc", txtRuc.Text);
                SqlDataReader registro = sqlcmd.ExecuteReader();

                if (registro.Read())
                {
                    LblId.Text = registro["Id_Contr"].ToString();

                }
                MessageBox.Show("INGRESOS GUARDADOS");
                
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                sqlcon.Close();
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet2TableAdapters.CONTRIBUYENTETableAdapter ta = new DataSet2TableAdapters.CONTRIBUYENTETableAdapter();
            ta.InsertContribuyente(txtRuc.Text.Trim(), TxtRazon.Text.Trim());
        }

        private void BtnIngresos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRuc.Text)|| string.IsNullOrEmpty(TxtRazon.Text))
            {
                MessageBox.Show("Debe completar la información");

                return;

            }
            IngresosTotales();
            DataSet2TableAdapters.INGRESOSTableAdapter ta = new DataSet2TableAdapters.INGRESOSTableAdapter();            
            decimal total;
            total = decimal.Parse(Txt1.Text) + decimal.Parse(txt2.Text) + decimal.Parse(txt3.Text) + decimal.Parse(txt4.Text) + decimal.Parse(txt5.Text) + decimal.Parse(txt6.Text) + decimal.Parse(txt7.Text) + decimal.Parse(txt8.Text) + decimal.Parse(txt9.Text) + decimal.Parse(txt10.Text) + decimal.Parse(txt11.Text);
            LblTotal.Text = "Ingresos Totales= $"+total.ToString();
            try
            {
                ta.InsertIngresos(total, Convert.ToInt32(LblId.Text));
            }catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
                
        }


        bool Punto = true, LetraM = true;

        private void TxtRazon_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloLetras(e);
        }

        private void txtRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void Txt1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void txt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void txt3_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void txt4_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void txt5_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void txt6_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void txt7_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void txt8_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void txt9_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void txt10_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void txt11_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void Txt1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != 46 && e.KeyChar != (char)Keys.M)
                e.Handled = true;
            else if (e.KeyChar == 46)
            {
                if (Punto)
                    Punto = false;
                else e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.M)
            {
                if (LetraM)
                    LetraM = false;
                else e.Handled = true;
            }

        }
    }
}
