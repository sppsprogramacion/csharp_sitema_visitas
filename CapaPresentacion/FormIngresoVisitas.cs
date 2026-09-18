using CapaDatos;
using CapaNegocio;
using CapaPresentacion.FuncionesGenerales;
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

namespace CapaPresentacion
{
    public partial class FormIngresoVisitas : Form
    {
        private ErrorProvider errorProvider = new ErrorProvider();


        public FormIngresoVisitas()
        {
            InitializeComponent();
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

            this.ControlTieneDiscapacidad(dCiudadanoIngresoResponse.ciudadanoResponse.tiene_discapacidad);
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
        }

        //GUARDAR ENTRADA SALIDA
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

           foreach(int id in idsMenoresSeleccionados){

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
                casillero = "",
                listaIdsMenores = idsMenoresSeleccionados
            };

            string dataEntrada = JsonConvert.SerializeObject(data);

            NEntradaSalida nEntradaSalida = new NEntradaSalida();
            this.Enabled = false;
            (DEntradaSalida dataRespuesta, string errorResponse) = await nEntradaSalida.CrearEntradaSalida(dataEntrada);
            this.Enabled = true;

            if (dataRespuesta != null)
            {
                MessageBox.Show("La entrada del ciudadano se guardo correctamente", "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        //FIN ENTRADA SALIDA
        //----------------------------------------------------------------



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
        private void ControlTieneDiscapacidad(bool tieneDiscapacidad)
        {
            if (tieneDiscapacidad)
            {
                lblDiscapacidad.Text = "TIENE DISCAPACIDAD";
                lblDiscapacidad.ForeColor = Color.DarkOrange;
                //lblDetalleTieneDiscapacidad.Text = dCiudadanoGlo.discapacidad_detalle;
                //lblDetalleTieneDiscapacidad.ForeColor = Color.SteelBlue;
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
        private async void bloquearChecksHuellasCargadas(List<DHuella> listaHuellas)
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
                        opPD.Enabled = false;
                        opPD.FlatStyle = FlatStyle.Flat;
                        opPD.BackColor = Color.Green;
                        break;

                    case 2:
                        opID.Enabled = false;
                        opID.FlatStyle = FlatStyle.Flat;
                        opID.BackColor = Color.Green;
                        break;

                    case 3:
                        opMAD.Enabled = false;
                        opMAD.FlatStyle = FlatStyle.Flat;
                        opMAD.BackColor = Color.Green;
                        break;

                    case 4:
                        opAD.Enabled = false;
                        opAD.FlatStyle = FlatStyle.Flat;
                        opAD.BackColor = Color.Green;
                        break;

                    case 5:
                        opMED.Enabled = false;
                        opMED.FlatStyle = FlatStyle.Flat;
                        opMED.BackColor = Color.Green;
                        break;

                    case 6:
                        opPI.Enabled = false;
                        opPI.FlatStyle = FlatStyle.Flat;
                        opPI.BackColor = Color.Green;
                        break;

                    case 7:
                        opII.Enabled = false;
                        opII.FlatStyle = FlatStyle.Flat;
                        opII.BackColor = Color.Green;
                        break;

                    case 8:
                        opMAI.Enabled = false;
                        opMAI.FlatStyle = FlatStyle.Flat;
                        opMAI.BackColor = Color.Green;
                        break;

                    case 9:
                        opAI.Enabled = false;
                        opAI.FlatStyle = FlatStyle.Flat;
                        opAI.BackColor = Color.Green;
                        break;

                    case 10:
                        opMEI.Enabled = false;
                        opMEI.FlatStyle = FlatStyle.Flat;
                        opMEI.BackColor = Color.Green;
                        break;

                    default:
                        break;


                }//fin switch
            }//fin foreach
        }//FIN PRocedimiento para bloquear dedos segun huella cargada
    }
}
