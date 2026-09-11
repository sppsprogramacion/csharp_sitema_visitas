using CapaDatos;
using CapaNegocio;
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
    public partial class FormHistorialProhibicion : Form
    {
        //VARIABLES GLOBALES
        int idProhibicionGlobal=0;

        public FormHistorialProhibicion(int idProhibicion)
        {
            idProhibicionGlobal = idProhibicion;

            InitializeComponent();
        }

        private async void FormHistorialProhibicion_Load(object sender, EventArgs e)
        {
            if (idProhibicionGlobal == 0)
            {
                MessageBox.Show("No se obtuvo el identificador de esta prohibicion.","Restriccion Visitas",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            NBitacoraProhibicionVisita nBitacoraProhibicionVisita = new NBitacoraProhibicionVisita();
            List<DBitacoraProhibicionVisita> listaBitacoraProhibicionesVisita = new List<DBitacoraProhibicionVisita>();
            listaBitacoraProhibicionesVisita = await nBitacoraProhibicionVisita.RetornarListaBitacoraProhibicionesVisita(idProhibicionGlobal);

            var datosfiltrados = listaBitacoraProhibicionesVisita
                .Select(c => new
                {
                    Id = c.id_bitacora_prohibicion_visita,
                    Disposicion = c.disposicion,
                    Detalle = c.detalle,
                    FechaInicio = c.fecha_inicio,
                    FechaFin = c.fecha_fin,
                    Vigente = c.vigente,
                    Anulado = c.anulado,
                    Motivo = c.motivo,
                    DetalleMotivo = c.detalle_motivo,
                    FechaCambio = c.fecha_cambio,
                    Organismo = c.organismo.organismo,
                    Usuario = c.usuario.apellido + " " + c.usuario.nombre

                })
                .ToList();

            dtgvHistorialProhibicion.DataSource = datosfiltrados;
        }

        private void dtgvHistorialProhibicion_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (dtgvHistorialProhibicion.SelectedRows.Count > 0)
                {
                    int idRegHistorial;
                    idRegHistorial = Convert.ToInt32(dtgvHistorialProhibicion.CurrentRow.Cells["Id"].Value.ToString());

                    if (idRegHistorial > 0)
                    {
                        //cargar datos de datagrid a controles
                        txtId.Text = idRegHistorial.ToString();
                        txtDisposicion.Text = dtgvHistorialProhibicion.CurrentRow.Cells["Disposicion"].Value.ToString();
                        txtDEtalle.Text = dtgvHistorialProhibicion.CurrentRow.Cells["Detalle"].Value.ToString();
                        txtFechaInicio.Text = Convert.ToDateTime(dtgvHistorialProhibicion.CurrentRow.Cells["FechaInicio"].Value).ToString("dd/MM/yyyy");
                        txtFechaFin.Text = Convert.ToDateTime(dtgvHistorialProhibicion.CurrentRow.Cells["FechaFin"].Value).ToString("dd/MM/yyyy");
                        chkVigente.Checked = Convert.ToBoolean(dtgvHistorialProhibicion.CurrentRow.Cells["Vigente"].Value.ToString());
                        chkAnulado.Checked = Convert.ToBoolean(dtgvHistorialProhibicion.CurrentRow.Cells["Anulado"].Value.ToString());
                        txtFechaCambio.Text = Convert.ToDateTime(dtgvHistorialProhibicion.CurrentRow.Cells["FechaCambio"].Value).ToString("dd/MM/yyyy");
                        txtMotivo.Text = dtgvHistorialProhibicion.CurrentRow.Cells["Motivo"].Value.ToString();
                        txtDetalleMotivo.Text = dtgvHistorialProhibicion.CurrentRow.Cells["DetalleMotivo"].Value.ToString();
                        txtOrganismo.Text = dtgvHistorialProhibicion.CurrentRow.Cells["Organismo"].Value.ToString();
                        txtUsuario.Text = dtgvHistorialProhibicion.CurrentRow.Cells["Usuario"].Value.ToString();

                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una excepcion.", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}
