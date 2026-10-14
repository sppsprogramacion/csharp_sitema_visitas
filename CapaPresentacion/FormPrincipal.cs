using CapaDatos;
using CapaNegocio;
using CapaPresentacion.FuncionesGenerales;
using CapaPresentacion.Reportes.IngresoVisistas;
using CommonCache;
using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
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

            //OBTENER COMPUTO
            DComputoVisitas computo = await this.ObtenerComputo();
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

        private void btnReimprimirFicha_Click(object sender, EventArgs e)
        {
            FormReimprimirFicha formReimprimirFicha = new FormReimprimirFicha();

            formReimprimirFicha.ShowDialog();
        }

        private async void btnActualizarComputo_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            DComputoVisitas computo = await this.ObtenerComputo();
            this.Enabled = true;
        }


        
        private async void btnImprimirComputo_Click(object sender, EventArgs e)
        {
            btnImprimirComputo.Enabled = false;

            try
            {
                // Obtener los datos del cómputo
                DComputoVisitas computo = await this.ObtenerComputo();

                if (computo == null)
                {
                    MessageBox.Show(
                        "No se pudo imprimir el cómputo",
                        "Sistema Visitas",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // Generar PDF directamente en formato vertical
                // de 80 mm de ancho, SIN ROTACIÓN
                using (MemoryStream msOriginal =
                    ReportesIngresoVisitas.RepPdfComputoVisitas(computo))
                {
                    // Clonar el MemoryStream para PdfiumViewer
                    using (MemoryStream ms =
                        new MemoryStream(msOriginal.ToArray()))
                    {
                        using (PdfDocument pdfDocument = PdfDocument.Load(ms))
                        {
                            using (Form formVisor = new Form())
                            {
                                formVisor.Text = "Vista previa - Cómputo de Visitas";
                                formVisor.Width = 850;
                                formVisor.Height = 600;
                                formVisor.StartPosition =
                                    FormStartPosition.CenterParent;

                                PdfViewer pdfViewer = new PdfViewer
                                {
                                    Dock = DockStyle.Fill,
                                    Document = pdfDocument
                                };

                                formVisor.Controls.Add(pdfViewer);

                                // IMPRESIÓN AUTOMÁTICA
                                // Descomentar cuando quieras imprimir
                                /*
                                formVisor.Shown += (s, args) =>
                                {
                                    try
                                    {
                                        using (PrintDocument printDocument =
                                            pdfDocument.CreatePrintDocument())
                                        {
                                            printDocument.DefaultPageSettings.Landscape = false;

                                            // Papel térmico 80 x 75 mm
                                            printDocument.DefaultPageSettings.PaperSize =
                                                new System.Drawing.Printing.PaperSize(
                                                    "Ticket 80x75",
                                                    315,
                                                    295
                                                );

                                            printDocument.PrintController =
                                                new StandardPrintController();

                                            printDocument.Print();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(
                                            "Error al imprimir el cómputo: " + ex.Message,
                                            "Sistema Visitas",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error
                                        );
                                    }
                                };
                                */

                                // Mostrar vista previa
                                formVisor.ShowDialog(this);

                                // Desvincular el documento antes de liberarlo
                                pdfViewer.Document = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al mostrar el cómputo: " + ex.Message,
                    "Sistema Visitas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                btnImprimirComputo.Enabled = true;
            }
        }

        //OBTENER COMPUTO
        private async Task<DComputoVisitas> ObtenerComputo()
        {
            NEntradaSalida nEntradaSalida = new NEntradaSalida();

            (List<DEntradaSalidaComputo> listaComputo, string errorResponse) =
                await nEntradaSalida.ListaComputoXOrganismo();

            if (listaComputo == null)
            {
                MessageBox.Show(errorResponse ?? "No se pudo obtener el cómputo", "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return null;
            }

            // Obtener cantidad por categoría y sexo
            int ObtenerCantidad(string categoria, int sexoId)
            {
                return listaComputo
                    .Where(x => x.categoria == categoria &&
                                x.sexo_id == sexoId)
                    .Sum(x => x.cantidad);
            }

            // Crear objeto con los datos
            DComputoVisitas datos = new DComputoVisitas
            {

                AdultosMasculinos = ObtenerCantidad("ADULTO", 2),
                AdultosFemeninos = ObtenerCantidad("ADULTO", 1),
                AdultosNoBinarios = ObtenerCantidad("ADULTO", 3),

                MenoresMasculinos = ObtenerCantidad("MENOR", 2),
                MenoresFemeninos = ObtenerCantidad("MENOR", 1),
                MenoresNoBinarios = ObtenerCantidad("MENOR", 3)
            };

            // Calcular totales
            int totalAdultos = datos.AdultosMasculinos + datos.AdultosFemeninos + datos.AdultosNoBinarios;

            int totalMenores = datos.MenoresMasculinos + datos.MenoresFemeninos + datos.MenoresNoBinarios;

            int totalMasculinos = datos.AdultosMasculinos + datos.MenoresMasculinos;

            int totalFemeninos = datos.AdultosFemeninos + datos.MenoresFemeninos;

            int totalNoBinarios = datos.AdultosNoBinarios + datos.MenoresNoBinarios;

            int totalGeneral = totalAdultos + totalMenores;

            // Actualizar los Label
            lblAdultosMasculinos.Text = datos.AdultosMasculinos.ToString();
            lblAdultosFemeninas.Text = datos.AdultosFemeninos.ToString();
            lblAdultosNoBinarios.Text = datos.AdultosNoBinarios.ToString();
            lblAdultosTotales.Text = totalAdultos.ToString();

            lblMenoresMasculinos.Text = datos.MenoresMasculinos.ToString();
            lblMenoresFemeninas.Text = datos.MenoresFemeninos.ToString();
            lblMenoresNoBinario.Text = datos.MenoresNoBinarios.ToString();
            lblMenoresTotales.Text = totalMenores.ToString();

            lblTotalesMasculinos.Text = totalMasculinos.ToString();
            lblTotalesFemeninas.Text = totalFemeninos.ToString();
            lblTotalesNoBinario.Text = totalNoBinarios.ToString();

            lblTotalTotales.Text = totalGeneral.ToString();

            return datos;
        }

        //FIN OBTENER COMPUTO
        //-------------------------------------------------------------------------

        private async void button1_Click(object sender, EventArgs e)
        {
            btnImprimirComputo.Enabled = false;

            try
            {
                DComputoVisitas computo = await this.ObtenerComputo();

                if (computo == null)
                {
                    MessageBox.Show(
                        "No se pudo obtener el cómputo",
                        "Sistema Visitas",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                using (MemoryStream msOriginal =
                    ReportesIngresoVisitas.RepPdfComputoVisitas(computo))
                using (MemoryStream ms =
                    new MemoryStream(msOriginal.ToArray()))
                using (PdfDocument pdfDocument = PdfDocument.Load(ms))
                using (Form formVisor = new Form())
                {
                    formVisor.Text = "Vista previa - Cómputo de Visitas";
                    formVisor.Width = 850;
                    formVisor.Height = 600;
                    formVisor.StartPosition = FormStartPosition.CenterParent;

                    // Panel inferior
                    Panel panelBotones = new Panel
                    {
                        Dock = DockStyle.Bottom,
                        Height = 70
                    };

                    // Botón imprimir
                    Button btnImprimir = new Button
                    {
                        Text = "Imprimir",
                        Width = 200,
                        Height = 50,
                        Left = 300,
                        Top = 10
                    };

                    btnImprimir.Click += (s, args) =>
                    {
                        try
                        {
                            using (PrintDocument printDocument =
                                pdfDocument.CreatePrintDocument())
                            {
                                // Orientación vertical
                                printDocument.DefaultPageSettings.Landscape = false;

                                // Tamaño del papel 80 x 75 mm
                                printDocument.DefaultPageSettings.PaperSize =
                                    new System.Drawing.Printing.PaperSize(
                                        "Ticket 80x75",
                                        315,
                                        295
                                    );

                                printDocument.PrintController =
                                    new StandardPrintController();

                                // Seleccionar impresora
                                using (PrintDialog dialogo = new PrintDialog())
                                {
                                    dialogo.Document = printDocument;
                                    dialogo.UseEXDialog = true;

                                    if (dialogo.ShowDialog(formVisor) == DialogResult.OK)
                                    {
                                        printDocument.Print();
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(
                                "Error al imprimir: " + ex.Message,
                                "Sistema Visitas",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                        }
                    };

                    panelBotones.Controls.Add(btnImprimir);

                    // Visor PDF
                    PdfViewer pdfViewer = new PdfViewer
                    {
                        Dock = DockStyle.Fill,
                        Document = pdfDocument,
                        ShowToolbar = false
                    };

                    formVisor.Controls.Add(pdfViewer);
                    formVisor.Controls.Add(panelBotones);

                    // Mostrar formulario
                    formVisor.ShowDialog(this);

                    pdfViewer.Document = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al mostrar el cómputo: " + ex.Message,
                    "Sistema Visitas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                btnImprimirComputo.Enabled = true;
            }
        }
    }
}
