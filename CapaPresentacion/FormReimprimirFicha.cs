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
    public partial class FormReimprimirFicha : Form
    {
        public FormReimprimirFicha()
        {
            InitializeComponent();
        }

        private void FormReimprimirFicha_Load(object sender, EventArgs e)
        {
            //// Ajustar el tamaño del formulario            
            FormularioAyudas.AjustarFormulario(this);

        }
    }
}
