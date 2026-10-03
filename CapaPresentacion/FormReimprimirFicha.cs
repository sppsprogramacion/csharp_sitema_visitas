using CapaDatos;
using CapaNegocio;
using CapaPresentacion.ClasesEspeciales;
using CapaPresentacion.FuncionesGenerales;
using CapaPresentacion.Reportes.IngresoVisistas;
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
using System.Windows.Forms.VisualStyles;

namespace CapaPresentacion
{
    public partial class FormReimprimirFicha : Form
    {
        //Variables globales
        DEntradaSalidaControl entradaSalidaControlGlobal = null;


        public FormReimprimirFicha()
        {
            InitializeComponent();
        }

        private async void FormReimprimirFicha_Load(object sender, EventArgs e)
        {
            //// Ajustar el tamaño del formulario            
            FormularioAyudas.AjustarFormulario(this);

            NEntradaSalida nEntradaSalida = new NEntradaSalida();
            (List<DEntradaSalidaConsulta> listaEntradaSalidaResponse, string errorResponse) = await nEntradaSalida.ListaEntradaSalidaActuales();

            if (listaEntradaSalidaResponse == null)
            {
                MessageBox.Show(errorResponse, "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //var datosfiltrados = listaEntradaSalidaResponse
            //    .Select(c => new
            //    {
            //        Id = c.id_entrada_salida,
            //        NumFicha = c.numero_ficha,
            //        Visita = c.nombre_visita,
            //        DniVisita = c.dni_visita,
            //        Interno = c.nombre_interno,
            //        Parentesco = c.parentesco,
            //        FechaIngreso = c.fecha_registro,
            //        HoraIngreso = c.hora_registro,
            //        HoraEgreso = c.hora_egreso,
            //        Organismo = c.organismo,

            //    })
            //    .ToList();

            //dtgIngresos.DataSource = listaEntradaSalidaResponse;

            var datosfiltrados = listaEntradaSalidaResponse
                .Select(c => new DEntradaSalidaGrilla
                {
                    Id = c.id_entrada_salida,
                    NumFicha = c.numero_ficha,
                    Visita = c.nombre_visita,
                    DniVisita = c.dni_visita,
                    Interno = c.nombre_interno,
                    Parentesco = c.parentesco,
                    FechaIngreso = c.fecha_registro,
                    HoraIngreso = c.hora_registro,
                    HoraEgreso = c.hora_egreso,
                    Organismo = c.organismo,
                })
                .ToList();

            var listaOrdenable = new SortableBindingList<DEntradaSalidaGrilla>(datosfiltrados);

            BindingSource bs = new BindingSource();
            bs.DataSource = listaOrdenable;
            dtgIngresos.DataSource = bs;


            if (listaEntradaSalidaResponse.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                dtgIngresos.Columns[0].Width = 50;
                dtgIngresos.Columns[1].Width = 80;
                dtgIngresos.Columns[2].Width = 250;
                dtgIngresos.Columns[4].Width = 250;
                dtgIngresos.Columns[5].Width = 100;
                dtgIngresos.Columns[6].Width = 100;
                dtgIngresos.Columns[7].Width = 100;
                dtgIngresos.Columns[8].Width = 100;
                dtgIngresos.Columns[9].Width = 180;
            }

        }

        private void btnReimprimirFicha_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdIngreso.Text.Trim()))
            {
                MessageBox.Show("Debe sleccionar una visita de la lista de Entradas.", "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!chkAdulto.Checked){
                MessageBox.Show("No se puede reimprimir la ficha de un menor. \nDebe reimprimir la ficha del adulto con el que ingreso.", "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.entradaSalidaControlGlobal != null)
            {

                // Generar PDF en memoria
                MemoryStream msOriginal = ReportesIngresoVisitas.RepPdfFichaIngresoReimpresion(this.entradaSalidaControlGlobal);

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

                    // Imprimir automáticamente al abrir el visor
                    formVisor.Shown += (s, args) =>
                    {
                        formVisor.StartPosition = FormStartPosition.CenterScreen;
                        try
                        {
                            using (PrintDocument printDocument = pdfDocument.CreatePrintDocument())
                            {
                                printDocument.Print();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al imprimir la ficha: " + ex.Message, "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };

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
                    MessageBox.Show("Error al mostrar la ficha: " + ex.Message);
                    ms.Dispose();
                    pdfDocument?.Dispose();
                }
                //this.HabilitarControles(false);
                //this.LimpiarControles();



                //cargar lista de ciudadanos en datagrid
                //this.CargarDataGridProhibiciones();
            }
            else
            {
                MessageBox.Show("No selecciono una entrada", "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void dtgIngresos_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;


                if (dtgIngresos.SelectedRows.Count > 0)
                {

                    var valorNumFicha = dtgIngresos.CurrentRow?.Cells["NumFicha"].Value;

                    if (valorNumFicha == null || !int.TryParse(valorNumFicha.ToString(), out int numeroFichaAux))
                    {
                        
                        return;
                    }


                    if (numeroFichaAux > 0)
                    {
                        this.CargarEntrada(numeroFichaAux);

                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una entrada.", "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }


        //CARGAR ENTRADA
        private async void CargarEntrada(int numeroficha)
        {
            NEntradaSalida nEntradaSalida = new NEntradaSalida();

            this.Enabled = false;
            (DEntradaSalidaControl dEntradaSalidaResponse, string errorResponse) = await nEntradaSalida.BuscarCiudadanoIngresoControlXFicha(numeroficha);
            this.Enabled = true;

            if (dEntradaSalidaResponse == null)
            {
                MessageBox.Show(errorResponse, "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            this.entradaSalidaControlGlobal = dEntradaSalidaResponse;

            //CARGAR DATOS DEL CIUDADANO
            lblApellidoNombre.Text = dEntradaSalidaResponse.nombre_visita;
            picFotoVisita.Load(dEntradaSalidaResponse.foto_visita);
            txtDni.Text = dEntradaSalidaResponse.dni_visita.ToString();
            txtSexo.Text = dEntradaSalidaResponse.sexo_visita;
            txtFechaNacimiento.Text = dEntradaSalidaResponse.fecha_nacimiento_visita.ToShortDateString();
            txtEdad.Text = dEntradaSalidaResponse.edad_visita.ToString();

            //CARGAR DATOS DE INGRESO
            txtNumeroFicha.Text = dEntradaSalidaResponse.numero_ficha.ToString();
            txtIdIngreso.Text = dEntradaSalidaResponse.id_entrada_salida.ToString();
            txtParentesco.Text = dEntradaSalidaResponse.parentesco;
            txtIntrno.Text = dEntradaSalidaResponse.nombre_interno;
            txtMenores.Text = dEntradaSalidaResponse.menores;
            txtCasillero.Text = dEntradaSalidaResponse.casillero;
            txtFechaIngreso.Text = dEntradaSalidaResponse.fecha_registro.ToShortDateString();
            txtHoraIngreso.Text = dEntradaSalidaResponse.hora_registro;
            txtHoraEgreso.Text = dEntradaSalidaResponse.hora_egreso;
            txtOrganismo.Text = dEntradaSalidaResponse.organismo;

            

            if (dEntradaSalidaResponse.edad_visita < 18)
            {
                lblCategoriaEdad.Text = "Edad: " + dEntradaSalidaResponse.edad_visita + " años. Es MENOR.";
                chkAdulto.Checked = false;
            }
            else
            {
                lblCategoriaEdad.Text = "Edad: " + dEntradaSalidaResponse.edad_visita + " años. Es ADULTO.";
                chkAdulto.Checked = true;
            }

            if (dEntradaSalidaResponse.tiene_discapacidad)
            {
                lblDiscapacidad.Text = "TIENE DISCAPACIDAD. " + dEntradaSalidaResponse.discapacidad_detalle;
            }
            else
            {
                lblDiscapacidad.Text = "NO TIENE DISCAPACIDAD";
                lblDiscapacidad.ForeColor = Color.White;
            }
            
        }

        //FIN CARGAR ENTRADA
        //----------------------------------------------------------------------------------
       
    }
}
