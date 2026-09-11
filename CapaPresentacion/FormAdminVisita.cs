using CapaDatos;
using CapaNegocio;
using CapaPresentacion.FuncionesGenerales;
using CapaPresentacion.Reportes;
using CapaPresentacion.Reportes.AdministrarVisita;
using CapaPresentacion.Validaciones;
using CapaPresentacion.Validaciones.AdminVisita.EdicionProhibicion;
using CapaPresentacion.Validaciones.AdminVisita.ValidacionProhibicion;
using Newtonsoft.Json;
using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace CapaPresentacion
{
    public partial class FormAdminVisita : Form
    {
        //VARIABLES GLOBALES
        DCiudadano dCiudadanoGlo = new DCiudadano();
        List<DVisitaInterno> listaVisitaInternosGlo = new List<DVisitaInterno>();

        private ErrorProvider errorProvider = new ErrorProvider();
        //la accion puede ser prohibir, levantar o quitar
        string accionProhibir = "";
        string accionProhibirParentesco = "";
        //cumplimentar/anular excepcion
        bool accionCumplimentarExcepcion = false;
        bool accionAnularExcepcion = false;
        //vigencia vinculo
        bool accionRevincularVinculo = false;
        bool accionDesvincularVinculo = false;

        public FormAdminVisita()
        {
            InitializeComponent();
        }

       
        private async void frmAdminVisita_Load(object sender, EventArgs e)
        {
            //// Ajustar el tamaño del formulario            
            FormularioAyudas.AjustarFormulario(this);

            int idCiudadano;
            //acceder a la instancia de FormTramites abierta.
            FormVisitas formVisitas = Application.OpenForms["FormVisitas"] as FormVisitas;
            NCiudadano nCiudadano = new NCiudadano();

            //BUSCAR CIUDADANO CON EL ID DEL FORMULARIO DE BUSQUEDA (formVisitas)
            tabVisita.Enabled = false;
            idCiudadano = Convert.ToInt32(formVisitas.idCiudadanoGlobal);
            (DCiudadano dCiudadanoX, string errorResponse) = await nCiudadano.BuscarCiudadanoXID(idCiudadano);
            

            this.dCiudadanoGlo = dCiudadanoX;

            if (this.dCiudadanoGlo == null)
            {
                tabVisita.Enabled = false;

                MessageBox.Show(errorResponse, "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //CARGAR DATOS DEL CIUDADANO
            txtIdCiudadano.Text = this.dCiudadanoGlo.id_ciudadano.ToString();
            if (this.dCiudadanoGlo.es_visita)
            {
                txtVisita.Text = "ES VISITA";
            }
            else
            {
                txtVisita.Text = "NO ES VISITA";
            }
            txtApellido.Text = this.dCiudadanoGlo.apellido;
            txtNombre.Text = this.dCiudadanoGlo.nombre;
            txtDni.Text = this.dCiudadanoGlo.dni.ToString();
            txtSexo.Text = this.dCiudadanoGlo.sexo.sexo;
            txtFechaNacimiento.Text = this.dCiudadanoGlo.fecha_nac.ToShortDateString();
            txtTelefono.Text = this.dCiudadanoGlo.telefono;
            txtEstadoCivil.Text = this.dCiudadanoGlo.estado_civil.estado_civil;
            txtNacionalidad.Text = this.dCiudadanoGlo.nacionalidad.nacionalidad;
            txtPais.Text = this.dCiudadanoGlo.pais.pais;
            txtProvincia.Text = this.dCiudadanoGlo.provincia.provincia;
            txtDepartamento.Text = this.dCiudadanoGlo.departamento.departamento;
            txtMunicipio.Text = this.dCiudadanoGlo.municipio.municipio;
            txtCiudad.Text = this.dCiudadanoGlo.ciudad;
            if (this.dCiudadanoGlo.tiene_discapacidad)
            {
                txtDiscapacidad.Text = "TIENE DISCAPACIDAD";
            }
            else
            {
                txtDiscapacidad.Text = "NO TIENE DISCAPACIDAD";
            }
            txtFechaAlta.Text = this.dCiudadanoGlo.fecha_alta.ToShortDateString();
            txtOrganismoAlta.Text = this.dCiudadanoGlo.organismo_alta.organismo;
            pictureFoto.Load(this.dCiudadanoGlo.foto);

            tabVisita.Enabled = true;
            this.ControlEsVisita();
            this.ControlTieneDiscapacidad();
            this.ControlEdad();
            
        }

        //REGION DATOS PERSONALES
        #region DatosPersonales
        //CONTROL ES VISITA
        private void ControlEsVisita()
        {
            if (this.dCiudadanoGlo.es_visita)
            {
                lblEsVisitaPrincipal.Text = "Ciudadano registrado como visita";
                lblEsVisitaPrincipal.ForeColor = Color.SteelBlue;                
            }
            else
            {
                lblEsVisitaPrincipal.Text = "Ciudadano no registrado como visita";
                lblEsVisitaPrincipal.ForeColor = Color.Red;                
            }
        }
        //FIN CONTROL ES VISITA

        //CONTROL TIENE DISCAPACIDAD
        private void ControlTieneDiscapacidad()
        {
            if (this.dCiudadanoGlo.tiene_discapacidad)
            {
                lblTieneDiscapacidad.Text = "Ciudadano registrado con discapacidad";
                lblTieneDiscapacidad.ForeColor = Color.SteelBlue;
                lblDetalleTieneDiscapacidad.Text = dCiudadanoGlo.discapacidad_detalle;
                lblDetalleTieneDiscapacidad.ForeColor = Color.SteelBlue;
            }
            else
            {
                lblTieneDiscapacidad.Text = "Ciudadano no registrado con discapacidad";
                lblTieneDiscapacidad.ForeColor = Color.Red;

                lblDetalleTieneDiscapacidad.Text = "";
            }
        }
        //FIN CONTROL TIENE DISCAPACIDAD

        //CONTROL EDAD
        private void ControlEdad()
        {
            if (this.dCiudadanoGlo.edad < 18)
            {
                lblMenorEdad.Text = "Edad: " + this.dCiudadanoGlo.edad + " años. Es MENOR.";
            }
            else
            {
                lblMenorEdad.Text = "Edad: " + this.dCiudadanoGlo.edad + " años. Es ADULTO.";
            }
        }
        //FIN CONTROL EDAD
        #endregion
        //FIN REGION DATOS PERSONALES.....................................

        //REGION PROHIBICIONES
        #region Prohibiciones

        //VER PROHIBICIONES
        private void btnVerProhibiciones_Click(object sender, EventArgs e)
        {
            this.CargarDataGridProhibiciones();

        }
        //FIN VER PROHIBICIONES................................

        //GUARDAR NUEVA PROHIBICION O NODIFICACION
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            NProhibicionVisita nProhibicionVisita = new NProhibicionVisita();
            

            //NUEVO
            if ( txtIdProhibicion.Text == null || txtIdProhibicion.Text == "")
            {
                //limpiar errores de provider
                errorProvider.Clear();

                //validacion de formulario
                var datosFormulario = new ProhibicionDatos
                {
                    txtIdCiudadano = txtIdCiudadano.Text,
                    txtDisposicion = txtDisposicion.Text,
                    txtDetalle = txtDetalle.Text,
                    dtpFechaInicio = dtpFechaInicio.Value,
                    dtpFechaFin = dtpFechaFin.Value,
                };

                var validator = new ProhibicionNuevaValidator();
                var result = validator.Validate(datosFormulario);

                if (!result.IsValid)
                {
                    MessageBox.Show("Complete correctamente los campos del formulario","Restriccion Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    foreach (var failure in result.Errors)
                    {
                        
                        Control control = Controls.Find(failure.PropertyName, true)[0];
                        errorProvider.SetError(control, failure.ErrorMessage);
                    }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
                    return;
                }

                //enviar datos si son correctos
                var data = new
                {
                    ciudadano_id = Convert.ToInt32(txtIdCiudadano.Text),
                    disposicion = txtDisposicion.Text,
                    detalle = txtDetalle.Text,
                    fecha_inicio = dtpFechaInicio.Value,
                    fecha_fin = dtpFechaFin.Value,
                };

                string dataProhibicion = JsonConvert.SerializeObject(data);

                tabVisita.Enabled = false;
                (DProhibicionVisita dataRespuesta, string errorResponse) = await nProhibicionVisita.CrearProhibicion(dataProhibicion);
                tabVisita.Enabled = true;

                if (dataRespuesta != null)
                {                        
                    MessageBox.Show("La prohibición se guardo correctamente", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.HabilitarControles(false);
                    this.LimpiarControles();

                    btnNuevo.Enabled = true;
                    btnEditar.Enabled = true;
                    btnGuardar.Enabled = false;
                    btnCancelar.Enabled = false;
                                        
                    //cargar lista de ciudadanos en datagrid
                    this.CargarDataGridProhibiciones();
                }
                else
                {
                    MessageBox.Show( errorResponse, "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
            //FIN NUEVO............................................................

            //EDITAR
            if (!string.IsNullOrEmpty(txtIdProhibicion.Text))
            {
                //limpiar errores de provider
                errorProvider.Clear();

                //validacion de formulario
                var datosFormulario = new ProhibicionDatos
                {                    
                    txtDisposicion = txtDisposicion.Text,
                    txtDetalle = txtDetalle.Text,
                    dtpFechaInicio = dtpFechaInicio.Value,
                    dtpFechaFin = dtpFechaFin.Value,
                    txtMotivo = txtMotivo.Text,
                };

                var validatorEdicion = new ProhibicionEdicionValidator();
                var result = validatorEdicion.Validate(datosFormulario);

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

                //enviar datos
                var data = new
                {
                    disposicion = txtDisposicion.Text,
                    detalle = txtDetalle.Text,
                    fecha_inicio = dtpFechaInicio.Value,
                    fecha_fin = dtpFechaFin.Value,
                    detalle_motivo = txtMotivo.Text,
                };

                string dataProhibicion = JsonConvert.SerializeObject(data);

                tabVisita.Enabled = false;
                (bool respuestaEditar, string errorResponse) = await nProhibicionVisita.EditarProhibicion(Convert.ToInt32(txtIdProhibicion.Text), dataProhibicion);
                tabVisita.Enabled = true;

                if (respuestaEditar)
                {
                        
                    MessageBox.Show("La edición de la prohibición se realizó correctamente", "Restricción Visitass", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.LimpiarControles();
                    this.HabilitarControles(false);

                    //cargar lista de prhibiciones en datagrid
                    this.CargarDataGridProhibiciones();
                        
                    btnNuevo.Enabled = true;
                    btnEditar.Enabled = true;
                    btnGuardar.Enabled = false;
                    btnCancelar.Enabled = false;
                }
                else
                {                        
                    MessageBox.Show(errorResponse, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                

            }
            //FIN EDITAR.........................................................
        }
        //FIN GUARDAR NUEVA PROHIBICION O NODIFICACION.........................

        //DATA GRID PROHIBICIONES
        private void dtgvProhibiciones_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (btnGuardar.Enabled == true || btnGuardarQP.Enabled == true)
                {
                    MessageBox.Show("No puede se puede seleccionar una prohibición mientras se esta editando o se está agregando una nueva prohibición.", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dtgvProhibiciones.SelectedRows.Count > 0)
                {
                    int idProhibicion;
                    idProhibicion = Convert.ToInt32(dtgvProhibiciones.CurrentRow.Cells["ID"].Value.ToString());
                    
                    if (idProhibicion > 0)
                    {
                        txtIdProhibicion.Text = idProhibicion.ToString();
                        txtDisposicion.Text = dtgvProhibiciones.CurrentRow.Cells["Disposicion"].Value.ToString();
                        txtDetalle.Text = dtgvProhibiciones.CurrentRow.Cells["Detalle"].Value.ToString();
                        dtpFechaInicio.Value = Convert.ToDateTime(dtgvProhibiciones.CurrentRow.Cells["FechaInicio"].Value.ToString());
                        dtpFechaFin.Value = Convert.ToDateTime(dtgvProhibiciones.CurrentRow.Cells["FechaFin"].Value.ToString());
                        txtOrganismo.Text = dtgvProhibiciones.CurrentRow.Cells["Organismo"].Value.ToString();
                        dtpFechaProhibicion.Value = Convert.ToDateTime(dtgvProhibiciones.CurrentRow.Cells["FechaProhibicion"].Value.ToString());
                        chkVigente.Checked = Convert.ToBoolean(dtgvProhibiciones.CurrentRow.Cells["Prohibida"].Value.ToString());
                        chkAnulado.Checked = Convert.ToBoolean(dtgvProhibiciones.CurrentRow.Cells["Anulado"].Value.ToString());

                        
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una prohibición.", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        //FIN DATA GRID PROHIBICIONES...............................................

        //CANCELAR NUEVA PROHIBICION O MODIFICIACION
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.HabilitarControles(false);
            this.LimpiarControles();
            
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
        }
        //FIN CANCELAR NUEVA PROHIBICION O MODIFICIACION..............................

        //HABILITAR EDICION
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtIdProhibicion.Text == null || txtIdProhibicion.Text == "")
            {
                MessageBox.Show("Debe seleccionar una prohibición", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.HabilitarControles(true);
            this.txtMotivo.Enabled = true;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
        }
        //FIN HABILITAR EDICION................................................


        //HABILITAR PARA NUEVA PROHIBICION
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.LimpiarControles();
            this.HabilitarControles(true);
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
        }
        //FIN HABILITAR PARA NUEVA PROHIBICION.........................

        //LEVANTAR PROHIBICION
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (txtIdProhibicion.Text == null || txtIdProhibicion.Text == "")
            {
                MessageBox.Show("Debe seleccionar una prohibición", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.accionProhibir = "levantar";
            this.HabilitarControlesQP(true);
        }
        //FIN LEVANTAR PROHIBICION............................................

       
        //ANULAR PROHIBICION
        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (txtIdProhibicion.Text == null || txtIdProhibicion.Text == "")
            {
                MessageBox.Show("Debe seleccionar una prohibición", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.accionProhibir = "anular";
            this.HabilitarControlesQP(true);
        }
        //FIN ANULAR PROHIBICION...............................................................

        //CANCELAR LEVANTAR Y ANULAR
        private void btnCancelarQP_Click(object sender, EventArgs e)
        {
            btnQuitar.Enabled = true;
            btnAnular.Enabled = true;
            this.HabilitarControlesQP(false);
            this.LimpiarControlesQP();
        }
        //FIN CANCELAR LEVANTAR Y ANULAR .......................

        //GUARDAR LEVANTAR Y ANULAR
        private async void btnGuardarQP_Click(object sender, EventArgs e)
        {
            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            var datosFormulario = new ProhibicionDatos
            {
                txtMotivoQP = txtMotivoQP.Text,
                dtpFechaFinQP = dtpFechaFinQP.Value,
            };

            var validator = new ProhibicionLevantarAnularValidator();
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


            NProhibicionVisita nProhibicionVisita = new NProhibicionVisita();
            
            var data = new
            {
                detalle_motivo = txtMotivoQP.Text,
                fecha_fin = dtpFechaFinQP.Value,
            };

            string dataEnviar = JsonConvert.SerializeObject(data);
            
            bool respuestaOk = false;
            string mensajeRespuesta = "";

            //determinar cual es la accion a realizar con la prohibicion
            //usar el respectivo metodo
            if (this.accionProhibir == "levantar")
            {
                tabVisita.Enabled = false;
                (bool respuestaEditar, string errorResponse) = await nProhibicionVisita.LevantarManualProhibicion(Convert.ToInt32(txtIdProhibicion.Text), dataEnviar);
                tabVisita.Enabled = true;

                if (respuestaEditar)
                {
                    respuestaOk = true;
                    mensajeRespuesta = "El levantamiento de la prohibición se realizó correctamente";
                }
                else
                {
                    mensajeRespuesta = errorResponse;
                }
            }
            

            if (this.accionProhibir == "anular")
            {
                tabVisita.Enabled = false;
                (bool respuestaEditar, string errorResponse) = await nProhibicionVisita.AnularProhibicion(Convert.ToInt32(txtIdProhibicion.Text), dataEnviar);
                tabVisita.Enabled = true;

                if (respuestaEditar)
                {
                    respuestaOk = true;
                    mensajeRespuesta = "La prohibición se anuló correctamente";
                }
                else
                {
                    mensajeRespuesta = errorResponse;
                }
            }            

            //verificar respuesta de la peticion
            if (respuestaOk)
            {

                MessageBox.Show(mensajeRespuesta, "Restricción Visitas",MessageBoxButtons.OK, MessageBoxIcon.Information);
                mensajeRespuesta = "";

                //INICIALIZACION CONTROLES LEVANTAMIENTO                        
                this.HabilitarControlesQP(false);
                this.LimpiarControlesQP();

                //INICIALIZACION DE CONTROLES PROHIBICION
                this.LimpiarControles();
                this.HabilitarControles(false);

                //cargar lista de prhibiciones en datagrid
                this.CargarDataGridProhibiciones();

                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
            }
            else
            {
                MessageBox.Show(mensajeRespuesta, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        //FIN GUARDAR LEVANTAR, PROHIBIR Y ANULAR..................................................................


        //METODO PARA OBTENER LA LISTA DE PROHIBICIONES Y CARGARLO EN UN DATA GRID DE PROHIBICIONES
        async private void CargarDataGridProhibiciones()
        {
            NProhibicionVisita nProhibicionVisita = new NProhibicionVisita();
            (List<DProhibicionVisita> listaProhibicionesVisita, string errorResponse) =  await nProhibicionVisita.RetornarListaProhibicionesVisita(this.dCiudadanoGlo.id_ciudadano);

            if(listaProhibicionesVisita == null)
            {
                MessageBox.Show(errorResponse, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var datosfiltrados = listaProhibicionesVisita
                .Select(c => new
                {
                    Id = c.id_prohibicion_visita,
                    Disposicion = c.disposicion,
                    Detalle = c.detalle,
                    FechaInicio = c.fecha_inicio,
                    FechaFin = c.fecha_fin,
                    FechaProhibicion = c.fecha_prohibicion,
                    Organismo = c.organismo.organismo,
                    Prohibida = c.vigente,
                    TipoLevantamiento = c.tipo_levantamiento,
                    Anulado = c.anulado

                })
                .ToList();

            dtgvProhibiciones.DataSource = datosfiltrados;

            if (listaProhibicionesVisita.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                dtgvProhibiciones.Columns[2].Width = 300;
            }

            foreach (DataGridViewRow row in dtgvProhibiciones.Rows)
            {
                if (row.Cells["Prohibida"].Value != null && Convert.ToBoolean(row.Cells["Prohibida"].Value) == true)
                {
                    row.DefaultCellStyle.BackColor = Color.Orange; // Cambiar color de fondo
                    row.DefaultCellStyle.ForeColor = Color.Black;    // Cambiar color del texto
                }

                if (row.Cells["Anulado"].Value != null && Convert.ToBoolean(row.Cells["Anulado"].Value) == true)
                {
                    row.DefaultCellStyle.BackColor = Color.Black; // Cambiar color de fondo
                    row.DefaultCellStyle.ForeColor = Color.White;    // Cambiar color del texto
                }
            }


        } 
        //FIN METODO PARA OBTENER LA LISTA DE PROHIBICIONES Y CARGARLO EN UN DATA GRID DE PROHIBICIONES...........

        
        //HABILITAR CONTROLES
        private void HabilitarControles(bool valor)
        {            
            txtDisposicion.Enabled = valor;
            txtDetalle.ReadOnly = !valor;
            dtpFechaInicio.Enabled = valor;
            dtpFechaFin.Enabled = valor;
            txtMotivo.Enabled = false;

            //botnes de quitar prohibicion
            btnQuitar.Enabled = !valor;
            btnAnular.Enabled = !valor;
        }        
        //FIN HABILITAR CONTROLES

        //LIMPIAR CONTROLES
        private void LimpiarControles()
        {
            //limpiar errores
            errorProvider.Clear();

            txtIdProhibicion.Text = string.Empty;
            txtDisposicion.Text = string.Empty;
            txtDetalle.Text = string.Empty;
            dtpFechaInicio.Text = string.Empty;
            dtpFechaFin.Text = string.Empty;
            txtOrganismo.Text = string.Empty;
            dtpFechaProhibicion.Text = string.Empty;
            chkVigente.Checked = false;
            chkAnulado.Checked = false;
            txtMotivo.Text = string.Empty;
        }
        //FIN LIMPIAR CONTROLES...................................

        

        //HABILITAR CONTROLES QUITAR/PROHIBIR
        private void HabilitarControlesQP(bool valor)
        {
            dtpFechaFinQP.Enabled = valor;
            txtMotivoQP.Enabled = valor;

            btnAnular.Enabled = !valor;
            btnQuitar.Enabled = !valor;

            btnGuardarQP.Enabled = valor;
            btnCancelarQP.Enabled = valor;

            //botones de prohibicion
            btnNuevo.Enabled = !valor;
            btnEditar.Enabled = !valor;
        }
        //FIN HABILITAR QUITAR/PRHIBIR

        //LIMPIAR CONTROLES QUITAR/PROHIBIR
        private void LimpiarControlesQP()
        {
            //limpiar errores
            errorProvider.Clear();

            dtpFechaFinQP.Text = string.Empty;
            txtMotivoQP.Text = string.Empty;
            
        }
        //FIN LIMPIAR QUITAR/PRHIBIR........................

        //HISTORIAL DE UNA PROHIBICION
        private void btnHistorial_Click(object sender, EventArgs e)
        {
            if (txtIdProhibicion.Text == "")
            {
                MessageBox.Show("Debe seleccionar una prohibición","Restricción Visitas",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                var frmHistorial = new FormHistorialProhibicion(Convert.ToInt32(txtIdProhibicion.Text));
                frmHistorial.ShowDialog();
            }
        }
        //FIN HISTORIAL DE UNA PROHIBICION.....................

        #endregion
        //FIN REGION PROHIBICIONES............................................................
        //........................................................................................

        //REGION PARENTESCOS
        #region Parentescos

        //METODO PARA OBTENER LA LISTA DE PARENTESCOS Y CARGARLO EN UN DATA GRID 
        async private void CargarDataGridParentescos()
        {
            NVisitaInterno nVisitaInterno = new NVisitaInterno();

            (List<DVisitaInterno> listaParentescos, string errorResponse) = await nVisitaInterno.RetornarListaParentescos(this.dCiudadanoGlo.id_ciudadano);

            if (listaParentescos == null)
            {
                MessageBox.Show(errorResponse, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var datosfiltrados = listaParentescos
                .Select(c => new
                {
                    Id = c.id_visita_interno,
                    Interno = c.interno.apellido + " " + c.interno.nombre,
                    Prontuario = c.interno.prontuario,
                    Unidad = c.interno.organismo.organismo,
                    Parentesco = c.parentesco.parentesco,
                    Vigente = c.vigente,
                    Anulado = c.anulado,
                    Prohibido = c.prohibido,
                    FechaProhib = c.fecha_prohibido,
                    FechaInicio = c.fecha_inicio,
                    FechaFin = c.fecha_fin,
                    DetalleProhib = c.detalles_prohibicion,
                    FechaAlta = c.fecha_alta,
                    Usuario = c.usuario.apellido + " " + c.usuario.nombre

                })
                .ToList();

            dtgvParentescos.DataSource = datosfiltrados;

            if (listaParentescos.Count == 0)
            {
                MessageBox.Show("No se encontraron registros.", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                dtgvParentescos.Columns[1].Width = 200;
            }           

        } //FIN METODO PARA OBTENER LA LISTA DE PARENTESCOS EN UN DATA GRID ...........

        //BOTON VER PARENTESCOS..................................................................
        private async void btnVerParentescos_Click(object sender, EventArgs e)
        {
            //formulario parentesco actual
            txtIdVisitaInterno.Text = "";
            txtInternoVinculado.Text = "";
            txtParentesco.Text = "";

            //formulario modificacion
            cmbParentescos.Enabled = false;
            txtMotivoModificarParentesco.Text = "";
            txtMotivoModificarParentesco.Enabled = false;
            btnModificarParentesco.Enabled = true;
            btnGuardarModificarParentesco.Enabled = false;
            btnCancelarModificarParentesco.Enabled = false;

            this.CargarDataGridParentescos();

            //Carga de combo parentescos
            NParentesco nParentesco = new NParentesco();
            (List<DParentesco> listaParentescos, string errorResponse) = await nParentesco.RetornarListaParentescos();

            if (listaParentescos == null)
            {
                MessageBox.Show("Advertencia al cargar lista de parentescos: " + errorResponse, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            cmbParentescos.ValueMember = "id_parentesco";
            cmbParentescos.DisplayMember = "parentesco";
            cmbParentescos.DataSource = listaParentescos;
        }
        //FIN VER PARENTESCOS....................................................

        //BOTON IMPRIMIR VINCULOS
        private async void btnImprimirVinculos_Click(object sender, EventArgs e)
        {
            NVisitaInterno nVisitaInterno = new NVisitaInterno();

            (List<DVisitaInterno> listaParentescos, string errorResponse) = await nVisitaInterno.RetornarListaParentescos(this.dCiudadanoGlo.id_ciudadano);

            if (listaParentescos == null)
            {
                MessageBox.Show(errorResponse, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Generar PDF en memoria
            MemoryStream msOriginal = ReportesAdminVisitaPDF.RepPdfInternosVinculados(this.dCiudadanoGlo ,listaParentescos);

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

        //FIN BOTON IMPRIMIR VINCULOS........................


        //BOTON PROHIBIR PARENTESCO
        private void btnProhibirParent_Click(object sender, EventArgs e)
        {
            if (txtIdVisitaInterno.Text == null || txtIdVisitaInterno.Text == "")
            {
                MessageBox.Show("Debe seleccionar un parentesco", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.accionProhibirParentesco = "prohibir";

            //habilitar controles
            this.HabilitarControlesProhibicionParentescos(true);
            
        }
        //FIN BOTON PROHIBIR PARENTESCO

        //BOTON LEVANTAR PROHIBICION PARENTESCO
        private void btnLevantarProhibirParent_Click(object sender, EventArgs e)
        {
            if (txtIdVisitaInterno.Text == null || txtIdVisitaInterno.Text == "")
            {
                MessageBox.Show("Debe seleccionar un parentesco", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.accionProhibirParentesco = "levantar";

            //habilitar controles
            this.HabilitarControlesProhibicionParentescos(true);
            
        }
        //FIN BOTON LEVANTAR PROHIBICION PARENTESCO..............................................


        //BOTON GUARDAR PROHIBIR PARENTESCO
        private async void btnGuardarPohibPar_Click(object sender, EventArgs e)
        {
            NVisitaInterno nVisitaInterno = new NVisitaInterno();

            bool respuestaOk = false;
            string mensajeRespuesta = "";

            //determinar cual es la accion a realizar con la prohibicion
            //prohibir parentesco
            if (this.accionProhibirParentesco == "prohibir")
            {
                //limpiar errores de provider
                errorProvider.Clear();

                //validacion de formulario
                var datosFormulario = new ProhibicionDatos
                {
                    dtpFechaIniProhibirParentesco = dtpFechaIniProhibirParentesco.Value,
                    dtpFechaFinProhibirParentesco = dtpFechaFinProhibirParentesco.Value,
                    txtDetalleProhibirParentesco = txtDetalleProhibirParentesco.Text,
                };

                var validator = new VinculoProhibirValidator();
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

                var data = new
                {
                    fecha_inicio = dtpFechaIniProhibirParentesco.Value,
                    fecha_fin = dtpFechaFinProhibirParentesco.Value,
                    detalles_prohibicion = txtDetalleProhibirParentesco.Text,
                };

                string dataProhibir = JsonConvert.SerializeObject(data);

                tabVisita.Enabled = false;
                (bool respuestaProhibir, string errorResponse) = await nVisitaInterno.ProhibirParentesco(Convert.ToInt32(txtIdVisitaInterno.Text), dataProhibir);
                tabVisita.Enabled = true;

                if (respuestaProhibir)
                {
                    respuestaOk = true;
                    mensajeRespuesta = "El parentesco se prohibió correctamente";
                }
                else
                {
                    mensajeRespuesta = errorResponse;
                }
            }

            //levantar prohibicion parentesco
            if (this.accionProhibirParentesco == "levantar")
            {
                //limpiar errores de provider
                errorProvider.Clear();

                //validacion de formulario
                var datosFormulario = new ProhibicionDatos
                {
                    dtpFechaFinProhibirParentesco = dtpFechaFinProhibirParentesco.Value,
                    txtDetalleProhibirParentesco = txtDetalleProhibirParentesco.Text,
                };

                var validator = new VinculoLevantarProhibicionValidator();
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

                var data = new
                {
                    fecha_fin = dtpFechaFinProhibirParentesco.Value,
                    detalle_levantamiento = txtDetalleProhibirParentesco.Text,
                };

                string dataLevantar = JsonConvert.SerializeObject(data);

                tabVisita.Enabled = false;
                (bool respuestaLevantar, string errorResponse) = await nVisitaInterno.LevantarProhibicionParentesco(Convert.ToInt32(txtIdVisitaInterno.Text), dataLevantar);
                tabVisita.Enabled = true;

                if (respuestaLevantar)
                {
                    respuestaOk = true;
                    mensajeRespuesta = "La prohibicion del parentesco se levnato correctamente";
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

                //deshabilitar controles
                this.HabilitarControlesProhibicionParentescos(false);

                //cargar lista de prhibiciones en datagrid
                this.CargarDataGridParentescos();

            }
            else
            {
                MessageBox.Show(mensajeRespuesta, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //FIN BOTON GUARDAR PROHIBIR PARENTESCO.........................................

        //BOTON CANCELAR PROHIBICION PARENTESCO
        private void btnCancelarPohibPar_Click(object sender, EventArgs e)
        {
            this.accionProhibirParentesco = "";

            //deshabilitar controles
            this.HabilitarControlesProhibicionParentescos(false);
            
        }
        //FIN BOTON CANCELAR PROHIBICION PARENTESCO......................................


        //SECCION REVINCULACION/DESVINCULACION PARENTESCO
        #region VINCULACION PARENTESCO
        //BOTON REVINCULAR
        private void btnRevincular_Click(object sender, EventArgs e)
        {
            if (txtIdVisitaInterno.Text == null || txtIdVisitaInterno.Text == "")
            {
                MessageBox.Show("Debe seleccionar un parentesco", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.accionRevincularVinculo = true;
            this.accionDesvincularVinculo = false;

            this.HabilitarControlesVinculacionParentescos(true);
        }
        //FIN BOTON REVINCULAR.......................................................

        //BOTON DESVINCULAR
        private void btnDesvincular_Click(object sender, EventArgs e)
        {
            if (txtIdVisitaInterno.Text == null || txtIdVisitaInterno.Text == "")
            {
                MessageBox.Show("Debe seleccionar un parentesco", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.accionDesvincularVinculo = true;
            this.accionRevincularVinculo = false;

            this.HabilitarControlesVinculacionParentescos(true);
        }
        //FIN BOTON DESVINCULAR...............................................................

        //BOTON CANCELAR VINCULACION
        private void btnCancelarVinculacionParentesco_Click(object sender, EventArgs e)
        {
            this.accionRevincularVinculo = false;
            this.accionDesvincularVinculo = false;

            this.HabilitarControlesVinculacionParentescos(false);
        }
        //FIN BOTON CANCELAR VINCULACION...........................................................

        //BOTON GUARDAR VINCULACION
        private async void btnGuardarVinculacionParentesco_Click(object sender, EventArgs e)
        {
            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            var datosFormulario = new ProhibicionDatos
            {
                
                txtDetalleVinculacionParentesco = txtDetalleVinculacionParentesco.Text,
            };

            var validator = new VinculoDesvincularRevincularValidator();
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

            NVisitaInterno nVisitaInterno = new NVisitaInterno();

            bool respuestaOk = false;
            string mensajeRespuesta = "";

            //determinar cual es la accion a realizar con la prohibicion
            //REvincular parentesco
            if (this.accionRevincularVinculo)
            {
                var data = new
                {
                    detalles_vigencia = txtDetalleVinculacionParentesco.Text,
                };

                string dataActualizar = JsonConvert.SerializeObject(data);

                tabVisita.Enabled = false;
                (bool respuestaRevincular, string errorResponse) = await nVisitaInterno.RevincularParentesco(Convert.ToInt32(txtIdVisitaInterno.Text), dataActualizar);
                tabVisita.Enabled = true;

                if (respuestaRevincular)
                {
                    respuestaOk = true;
                    mensajeRespuesta = "El parentesco se revinculó correctamente";
                    MessageBox.Show("Revinculado", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    mensajeRespuesta = errorResponse;
                }

                this.accionRevincularVinculo = false;
            }

            //Desvincular parentesco
            if (this.accionDesvincularVinculo)
            {
                var data = new
                {
                    detalles_vigencia = txtDetalleVinculacionParentesco.Text,
                };

                string dataActualizar2 = JsonConvert.SerializeObject(data);

                (bool respuestaDesvincular, string errorResponse) = await nVisitaInterno.DesvincularParentesco(Convert.ToInt32(txtIdVisitaInterno.Text), dataActualizar2);

                if (respuestaDesvincular)
                {
                    respuestaOk = true;
                    mensajeRespuesta = "El parentesco se desvinculó correctamente";
                    MessageBox.Show("desvinculado", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    mensajeRespuesta = errorResponse;
                }

                this.accionDesvincularVinculo = false;
            }

            //verificar respuesta de la peticion
            if (respuestaOk)
            {

                MessageBox.Show(mensajeRespuesta, "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mensajeRespuesta = "";

                //deshabilitar controles
                this.HabilitarControlesVinculacionParentescos(false);

                //cargar lista de prhibiciones en datagrid
                this.CargarDataGridParentescos();

            }
            else
            {
                MessageBox.Show(mensajeRespuesta, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //FIN BOTON GUARDAR VINCULACION.......................................................
        #endregion VINCULACION PARENTESCO
        //FIN SECCION REVINCULACION/DESVINCULACION PARENTESCO.......................................

        //DATA GRID PARENTESCOS
        private void dtgvParentescos_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (dtgvParentescos.SelectedRows.Count > 0)
                {
                    int id_visita_interno;
                    id_visita_interno = Convert.ToInt32(dtgvParentescos.CurrentRow.Cells["ID"].Value.ToString());

                    //deshabilitar controles parentescos
                    this.HabilitarControlesProhibicionParentescos(false);
                    this.HabilitarControlesVinculacionParentescos(false);
                    this.HabilitarControlesCambioParentesco(false);

                    if (id_visita_interno > 0) 
                    {
                        txtIdVisitaInterno.Text = id_visita_interno.ToString();
                        txtInternoVinculado.Text = dtgvParentescos.CurrentRow.Cells["Interno"].Value.ToString();
                        txtParentesco.Text = dtgvParentescos.CurrentRow.Cells["Parentesco"].Value.ToString();
                        txtDetalleProhibicionParentesco.Text = dtgvParentescos.CurrentRow.Cells["DetalleProhib"].Value?.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una prohibición.", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        //FIN DATA GRID PARENTESCOS.......................................
        
        //BOTON MODIFICAR PARENTESCO
        private void btnModificarParentesco_Click(object sender, EventArgs e)
        {
            if (txtIdVisitaInterno.Text == null || txtIdVisitaInterno.Text == "")
            {
                MessageBox.Show("Debe seleccionar una vinculación", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.HabilitarControlesCambioParentesco(true);
        }
        //FIN BOTON MODIFICAR PARENTESCO..................................................

        //BOTON GUARDAR MODIFICAR PARENTESCO
        private async void btnGuardarModificarParentesco_Click(object sender, EventArgs e)
        {
            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            var datosFormulario = new ProhibicionDatos
            {
                cmbParentescos = cmbParentescos.SelectedValue?.ToString() ?? string.Empty,
                txtMotivoModificarParentesco = txtMotivoModificarParentesco.Text,
            };

            var validator = new VinculoCambiarParentescoValidator();
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

            NVisitaInterno nVisitaInterno = new NVisitaInterno();

            //EDITAR
            if (txtIdVisitaInterno.Text != null || txtIdVisitaInterno.Text != "")
            {
                var data = new
                {
                    parentesco_id = cmbParentescos.SelectedValue,
                    detalle_motivo = txtMotivoModificarParentesco.Text
                };

                string dataVisitaInterno = JsonConvert.SerializeObject(data);

                try
                {
                    tabVisita.Enabled = false;
                    (bool respuestaEditar, string errorResponse) = await nVisitaInterno.CambiarParentesco(Convert.ToInt32(txtIdVisitaInterno.Text), dataVisitaInterno);
                    tabVisita.Enabled = true;

                    if (respuestaEditar)
                    {

                        MessageBox.Show("El cambio de parentesco se realizó correctamente", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //cargar lista de prhibiciones en datagrid
                        this.CargarDataGridParentescos();

                        //formulario parentesco actual
                        txtIdVisitaInterno.Text = "";
                        txtInternoVinculado.Text = "";
                        txtParentesco.Text = "";

                        //formulario modificacion
                        this.HabilitarControlesCambioParentesco(false);
                    }
                    else
                    {
                        MessageBox.Show(errorResponse, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    // Manejo de otros tipos de errores MySQL
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
            //FIN EDITAR.........................................................
        }
        //FIN BOTON GUARDAR MODIFICAR PARENTESCO
                

        //BOTON CANCELAR MODIFICAR PARENTESCO
        private void btnCancelarModificarParentesco_Click(object sender, EventArgs e)
        {
            //formulario modificacion
            this.HabilitarControlesCambioParentesco(false);
        }
        //FIN BOTON MODIFICAR PARENTESCO...................................

        //METODO HABILITAR CONTROLES PROHIBICION VINCULO
        private void HabilitarControlesProhibicionParentescos(bool habilitar)
        {
            //limpiar errores de provider
            errorProvider.Clear();

            dtpFechaIniProhibirParentesco.ResetText();
            dtpFechaIniProhibirParentesco.Enabled = habilitar;
            //determinar si se esta prohibiendo para habilitar la fecha de inicio, sino debe permaneces deshabilitado
            if (this.accionProhibirParentesco == "levantar")
            {
                dtpFechaIniProhibirParentesco.ResetText();
                dtpFechaIniProhibirParentesco.Enabled = false;
            }
            dtpFechaFinProhibirParentesco.ResetText();
            dtpFechaFinProhibirParentesco.Enabled = habilitar;
            txtDetalleProhibirParentesco.Enabled = habilitar;
            txtDetalleProhibirParentesco.Text = "";

            btnProhibirParent.Enabled = !habilitar;
            btnLevantarProhibirParent.Enabled = !habilitar;
            btnGuardarPohibPar.Enabled = habilitar;
            btnCancelarPohibPar.Enabled = habilitar;
        }
        //METODO HABILITAR CONTROLES PROHIBICION VINCULO

        //METODO HABILITAR CONTROLES VINCULACION VINCULO
        private void HabilitarControlesVinculacionParentescos(bool habilitar)
        {
            //limpiar errores de provider
            errorProvider.Clear();

            txtDetalleVinculacionParentesco.Enabled = habilitar;
            txtDetalleVinculacionParentesco.Text = "";

            btnRevincular.Enabled = !habilitar;
            btnDesvincular.Enabled = !habilitar;
            btnGuardarVinculacionParentesco.Enabled = habilitar;
            btnCancelarVinculacionParentesco.Enabled = habilitar;

        }
        //METODO HABILITAR CONTROLES VINCULACION VINCULO

        //METODO HABILITAR CONTROLES CAMBIO PARENTESCO
        private void HabilitarControlesCambioParentesco(bool habilitar)
        {
            //limpiar errores de provider
            errorProvider.Clear();

            cmbParentescos.Enabled = habilitar;
            txtMotivoModificarParentesco.Text = "";
            txtMotivoModificarParentesco.Enabled = habilitar;
            btnModificarParentesco.Enabled = !habilitar;
            btnGuardarModificarParentesco.Enabled = habilitar;
            btnCancelarModificarParentesco.Enabled = habilitar;
        }
        //FIN METODO HABILITAR CONTROLES CAMBIO PARENTESCO
        #endregion
        //FIN REGION PARENTESCOS..........................................................
        //.................................................................................


        //REGION NOVEDADES
        #region Novedades

        //VER NOVEDADES
        private void btnVerNovedades_Click(object sender, EventArgs e)
        {
            this.CargarDataGridNovedades();

        }
        //FIN VER NOVEDADES................................

        //METODO PARA OBTENER LA LISTA DE NOVEDADES Y CARGARLO EN UN DATA GRID
        async private void CargarDataGridNovedades()
        {
            NNovedadCiudadano nNovedadCiudadano = new NNovedadCiudadano();

            (List<DNovedadCiudadano> listaNovedades, string errorResponse) = await nNovedadCiudadano.RetornarListaNovedadesCiudadano(this.dCiudadanoGlo.id_ciudadano);

            if (listaNovedades == null)
            {
                MessageBox.Show(errorResponse, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var datosfiltrados = listaNovedades
                .Select(c => new
                {
                    Id = c.id_novedad_ciudadano,
                    Novedad = c.novedad,
                    Detalle = c.novedad_detalle,
                    FechaNovedad = c.fecha_novedad,
                    Organismo = c.organismo.organismo,
                    Usuario = c.usuario.apellido + " " + c.usuario.nombre

                })
                .ToList();

            dtgvNovedades.DataSource = datosfiltrados;

            if (listaNovedades.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                
                dtgvNovedades.Columns[1].Width = 200;
                dtgvNovedades.Columns[2].Width = 400;
            }
        }
        //FIN METODO PARA OBTENER LA LISTA DE NOVEDADES EN UN DATA GRID ...........
                

        private void dtgvNovedades_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (dtgvNovedades.SelectedRows.Count > 0)
                {
                    int id_novedad;
                    id_novedad = Convert.ToInt32(dtgvNovedades.CurrentRow.Cells["ID"].Value.ToString());

                    if (id_novedad > 0)
                    {
                        txtIdNovedad.Text = id_novedad.ToString();
                        txtFechaNovedad.Text = Convert.ToDateTime(dtgvNovedades.CurrentRow.Cells["FechaNovedad"].Value).ToString("dd/MM/yyyy");
                        txtOrganismoNovedad.Text = dtgvNovedades.CurrentRow.Cells["Organismo"].Value.ToString();
                        txtUsuarioNovedad.Text = dtgvNovedades.CurrentRow.Cells["Usuario"].Value.ToString();
                        txtNovedad.Text = dtgvNovedades.CurrentRow.Cells["Novedad"].Value.ToString();
                        txtDetalleNovedad.Text = dtgvNovedades.CurrentRow.Cells["Detalle"].Value.ToString();
                        
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una novedad.", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
                

        private void btnNuevaNovedad_Click(object sender, EventArgs e)
        {
            txtNuevaNovedad.Enabled = true;
            btnNuevaNovedad.Enabled = false;
            btnGuardarNovedad.Enabled = true;
            btnCancelarNovedad.Enabled = true;
        }

        private void btnCancelarNovedad_Click(object sender, EventArgs e)
        {
            //limpiar errores de provider
            errorProvider.Clear();

            txtNuevaNovedad.Enabled = false;
            txtNuevaNovedad.Text = "";
            btnNuevaNovedad.Enabled = true;
            btnGuardarNovedad.Enabled = false;
            btnCancelarNovedad.Enabled = false;
        }

        private async void btnGuardarNovedad_Click(object sender, EventArgs e)
        {
            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            var datosFormulario = new ProhibicionDatos
            {
                txtIdCiudadano = txtIdCiudadano.Text,
                txtNuevaNovedad = txtNuevaNovedad.Text,
            };

            var validator = new NovedadNuevaValidator();
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

            NNovedadCiudadano nNovedadCiudadano = new NNovedadCiudadano();

            bool respuestaOk = false;
            string mensajeRespuesta = "";

            
            var data = new
            {
                ciudadano_id = Convert.ToInt32(txtIdCiudadano.Text),
                novedad_detalle = txtNuevaNovedad.Text,
            };

            string dataNovedad = JsonConvert.SerializeObject(data);

            tabVisita.Enabled = false;
            (DNovedadCiudadano respuestaNovedad, string errorResponse) = await nNovedadCiudadano.CrearNovedad(dataNovedad);
            tabVisita.Enabled = true;

            if (respuestaNovedad != null)
            {
                MessageBox.Show("La novedad se guardo correctamente", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNuevaNovedad.Enabled = false;
                txtNuevaNovedad.Text = "";
                btnNuevaNovedad.Enabled = true;
                btnGuardarNovedad.Enabled = false;
                btnCancelarNovedad.Enabled = false;

                //cargar lista de ciudadanos en datagrid
                this.CargarDataGridNovedades();
            }
            else
            {
                MessageBox.Show(errorResponse, "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        #endregion

        //FIN REGION NOVEDADES............................................................
        //.................................................................................

        //REGION EXCEPCIONES
        #region Excepciones
        private void btnNuevaExcepcion_Click(object sender, EventArgs e)
        {

            //habilitar controles
            this.HabilitarControlesExcepcion(true);
        }

        private void btnCancelarExcepcion_Click(object sender, EventArgs e)
        {
            //deshabilitar controles
            this.HabilitarControlesExcepcion(false);
        }

        //BOTON GUARDAR EXCEPCION
        private async void btnGuardarExcepcion_Click(object sender, EventArgs e)
        {
            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            var datosFormulario = new ProhibicionDatos
            {
                dtpFechaExcepcion = dtpFechaExcepcion.Value,
                txtMotivoExcepcion = txtMotivoExcepcion.Text,
                txtDetalleExcepcion = txtDetalleExcepcion.Text,
                txtIdInternoExcepcion = txtIdInternoExcepcion.Text,
            };

            var validator = new ExcepcionIngresoNuevaValidator();
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

            NExcepcionIngresoVisita nExcepcionIngresoVisita = new NExcepcionIngresoVisita();

            var data = new
            {
                ciudadano_id = Convert.ToInt32(txtIdCiudadano.Text),
                interno_id = Convert.ToInt32(txtIdInternoExcepcion.Text),
                motivo = txtMotivoExcepcion.Text,
                detalle_excepcion = txtDetalleExcepcion.Text,
                fecha_excepcion = dtpFechaExcepcion.Value,
                es_visita_ordinaria = chkEsParaOrdinaria.Checked
            };

            string dataExcepcion = JsonConvert.SerializeObject(data);

            tabVisita.Enabled = false;
            (DExcepcionIngresoVisita respuestaExcepcion, string errorResponse) = await nExcepcionIngresoVisita.CrearExcepcion(dataExcepcion);
            tabVisita.Enabled = true;

            if (respuestaExcepcion != null)
            {
                MessageBox.Show("La excepción se guardó correctamente", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //deshabilitar controles
                this.HabilitarControlesExcepcion(false);

                //cargar lista de excepciones en datagrid
                this.CargarDataGridExcepciones();
            }
            else
            {
                MessageBox.Show(errorResponse, "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //FIN BOTON GUARDAR EXCEPCION...........................................................


        private void btnVerExcepciones_Click(object sender, EventArgs e)
        {

            this.CargarDataGridExcepciones();   
        }

        //DATA GRID eXCEPCIONES
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
                        //deshabilitar controles
                        this.HabilitarControlesExcepcion(false);
                        this.HabilitarControlesCumplimentarAnularExcepcion(false);

                        //cargar datos de datagrid a controles
                        txtIdExcepcion.Text = id_excepcion_ingreso.ToString();
                        txtMotivoExcepcion.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["MotivoExcepcion"].Value.ToString();
                        txtDetalleExcepcion.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["Detalle"].Value.ToString();
                        txtInternoExcepcion.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["Interno"].Value.ToString();
                        dtpFechaExcepcion.Value = Convert.ToDateTime(dtgvExcepcionesIngreso.CurrentRow.Cells["FechaExcepcion"].Value.ToString());
                        txtFechaCargaExcepcion.Text = Convert.ToDateTime(dtgvExcepcionesIngreso.CurrentRow.Cells["FechaCarga"].Value).ToString("dd/MM/yyyy");
                        chkEsParaOrdinaria.Checked = Convert.ToBoolean(dtgvExcepcionesIngreso.CurrentRow.Cells["VisitaOrdinaria"].Value.ToString());
                        txtOrganismoExepcion.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["Organismo"].Value.ToString();
                        txtUsuarioCargaExcepcion.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["Usuario"].Value.ToString();
                        chkCumplimentadoExcepcion.Checked = Convert.ToBoolean(dtgvExcepcionesIngreso.CurrentRow.Cells["Cumplimentado"].Value.ToString());
                        chkControladoExcepcion.Checked = Convert.ToBoolean(dtgvExcepcionesIngreso.CurrentRow.Cells["Controlado"].Value.ToString());

                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una excepcion.", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        //FIN DATAGRID EXCEPCIONES........................................................

        //BOTON GUARDAR CUMPLIMENTAR ANULAR EEXCEPCION
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

            var data = new
            {
                detalle_cambio = txtDetalleCumplAnularExcepcion.Text,
            };

            string dataEnviar = JsonConvert.SerializeObject(data);


            bool respuestaOk = false;
            string mensajeRespuesta = "";

            //determinar cual es la accion a realizar con la prohibicion
            //usar el respectivo metodo
            if (this.accionAnularExcepcion)
            {
                tabVisita.Enabled = false;
                (bool respuestaEditar, string errorResponse) = await nExcepcionIngreso.AnularExcepcion(Convert.ToInt32(txtIdExcepcion.Text), dataEnviar);
                tabVisita.Enabled = true;

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
                tabVisita.Enabled = false;
                (bool respuestaEditar, string errorResponse) = await nExcepcionIngreso.CumplimentarExcepcion(Convert.ToInt32(txtIdExcepcion.Text), dataEnviar);
                tabVisita.Enabled = true;

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

                this.HabilitarControlesExcepcion(false);
                this.HabilitarControlesCumplimentarAnularExcepcion(false);
                this.CargarDataGridExcepciones();
            }
            else
            {
                MessageBox.Show(mensajeRespuesta, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //FIN BOTON GUARDAR CUMPLIMENTAR ANULAR EEXCEPCION..........................................

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

        private void btnCancelarCumplAnularExcepcion_Click(object sender, EventArgs e)
        {
            this.accionCumplimentarExcepcion = false;
            this.accionAnularExcepcion = false;
            lblDetalleCumplAnularExcepcion.Text = "DETALLE:";
            this.HabilitarControlesCumplimentarAnularExcepcion(false);
        }


        //HABILITAR CONTROLES NUEVA EXCEPCION
        private void HabilitarControlesExcepcion(bool habilitar)
        {
            //habilita controles
            dtpFechaExcepcion.Enabled = habilitar;
            dtpFechaExcepcion.ResetText();
            txtIdInternoExcepcion.Enabled = habilitar;
            txtIdInternoExcepcion.Text = string.Empty;
            txtInternoExcepcion.Enabled = habilitar;
            txtInternoExcepcion.Text = string.Empty;
            txtMotivoExcepcion.Enabled = habilitar;
            txtMotivoExcepcion.Text = string.Empty;
            txtDetalleExcepcion.ReadOnly = !habilitar;
            txtDetalleExcepcion.Text = string.Empty;
            chkEsParaOrdinaria.Enabled = habilitar;

            //limpia
            txtIdExcepcion.Text = string.Empty;
            txtFechaCargaExcepcion.Text = string.Empty;
            txtOrganismoExepcion.Text = string.Empty;
            txtUsuarioCargaExcepcion.Text = string.Empty;
            chkCumplimentadoExcepcion.Checked = false;
            chkControladoExcepcion.Checked = false;
            chkEsParaOrdinaria.Checked = false;

            //habilita botones
            btnInterno.Enabled = habilitar;
            btnNuevaExcepcion.Enabled = !habilitar;
            btnGuardarExcepcion.Enabled = habilitar;
            btnCancelarExcepcion.Enabled = habilitar;

            //habilitar botones cumplimentar/anular
            btnCumplimentarExcepcion.Enabled = !habilitar;
            btnAnularExcepcion.Enabled = !habilitar;
        }

        //FIN HABILITAR CONTROLES NUEVA EXCEPCION..............................

        //HABILITAR CONTROLES CUMPLIMENTAR/ANULAR EXCEPCION
        private void HabilitarControlesCumplimentarAnularExcepcion(bool habilitar)
        {
            //habilita controles
            txtDetalleCumplAnularExcepcion.Enabled = habilitar;

            //limpia
            txtDetalleCumplAnularExcepcion.Text = string.Empty;


            //habilita botones
            btnAnularExcepcion.Enabled = !habilitar;
            btnCumplimentarExcepcion.Enabled = !habilitar;
            btnGuardarCumplAnularExcepcion.Enabled = habilitar;
            btnCancelarCumplAnularExcepcion.Enabled = habilitar;

            //habilitar botones nueva excepcion
            btnNuevaExcepcion.Enabled = !habilitar;
        }

        //FIN HABILITAR CONTROLES CUMPLIMENTAR/ANULAR EXCEPCION..............................

        //METODO PARA OBTENER LA LISTA DE EXCEPCIONES Y CARGARLO EN UN DATA GRID
        async private void CargarDataGridExcepciones()
        {
            NExcepcionIngresoVisita nExcepcionIngresoVisita = new NExcepcionIngresoVisita();

            (List<DExcepcionIngresoVisita> listaExcepcionesIngreso, string errorResponse) = await nExcepcionIngresoVisita.ListaExcepcionesIngreso(this.dCiudadanoGlo.id_ciudadano);

            if (listaExcepcionesIngreso == null)
            {
                MessageBox.Show(errorResponse, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var datosfiltrados = listaExcepcionesIngreso
                .Select(c => new
                {
                    Id = c.id_excepcion_ingreso_visita,
                    FechaExcepcion = c.fecha_excepcion,
                    MotivoExcepcion = c.motivo,
                    Detalle = c.detalle_excepcion,
                    Interno = c.interno.apellido + " " + c.interno.nombre,
                    FechaCarga = c.fecha_carga,
                    VisitaOrdinaria = c.es_visita_ordinaria,
                    Organismo = c.organismo.organismo,
                    Usuario = c.usuario_carga.apellido + " " + c.usuario_carga.nombre,
                    Cumplimentado = c.cumplimentado,
                    Controlado = c.controlado,
                    Anulado = c.anulado

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

                dtgvExcepcionesIngreso.Columns[2].Width = 200;
                dtgvExcepcionesIngreso.Columns[3].Width = 400;
            }
        }

        private async void btnVerRegistroDiario_Click(object sender, EventArgs e)
        {
            if (this.txtIdCiudadano.Text == string.Empty)
            {
                MessageBox.Show("debe esperar que cargue los datos del ciudadano");
            }
            else
            {
                NRegistroDiario nRegistroDiario = new NRegistroDiario();
                (List<DRegistroDiario> listaRegistroDiario, string errorResponse) = await nRegistroDiario.RetornarListaXCiudadano(Convert.ToInt32(this.txtIdCiudadano.Text));

                if (listaRegistroDiario == null)
                {
                    MessageBox.Show(errorResponse, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                                
                var datosFiltrados = listaRegistroDiario
                .Select(c => new
                {
                    Ingreso = c.fecha_ingreso,
                    HoraIngreso = c.hora_ingreso,
                    HoraEgreso = c.hora_egreso,
                    TipoAtencion = c.tipo_atencion.tipo_atencion,
                    TipoAcceso = c.tipo_acceso.tipo_acceso,
                    SectorDestino = c.sector_destino.sector_destino,
                    MotivoAtencion = c.motivo_atencion.motivo_atencion,
                    Interno = c.interno,
                    Observacion = c.observaciones,
                    Organismo = c.organismo.organismo,
                    Usuario = c.usuario.apellido + " " + c.usuario.nombre

                })
                .ToList();

                dgvRegistroDiario.DataSource = datosFiltrados;

                if (listaRegistroDiario.Count == 0)
                {
                    MessageBox.Show("No se encontraron registros", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
        }

        private void btnInterno_Click(object sender, EventArgs e)
        {
            using (FormInternos formInternos = new FormInternos())
            {
                // Aquí se abre el FormularioB
                if (formInternos.ShowDialog() == DialogResult.OK)
                {
                    // Recién después de cerrar FormularioB, puedo leer el dato
                    txtIdInternoExcepcion.Text = formInternos.IdInternoSeleccionado;
                    txtInternoExcepcion.Text = formInternos.InternoSeleccionadoApellido + " " + formInternos.InternoSeleccionadoNombre;
                }
            }
        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }

        private void dtgvNovedades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox11_Enter(object sender, EventArgs e)
        {

        }

        //FIN METODO PARA OBTENER LA LISTA DE NOVEDADES EN UN DATA GRID ............................

        #endregion Excepxiones
        //FIN REGION EXCEPCIONES.........................................................
        //...............................................................................
    }


}
