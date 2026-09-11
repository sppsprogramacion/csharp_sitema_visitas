using CapaDatos;
using CapaNegocio;
using CapaPresentacion.Validaciones.Login.Datos;
using CapaPresentacion.Validaciones.Login.ValidacionLogin;
using CommonCache;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormLogin : Form
    {
        private ErrorProvider errorProvider = new ErrorProvider();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.Multiline = true;
            txtUsuario.ScrollBars = ScrollBars.None;
            txtUsuario.TextAlign = HorizontalAlignment.Left;
            txtUsuario.Padding = new Padding(20, 20, 20, 0); // Ajusta para que se vea bien
            txtPassword.PasswordChar = '●';
            txtPassword.TextAlign = HorizontalAlignment.Left;
            txtPassword.Padding = new Padding(15, 15, 15, 15); // Ajusta para que se vea bien

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {

            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            var datosFormulario = new LoginDatos
            {
                txtUsuario = txtUsuario.Text,
                txtPassword = txtPassword.Text
            };

            var validator = new LoginValidator();
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
            //fin validadr formulario

            NAuth nAuth = new NAuth();

            var data = new
            {
                dni = txtUsuario.Text,
                clave = txtPassword.Text
            };

            string dataLogin = JsonConvert.SerializeObject(data);

            btnLogin.Enabled = false;
            btnCerrarSistema.Enabled = false;
            (bool acceso, string error) = await nAuth.LoginUsuario(dataLogin);
            btnLogin.Enabled = true;
            btnCerrarSistema.Enabled = true;

            if (acceso)
            {
                CurrentUser currentUser = CurrentUser.Instance;

                MessageBox.Show("Bienvenido " + currentUser.nombre + " " + currentUser.apellido, "Accesso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                FormPrincipal formPrincipal = new FormPrincipal();

                this.Hide();
                formPrincipal.Show();
            }
            else
            {
                MessageBox.Show($"{error}", "Error de inicio de sesion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
