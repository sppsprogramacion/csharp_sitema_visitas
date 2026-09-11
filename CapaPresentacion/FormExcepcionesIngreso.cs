using CapaDatos;
using CapaNegocio;
using CapaPresentacion.Validaciones.AdminVisita.ValidacionProhibicion;
using CapaPresentacion.Validaciones;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion.Reportes.AdministrarVisita;
using PdfiumViewer;
using System.IO;
using CapaPresentacion.Reportes.ExcepcionIngreso;

namespace CapaPresentacion
{
    public partial class FormExcepcionesIngreso : Form
    {
        private ErrorProvider errorProvider = new ErrorProvider();

        //cumplimentar/anular excepcion
        bool accionCumplimentarExcepcion = false;
        bool accionAnularExcepcion = false;

        public FormExcepcionesIngreso()
        {
            InitializeComponent();
        }

        private async void btnVerExcepciones_Click(object sender, EventArgs e)
        {
            this.CargarDataGridExcepciones();
        }

        private void dtgvExcepcionesIngreso_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (dtgvExcepcionesIngreso.SelectedRows.Count > 0)
                {
                    int id_excepcion_ingreso;
                    id_excepcion_ingreso = Convert.ToInt32(dtgvExcepcionesIngreso.CurrentRow.Cells["ID"].Value.ToString());

                    if (id_excepcion_ingreso > 0)
                    {
                        txtIdExcepcion.Text = id_excepcion_ingreso.ToString();
                        dtpFechaExcepcion.Value = Convert.ToDateTime(dtgvExcepcionesIngreso.CurrentRow.Cells["FechaExcepcion"].Value.ToString());
                        chkCumplimentadoExcepcion.Checked = Convert.ToBoolean(dtgvExcepcionesIngreso.CurrentRow.Cells["Cumplimentado"].Value.ToString());
                        txtOrganismoExepcion.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["Organismo"].Value.ToString();
                        txtUsuarioCargaExcepcion.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["Usuario"].Value.ToString();
                        txtVisita.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["Visita"].Value.ToString();
                        txtDniVisita.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["DniVisita"].Value.ToString();
                        txtInternoExcepcion.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["Interno"].Value.ToString();
                        txtMotivoExcepcion.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["MotivoExcepcion"].Value.ToString();
                        txtDetalleExcepcion.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["Detalle"].Value.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una excepcion.", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnCumplimentarExcepcion_Click(object sender, EventArgs e)
        {
            if (txtIdExcepcion.Text == string.Empty)
            {
                MessageBox.Show("Debe selecionar una excepción para cumplimentar", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.accionAnularExcepcion = false;
            this.accionCumplimentarExcepcion = true;
            lblDetalleCumplAnularExcepcion.Text = "DETALLE CUMPLIMENTAR:";
            this.HabilitarControlesCumplimentarAnularExcepcion(true);
        }

        private void btnAnularExcepcion_Click(object sender, EventArgs e)
        {
            if (txtIdExcepcion.Text == string.Empty)
            {
                MessageBox.Show("Debe selecionar una excepción para anular", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.accionCumplimentarExcepcion = false;
            this.accionAnularExcepcion = true;
            lblDetalleCumplAnularExcepcion.Text = "DETALLE ANULAR:";
            this.HabilitarControlesCumplimentarAnularExcepcion(true);
            chkCumplimentarExcepcion.Enabled = false;
        }


        private async void btnGuardarCumplAnularExcepcion_Click(object sender, EventArgs e)
        {
            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            var datosFormulario = new ProhibicionDatos
            {
                txtDetalleCumplAnularExcepcion = txtDetalleCumplAnularExcepcion.Text,
            };

            var validator = new ExcepcionIngresoCumplimentarAnularValidator();
            var result = validator.Validate(datosFormulario);

            if (!result.IsValid)
            {
                MessageBox.Show("Complete correctamente los campos del formulario", "Restriccion Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                foreach (var failure in result.Errors)
                {

                    Control control = Controls.Find(failure.PropertyName, true)[0];
                    errorProvider.SetError(control, failure.ErrorMessage);
                }
                return;
            }
            //fin validacion de formulario

            NExcepcionIngresoVisita nExcepcionIngreso = new NExcepcionIngresoVisita();

            
            bool respuestaOk = false;
            string mensajeRespuesta = "";
            string dataEnviar;

            //determinar cual es la accion a realizar con la prohibicion
            //usar el respectivo metodo
            if (this.accionAnularExcepcion)
            {

                var dataAnular = new
                {
                    detalle_cambio = txtDetalleCumplAnularExcepcion.Text,
                };

                dataEnviar = JsonConvert.SerializeObject(dataAnular);

                groupCumplimentarAnular.Enabled = false;
                (bool respuestaEditar, string errorResponse) = await nExcepcionIngreso.AnularExcepcion(Convert.ToInt32(txtIdExcepcion.Text), dataEnviar);
                groupCumplimentarAnular.Enabled = true;

                if (respuestaEditar)
                {
                    respuestaOk = true;
                    mensajeRespuesta = "La excepción se anuló correctamente";
                }
                else
                {
                    mensajeRespuesta = errorResponse;
                }
            }


            if (this.accionCumplimentarExcepcion)
            {
                var dataCumplimentar = new
                {
                    cumplimentado = chkCumplimentarExcepcion.Checked,
                    detalle_cambio = txtDetalleCumplAnularExcepcion.Text,
                };

                dataEnviar = JsonConvert.SerializeObject(dataCumplimentar);

                groupCumplimentarAnular.Enabled = false;
                (bool respuestaEditar, string errorResponse) = await nExcepcionIngreso.CumplimentarExcepcion(Convert.ToInt32(txtIdExcepcion.Text), dataEnviar);
                groupCumplimentarAnular.Enabled = true;

                if (respuestaEditar)
                {
                    respuestaOk = true;
                    mensajeRespuesta = "La excepción se cumplimentó correctamente";
                }
                else
                {
                    mensajeRespuesta = errorResponse;
                }
            }

            //verificar respuesta de la peticion
            if (respuestaOk)
            {

                MessageBox.Show(mensajeRespuesta, "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mensajeRespuesta = "";

                this.HabilitarControlesCumplimentarAnularExcepcion(false);
                this.CargarDataGridExcepciones();
            }
            else
            {
                MessageBox.Show(mensajeRespuesta, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //HABILITAR CONTROLES CUMPLIMENTAR/ANULAR EXCEPCION
        private void HabilitarControlesCumplimentarAnularExcepcion(bool habilitar)
        {
            //habilita controles
            chkCumplimentarExcepcion.Enabled = habilitar;
            txtDetalleCumplAnularExcepcion.Enabled = habilitar;

            //limpia
            txtDetalleCumplAnularExcepcion.Text = string.Empty;
            chkCumplimentarExcepcion.Checked = false;

            //habilita botones
            btnAnularExcepcion.Enabled = !habilitar;
            btnCumplimentarExcepcion.Enabled = !habilitar;
            btnGuardarCumplAnularExcepcion.Enabled = habilitar;
            btnCancelarCumplAnularExcepcion.Enabled = habilitar;

           
        }


        //FIN HABILITAR CONTROLES CUMPLIMENTAR/ANULAR EXCEPCION..............................


        //METODO PARA OBTENER LA LISTA DE EXCEPCIONES Y CARGARLO EN UN DATA GRID
        async private void CargarDataGridExcepciones()
        {
            NExcepcionIngresoVisita nExcepcionIngresoVisita = new NExcepcionIngresoVisita();
            (List<DExcepcionIngresoVisita> listaExcepcionesIngreso, string errorResponse) = await nExcepcionIngresoVisita.ListaExcepcionesIngresoXFecha(dtpFechaInicioExcepcion.Value.ToString("yyyy-MM-dd"), dtpFechaFinExcepcion.Value.ToString("yyyy-MM-dd"));

            if (listaExcepcionesIngreso == null)
            {
                MessageBox.Show(errorResponse, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var datosfiltrados = listaExcepcionesIngreso
                .Select(c => new
                {
                    Id = c.id_excepcion_ingreso_visita,
                    Visita = c.ciudadano.apellido + " " + c.ciudadano.nombre,
                    DniVisita = c.ciudadano.dni,
                    Interno = c.interno.apellido + " " + c.interno.nombre,
                    MotivoExcepcion = c.motivo,
                    FechaExcepcion = c.fecha_excepcion,
                    Cumplimentado = c.cumplimentado,
                    Detalle = c.detalle_excepcion,
                    Controlado = c.controlado,
                    FechaCarga = c.fecha_carga,
                    Organismo = c.organismo.organismo,
                    Usuario = c.usuario_carga.apellido + " " + c.usuario_carga.nombre

                })
                .ToList();

            dtgvExcepcionesIngreso.DataSource = datosfiltrados;

            if (listaExcepcionesIngreso.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                dtgvExcepcionesIngreso.Columns[0].Width = 80;
                dtgvExcepcionesIngreso.Columns[1].Width = 200;
                dtgvExcepcionesIngreso.Columns[2].Width = 100;
                dtgvExcepcionesIngreso.Columns[3].Width = 200;
                dtgvExcepcionesIngreso.Columns[4].Width = 150;
            }
        }




        private void btnCancelarCumplAnularExcepcion_Click(object sender, EventArgs e)
        {
            this.accionCumplimentarExcepcion = false;
            this.accionAnularExcepcion = false;
            lblDetalleCumplAnularExcepcion.Text = "DETALLE:";
            this.HabilitarControlesCumplimentarAnularExcepcion(false);
        }

        private async void btnImprimirExcepciones_Click(object sender, EventArgs e)
        {
            NExcepcionIngresoVisita nExcepcionIngresoVisita = new NExcepcionIngresoVisita();
            (List<DExcepcionIngresoVisita> listaExcepcionesIngreso, string errorResponse) = await nExcepcionIngresoVisita.ListaExcepcionesIngresoXFecha(dtpFechaInicioExcepcion.Value.ToString("yyyy-MM-dd"), dtpFechaFinExcepcion.Value.ToString("yyyy-MM-dd"));

            if (listaExcepcionesIngreso == null)
            {
                MessageBox.Show(errorResponse, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Generar PDF en memoria
            MemoryStream msOriginal = ReportesExcepcionesIngresoPDF.RepPdfExcepcionesIngreso( listaExcepcionesIngreso);

            // Clonar el stream para que PdfiumViewer pueda cerrarlo sin afectar el original
            MemoryStream ms = new MemoryStream(msOriginal.ToArray());

            PdfDocument pdfDocument = null;

            try
            {
                pdfDocument = PdfDocument.Load(ms);

                Form formVisor = new Form
                {
                    Text = "Vista previa PDF",
                    Width = 800,
                    Height = 600
                };

                PdfViewer pdfViewer = new PdfViewer
                {
                    Dock = DockStyle.Fill,
                    Document = pdfDocument
                };

                formVisor.Controls.Add(pdfViewer);

                formVisor.FormClosed += (s, args) =>
                {
                    // Liberar recursos al cerrar el visor
                    pdfViewer.Document.Dispose();
                    pdfViewer.Dispose();
                    formVisor.Dispose();
                    ms.Dispose();
                    pdfDocument = null;
                };

                formVisor.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar PDF: " + ex.Message);
                ms.Dispose();
                pdfDocument?.Dispose();
            }
        }
    }
}
