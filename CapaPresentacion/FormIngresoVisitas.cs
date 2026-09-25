using CapaDatos;
using CapaNegocio;
using CapaPresentacion.Biometria;
using CapaPresentacion.FuncionesGenerales;
using CapaPresentacion.Reportes.IngresoVisistas;
using CapaPresentacion.Validaciones;
using Newtonsoft.Json;
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
    public partial class FormIngresoVisitas : Form
    {
        private ErrorProvider errorProvider = new ErrorProvider();

        //para huellas
        private FingerprintCapture fingerprintCapture;
        private FingerprintProcessor fingerprintProcessor;
        private FingerprintTemplate fingerprintTemplate;
        private FingerprintVerifier fingerprintVerifier;
        private DPFP.Template templateRegistrado;
        private byte[] templateBytesRegistrado;
        private bool modoVerificacion = false;
        private bool modoIdentificacion = false;
        private string huellaBase64Global = "";

        public FormIngresoVisitas()
        {
            InitializeComponent();

            fingerprintCapture = new FingerprintCapture();
            fingerprintProcessor = new FingerprintProcessor();
            fingerprintTemplate = new FingerprintTemplate();
            fingerprintVerifier = new FingerprintVerifier();

            fingerprintCapture.FingerDetected += FingerprintCapture_FingerDetected;
            fingerprintCapture.FingerRemoved += FingerprintCapture_FingerRemoved;
            fingerprintCapture.CaptureError += FingerprintCapture_CaptureError;
            fingerprintCapture.SampleCaptured += FingerprintCapture_SampleCaptured;
        }

        private void FormIngresoVisitas_Load(object sender, EventArgs e)
        {
            //// Ajustar el tamaño del formulario            
            FormularioAyudas.AjustarFormulario(this);

            txtDniBuscar.Focus();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            NEntradaSalida nEntradaSalida = new NEntradaSalida();


            //BUSCAR CIUDADANO CON EL DNI
            this.Enabled = false;
            int dniCiudadano = Convert.ToInt32(txtDniBuscar.Text);
            (DCiudadanoIngreso dCiudadanoIngresoResponse, string errorResponse) = await nEntradaSalida.BuscarCiudadanoIngresoXDni(dniCiudadano);

            if (dCiudadanoIngresoResponse == null)
            {
                MessageBox.Show(errorResponse, "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Enabled = true;

                return;
            }

            //CARGAR DATOS DEL CIUDADANO
            txtIdCiudadano.Text = dCiudadanoIngresoResponse.ciudadanoResponse.id_ciudadano.ToString();

            lblApellidoNombre.Text = dCiudadanoIngresoResponse.ciudadanoResponse.apellido + " " + dCiudadanoIngresoResponse.ciudadanoResponse.nombre;
            txtDni.Text = dCiudadanoIngresoResponse.ciudadanoResponse.dni.ToString();
            txtSexo.Text = dCiudadanoIngresoResponse.ciudadanoResponse.sexo;
            txtFechaNacimiento.Text = dCiudadanoIngresoResponse.ciudadanoResponse.fecha_nacimiento.ToShortDateString();
            txtNacionalidad.Text = dCiudadanoIngresoResponse.ciudadanoResponse.nacionalidad;
            txtPais.Text = dCiudadanoIngresoResponse.ciudadanoResponse.pais;
            txtProvincia.Text = dCiudadanoIngresoResponse.ciudadanoResponse.provincia;
            txtDepartamento.Text = dCiudadanoIngresoResponse.ciudadanoResponse.departamento;
            txtMunicipio.Text = dCiudadanoIngresoResponse.ciudadanoResponse.municipio;
            txtCiudad.Text = dCiudadanoIngresoResponse.ciudadanoResponse.ciudad;
            txtBarrio.Text = dCiudadanoIngresoResponse.ciudadanoResponse.barrio;
            txtDireccion.Text = dCiudadanoIngresoResponse.ciudadanoResponse.direccion;
            txtFechaAlta.Text = dCiudadanoIngresoResponse.ciudadanoResponse.fecha_alta.ToShortDateString();
            picFotoVisita.Load(dCiudadanoIngresoResponse.ciudadanoResponse.foto);

            this.Enabled = true;


            this.ControlTieneDiscapacidad(dCiudadanoIngresoResponse.ciudadanoResponse.tiene_discapacidad, dCiudadanoIngresoResponse.ciudadanoResponse.discapacidad_detalle);
            this.ControlEdad(dCiudadanoIngresoResponse.ciudadanoResponse.edad);

            //Cargar Huellas
            this.bloquearChecksHuellasCargadas(dCiudadanoIngresoResponse.huellasCiudadanoResponse);

            //Cargar menores
            var datosfiltradosMenores = dCiudadanoIngresoResponse.menoresResponse
                .Select(c => new
                {
                    Id = c.id_ciudadano,
                    ApellidoNombre = c.apellido + " " + c.nombre,
                    Dni = c.dni,
                    Edad = c.edad,

                })
                .ToList();
            dtgMenores.DataSource = datosfiltradosMenores;

            // Agregar columna para seleccionar
            if (!dtgMenores.Columns.Contains("Seleccionar"))
            {
                DataGridViewCheckBoxColumn columnaSeleccion =
                    new DataGridViewCheckBoxColumn();

                columnaSeleccion.Name = "Seleccionar";
                columnaSeleccion.HeaderText = "";
                columnaSeleccion.Width = 35;
                columnaSeleccion.ReadOnly = false;

                dtgMenores.Columns.Insert(0, columnaSeleccion);

            }
            //dimensionar columnas
            if (dCiudadanoIngresoResponse.menoresResponse.Count > 0)
            {
                dtgMenores.Columns["Id"].Width = 40;
                dtgMenores.Columns["ApellidoNombre"].Width = 300;
                dtgMenores.Columns["Dni"].Width = 80;
                dtgMenores.Columns["Edad"].Width = 50;
            }


            //Cargar internos
            var datosfiltradosInternos = dCiudadanoIngresoResponse.internosResponse
                .Select(c => new
                {
                    Id = c.id_interno,
                    ApellidoNombre = c.apellido_nombre,
                    Parentesco = c.parentesco,
                    Prontuario = c.prontuario

                })
                .ToList();
            dtgInternos.DataSource = datosfiltradosInternos;

            if (dCiudadanoIngresoResponse.internosResponse.Count > 0)
            {
                dtgInternos.Columns[0].Width = 40;
                dtgInternos.Columns[1].Width = 300;
                dtgInternos.Columns[2].Width = 80;
                dtgInternos.Columns[3].Width = 60;
            }

            //control de prohibicion
            if (!dCiudadanoIngresoResponse.ciudadanoResponse.esta_prohibido)
            {
                lblEstadoCiudadano.Text = "SIN RESTRICCIONES DE INGRESO";
                lblEstadoCiudadano.ForeColor = Color.LimeGreen;
                

                //habilitar verificacion de huella
                picHuella.Visible = true;
                fingerprintCapture.Start();
                modoVerificacion = true;
                lblLectorEstado.Text = "Coloque el dedo para verificar.";
                lblLectorDedo.Text = "Esperando huella...";
                
            }
            else
            {
                lblEstadoCiudadano.Text = "TIENE RESTRICCIONES PARA EL INGRESO";
                lblEstadoCiudadano.ForeColor = Color.Red;
            }

            txtDniBuscar.Enabled = false;
            btnBuscar.Enabled = false;
        }

        //BOTON GUARDAR ENTRADA SALIDA
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            List<int> idsMenoresSeleccionados = new List<int>();

            foreach (DataGridViewRow row in dtgMenores.Rows)
            {
                bool seleccionado = Convert.ToBoolean(
                    row.Cells["Seleccionar"].Value ?? false
                );

                if (seleccionado)
                {
                    int id = Convert.ToInt32(row.Cells["Id"].Value);
                    idsMenoresSeleccionados.Add(id);
                }
            }

            foreach (int id in idsMenoresSeleccionados)
            {

                MessageBox.Show("id: " + id);
            }

            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            //var datosFormulario = new ProhibicionDatos
            //{
            //    txtIdCiudadano = txtIdCiudadano.Text,
            //    txtDisposicion = txtDisposicion.Text,
            //    txtDetalle = txtDetalle.Text,
            //    dtpFechaInicio = dtpFechaInicio.Value,
            //    dtpFechaFin = dtpFechaFin.Value,
            //};

            //var validator = new ProhibicionNuevaValidator();
            //var result = validator.Validate(datosFormulario);

            //if (!result.IsValid)
            //{
            //    MessageBox.Show("Complete correctamente los campos del formulario", "Restriccion Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    foreach (var failure in result.Errors)
            //    {

            //        Control control = Controls.Find(failure.PropertyName, true)[0];
            //        errorProvider.SetError(control, failure.ErrorMessage);
            //    }
            //    return;
            //}

            //enviar datos si son correctos
            int idInterno = 0;

            if (dtgInternos.SelectedRows.Count > 0)
            {
                idInterno = Convert.ToInt32(dtgInternos.CurrentRow.Cells["Id"].Value.ToString());

                if (idInterno == 0)
                {

                    MessageBox.Show("Debe seleccionar un interno.", "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var data = new
            {
                interno_id = idInterno,
                ciudadano_id = Convert.ToInt32(txtIdCiudadano.Text),
                casillero = txtCasillero.Text,
                listaIdsMenores = idsMenoresSeleccionados
            };

            string dataEntrada = JsonConvert.SerializeObject(data);

            NEntradaSalida nEntradaSalida = new NEntradaSalida();
            this.Enabled = false;
            (DEntradaSalidaIngresoPPResponse dataEntradaSalidaResponse, string errorResponse) = await nEntradaSalida.CrearEntradaSalida(dataEntrada);
            this.Enabled = true;

            if (dataEntradaSalidaResponse != null)
            {
                MessageBox.Show("La entrada del ciudadano se guardo correctamente", "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // Generar PDF en memoria
                MemoryStream msOriginal = ReportesIngresoVisitas.RepPdfFichaIngreso(dataEntradaSalidaResponse);

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
                        try
                        {
                            using (PrintDocument printDocument = pdfDocument.CreatePrintDocument())
                            {
                                printDocument.Print();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(
                                "Error al imprimir la ficha: " + ex.Message,
                                "Sistema Visitas",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
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
                MessageBox.Show(errorResponse, "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }
        //FIN BOTON GUARDAR ENTRADA SALIDA
        //----------------------------------------------------------------

        //BOTON CANCELAR
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            lblEstadoCiudadano.Text = "Restriccion";
            lblEstadoCiudadano.ForeColor = Color.LimeGreen;

            txtIdCiudadano.Text = string.Empty;
            lblApellidoNombre.Text = "Apellido y nombre";
            txtDni.Text = string.Empty;
            txtSexo.Text = string.Empty;
            txtFechaNacimiento.Text = string.Empty;
            txtNacionalidad.Text = string.Empty;
            txtPais.Text = string.Empty;
            txtProvincia.Text = string.Empty;
            txtDepartamento.Text = string.Empty;
            txtMunicipio.Text = string.Empty;
            txtCiudad.Text = string.Empty;
            txtBarrio.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtFechaAlta.Text = string.Empty;
            picFotoVisita.Image = null;

            lblCategoriaEdad.Text = "Categoria - edad";
            lblDiscapacidad.Text = "Discapacidad";

            opPD.BackColor = Color.White;
            opID.BackColor = Color.White;
            opMAD.BackColor = Color.White;
            opAD.BackColor = Color.White;
            opMED.BackColor = Color.White;
            opPI.BackColor = Color.White;
            opII.BackColor = Color.White;
            opMAI.BackColor = Color.White;
            opAI.BackColor = Color.White;
            opMEI.BackColor = Color.White;

            picHuella.Visible = false;
            fingerprintCapture.Stop();
            lblLectorEstado.Text = "Lector detenido";
            lblLectorDedo.Text = "Detenido...";


            dtgMenores.DataSource = null;
            dtgInternos.DataSource = null;
            txtCasillero.Text = string.Empty;
            gboxDatosParaIngreso.Enabled = false;

            btnBuscar.Enabled = true;
            txtDniBuscar.Enabled = true;
            txtDniBuscar.Text = string.Empty;
            txtDniBuscar.Focus();

        }
        //FIN BOTON CANCELAR
        //--------------------------------------------------------------------------


        //CONTROL EDAD
        private void ControlEdad(int edad)
        {
            if (edad < 18)
            {
                lblCategoriaEdad.Text = "Edad: " + edad + " años. Es MENOR.";
            }
            else
            {
                lblCategoriaEdad.Text = "Edad: " + edad + " años. Es ADULTO.";
            }
        }
        //FIN CONTROL EDAD
        //-------------------------------------------------------------------------------------

        //CONTROL TIENE DISCAPACIDAD
        private void ControlTieneDiscapacidad(bool tieneDiscapacidad, string detalle)
        {
            if (tieneDiscapacidad)
            {
                lblDiscapacidad.Text = "TIENE DISCAPACIDAD. " + detalle;
                //lblDiscapacidad.ForeColor = Color.DarkOrange;
            }
            else
            {
                lblDiscapacidad.Text = "NO TIENE DISCAPACIDAD";
                lblDiscapacidad.ForeColor = Color.White;
                lblDiscapacidad.Text = "";
            }
        }
        //FIN CONTROL TIENE DISCAPACIDAD
        //------------------------------------------------------------------------------------------

        //BLOQUEAR DEDOS SEGUN HUELLA CARGADA
        private void bloquearChecksHuellasCargadas(List<DHuella> listaHuellas)
        {

            if (listaHuellas.Count == 0)
            {
                MessageBox.Show("El ciudadano no posee huellas registradas.", "Sistema Visistas", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            foreach (DHuella huella in listaHuellas)
            {
                int dedo = Convert.ToInt32(huella.dedo_id);
                //MessageBox.Show (dedo);
                switch (dedo)
                {
                    case 1:
                        opPD.BackColor = Color.Green;
                        break;

                    case 2:

                        opID.BackColor = Color.Green;
                        break;

                    case 3:

                        opMAD.BackColor = Color.Green;
                        break;

                    case 4:

                        opAD.BackColor = Color.Green;
                        break;

                    case 5:

                        opMED.BackColor = Color.Green;
                        break;

                    case 6:

                        opPI.BackColor = Color.Green;
                        break;

                    case 7:

                        opII.BackColor = Color.Green;
                        break;

                    case 8:

                        opMAI.BackColor = Color.Green;
                        break;

                    case 9:

                        opAI.BackColor = Color.Green;
                        break;

                    case 10:

                        opMEI.BackColor = Color.Green;
                        break;

                    default:
                        break;


                }//fin switch
            }//fin foreach
        }//FIN PRocedimiento para bloquear dedos segun huella cargada
         //BLOQUEAR DEDOS SEGUN HUELLA CARGADA
         //----------------------------------------------------------------------------------------


        //------------------------------------------------------
        //METODOS PARA HUELLAS
        //------------------------------------------------------
        #region Metodos para huellas
        private void FingerprintCapture_FingerDetected(
            object sender,
            EventArgs e)
        {
            EjecutarEnUI(() =>
            {
                lblLectorDedo.Text = "Dedo detectado";
            });
        }

        private void FingerprintCapture_FingerRemoved(
            object sender,
            EventArgs e)
        {
            EjecutarEnUI(() =>
            {
                lblLectorDedo.Text = "Dedo retirado";
            });
        }

        private void FingerprintCapture_CaptureError(object sender, string e)
        {
            MessageBox.Show(
                e,
                "Error del lector",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }


        //METODO DE CAPTURA PARA REGISTRO Y/O VERIFICACION
        private async void FingerprintCapture_SampleCaptured(object sender, FingerprintCapture.SampleEventArgs e)
        {
            try
            {
                DPFP.FeatureSet featureSet;

                bool resultado;

                //if (modoVerificacion || modoIdentificacion)
                //{
                    resultado = fingerprintProcessor.ExtractFeaturesForVerification(
                            e.Sample,
                            out featureSet
                        );
                //}
                //else
                //{
                //    resultado = fingerprintProcessor.ExtractFeaturesForEnrollment(
                //            e.Sample,
                //            out featureSet
                //        );
                //}

                if (!resultado)
                {
                    EjecutarEnUI(() =>
                    {
                        lblLectorEstado.Text = "La calidad de la huella no es suficiente.";
                    });

                    return;
                }


                // -----------------------------------------
                // MODO VERIFICACIÓN
                // -----------------------------------------

                if (modoVerificacion)
                {
                    NHuella nHuellas = new NHuella();
                    //MessageBox.Show("Verificando huella", "Sistema Visistas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    (List<DHuella> listaHuellas, string errorResponse) = await nHuellas.RetornarListaXCiudadano(Convert.ToInt32(txtIdCiudadano.Text));
                    if (listaHuellas == null)
                    {
                        MessageBox.Show(errorResponse, "Sistema Visistas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (listaHuellas.Count == 0)
                    {
                        MessageBox.Show("El ciudadano no posee huellas registradas.", "Sistema Visistas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return;
                    }

                    foreach (DHuella huella in listaHuellas)
                    {
                        try
                        {
                            byte[] templateBytes = Convert.FromBase64String(huella.huella);

                            DPFP.Template template = fingerprintTemplate.LoadTemplate(templateBytes);

                            if (fingerprintVerifier.Verify(featureSet, template))
                            {
                                EjecutarEnUI(() =>
                                {
                                    gboxDatosParaIngreso.Enabled = true;
                                    
                                });

                                MessageBox.Show($"IDENTIDAD VERIFICADA.\nPuede continuar con el ingreso.", "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            // registrar error si quieres
                            continue;
                        }
                    }

                    MessageBox.Show("NO SE VERIFICO LA IDENTIDAD CON ESTA HUELLA. \n\nSE PROCEDE A IDENTIFICACION", "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    modoIdentificacion = true;
                    //return;

                }

                // -----------------------------------------
                // MODO IDENTIFICACION
                // -----------------------------------------

                if (modoIdentificacion)
                {
                    //MessageBox.Show("Identificando huella", "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DSQLite sqlite = new DSQLite();

                    sqlite.Inicializar();
                    //MessageBox.Show("Inicializado", "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //SINCRONIZACION
                    NHuella nHuella = new NHuella();

                    EjecutarEnUI(() =>
                    {
                        this.Enabled = false;
                        
                    });
                    //MessageBox.Show("inicia sincronizacion", "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    (bool estadoResponse, string errorResponse) = await nHuella.Sincronizar();
                    EjecutarEnUI(() =>
                    {
                        this.Enabled = true;

                    });

                    //MessageBox.Show("sincronizado", "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (estadoResponse == false)
                    {
                        MessageBox.Show(errorResponse, "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    

                    //FIN SINCRONIZACION 

                    List<DHuellaLocal> listaHuellas = sqlite.ObtenerTodasLasHuellas();

                    if (listaHuellas.Count == 0)
                    {
                        MessageBox.Show("No hay huellas registradas.", "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }

                    //MessageBox.Show("Ya tengo las huellas de sqlite", "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    foreach (DHuellaLocal huella in listaHuellas)
                    {
                        try
                        {

                            //byte[] templateBytes = Convert.FromBase64String(huella.huella);

                            //DPFP.Template template = fingerprintTemplate.LoadTemplate(templateBytes);
                            DPFP.Template template = fingerprintTemplate.LoadTemplate(huella.huella);

                            if (fingerprintVerifier.Verify(featureSet, template))
                            {
                                MessageBox.Show($"COINCIDENCIA ENCONCTRADA CON ESTA HUELLA", "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                FormHuellasEncontrado formHuellasEncontrado = new FormHuellasEncontrado(huella.ciudadano_id);
                                formHuellasEncontrado.ShowDialog();
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            // registrar error si quieres
                            continue;
                        }
                    }

                    MessageBox.Show("NO SE ENCONTRO COINCIDENCIA DE ESTA HUELLA", "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;

                }


                // -----------------------------------------
                // MODO REGISTRO - formacion del template
                // -----------------------------------------

                bool agregada = fingerprintTemplate.AddFeatures(featureSet);

                uint faltantes = fingerprintTemplate.FeaturesNeeded;


                EjecutarEnUI(() =>
                {
                    if (fingerprintTemplate.IsComplete)
                    {
                        // Obtiene el Template original.
                        templateRegistrado = fingerprintTemplate.GetTemplate();

                        // Lo convierte a bytes.
                        templateBytesRegistrado = fingerprintTemplate.GetTemplateBytes();
                        string huellaBase64 = Convert.ToBase64String(templateBytesRegistrado);
                        this.huellaBase64Global = huellaBase64;

                        EjecutarEnUI(() =>
                        {
                            if (huellaBase64 != "")
                            {
                                lblLectorEstado.Text = "Template generado correctamente.";
                            }
                            else
                            {
                                lblLectorEstado.Text = "Error al construir el Template.";
                            }
                        });

                    }
                    else if (agregada)
                    {
                        lblLectorEstado.Text = "Captura correcta. Faltan " + faltantes + " muestras.";
                    }
                    else
                    {
                        lblLectorEstado.Text = "La muestra no fue aceptada. " + "Coloque nuevamente el dedo.";
                    }
                });
            }
            catch (Exception ex)
            {
                EjecutarEnUI(() =>
                {
                    lblLectorEstado.Text = "Error: " + ex.Message;
                });
            }
        }
        //FIN METODO DE CAPTURA PARA REGISTRO Y/O VERIFICACION
        //-------------------------------------------------------------------------------------------


        protected override void OnFormClosing(
            FormClosingEventArgs e)
        {
            fingerprintCapture?.Dispose();

            base.OnFormClosing(e);
        }

        //PERMITE ACCEDER A CONTROLES DESDE UN METODO QUE NO PODRIA
        private void EjecutarEnUI(Action accion)
        {
            if (InvokeRequired)
            {
                Invoke(accion);
                return;
            }

            accion();
        }

        private void gboxVisita_Enter(object sender, EventArgs e)
        {

        }

        #endregion Metodos para huellas
        //----------------------------------------------------------
        //FIN METODOS PARA HUELLAS
        //----------------------------------------------------------
    }
}
