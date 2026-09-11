namespace CapaPresentacion
{
    partial class FormProhibicionesAnticipadas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProhibicionesAnticipadas));
            this.dtgvProhibicionesAnticipadas = new System.Windows.Forms.DataGridView();
            this.label26 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscarApellido = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbSexoVisita = new System.Windows.Forms.ComboBox();
            this.txtDetalleVisitaAnticipada = new System.Windows.Forms.TextBox();
            this.txtNombreVisita = new System.Windows.Forms.TextBox();
            this.txtApellidoVisita = new System.Windows.Forms.TextBox();
            this.txtDniVisita = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreInterno = new System.Windows.Forms.TextBox();
            this.txtApellidoInterno = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.chckExInterno = new System.Windows.Forms.CheckBox();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnInterno = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvProhibicionesAnticipadas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgvProhibicionesAnticipadas
            // 
            this.dtgvProhibicionesAnticipadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvProhibicionesAnticipadas.Location = new System.Drawing.Point(9, 26);
            this.dtgvProhibicionesAnticipadas.Name = "dtgvProhibicionesAnticipadas";
            this.dtgvProhibicionesAnticipadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvProhibicionesAnticipadas.Size = new System.Drawing.Size(800, 316);
            this.dtgvProhibicionesAnticipadas.TabIndex = 15;
            this.dtgvProhibicionesAnticipadas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgvVisitas_KeyDown);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(8, 19);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 15);
            this.label26.TabIndex = 68;
            this.label26.Text = "APELLIDO";
            // 
            // txtApellido
            // 
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.Location = new System.Drawing.Point(11, 39);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(214, 21);
            this.txtApellido.TabIndex = 13;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Indigo;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(1, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(811, 29);
            this.label28.TabIndex = 75;
            this.label28.Text = "PROHIBICIONES ANTICIPADAS DE VISITAS";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.btnBuscarApellido);
            this.groupBox1.Controls.Add(this.txtApellido);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 288);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(783, 78);
            this.groupBox1.TabIndex = 76;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda";
            // 
            // btnBuscarApellido
            // 
            this.btnBuscarApellido.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnBuscarApellido.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscarApellido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarApellido.ForeColor = System.Drawing.Color.White;
            this.btnBuscarApellido.Location = new System.Drawing.Point(259, 21);
            this.btnBuscarApellido.Name = "btnBuscarApellido";
            this.btnBuscarApellido.Size = new System.Drawing.Size(80, 45);
            this.btnBuscarApellido.TabIndex = 14;
            this.btnBuscarApellido.Text = "BUSCAR";
            this.btnBuscarApellido.UseVisualStyleBackColor = false;
            this.btnBuscarApellido.Click += new System.EventHandler(this.btnBuscarApellido_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgvProhibicionesAnticipadas);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 376);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(815, 356);
            this.groupBox2.TabIndex = 77;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Prohibiciones";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 15);
            this.label7.TabIndex = 100;
            this.label7.Text = "SEXO:";
            // 
            // cmbSexoVisita
            // 
            this.cmbSexoVisita.Enabled = false;
            this.cmbSexoVisita.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSexoVisita.FormattingEnabled = true;
            this.cmbSexoVisita.Location = new System.Drawing.Point(11, 83);
            this.cmbSexoVisita.Name = "cmbSexoVisita";
            this.cmbSexoVisita.Size = new System.Drawing.Size(128, 23);
            this.cmbSexoVisita.TabIndex = 4;
            // 
            // txtDetalleVisitaAnticipada
            // 
            this.txtDetalleVisitaAnticipada.Enabled = false;
            this.txtDetalleVisitaAnticipada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetalleVisitaAnticipada.Location = new System.Drawing.Point(9, 132);
            this.txtDetalleVisitaAnticipada.Multiline = true;
            this.txtDetalleVisitaAnticipada.Name = "txtDetalleVisitaAnticipada";
            this.txtDetalleVisitaAnticipada.Size = new System.Drawing.Size(621, 53);
            this.txtDetalleVisitaAnticipada.TabIndex = 8;
            // 
            // txtNombreVisita
            // 
            this.txtNombreVisita.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreVisita.Enabled = false;
            this.txtNombreVisita.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreVisita.Location = new System.Drawing.Point(250, 39);
            this.txtNombreVisita.Name = "txtNombreVisita";
            this.txtNombreVisita.Size = new System.Drawing.Size(228, 21);
            this.txtNombreVisita.TabIndex = 2;
            // 
            // txtApellidoVisita
            // 
            this.txtApellidoVisita.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellidoVisita.Enabled = false;
            this.txtApellidoVisita.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidoVisita.Location = new System.Drawing.Point(9, 39);
            this.txtApellidoVisita.Name = "txtApellidoVisita";
            this.txtApellidoVisita.Size = new System.Drawing.Size(228, 21);
            this.txtApellidoVisita.TabIndex = 1;
            // 
            // txtDniVisita
            // 
            this.txtDniVisita.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDniVisita.Enabled = false;
            this.txtDniVisita.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDniVisita.Location = new System.Drawing.Point(492, 39);
            this.txtDniVisita.Name = "txtDniVisita";
            this.txtDniVisita.Size = new System.Drawing.Size(135, 21);
            this.txtDniVisita.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 15);
            this.label6.TabIndex = 98;
            this.label6.Text = "DETALLE:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(247, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 15);
            this.label5.TabIndex = 96;
            this.label5.Text = "NOMBRE VISITA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 15);
            this.label4.TabIndex = 95;
            this.label4.Text = "APELLIDO VISITA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(489, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 94;
            this.label1.Text = "DNI VISITA:";
            // 
            // txtNombreInterno
            // 
            this.txtNombreInterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreInterno.Enabled = false;
            this.txtNombreInterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreInterno.Location = new System.Drawing.Point(262, 210);
            this.txtNombreInterno.Name = "txtNombreInterno";
            this.txtNombreInterno.Size = new System.Drawing.Size(249, 21);
            this.txtNombreInterno.TabIndex = 10;
            // 
            // txtApellidoInterno
            // 
            this.txtApellidoInterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellidoInterno.Enabled = false;
            this.txtApellidoInterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidoInterno.Location = new System.Drawing.Point(10, 210);
            this.txtApellidoInterno.Name = "txtApellidoInterno";
            this.txtApellidoInterno.Size = new System.Drawing.Size(228, 21);
            this.txtApellidoInterno.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(259, 191);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(121, 15);
            this.label13.TabIndex = 103;
            this.label13.Text = "NOMBRE INTERNO:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 191);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 15);
            this.label10.TabIndex = 101;
            this.label10.Text = "APELLIDO INTERNO:";
            // 
            // chckExInterno
            // 
            this.chckExInterno.AutoSize = true;
            this.chckExInterno.Enabled = false;
            this.chckExInterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckExInterno.Location = new System.Drawing.Point(442, 82);
            this.chckExInterno.Name = "chckExInterno";
            this.chckExInterno.Size = new System.Drawing.Size(115, 19);
            this.chckExInterno.TabIndex = 7;
            this.chckExInterno.Text = "ES EXINTERNO";
            this.chckExInterno.UseVisualStyleBackColor = true;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Enabled = false;
            this.dtpFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(298, 82);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(115, 21);
            this.dtpFechaFin.TabIndex = 6;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(295, 65);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 15);
            this.label16.TabIndex = 112;
            this.label16.Text = "FECHA FIN:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Enabled = false;
            this.dtpFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(160, 83);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(115, 21);
            this.dtpFechaInicio.TabIndex = 5;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(156, 64);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(87, 15);
            this.label18.TabIndex = 113;
            this.label18.Text = "FECHA INICIO:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnInterno);
            this.groupBox3.Controls.Add(this.btnNuevo);
            this.groupBox3.Controls.Add(this.btnGuardar);
            this.groupBox3.Controls.Add(this.btnCancelar);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.dtpFechaFin);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.dtpFechaInicio);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.txtDniVisita);
            this.groupBox3.Controls.Add(this.chckExInterno);
            this.groupBox3.Controls.Add(this.txtApellidoVisita);
            this.groupBox3.Controls.Add(this.txtNombreInterno);
            this.groupBox3.Controls.Add(this.txtNombreVisita);
            this.groupBox3.Controls.Add(this.txtApellidoInterno);
            this.groupBox3.Controls.Add(this.txtDetalleVisitaAnticipada);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.cmbSexoVisita);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(8, 35);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(783, 244);
            this.groupBox3.TabIndex = 114;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nueva prohibicón";
            // 
            // btnInterno
            // 
            this.btnInterno.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnInterno.Enabled = false;
            this.btnInterno.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnInterno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInterno.ForeColor = System.Drawing.Color.White;
            this.btnInterno.Location = new System.Drawing.Point(528, 201);
            this.btnInterno.Name = "btnInterno";
            this.btnInterno.Size = new System.Drawing.Size(80, 30);
            this.btnInterno.TabIndex = 114;
            this.btnInterno.Text = "BUSCAR";
            this.btnInterno.UseVisualStyleBackColor = false;
            this.btnInterno.Click += new System.EventHandler(this.btnInterno_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.Indigo;
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(676, 31);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(98, 40);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Green;
            this.btnGuardar.Enabled = false;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(677, 91);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(98, 40);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.DarkOrange;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(677, 138);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(98, 40);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormProhibicionesAnticipadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(834, 736);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label28);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProhibicionesAnticipadas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prohibiciones Anticipadas";
            this.Load += new System.EventHandler(this.FormProhibicionesAnticipadas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvProhibicionesAnticipadas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dtgvProhibicionesAnticipadas;
        private System.Windows.Forms.Button btnBuscarApellido;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbSexoVisita;
        private System.Windows.Forms.TextBox txtDetalleVisitaAnticipada;
        private System.Windows.Forms.TextBox txtNombreVisita;
        private System.Windows.Forms.TextBox txtApellidoVisita;
        private System.Windows.Forms.TextBox txtDniVisita;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreInterno;
        private System.Windows.Forms.TextBox txtApellidoInterno;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chckExInterno;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnInterno;
    }
}