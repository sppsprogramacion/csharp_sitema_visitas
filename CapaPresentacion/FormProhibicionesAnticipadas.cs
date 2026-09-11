using CapaDatos;
using CapaNegocio;
using CapaPresentacion.FuncionesGenerales;
using CapaPresentacion.Validaciones;
using CapaPresentacion.Validaciones.ProhibicionesAnticipadas.Datos;
using CapaPresentacion.Validaciones.ProhibicionesAnticipadas.ValidacionesProhibicionesAnticipadas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormProhibicionesAnticipadas : Form
    {
        //variable global
        public int idProhibicionAnticipadaGlobal { get; set; }

        private ErrorProvider errorProvider = new ErrorProvider();

        public FormProhibicionesAnticipadas()
        {
            InitializeComponent();
        }

        private async void FormProhibicionesAnticipadas_Load(object sender, EventArgs e)
        {
            //// Ajustar el tamaño del formulario            
            FormularioAyudas.AjustarFormulario(this);

            //CARGAR LISTA SEXO
            //Carga de combo sexo
            NSexo nSexo = new NSexo();
            (List<DSexo> listaSexo, string errorResponse) = await nSexo.RetornarListaSexo();

            if (listaSexo == null)
            {
                MessageBox.Show("Advertencia al cargar lista de sexos: " + errorResponse, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            cmbSexoVisita.ValueMember = "id_sexo";
            cmbSexoVisita.DisplayMember = "sexo";
            cmbSexoVisita.DataSource = listaSexo;
        }


        private void dtgvVisitas_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                this.idProhibicionAnticipadaGlobal = Convert.ToInt32(dtgvProhibicionesAnticipadas.CurrentRow.Cells["ID"].Value.ToString());

                if (dtgvProhibicionesAnticipadas.SelectedRows.Count > 0)
                {
                    if (this.idProhibicionAnticipadaGlobal > 0)
                    {
                        FormAdminProhibicionAnticipada formAdminProhibicionAnticipada = new FormAdminProhibicionAnticipada();
                        formAdminProhibicionAnticipada.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una prohibición.");
                    }
                }
            }
        }


        private async void btnBuscarApellido_Click(object sender, EventArgs e)
        {
            if (txtApellido.Text == "")
            {
                MessageBox.Show("Debe ingresar el apellido a buscar (minimo 2 caracteres)","Restricion Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NProhibicionVisitaAnticipada nProhibiciones = new NProhibicionVisitaAnticipada();
            (List<DProhibicionAnticipada> listaProhibiciones, string errorResponse) = await nProhibiciones.ListaProhibicionesXApellido(txtApellido.Text);

            if (listaProhibiciones == null)
            {
                MessageBox.Show(errorResponse, "Restricion Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var datosFiltrados = listaProhibiciones
                .Select(c => new
                {
                    ID = c.id_prohibicion_anticipada,
                    Apellido = c.apellido_visita,
                    Nombre = c.nombre_visita,
                    DNI = c.dni_visita,
                    Sexo = c.sexo.sexo,
                    Vigente = c.vigente

                })
                .ToList();

            dtgvProhibicionesAnticipadas.DataSource = datosFiltrados;

            if (listaProhibiciones.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                dtgvProhibicionesAnticipadas.Columns[0].Width = 90;
                dtgvProhibicionesAnticipadas.Columns[1].Width = 200;
                dtgvProhibicionesAnticipadas.Columns[2].Width = 200;
                dtgvProhibicionesAnticipadas.Columns[3].Width = 90;
                dtgvProhibicionesAnticipadas.Columns[4].Width = 90;
                dtgvProhibicionesAnticipadas.Columns[5].Width = 90;
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            var datosFormulario = new ProhibicionAnticipadaDatos
            {
                txtApellidoVisita = txtApellidoVisita.Text,
                txtNombreVisita = txtNombreVisita.Text,
                txtDniVisita = txtDniVisita.Text,
                cmbSexoVisita = cmbSexoVisita.SelectedValue?.ToString() ?? string.Empty,
                txtDetalleVisitaAnticipada = txtDetalleVisitaAnticipada.Text,
                txtApellidoInterno = txtApellidoInterno.Text,
                txtNombreInterno = txtNombreInterno.Text,
                dtpFechaInicio = dtpFechaInicio.Value,
                dtpFechaFin = dtpFechaFin.Value,
            };

            var validator = new ProhibicionAnticipadaNuevaValidator();
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
            //fin validar formulario

            NProhibicionVisitaAnticipada nProhibicion = new NProhibicionVisitaAnticipada();
            
            var data = new
            {
                dni_visita = Convert.ToInt32(txtDniVisita.Text),
                apellido_visita = txtApellidoVisita.Text,
                nombre_visita = txtNombreVisita.Text,
                sexo_id = cmbSexoVisita.SelectedValue,
                detalle = txtDetalleVisitaAnticipada.Text,
                apellido_interno = txtApellidoInterno.Text,
                nombre_interno = txtNombreInterno.Text,
                is_exinterno = chckExInterno.Checked,
                fecha_inicio = dtpFechaInicio.Value,
                fecha_fin = dtpFechaFin.Value
            };

            string dataProhibir = JsonConvert.SerializeObject(data);

            (DProhibicionAnticipada dataRespuesta, string errorResponse) = await nProhibicion.CrearProhibicion(dataProhibir);

            if (dataRespuesta != null)
            {
                MessageBox.Show("La prohibición se guardo correctamente", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.HabilitarControlesNuevo(false);
                                
            }
            else
            {
                MessageBox.Show(errorResponse, "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.HabilitarControlesNuevo(true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //limpiar errores de provider
            errorProvider.Clear();

            this.HabilitarControlesNuevo(false);
        }

        //HABILITAR CONTROLES
        private void HabilitarControlesNuevo(bool habilitar)
        {
            txtApellidoVisita.Enabled = habilitar;
            txtApellidoVisita.Text = "";
            txtNombreVisita.Enabled = habilitar;
            txtNombreVisita.Text = "";
            txtDniVisita.Enabled = habilitar;
            txtDniVisita.Text = "";
            cmbSexoVisita.Enabled = habilitar;
            dtpFechaInicio.Enabled = habilitar;
            dtpFechaFin.Enabled = habilitar;
            txtDetalleVisitaAnticipada.Enabled = habilitar;
            txtDetalleVisitaAnticipada.Text = "";
            txtApellidoInterno.Enabled = habilitar;
            txtApellidoInterno.Text = "";
            txtNombreInterno.Enabled = habilitar;
            txtNombreInterno.Text = "";
            chckExInterno.Enabled = habilitar;
                        
            btnNuevo.Enabled = !habilitar;
            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
            btnBuscarApellido.Enabled = !habilitar;
            btnInterno.Enabled = habilitar;
        }

        private void btnInterno_Click(object sender, EventArgs e)
        {
            using (FormInternos formInternos = new FormInternos())
            {
                // Aquí se abre el FormularioB
                if (formInternos.ShowDialog() == DialogResult.OK)
                {
                    // Recién después de cerrar FormularioB, puedo leer el dato
                    txtApellidoInterno.Text = formInternos.InternoSeleccionadoApellido;
                    txtNombreInterno.Text = formInternos.InternoSeleccionadoNombre;
                }
            }
        }
        //FIN HABILITAR CONTROLES...............................................

    }
}
