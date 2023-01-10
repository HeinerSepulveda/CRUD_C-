using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace DirectorioTelefonico
{
    public partial class Form1 : Form
    {
        private string connectionString
           = "Data Source=DESKTOP-76QT684\\SQLEXPRESS; Initial Catalog=directoriotelefonico;User=Heiner;Password=123456";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refrescar();
            this.dataGridView1.Columns["id"].Visible = false;
        }

        private void Refrescar()
        {
            DataDirectorio con = new DataDirectorio();
            dataGridView1.DataSource = con.Get();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataDirectorio con = new DataDirectorio();
            if (con.ProbarConexion())
            {
                MessageBox.Show("Conectado");
            }else
            {
                MessageBox.Show("no se conecto");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NuevoEmpleado frmEmpleado = new NuevoEmpleado();
            frmEmpleado.ShowDialog();
            Refrescar();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int? id = ObtenerIDTabla();
            if (id != null)
            {
                NuevoEmpleado frmEdit = new NuevoEmpleado(id);
                frmEdit.ShowDialog();
                Refrescar();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int? id = ObtenerIDTabla();
            try
            {            
                if (id != null)
                {
                    DataDirectorio con = new DataDirectorio();
                    con.Eliminar((int)id);
                    Refrescar();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrio un error al eliminar" + ex.Message);

            }
        }
        private int? ObtenerIDTabla()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());

            } catch
            {
                return null;
            }
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            using (SqlConnection cnx = new SqlConnection(connectionString))
            {

                string query = "SELECT * FROM Directorio WHERE NroDocumento LIKE @param + '%'";


                SqlCommand cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@param", textBox1.Text.Trim());

                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                dataGridView1.DataSource = dt;

            }

        }
    }
}
