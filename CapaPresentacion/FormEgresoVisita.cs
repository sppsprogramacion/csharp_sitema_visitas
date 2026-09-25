using CapaDatos;
using CapaNegocio;
using CapaPresentacion.Biometria;
using CapaPresentacion.FuncionesGenerales;
using CapaPresentacion.Reportes.IngresoVisistas;
using Newtonsoft.Json;
using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormEgresoVisita : Form
    {
        public FormEgresoVisita()
        {
            InitializeComponent();
        }

        private void FormEgresoVisita_Load(object sender, EventArgs e)
        {
            FormularioAyudas.AjustarFormulario(this);
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            NEntradaSalida nEntradaSalida = new NEntradaSalida();


            //BUSCAR CIUDADANO CON EL DNI
            this.Enabled = false;
            int numeroFicha = 0;
            //try
            //{
            //    numeroFicha = Convert.ToInt32(txtNumeroFichaBuscar.Text);

            //}
            //catch {
            //    MessageBox.Show("Debe ingresar un numero de ficha valido", "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            numeroFicha = Convert.ToInt32(txtNumeroFichaBuscar.Text);
            (DCiudadanoIngresoControl dCiudadanoIngresoResponse, string errorResponse) = await nEntradaSalida.BuscarCiudadanoIngresoControlXFicha(numeroFicha);

            if (dCiudadanoIngresoResponse == null)
            {
                MessageBox.Show(errorResponse, "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Enabled = true;

                return;
            }

            //CARGAR DATOS DEL CIUDADANO
            lblApellidoNombre.Text = dCiudadanoIngresoResponse.nombre_visita;
            picFotoVisita.Load(dCiudadanoIngresoResponse.foto_visita);
            txtDni.Text = dCiudadanoIngresoResponse.dni_visita.ToString();
            txtSexo.Text = dCiudadanoIngresoResponse.sexo_visita;
            txtFechaNacimiento.Text = dCiudadanoIngresoResponse.fecha_nacimiento_visita.ToShortDateString();
            txtEdad.Text = dCiudadanoIngresoResponse.edad_visita.ToString();

            //CARGAR DATOS DE INGRESO
            txtNumeroFicha.Text = dCiudadanoIngresoResponse.numero_ficha.ToString();
            txtIdIngreso.Text = dCiudadanoIngresoResponse.id_entrada_salida.ToString();
            txtNumeroFicha.Text = dCiudadanoIngresoResponse.numero_ficha.ToString();
            txtParentesco.Text = dCiudadanoIngresoResponse.parentesco;
            txtIntrno.Text = dCiudadanoIngresoResponse.nombre_interno;
            txtCasillero.Text = dCiudadanoIngresoResponse.casillero;
            txtFechaIngreso.Text = dCiudadanoIngresoResponse.fecha_registro.ToShortDateString();
            txtHoraIngreso.Text = dCiudadanoIngresoResponse.hora_registro;
            txtOrganismo.Text = dCiudadanoIngresoResponse.organismo;

            this.Enabled = true;


            this.ControlTieneDiscapacidad(dCiudadanoIngresoResponse.tiene_discapacidad, dCiudadanoIngresoResponse.discapacidad_detalle);
            this.ControlEdad(dCiudadanoIngresoResponse.edad_visita);

            //Cargar Huellas
            this.bloquearChecksHuellasCargadas(dCiudadanoIngresoResponse.huellasCiudadanoResponse);

            //Cargar menores
            var datosfiltradosMenores = dCiudadanoIngresoResponse.menoresIngresadosResponse
                .Select(c => new
                {
                    Id = c.id_ciudadano,
                    ApellidoNombre = c.nombre_menor,
                    Dni = c.dni,
                    Edad = c.edad,

                })
                .ToList();
            dtgMenores.DataSource = datosfiltradosMenores;

            
            //dimensionar columnas
            if (dCiudadanoIngresoResponse.menoresIngresadosResponse.Count > 0)
            {
                dtgMenores.Columns["Id"].Width = 40;
                dtgMenores.Columns["ApellidoNombre"].Width = 300;
                dtgMenores.Columns["Dni"].Width = 80;
                dtgMenores.Columns["Edad"].Width = 50;
            }
                        
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            this.InicializarContrles();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            //VALIDACIONES
            if (string.IsNullOrEmpty(txtIdIngreso.Text))
            {
                MessageBox.Show("Debe cargar datos del ingreso de un ciudadano para poder dar el egreso.", "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(txtObservaciones.Text.Trim().Length > 200)
            {
                MessageBox.Show("Las observaciones debe tener 200 caracteres como maximo.", "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            //FIN VALIDACIONES

            var data = new
            {
                
                observaciones_usuarios = txtObservaciones.Text.Trim(),
            };

            string dataEgreso = JsonConvert.SerializeObject(data);

            NEntradaSalida nEntradaSalida = new NEntradaSalida();

            this.Enabled = false;
            (bool respuestaEditar, string errorResponse) = await nEntradaSalida.EgresoPuertaPrincipal(Convert.ToInt32(txtIdIngreso.Text), dataEgreso);
            this.Enabled = true;

            if (respuestaEditar)
            {

                MessageBox.Show("El egreso se registró correctamente", "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.InicializarContrles();

            }
            else
            {
                MessageBox.Show(errorResponse, "Sistema Visitas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


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
            }
            else
            {
                lblDiscapacidad.Text = "NO TIENE DISCAPACIDAD";
                lblDiscapacidad.ForeColor = Color.White;
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
        }
        //FIN PRocedimiento para bloquear dedos segun huella cargada
        //-------------------------------------------------------------------------------

        //BLOQUEAR DEDOS SEGUN HUELLA CARGADA
        //----------------------------------------------------------------------------------------

        //INICIALIZAR CONTROLES
        private void InicializarContrles()
        {
            //CARGAR DATOS DEL CIUDADANO
            lblApellidoNombre.Text = string.Empty; ;
            picFotoVisita.Image = null;
            txtDni.Text = string.Empty; ;
            txtSexo.Text = string.Empty; ;
            txtFechaNacimiento.Text = string.Empty; ;
            txtEdad.Text = string.Empty; ;

            //CARGAR DATOS DE INGRESO
            txtNumeroFicha.Text = string.Empty; ;
            txtIdIngreso.Text = string.Empty; ;
            txtNumeroFicha.Text = string.Empty; ;
            txtParentesco.Text = string.Empty; ;
            txtIntrno.Text = string.Empty; ;
            txtCasillero.Text = string.Empty; ;
            txtFechaIngreso.Text = string.Empty; ;
            txtHoraIngreso.Text = string.Empty; ;
            txtOrganismo.Text = string.Empty;

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

            //picHuella.Visible = false;
            //fingerprintCapture.Stop();
            //lblLectorEstado.Text = "Lector detenido";
            //lblLectorDedo.Text = "Detenido...";


            dtgMenores.DataSource = null;
            txtCasillero.Text = string.Empty;
            btnBuscar.Enabled = true;
            txtNumeroFichaBuscar.Text = string.Empty;
            txtNumeroFichaBuscar.Focus();
        }
        //FINALIZAR INICIALIZAR CONTROLES
        //----------------------------------------------------------------------------
    }
}
