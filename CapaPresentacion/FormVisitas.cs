using CapaDatos;
using CapaNegocio;
using CapaPresentacion.FuncionesGenerales;
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
    public partial class FormVisitas : Form
    {
        //variable global id_ciudadano
        public int idCiudadanoGlobal { get; set; }

        
        public FormVisitas()
        {
            InitializeComponent();
        }

        private void Visitas_Load(object sender, EventArgs e)
        {
            FormularioAyudas.AjustarFormulario(this);             
        }

        private void dtgvVisitas_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                this.idCiudadanoGlobal = Convert.ToInt32(dtgvVisitas.CurrentRow.Cells["ID"].Value.ToString());

                if (dtgvVisitas.SelectedRows.Count > 0)
                {
                    if (this.idCiudadanoGlobal > 0)
                    {
                        FormAdminVisita formAdminVisita = new FormAdminVisita();
                        formAdminVisita.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un ciudadano.");
                    }
                }
            }
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private async void btnBuscarApellido_Click(object sender, EventArgs e)
        {
            NCiudadano nCiudadano = new NCiudadano();
            (List<DCiudadano> listaCiudadanos, string errorResponse) = await nCiudadano.RetornarListaCiudadanosXApellido(txtApellido.Text);

            if (listaCiudadanos == null)
            {
                MessageBox.Show(errorResponse, "Restricion Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var datosFiltrados = listaCiudadanos
                .Select(c => new
                {
                    ID = c.id_ciudadano,
                    Apellido = c.apellido,
                    Nombre = c.nombre,
                    DNI = c.dni,
                    Sexo = c.sexo.sexo

                })
                .ToList();

            dtgvVisitas.DataSource = datosFiltrados;

            if (listaCiudadanos.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                dtgvVisitas.Columns[0].Width = 90;
                dtgvVisitas.Columns[1].Width = 200;
                dtgvVisitas.Columns[2].Width = 200;
                dtgvVisitas.Columns[3].Width = 90;
                dtgvVisitas.Columns[4].Width = 90;
            }
        }

        private async void btnBuscarDni_Click(object sender, EventArgs e)
        {
            NCiudadano nCiudadano = new NCiudadano();
            (List<DCiudadano> listaCiudadanos, string errorResponse) = await nCiudadano.RetornarListaCiudadanosXDni(txtDni.Text);

            if (listaCiudadanos == null)
            {
                MessageBox.Show(errorResponse, "Restricion Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var datosFiltrados = listaCiudadanos
                .Select(c => new
                {
                    ID = c.id_ciudadano,
                    Apellido = c.apellido,
                    Nombre = c.nombre,
                    DNI = c.dni,
                    Sexo = c.sexo.sexo

                })
                .ToList();

            dtgvVisitas.DataSource = datosFiltrados;

            if (listaCiudadanos.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                dtgvVisitas.Columns[0].Width = 90;
                dtgvVisitas.Columns[1].Width = 200;
                dtgvVisitas.Columns[2].Width = 200;
                dtgvVisitas.Columns[3].Width = 90;
                dtgvVisitas.Columns[4].Width = 90;
            }
        }

       
    }
}
