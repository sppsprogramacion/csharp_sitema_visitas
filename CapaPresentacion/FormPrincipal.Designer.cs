namespace CapaPresentacion
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.btnVerVisitas = new System.Windows.Forms.Button();
            this.lblEncabezado = new System.Windows.Forms.Label();
            this.btnCerrarSistema = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnIngresoVisita = new System.Windows.Forms.Button();
            this.btnEgresoVisitas = new System.Windows.Forms.Button();
            this.btnReimprimirFicha = new System.Windows.Forms.Button();
            this.btnImprimirComputo = new System.Windows.Forms.Button();
            this.btnActualizarComputo = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotalTotales = new System.Windows.Forms.Label();
            this.lblTotalesNoBinario = new System.Windows.Forms.Label();
            this.lblTotalesFemeninas = new System.Windows.Forms.Label();
            this.lblTotalesMasculinos = new System.Windows.Forms.Label();
            this.lblMenoresTotales = new System.Windows.Forms.Label();
            this.lblMenoresNoBinario = new System.Windows.Forms.Label();
            this.lblMenoresFemeninas = new System.Windows.Forms.Label();
            this.lblMenoresMasculinos = new System.Windows.Forms.Label();
            this.lblAdultosTotales = new System.Windows.Forms.Label();
            this.lblAdultosNoBinarios = new System.Windows.Forms.Label();
            this.lblAdultosFemeninas = new System.Windows.Forms.Label();
            this.lblAdultosMasculinos = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVerVisitas
            // 
            this.btnVerVisitas.BackColor = System.Drawing.Color.Indigo;
            this.btnVerVisitas.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.btnVerVisitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerVisitas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerVisitas.ForeColor = System.Drawing.Color.White;
            this.btnVerVisitas.Location = new System.Drawing.Point(155, 144);
            this.btnVerVisitas.Name = "btnVerVisitas";
            this.btnVerVisitas.Size = new System.Drawing.Size(120, 70);
            this.btnVerVisitas.TabIndex = 0;
            this.btnVerVisitas.Text = "Visitas";
            this.btnVerVisitas.UseVisualStyleBackColor = false;
            this.btnVerVisitas.Click += new System.EventHandler(this.btnVerVisitas_Click);
            // 
            // lblEncabezado
            // 
            this.lblEncabezado.BackColor = System.Drawing.Color.SteelBlue;
            this.lblEncabezado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncabezado.ForeColor = System.Drawing.Color.White;
            this.lblEncabezado.Location = new System.Drawing.Point(1, 1);
            this.lblEncabezado.Name = "lblEncabezado";
            this.lblEncabezado.Size = new System.Drawing.Size(903, 29);
            this.lblEncabezado.TabIndex = 76;
            this.lblEncabezado.Text = "SISTEMA DE VISITAS";
            this.lblEncabezado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCerrarSistema
            // 
            this.btnCerrarSistema.BackColor = System.Drawing.Color.Red;
            this.btnCerrarSistema.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnCerrarSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSistema.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSistema.Location = new System.Drawing.Point(811, 549);
            this.btnCerrarSistema.Name = "btnCerrarSistema";
            this.btnCerrarSistema.Size = new System.Drawing.Size(93, 45);
            this.btnCerrarSistema.TabIndex = 50;
            this.btnCerrarSistema.Text = "Cerrar sistema";
            this.btnCerrarSistema.UseVisualStyleBackColor = false;
            this.btnCerrarSistema.Click += new System.EventHandler(this.btnCerrarSistema_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(40, 574);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(50, 16);
            this.lblUsuario.TabIndex = 78;
            this.lblUsuario.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.usuario;
            this.pictureBox1.Location = new System.Drawing.Point(12, 569);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 77;
            this.pictureBox1.TabStop = false;
            // 
            // btnIngresoVisita
            // 
            this.btnIngresoVisita.BackColor = System.Drawing.Color.Indigo;
            this.btnIngresoVisita.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.btnIngresoVisita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresoVisita.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresoVisita.ForeColor = System.Drawing.Color.White;
            this.btnIngresoVisita.Location = new System.Drawing.Point(23, 56);
            this.btnIngresoVisita.Name = "btnIngresoVisita";
            this.btnIngresoVisita.Size = new System.Drawing.Size(120, 70);
            this.btnIngresoVisita.TabIndex = 80;
            this.btnIngresoVisita.Text = "Ingreso de visitas";
            this.btnIngresoVisita.UseVisualStyleBackColor = false;
            this.btnIngresoVisita.Click += new System.EventHandler(this.btnIngresoVisita_Click);
            // 
            // btnEgresoVisitas
            // 
            this.btnEgresoVisitas.BackColor = System.Drawing.Color.DarkOrange;
            this.btnEgresoVisitas.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btnEgresoVisitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEgresoVisitas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEgresoVisitas.ForeColor = System.Drawing.Color.White;
            this.btnEgresoVisitas.Location = new System.Drawing.Point(155, 56);
            this.btnEgresoVisitas.Name = "btnEgresoVisitas";
            this.btnEgresoVisitas.Size = new System.Drawing.Size(120, 70);
            this.btnEgresoVisitas.TabIndex = 81;
            this.btnEgresoVisitas.Text = "Egreso de visitas";
            this.btnEgresoVisitas.UseVisualStyleBackColor = false;
            this.btnEgresoVisitas.Click += new System.EventHandler(this.btnEgresoVisitas_Click);
            // 
            // btnReimprimirFicha
            // 
            this.btnReimprimirFicha.BackColor = System.Drawing.Color.Indigo;
            this.btnReimprimirFicha.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.btnReimprimirFicha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReimprimirFicha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReimprimirFicha.ForeColor = System.Drawing.Color.White;
            this.btnReimprimirFicha.Location = new System.Drawing.Point(23, 144);
            this.btnReimprimirFicha.Name = "btnReimprimirFicha";
            this.btnReimprimirFicha.Size = new System.Drawing.Size(120, 70);
            this.btnReimprimirFicha.TabIndex = 82;
            this.btnReimprimirFicha.Text = "Reimprimir ficha";
            this.btnReimprimirFicha.UseVisualStyleBackColor = false;
            this.btnReimprimirFicha.Click += new System.EventHandler(this.btnReimprimirFicha_Click);
            // 
            // btnImprimirComputo
            // 
            this.btnImprimirComputo.BackColor = System.Drawing.Color.SteelBlue;
            this.btnImprimirComputo.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnImprimirComputo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirComputo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirComputo.ForeColor = System.Drawing.Color.White;
            this.btnImprimirComputo.Location = new System.Drawing.Point(708, 262);
            this.btnImprimirComputo.Name = "btnImprimirComputo";
            this.btnImprimirComputo.Size = new System.Drawing.Size(194, 40);
            this.btnImprimirComputo.TabIndex = 130;
            this.btnImprimirComputo.Text = "Imprimir computo";
            this.btnImprimirComputo.UseVisualStyleBackColor = false;
            // 
            // btnActualizarComputo
            // 
            this.btnActualizarComputo.BackColor = System.Drawing.Color.SteelBlue;
            this.btnActualizarComputo.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnActualizarComputo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarComputo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarComputo.ForeColor = System.Drawing.Color.White;
            this.btnActualizarComputo.Location = new System.Drawing.Point(500, 262);
            this.btnActualizarComputo.Name = "btnActualizarComputo";
            this.btnActualizarComputo.Size = new System.Drawing.Size(194, 40);
            this.btnActualizarComputo.TabIndex = 129;
            this.btnActualizarComputo.Text = "Actualizar computo";
            this.btnActualizarComputo.UseVisualStyleBackColor = false;
            this.btnActualizarComputo.Click += new System.EventHandler(this.btnActualizarComputo_Click);
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(392, 141);
            this.label21.Margin = new System.Windows.Forms.Padding(0);
            this.label21.Name = "label21";
            this.label21.Padding = new System.Windows.Forms.Padding(5);
            this.label21.Size = new System.Drawing.Size(90, 48);
            this.label21.TabIndex = 128;
            this.label21.Text = "MENORES";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(392, 193);
            this.label20.Margin = new System.Windows.Forms.Padding(0);
            this.label20.Name = "label20";
            this.label20.Padding = new System.Windows.Forms.Padding(5);
            this.label20.Size = new System.Drawing.Size(90, 48);
            this.label20.TabIndex = 127;
            this.label20.Text = "TOTALES";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(391, 89);
            this.label19.Margin = new System.Windows.Forms.Padding(0);
            this.label19.Name = "label19";
            this.label19.Padding = new System.Windows.Forms.Padding(5);
            this.label19.Size = new System.Drawing.Size(90, 48);
            this.label19.TabIndex = 126;
            this.label19.Text = "ADULTOS";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(797, 56);
            this.label18.Margin = new System.Windows.Forms.Padding(0);
            this.label18.Name = "label18";
            this.label18.Padding = new System.Windows.Forms.Padding(5);
            this.label18.Size = new System.Drawing.Size(100, 30);
            this.label18.TabIndex = 125;
            this.label18.Text = "TOTALES";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(693, 56);
            this.label17.Margin = new System.Windows.Forms.Padding(0);
            this.label17.Name = "label17";
            this.label17.Padding = new System.Windows.Forms.Padding(5);
            this.label17.Size = new System.Drawing.Size(100, 30);
            this.label17.TabIndex = 124;
            this.label17.Text = "NO BINARIO";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(589, 56);
            this.label16.Margin = new System.Windows.Forms.Padding(0);
            this.label16.Name = "label16";
            this.label16.Padding = new System.Windows.Forms.Padding(5);
            this.label16.Size = new System.Drawing.Size(100, 30);
            this.label16.TabIndex = 123;
            this.label16.Text = "FEMENINAS";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(485, 56);
            this.label15.Margin = new System.Windows.Forms.Padding(0);
            this.label15.Name = "label15";
            this.label15.Padding = new System.Windows.Forms.Padding(5);
            this.label15.Size = new System.Drawing.Size(100, 30);
            this.label15.TabIndex = 122;
            this.label15.Text = "MASCULINOS";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(391, 56);
            this.label14.Margin = new System.Windows.Forms.Padding(0);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(5);
            this.label14.Size = new System.Drawing.Size(90, 30);
            this.label14.TabIndex = 121;
            this.label14.Text = "CATEGORIA";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalTotales
            // 
            this.lblTotalTotales.BackColor = System.Drawing.Color.Teal;
            this.lblTotalTotales.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTotales.ForeColor = System.Drawing.Color.White;
            this.lblTotalTotales.Location = new System.Drawing.Point(797, 193);
            this.lblTotalTotales.Name = "lblTotalTotales";
            this.lblTotalTotales.Padding = new System.Windows.Forms.Padding(5);
            this.lblTotalTotales.Size = new System.Drawing.Size(100, 48);
            this.lblTotalTotales.TabIndex = 120;
            this.lblTotalTotales.Text = "0";
            this.lblTotalTotales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalesNoBinario
            // 
            this.lblTotalesNoBinario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalesNoBinario.ForeColor = System.Drawing.Color.White;
            this.lblTotalesNoBinario.Location = new System.Drawing.Point(693, 193);
            this.lblTotalesNoBinario.Name = "lblTotalesNoBinario";
            this.lblTotalesNoBinario.Padding = new System.Windows.Forms.Padding(5);
            this.lblTotalesNoBinario.Size = new System.Drawing.Size(100, 48);
            this.lblTotalesNoBinario.TabIndex = 119;
            this.lblTotalesNoBinario.Text = "0";
            this.lblTotalesNoBinario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalesFemeninas
            // 
            this.lblTotalesFemeninas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalesFemeninas.ForeColor = System.Drawing.Color.White;
            this.lblTotalesFemeninas.Location = new System.Drawing.Point(589, 193);
            this.lblTotalesFemeninas.Name = "lblTotalesFemeninas";
            this.lblTotalesFemeninas.Padding = new System.Windows.Forms.Padding(5);
            this.lblTotalesFemeninas.Size = new System.Drawing.Size(100, 48);
            this.lblTotalesFemeninas.TabIndex = 118;
            this.lblTotalesFemeninas.Text = "0";
            this.lblTotalesFemeninas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalesMasculinos
            // 
            this.lblTotalesMasculinos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalesMasculinos.ForeColor = System.Drawing.Color.White;
            this.lblTotalesMasculinos.Location = new System.Drawing.Point(485, 193);
            this.lblTotalesMasculinos.Name = "lblTotalesMasculinos";
            this.lblTotalesMasculinos.Padding = new System.Windows.Forms.Padding(5);
            this.lblTotalesMasculinos.Size = new System.Drawing.Size(100, 48);
            this.lblTotalesMasculinos.TabIndex = 117;
            this.lblTotalesMasculinos.Text = "0";
            this.lblTotalesMasculinos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMenoresTotales
            // 
            this.lblMenoresTotales.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenoresTotales.ForeColor = System.Drawing.Color.White;
            this.lblMenoresTotales.Location = new System.Drawing.Point(797, 141);
            this.lblMenoresTotales.Name = "lblMenoresTotales";
            this.lblMenoresTotales.Padding = new System.Windows.Forms.Padding(5);
            this.lblMenoresTotales.Size = new System.Drawing.Size(100, 48);
            this.lblMenoresTotales.TabIndex = 116;
            this.lblMenoresTotales.Text = "0";
            this.lblMenoresTotales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMenoresNoBinario
            // 
            this.lblMenoresNoBinario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenoresNoBinario.ForeColor = System.Drawing.Color.White;
            this.lblMenoresNoBinario.Location = new System.Drawing.Point(693, 141);
            this.lblMenoresNoBinario.Name = "lblMenoresNoBinario";
            this.lblMenoresNoBinario.Padding = new System.Windows.Forms.Padding(5);
            this.lblMenoresNoBinario.Size = new System.Drawing.Size(100, 48);
            this.lblMenoresNoBinario.TabIndex = 115;
            this.lblMenoresNoBinario.Text = "0";
            this.lblMenoresNoBinario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMenoresFemeninas
            // 
            this.lblMenoresFemeninas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenoresFemeninas.ForeColor = System.Drawing.Color.White;
            this.lblMenoresFemeninas.Location = new System.Drawing.Point(589, 141);
            this.lblMenoresFemeninas.Name = "lblMenoresFemeninas";
            this.lblMenoresFemeninas.Padding = new System.Windows.Forms.Padding(5);
            this.lblMenoresFemeninas.Size = new System.Drawing.Size(100, 48);
            this.lblMenoresFemeninas.TabIndex = 114;
            this.lblMenoresFemeninas.Text = "0";
            this.lblMenoresFemeninas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMenoresMasculinos
            // 
            this.lblMenoresMasculinos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenoresMasculinos.ForeColor = System.Drawing.Color.White;
            this.lblMenoresMasculinos.Location = new System.Drawing.Point(485, 141);
            this.lblMenoresMasculinos.Name = "lblMenoresMasculinos";
            this.lblMenoresMasculinos.Padding = new System.Windows.Forms.Padding(5);
            this.lblMenoresMasculinos.Size = new System.Drawing.Size(100, 48);
            this.lblMenoresMasculinos.TabIndex = 113;
            this.lblMenoresMasculinos.Text = "0";
            this.lblMenoresMasculinos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAdultosTotales
            // 
            this.lblAdultosTotales.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdultosTotales.ForeColor = System.Drawing.Color.White;
            this.lblAdultosTotales.Location = new System.Drawing.Point(797, 89);
            this.lblAdultosTotales.Name = "lblAdultosTotales";
            this.lblAdultosTotales.Padding = new System.Windows.Forms.Padding(5);
            this.lblAdultosTotales.Size = new System.Drawing.Size(100, 48);
            this.lblAdultosTotales.TabIndex = 112;
            this.lblAdultosTotales.Text = "0";
            this.lblAdultosTotales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAdultosNoBinarios
            // 
            this.lblAdultosNoBinarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdultosNoBinarios.ForeColor = System.Drawing.Color.White;
            this.lblAdultosNoBinarios.Location = new System.Drawing.Point(693, 89);
            this.lblAdultosNoBinarios.Name = "lblAdultosNoBinarios";
            this.lblAdultosNoBinarios.Padding = new System.Windows.Forms.Padding(5);
            this.lblAdultosNoBinarios.Size = new System.Drawing.Size(100, 48);
            this.lblAdultosNoBinarios.TabIndex = 111;
            this.lblAdultosNoBinarios.Text = "0";
            this.lblAdultosNoBinarios.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAdultosFemeninas
            // 
            this.lblAdultosFemeninas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdultosFemeninas.ForeColor = System.Drawing.Color.White;
            this.lblAdultosFemeninas.Location = new System.Drawing.Point(589, 89);
            this.lblAdultosFemeninas.Name = "lblAdultosFemeninas";
            this.lblAdultosFemeninas.Padding = new System.Windows.Forms.Padding(5);
            this.lblAdultosFemeninas.Size = new System.Drawing.Size(100, 48);
            this.lblAdultosFemeninas.TabIndex = 110;
            this.lblAdultosFemeninas.Text = "0";
            this.lblAdultosFemeninas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAdultosMasculinos
            // 
            this.lblAdultosMasculinos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdultosMasculinos.ForeColor = System.Drawing.Color.White;
            this.lblAdultosMasculinos.Location = new System.Drawing.Point(485, 89);
            this.lblAdultosMasculinos.Margin = new System.Windows.Forms.Padding(0);
            this.lblAdultosMasculinos.Name = "lblAdultosMasculinos";
            this.lblAdultosMasculinos.Padding = new System.Windows.Forms.Padding(5);
            this.lblAdultosMasculinos.Size = new System.Drawing.Size(100, 48);
            this.lblAdultosMasculinos.TabIndex = 109;
            this.lblAdultosMasculinos.Text = "0";
            this.lblAdultosMasculinos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(388, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(513, 192);
            this.label1.TabIndex = 108;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(103)))), ((int)(((byte)(153)))));
            this.ClientSize = new System.Drawing.Size(916, 606);
            this.Controls.Add(this.btnImprimirComputo);
            this.Controls.Add(this.btnActualizarComputo);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblTotalTotales);
            this.Controls.Add(this.lblTotalesNoBinario);
            this.Controls.Add(this.lblTotalesFemeninas);
            this.Controls.Add(this.lblTotalesMasculinos);
            this.Controls.Add(this.lblMenoresTotales);
            this.Controls.Add(this.lblMenoresNoBinario);
            this.Controls.Add(this.lblMenoresFemeninas);
            this.Controls.Add(this.lblMenoresMasculinos);
            this.Controls.Add(this.lblAdultosTotales);
            this.Controls.Add(this.lblAdultosNoBinarios);
            this.Controls.Add(this.lblAdultosFemeninas);
            this.Controls.Add(this.lblAdultosMasculinos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReimprimirFicha);
            this.Controls.Add(this.btnEgresoVisitas);
            this.Controls.Add(this.btnIngresoVisita);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCerrarSistema);
            this.Controls.Add(this.lblEncabezado);
            this.Controls.Add(this.btnVerVisitas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVerVisitas;
        private System.Windows.Forms.Label lblEncabezado;
        private System.Windows.Forms.Button btnCerrarSistema;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnIngresoVisita;
        private System.Windows.Forms.Button btnEgresoVisitas;
        private System.Windows.Forms.Button btnReimprimirFicha;
        private System.Windows.Forms.Button btnImprimirComputo;
        private System.Windows.Forms.Button btnActualizarComputo;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTotalTotales;
        private System.Windows.Forms.Label lblTotalesNoBinario;
        private System.Windows.Forms.Label lblTotalesFemeninas;
        private System.Windows.Forms.Label lblTotalesMasculinos;
        private System.Windows.Forms.Label lblMenoresTotales;
        private System.Windows.Forms.Label lblMenoresNoBinario;
        private System.Windows.Forms.Label lblMenoresFemeninas;
        private System.Windows.Forms.Label lblMenoresMasculinos;
        private System.Windows.Forms.Label lblAdultosTotales;
        private System.Windows.Forms.Label lblAdultosNoBinarios;
        private System.Windows.Forms.Label lblAdultosFemeninas;
        private System.Windows.Forms.Label lblAdultosMasculinos;
        private System.Windows.Forms.Label label1;
    }
}

