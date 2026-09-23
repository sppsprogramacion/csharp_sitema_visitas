using CapaDatos;
using CapaNegocio;
using CapaPresentacion.Biometria;
using CapaPresentacion.FuncionesGenerales;
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
            int numeroFicha = Convert.ToInt32(txtNumeroFichaBuscar.Text);
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
        }//FIN PRocedimiento para bloquear dedos segun huella cargada

        
        //BLOQUEAR DEDOS SEGUN HUELLA CARGADA
        //----------------------------------------------------------------------------------------

    }
}
