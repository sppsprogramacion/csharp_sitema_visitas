using CapaDatos;
using CapaNegocio;
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
    public partial class FormIngresoVisitas : Form
    {
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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            List<int> idsSeleccionados = new List<int>();

            foreach (DataGridViewRow row in dtgMenores.Rows)
            {
                bool seleccionado = Convert.ToBoolean(
                    row.Cells["Seleccionar"].Value ?? false
                );

                if (seleccionado)
                {
                    int id = Convert.ToInt32(row.Cells["Id"].Value);
                    idsSeleccionados.Add(id);
                }
            }

           foreach(int id in idsSeleccionados){

                MessageBox.Show("id: " + id); 
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


    }
}
