using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectorioTelefonico
{
    public partial class NuevoEmpleado : Form
    {
        private int? id;
        public NuevoEmpleado(int? id=null)
        {
            InitializeComponent();
            this.id = id;
            if (this.id != null)
                CargarDatos();
        }

        private void CargarDatos()
        {
            DataDirectorio con = new DataDirectorio();
            Directorio datosDirectorio = con.Get((int)id);
            txtNombre.Text = datosDirectorio.Nombre;
            txtApellido.Text = datosDirectorio.Apellido;
            txtCedula.Text = datosDirectorio.NroDocumento;
            txtCelular.Text = datosDirectorio.Celular;
            txtCargo.Text = datosDirectorio.Cargo;
            txtOficina.Text = datosDirectorio.NroOficina.ToString();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataDirectorio con = new DataDirectorio();
            try
            {
                if (id == null)
                    con.Agregar(txtNombre.Text, txtApellido.Text, txtCedula.Text, txtCelular.Text, txtCargo.Text, int.Parse(txtOficina.Text));
                else
                    con.Editar(txtNombre.Text, txtApellido.Text, txtCedula.Text, txtCelular.Text, txtCargo.Text, int.Parse(txtOficina.Text), (int)id);
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrio un error al guardar: "+ex.Message);
            }
        }
    }
}
