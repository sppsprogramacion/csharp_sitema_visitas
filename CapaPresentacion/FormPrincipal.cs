using CapaPresentacion.FuncionesGenerales;
using CommonCache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnVerVisitas_Click(object sender, EventArgs e)
        {
            FormVisitas formVisitas = new FormVisitas();

            formVisitas.ShowDialog();
        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnProhibicionesAnticipadas_Click(object sender, EventArgs e)
        {
            FormProhibicionesAnticipadas formProhibicionesAnticipadas = new FormProhibicionesAnticipadas();

            formProhibicionesAnticipadas.ShowDialog();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            FormularioAyudas.AjustarFormulario(this);
            this.ControlBox = false;

            lblEncabezado.Text = lblEncabezado.Text + " - " + CurrentUser.Instance.organismo;
            lblUsuario.Text = CurrentUser.Instance.nombre.ToUpper() + " " + CurrentUser.Instance.apellido.ToUpper();
        }

        private void btnExcepcionesIngreso_Click(object sender, EventArgs e)
        {
            FormExcepcionesIngreso formExepcionesIngreso = new FormExcepcionesIngreso();

            formExepcionesIngreso.ShowDialog();
        }

        private void btnIngresoVisita_Click(object sender, EventArgs e)
        {
            FormIngresoVisitas formIngresoVisitas = new FormIngresoVisitas();

            formIngresoVisitas.ShowDialog();
        }
    }
}
