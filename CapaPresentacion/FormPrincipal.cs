using CapaDatos;
using CapaNegocio;
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

        private async void FormPrincipal_Load(object sender, EventArgs e)
        {
            FormularioAyudas.AjustarFormulario(this);
            this.ControlBox = false;

            lblEncabezado.Text = lblEncabezado.Text + " - " + CurrentUser.Instance.organismo;
            lblUsuario.Text = CurrentUser.Instance.nombre.ToUpper() + " " + CurrentUser.Instance.apellido.ToUpper();

            //INICIAR SQLLITE
            try
            {
                DSQLite sqlite = new DSQLite();

                sqlite.Inicializar();

                //SINCRONIZACION
                NHuella nHuella = new NHuella();

                this.Enabled = false;
                (bool estadoResponse, string errorResponse) = await nHuella.Sincronizar();
                this.Enabled = true;

                if (estadoResponse == false)
                {
                    MessageBox.Show(errorResponse, "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //FIN SINCRONIZACION 
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
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

        private void btnEgresoVisitas_Click(object sender, EventArgs e)
        {
            FormEgresoVisita formEgresoVisitas = new FormEgresoVisita();

            formEgresoVisitas.ShowDialog();
        }
    }
}
