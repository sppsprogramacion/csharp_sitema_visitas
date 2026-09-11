namespace CapaPresentacion
{
    partial class FormAdminProhibicionAnticipada
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdminProhibicionAnticipada));
            this.label28 = new System.Windows.Forms.Label();
            this.pagHistorial = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDatosModificados = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.txtUsuarioHistorial = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtDetalleMotivo = new System.Windows.Forms.TextBox();
            this.txtOrganismoHistorial = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.txtFechaHistorial = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.txtIdHistorial = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.dtgvNovedades = new System.Windows.Forms.DataGridView();
            this.btnVerNovedades = new System.Windows.Forms.Button();
            this.pagProhibicion = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLevantar = new System.Windows.Forms.Button();
            this.btnCancelarLevantar = new System.Windows.Forms.Button();
            this.btnGuardarLevantar = new System.Windows.Forms.Button();
            this.label38 = new System.Windows.Forms.Label();
            this.txtMotivoLevantar = new System.Windows.Forms.TextBox();
            this.dtpFechaFinLevantar = new System.Windows.Forms.DateTimePicker();
            this.label37 = new System.Windows.Forms.Label();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.txtMotivoDetalle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.btnEditarProhibicion = new System.Windows.Forms.Button();
            this.btnGuardarProhibicion = new System.Windows.Forms.Button();
            this.btnCancelarProhibicion = new System.Windows.Forms.Button();
            this.txtIdProhibicionAnticipada = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSexoVisita = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkProhibicionVigente = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkExInterno = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDetalleProhibicionAnticipada = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtFechaProhibicion = new System.Windows.Forms.TextBox();
            this.txtOrganismoAlta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsuarioAlta = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTipoLevantamiento = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.txtNombreInterno = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtApellidoInterno = new System.Windows.Forms.TextBox();
            this.txtDniVisita = new System.Windows.Forms.TextBox();
            this.txtNombreVisita = new System.Windows.Forms.TextBox();
            this.txtApellidoVisita = new System.Windows.Forms.TextBox();
            this.tabVisita = new System.Windows.Forms.TabControl();
            this.pagHistorial.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvNovedades)).BeginInit();
            this.pagProhibicion.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.tabVisita.SuspendLayout();
            this.SuspendLayout();
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Indigo;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(2, 1);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(1090, 29);
            this.label28.TabIndex = 74;
            this.label28.Text = "ADMINISTRAR PROHIBICION ANTICIPADA";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pagHistorial
            // 
            this.pagHistorial.Controls.Add(this.groupBox10);
            this.pagHistorial.Controls.Add(this.dtgvNovedades);
            this.pagHistorial.Controls.Add(this.btnVerNovedades);
            this.pagHistorial.Location = new System.Drawing.Point(4, 25);
            this.pagHistorial.Name = "pagHistorial";
            this.pagHistorial.Padding = new System.Windows.Forms.Padding(3);
            this.pagHistorial.Size = new System.Drawing.Size(1070, 626);
            this.pagHistorial.TabIndex = 1;
            this.pagHistorial.Text = "Historial";
            this.pagHistorial.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label11);
            this.groupBox10.Controls.Add(this.txtDatosModificados);
            this.groupBox10.Controls.Add(this.label47);
            this.groupBox10.Controls.Add(this.txtMotivo);
            this.groupBox10.Controls.Add(this.txtUsuarioHistorial);
            this.groupBox10.Controls.Add(this.label23);
            this.groupBox10.Controls.Add(this.label20);
            this.groupBox10.Controls.Add(this.txtDetalleMotivo);
            this.groupBox10.Controls.Add(this.txtOrganismoHistorial);
            this.groupBox10.Controls.Add(this.label43);
            this.groupBox10.Controls.Add(this.txtFechaHistorial);
            this.groupBox10.Controls.Add(this.label45);
            this.groupBox10.Controls.Add(this.txtIdHistorial);
            this.groupBox10.Controls.Add(this.label46);
            this.groupBox10.Location = new System.Drawing.Point(8, 347);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(1035, 248);
            this.groupBox10.TabIndex = 83;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Historial";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 147);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 15);
            this.label11.TabIndex = 88;
            this.label11.Text = "DATOS MODIFICADOS:";
            // 
            // txtDatosModificados
            // 
            this.txtDatosModificados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDatosModificados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatosModificados.Location = new System.Drawing.Point(9, 166);
            this.txtDatosModificados.Multiline = true;
            this.txtDatosModificados.Name = "txtDatosModificados";
            this.txtDatosModificados.ReadOnly = true;
            this.txtDatosModificados.Size = new System.Drawing.Size(1011, 70);
            this.txtDatosModificados.TabIndex = 87;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(6, 63);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(56, 15);
            this.label47.TabIndex = 86;
            this.label47.Text = "MOTIVO:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivo.Location = new System.Drawing.Point(9, 82);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.ReadOnly = true;
            this.txtMotivo.Size = new System.Drawing.Size(317, 60);
            this.txtMotivo.TabIndex = 85;
            // 
            // txtUsuarioHistorial
            // 
            this.txtUsuarioHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioHistorial.Location = new System.Drawing.Point(570, 36);
            this.txtUsuarioHistorial.Name = "txtUsuarioHistorial";
            this.txtUsuarioHistorial.ReadOnly = true;
            this.txtUsuarioHistorial.Size = new System.Drawing.Size(227, 21);
            this.txtUsuarioHistorial.TabIndex = 84;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(566, 17);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 15);
            this.label23.TabIndex = 83;
            this.label23.Text = "USUARIO:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(335, 63);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(112, 15);
            this.label20.TabIndex = 82;
            this.label20.Text = "DETALLE MOTIVO:";
            // 
            // txtDetalleMotivo
            // 
            this.txtDetalleMotivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetalleMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetalleMotivo.Location = new System.Drawing.Point(338, 82);
            this.txtDetalleMotivo.Multiline = true;
            this.txtDetalleMotivo.Name = "txtDetalleMotivo";
            this.txtDetalleMotivo.ReadOnly = true;
            this.txtDetalleMotivo.Size = new System.Drawing.Size(682, 60);
            this.txtDetalleMotivo.TabIndex = 81;
            // 
            // txtOrganismoHistorial
            // 
            this.txtOrganismoHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrganismoHistorial.Location = new System.Drawing.Point(210, 36);
            this.txtOrganismoHistorial.Name = "txtOrganismoHistorial";
            this.txtOrganismoHistorial.ReadOnly = true;
            this.txtOrganismoHistorial.Size = new System.Drawing.Size(349, 21);
            this.txtOrganismoHistorial.TabIndex = 80;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(6, 17);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(22, 15);
            this.label43.TabIndex = 78;
            this.label43.Text = "ID:";
            // 
            // txtFechaHistorial
            // 
            this.txtFechaHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaHistorial.Location = new System.Drawing.Point(103, 37);
            this.txtFechaHistorial.Name = "txtFechaHistorial";
            this.txtFechaHistorial.ReadOnly = true;
            this.txtFechaHistorial.Size = new System.Drawing.Size(95, 21);
            this.txtFechaHistorial.TabIndex = 64;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(100, 17);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(49, 15);
            this.label45.TabIndex = 66;
            this.label45.Text = "FECHA:";
            // 
            // txtIdHistorial
            // 
            this.txtIdHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdHistorial.Location = new System.Drawing.Point(9, 37);
            this.txtIdHistorial.Name = "txtIdHistorial";
            this.txtIdHistorial.ReadOnly = true;
            this.txtIdHistorial.Size = new System.Drawing.Size(80, 21);
            this.txtIdHistorial.TabIndex = 77;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(206, 17);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(84, 15);
            this.label46.TabIndex = 72;
            this.label46.Text = "ORGANISMO:";
            // 
            // dtgvNovedades
            // 
            this.dtgvNovedades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvNovedades.Location = new System.Drawing.Point(8, 61);
            this.dtgvNovedades.Name = "dtgvNovedades";
            this.dtgvNovedades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvNovedades.Size = new System.Drawing.Size(1035, 279);
            this.dtgvNovedades.TabIndex = 2;
            this.dtgvNovedades.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgvNovedades_KeyDown);
            // 
            // btnVerNovedades
            // 
            this.btnVerNovedades.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnVerNovedades.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnVerNovedades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerNovedades.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerNovedades.ForeColor = System.Drawing.Color.White;
            this.btnVerNovedades.Location = new System.Drawing.Point(8, 8);
            this.btnVerNovedades.Name = "btnVerNovedades";
            this.btnVerNovedades.Size = new System.Drawing.Size(141, 45);
            this.btnVerNovedades.TabIndex = 1;
            this.btnVerNovedades.Text = "VER HISTORIAL";
            this.btnVerNovedades.UseVisualStyleBackColor = false;
            this.btnVerNovedades.Click += new System.EventHandler(this.btnVerNovedades_Click);
            // 
            // pagProhibicion
            // 
            this.pagProhibicion.Controls.Add(this.groupBox2);
            this.pagProhibicion.Controls.Add(this.groupBox14);
            this.pagProhibicion.Location = new System.Drawing.Point(4, 25);
            this.pagProhibicion.Name = "pagProhibicion";
            this.pagProhibicion.Padding = new System.Windows.Forms.Padding(3);
            this.pagProhibicion.Size = new System.Drawing.Size(1070, 626);
            this.pagProhibicion.TabIndex = 0;
            this.pagProhibicion.Text = "Prohibicion";
            this.pagProhibicion.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLevantar);
            this.groupBox2.Controls.Add(this.btnCancelarLevantar);
            this.groupBox2.Controls.Add(this.btnGuardarLevantar);
            this.groupBox2.Controls.Add(this.label38);
            this.groupBox2.Controls.Add(this.txtMotivoLevantar);
            this.groupBox2.Controls.Add(this.dtpFechaFinLevantar);
            this.groupBox2.Controls.Add(this.label37);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(657, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 290);
            this.groupBox2.TabIndex = 93;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Levantar";
            // 
            // btnLevantar
            // 
            this.btnLevantar.BackColor = System.Drawing.Color.Indigo;
            this.btnLevantar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLevantar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLevantar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLevantar.ForeColor = System.Drawing.Color.White;
            this.btnLevantar.Location = new System.Drawing.Point(10, 21);
            this.btnLevantar.Name = "btnLevantar";
            this.btnLevantar.Size = new System.Drawing.Size(101, 37);
            this.btnLevantar.TabIndex = 14;
            this.btnLevantar.Text = "LEVANTAR";
            this.btnLevantar.UseVisualStyleBackColor = false;
            this.btnLevantar.Click += new System.EventHandler(this.btnLevantar_Click);
            // 
            // btnCancelarLevantar
            // 
            this.btnCancelarLevantar.BackColor = System.Drawing.Color.DarkOrange;
            this.btnCancelarLevantar.Enabled = false;
            this.btnCancelarLevantar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancelarLevantar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarLevantar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarLevantar.ForeColor = System.Drawing.Color.White;
            this.btnCancelarLevantar.Location = new System.Drawing.Point(111, 239);
            this.btnCancelarLevantar.Name = "btnCancelarLevantar";
            this.btnCancelarLevantar.Size = new System.Drawing.Size(98, 40);
            this.btnCancelarLevantar.TabIndex = 18;
            this.btnCancelarLevantar.Text = "CANCELAR";
            this.btnCancelarLevantar.UseVisualStyleBackColor = false;
            this.btnCancelarLevantar.Click += new System.EventHandler(this.btnCancelarLevantar_Click);
            // 
            // btnGuardarLevantar
            // 
            this.btnGuardarLevantar.BackColor = System.Drawing.Color.Green;
            this.btnGuardarLevantar.Enabled = false;
            this.btnGuardarLevantar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarLevantar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarLevantar.ForeColor = System.Drawing.Color.White;
            this.btnGuardarLevantar.Location = new System.Drawing.Point(10, 239);
            this.btnGuardarLevantar.Name = "btnGuardarLevantar";
            this.btnGuardarLevantar.Size = new System.Drawing.Size(98, 40);
            this.btnGuardarLevantar.TabIndex = 17;
            this.btnGuardarLevantar.Text = "GUARDAR";
            this.btnGuardarLevantar.UseVisualStyleBackColor = false;
            this.btnGuardarLevantar.Click += new System.EventHandler(this.btnGuardarLevantar_Click);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(7, 122);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(56, 15);
            this.label38.TabIndex = 78;
            this.label38.Text = "MOTIVO:";
            // 
            // txtMotivoLevantar
            // 
            this.txtMotivoLevantar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMotivoLevantar.Enabled = false;
            this.txtMotivoLevantar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivoLevantar.Location = new System.Drawing.Point(10, 141);
            this.txtMotivoLevantar.Multiline = true;
            this.txtMotivoLevantar.Name = "txtMotivoLevantar";
            this.txtMotivoLevantar.Size = new System.Drawing.Size(376, 85);
            this.txtMotivoLevantar.TabIndex = 16;
            // 
            // dtpFechaFinLevantar
            // 
            this.dtpFechaFinLevantar.Enabled = false;
            this.dtpFechaFinLevantar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFinLevantar.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinLevantar.Location = new System.Drawing.Point(10, 87);
            this.dtpFechaFinLevantar.Name = "dtpFechaFinLevantar";
            this.dtpFechaFinLevantar.Size = new System.Drawing.Size(115, 21);
            this.dtpFechaFinLevantar.TabIndex = 15;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(7, 68);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(71, 15);
            this.label37.TabIndex = 44;
            this.label37.Text = "FECHA FIN:";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.txtMotivoDetalle);
            this.groupBox14.Controls.Add(this.label9);
            this.groupBox14.Controls.Add(this.dtpFechaFin);
            this.groupBox14.Controls.Add(this.label3);
            this.groupBox14.Controls.Add(this.dtpFechaInicio);
            this.groupBox14.Controls.Add(this.label8);
            this.groupBox14.Controls.Add(this.btnEditarProhibicion);
            this.groupBox14.Controls.Add(this.btnGuardarProhibicion);
            this.groupBox14.Controls.Add(this.btnCancelarProhibicion);
            this.groupBox14.Controls.Add(this.txtIdProhibicionAnticipada);
            this.groupBox14.Controls.Add(this.label7);
            this.groupBox14.Controls.Add(this.label1);
            this.groupBox14.Controls.Add(this.cmbSexoVisita);
            this.groupBox14.Controls.Add(this.label4);
            this.groupBox14.Controls.Add(this.chkProhibicionVigente);
            this.groupBox14.Controls.Add(this.label5);
            this.groupBox14.Controls.Add(this.chkExInterno);
            this.groupBox14.Controls.Add(this.label10);
            this.groupBox14.Controls.Add(this.txtDetalleProhibicionAnticipada);
            this.groupBox14.Controls.Add(this.label13);
            this.groupBox14.Controls.Add(this.txtFechaProhibicion);
            this.groupBox14.Controls.Add(this.txtOrganismoAlta);
            this.groupBox14.Controls.Add(this.label2);
            this.groupBox14.Controls.Add(this.txtUsuarioAlta);
            this.groupBox14.Controls.Add(this.label14);
            this.groupBox14.Controls.Add(this.txtTipoLevantamiento);
            this.groupBox14.Controls.Add(this.label15);
            this.groupBox14.Controls.Add(this.label27);
            this.groupBox14.Controls.Add(this.label30);
            this.groupBox14.Controls.Add(this.txtNombreInterno);
            this.groupBox14.Controls.Add(this.label6);
            this.groupBox14.Controls.Add(this.txtApellidoInterno);
            this.groupBox14.Controls.Add(this.txtDniVisita);
            this.groupBox14.Controls.Add(this.txtNombreVisita);
            this.groupBox14.Controls.Add(this.txtApellidoVisita);
            this.groupBox14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox14.Location = new System.Drawing.Point(10, 8);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(641, 612);
            this.groupBox14.TabIndex = 92;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Editar";
            // 
            // txtMotivoDetalle
            // 
            this.txtMotivoDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivoDetalle.Location = new System.Drawing.Point(11, 373);
            this.txtMotivoDetalle.Multiline = true;
            this.txtMotivoDetalle.Name = "txtMotivoDetalle";
            this.txtMotivoDetalle.ReadOnly = true;
            this.txtMotivoDetalle.Size = new System.Drawing.Size(615, 52);
            this.txtMotivoDetalle.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 355);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 15);
            this.label9.TabIndex = 119;
            this.label9.Text = "MOTIVO EDICION:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Enabled = false;
            this.dtpFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(263, 331);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(115, 21);
            this.dtpFechaFin.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(260, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 116;
            this.label3.Text = "FECHA FIN:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Enabled = false;
            this.dtpFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(11, 331);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(115, 21);
            this.dtpFechaInicio.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 314);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 15);
            this.label8.TabIndex = 117;
            this.label8.Text = "FECHA INICIO:";
            // 
            // btnEditarProhibicion
            // 
            this.btnEditarProhibicion.BackColor = System.Drawing.Color.Indigo;
            this.btnEditarProhibicion.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEditarProhibicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarProhibicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarProhibicion.ForeColor = System.Drawing.Color.White;
            this.btnEditarProhibicion.Location = new System.Drawing.Point(11, 563);
            this.btnEditarProhibicion.Name = "btnEditarProhibicion";
            this.btnEditarProhibicion.Size = new System.Drawing.Size(98, 40);
            this.btnEditarProhibicion.TabIndex = 11;
            this.btnEditarProhibicion.Text = "EDITAR";
            this.btnEditarProhibicion.UseVisualStyleBackColor = false;
            this.btnEditarProhibicion.Click += new System.EventHandler(this.btnEditarProhibicion_Click);
            // 
            // btnGuardarProhibicion
            // 
            this.btnGuardarProhibicion.BackColor = System.Drawing.Color.Green;
            this.btnGuardarProhibicion.Enabled = false;
            this.btnGuardarProhibicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarProhibicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarProhibicion.ForeColor = System.Drawing.Color.White;
            this.btnGuardarProhibicion.Location = new System.Drawing.Point(141, 563);
            this.btnGuardarProhibicion.Name = "btnGuardarProhibicion";
            this.btnGuardarProhibicion.Size = new System.Drawing.Size(98, 40);
            this.btnGuardarProhibicion.TabIndex = 12;
            this.btnGuardarProhibicion.Text = "GUARDAR";
            this.btnGuardarProhibicion.UseVisualStyleBackColor = false;
            this.btnGuardarProhibicion.Click += new System.EventHandler(this.btnGuardarProhibicion_Click);
            // 
            // btnCancelarProhibicion
            // 
            this.btnCancelarProhibicion.BackColor = System.Drawing.Color.DarkOrange;
            this.btnCancelarProhibicion.Enabled = false;
            this.btnCancelarProhibicion.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancelarProhibicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarProhibicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarProhibicion.ForeColor = System.Drawing.Color.White;
            this.btnCancelarProhibicion.Location = new System.Drawing.Point(245, 563);
            this.btnCancelarProhibicion.Name = "btnCancelarProhibicion";
            this.btnCancelarProhibicion.Size = new System.Drawing.Size(98, 40);
            this.btnCancelarProhibicion.TabIndex = 13;
            this.btnCancelarProhibicion.Text = "CANCELAR";
            this.btnCancelarProhibicion.UseVisualStyleBackColor = false;
            this.btnCancelarProhibicion.Click += new System.EventHandler(this.btnCancelarProhibicion_Click);
            // 
            // txtIdProhibicionAnticipada
            // 
            this.txtIdProhibicionAnticipada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdProhibicionAnticipada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdProhibicionAnticipada.Location = new System.Drawing.Point(11, 34);
            this.txtIdProhibicionAnticipada.Name = "txtIdProhibicionAnticipada";
            this.txtIdProhibicionAnticipada.ReadOnly = true;
            this.txtIdProhibicionAnticipada.Size = new System.Drawing.Size(228, 21);
            this.txtIdProhibicionAnticipada.TabIndex = 54;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(260, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 15);
            this.label7.TabIndex = 90;
            this.label7.Text = "SEXO:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "DNI VISITA:";
            // 
            // cmbSexoVisita
            // 
            this.cmbSexoVisita.Enabled = false;
            this.cmbSexoVisita.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSexoVisita.FormattingEnabled = true;
            this.cmbSexoVisita.Location = new System.Drawing.Point(263, 116);
            this.cmbSexoVisita.Name = "cmbSexoVisita";
            this.cmbSexoVisita.Size = new System.Drawing.Size(228, 23);
            this.cmbSexoVisita.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 15);
            this.label4.TabIndex = 28;
            this.label4.Text = "APELLIDO VISITA";
            // 
            // chkProhibicionVigente
            // 
            this.chkProhibicionVigente.AutoSize = true;
            this.chkProhibicionVigente.Enabled = false;
            this.chkProhibicionVigente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkProhibicionVigente.Location = new System.Drawing.Point(11, 439);
            this.chkProhibicionVigente.Name = "chkProhibicionVigente";
            this.chkProhibicionVigente.Size = new System.Drawing.Size(77, 19);
            this.chkProhibicionVigente.TabIndex = 88;
            this.chkProhibicionVigente.Text = "VIGENTE";
            this.chkProhibicionVigente.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(318, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 15);
            this.label5.TabIndex = 29;
            this.label5.Text = "NOMBRE VISITA";
            // 
            // chkExInterno
            // 
            this.chkExInterno.AutoSize = true;
            this.chkExInterno.Enabled = false;
            this.chkExInterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExInterno.Location = new System.Drawing.Point(261, 38);
            this.chkExInterno.Name = "chkExInterno";
            this.chkExInterno.Size = new System.Drawing.Size(115, 19);
            this.chkExInterno.TabIndex = 0;
            this.chkExInterno.Text = "ES EXINTERNO";
            this.chkExInterno.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 273);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 15);
            this.label10.TabIndex = 40;
            this.label10.Text = "APELLIDO INTERNO:";
            // 
            // txtDetalleProhibicionAnticipada
            // 
            this.txtDetalleProhibicionAnticipada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetalleProhibicionAnticipada.Location = new System.Drawing.Point(11, 157);
            this.txtDetalleProhibicionAnticipada.Multiline = true;
            this.txtDetalleProhibicionAnticipada.Name = "txtDetalleProhibicionAnticipada";
            this.txtDetalleProhibicionAnticipada.ReadOnly = true;
            this.txtDetalleProhibicionAnticipada.Size = new System.Drawing.Size(615, 110);
            this.txtDetalleProhibicionAnticipada.TabIndex = 5;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(318, 273);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(121, 15);
            this.label13.TabIndex = 44;
            this.label13.Text = "NOMBRE INTERNO:";
            // 
            // txtFechaProhibicion
            // 
            this.txtFechaProhibicion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFechaProhibicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaProhibicion.Location = new System.Drawing.Point(11, 531);
            this.txtFechaProhibicion.Name = "txtFechaProhibicion";
            this.txtFechaProhibicion.ReadOnly = true;
            this.txtFechaProhibicion.Size = new System.Drawing.Size(228, 21);
            this.txtFechaProhibicion.TabIndex = 62;
            // 
            // txtOrganismoAlta
            // 
            this.txtOrganismoAlta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrganismoAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrganismoAlta.Location = new System.Drawing.Point(261, 490);
            this.txtOrganismoAlta.Name = "txtOrganismoAlta";
            this.txtOrganismoAlta.ReadOnly = true;
            this.txtOrganismoAlta.Size = new System.Drawing.Size(228, 21);
            this.txtOrganismoAlta.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(258, 432);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 15);
            this.label2.TabIndex = 50;
            this.label2.Text = "TIPO LEVANTAMIENTO:";
            // 
            // txtUsuarioAlta
            // 
            this.txtUsuarioAlta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuarioAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioAlta.Location = new System.Drawing.Point(11, 490);
            this.txtUsuarioAlta.Name = "txtUsuarioAlta";
            this.txtUsuarioAlta.ReadOnly = true;
            this.txtUsuarioAlta.Size = new System.Drawing.Size(228, 21);
            this.txtUsuarioAlta.TabIndex = 53;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(8, 473);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 15);
            this.label14.TabIndex = 52;
            this.label14.Text = "USUARIO ALTA:";
            // 
            // txtTipoLevantamiento
            // 
            this.txtTipoLevantamiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipoLevantamiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoLevantamiento.Location = new System.Drawing.Point(261, 449);
            this.txtTipoLevantamiento.Name = "txtTipoLevantamiento";
            this.txtTipoLevantamiento.ReadOnly = true;
            this.txtTipoLevantamiento.Size = new System.Drawing.Size(228, 21);
            this.txtTipoLevantamiento.TabIndex = 51;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(8, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 15);
            this.label15.TabIndex = 55;
            this.label15.Text = "ID:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(258, 473);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(112, 15);
            this.label27.TabIndex = 57;
            this.label27.Text = "ORGANISMO ALTA";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(8, 514);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(130, 15);
            this.label30.TabIndex = 61;
            this.label30.Text = "FECHA PROHIBICION:";
            // 
            // txtNombreInterno
            // 
            this.txtNombreInterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreInterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreInterno.Location = new System.Drawing.Point(321, 290);
            this.txtNombreInterno.Name = "txtNombreInterno";
            this.txtNombreInterno.ReadOnly = true;
            this.txtNombreInterno.Size = new System.Drawing.Size(290, 21);
            this.txtNombreInterno.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 15);
            this.label6.TabIndex = 64;
            this.label6.Text = "DETALLE:";
            // 
            // txtApellidoInterno
            // 
            this.txtApellidoInterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellidoInterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidoInterno.Location = new System.Drawing.Point(11, 290);
            this.txtApellidoInterno.Name = "txtApellidoInterno";
            this.txtApellidoInterno.ReadOnly = true;
            this.txtApellidoInterno.Size = new System.Drawing.Size(290, 21);
            this.txtApellidoInterno.TabIndex = 6;
            // 
            // txtDniVisita
            // 
            this.txtDniVisita.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDniVisita.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDniVisita.Location = new System.Drawing.Point(11, 116);
            this.txtDniVisita.Name = "txtDniVisita";
            this.txtDniVisita.ReadOnly = true;
            this.txtDniVisita.Size = new System.Drawing.Size(228, 21);
            this.txtDniVisita.TabIndex = 3;
            // 
            // txtNombreVisita
            // 
            this.txtNombreVisita.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreVisita.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreVisita.Location = new System.Drawing.Point(321, 75);
            this.txtNombreVisita.Name = "txtNombreVisita";
            this.txtNombreVisita.ReadOnly = true;
            this.txtNombreVisita.Size = new System.Drawing.Size(290, 21);
            this.txtNombreVisita.TabIndex = 2;
            // 
            // txtApellidoVisita
            // 
            this.txtApellidoVisita.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellidoVisita.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidoVisita.Location = new System.Drawing.Point(11, 75);
            this.txtApellidoVisita.Name = "txtApellidoVisita";
            this.txtApellidoVisita.ReadOnly = true;
            this.txtApellidoVisita.Size = new System.Drawing.Size(290, 21);
            this.txtApellidoVisita.TabIndex = 1;
            // 
            // tabVisita
            // 
            this.tabVisita.Controls.Add(this.pagProhibicion);
            this.tabVisita.Controls.Add(this.pagHistorial);
            this.tabVisita.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabVisita.Location = new System.Drawing.Point(2, 33);
            this.tabVisita.Name = "tabVisita";
            this.tabVisita.SelectedIndex = 0;
            this.tabVisita.Size = new System.Drawing.Size(1078, 655);
            this.tabVisita.TabIndex = 0;
            // 
            // FormAdminProhibicionAnticipada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1094, 691);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.tabVisita);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAdminProhibicionAnticipada";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar Prohibicion Anticipada";
            this.Load += new System.EventHandler(this.FormAdminProhibicionAnticipada_Load_1);
            this.pagHistorial.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvNovedades)).EndInit();
            this.pagProhibicion.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.tabVisita.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TabPage pagHistorial;
        private System.Windows.Forms.TabPage pagProhibicion;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnEditarProhibicion;
        private System.Windows.Forms.Button btnGuardarProhibicion;
        private System.Windows.Forms.Button btnCancelarProhibicion;
        private System.Windows.Forms.TextBox txtIdProhibicionAnticipada;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSexoVisita;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkProhibicionVigente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkExInterno;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDetalleProhibicionAnticipada;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtFechaProhibicion;
        private System.Windows.Forms.TextBox txtOrganismoAlta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsuarioAlta;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTipoLevantamiento;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtNombreInterno;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtApellidoInterno;
        private System.Windows.Forms.TextBox txtDniVisita;
        private System.Windows.Forms.TextBox txtNombreVisita;
        private System.Windows.Forms.TextBox txtApellidoVisita;
        private System.Windows.Forms.TabControl tabVisita;
        private System.Windows.Forms.TextBox txtMotivoDetalle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLevantar;
        private System.Windows.Forms.Button btnCancelarLevantar;
        private System.Windows.Forms.Button btnGuardarLevantar;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox txtMotivoLevantar;
        private System.Windows.Forms.DateTimePicker dtpFechaFinLevantar;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.TextBox txtUsuarioHistorial;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtDetalleMotivo;
        private System.Windows.Forms.TextBox txtOrganismoHistorial;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox txtFechaHistorial;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox txtIdHistorial;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.DataGridView dtgvNovedades;
        private System.Windows.Forms.Button btnVerNovedades;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDatosModificados;
    }
}