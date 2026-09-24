namespace CapaPresentacion
{
    partial class FormEgresoVisita
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtNumeroFichaBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gboxVisita = new System.Windows.Forms.GroupBox();
            this.txtIdIngreso = new System.Windows.Forms.TextBox();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDiscapacidad = new System.Windows.Forms.Label();
            this.lblCategoriaEdad = new System.Windows.Forms.Label();
            this.lblApellidoNombre = new System.Windows.Forms.Label();
            this.opMED = new System.Windows.Forms.CheckBox();
            this.opAD = new System.Windows.Forms.CheckBox();
            this.opMAD = new System.Windows.Forms.CheckBox();
            this.txtNumeroFicha = new System.Windows.Forms.TextBox();
            this.opID = new System.Windows.Forms.CheckBox();
            this.opPD = new System.Windows.Forms.CheckBox();
            this.opPI = new System.Windows.Forms.CheckBox();
            this.opII = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.opMAI = new System.Windows.Forms.CheckBox();
            this.opAI = new System.Windows.Forms.CheckBox();
            this.opMEI = new System.Windows.Forms.CheckBox();
            this.label70 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.txtSexo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFechaNacimiento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.picFotoVisita = new System.Windows.Forms.PictureBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtHoraIngreso = new System.Windows.Forms.TextBox();
            this.txtFechaIngreso = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gboxDatosParaIngreso = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOrganismo = new System.Windows.Forms.TextBox();
            this.txtIntrno = new System.Windows.Forms.TextBox();
            this.txtParentesco = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCasillero = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtgMenores = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gboxVisita.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFotoVisita)).BeginInit();
            this.gboxDatosParaIngreso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMenores)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.DarkOrange;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(356, 26);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(105, 40);
            this.btnCancelar.TabIndex = 156;
            this.btnCancelar.Text = "FINALIZAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(10, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(198, 18);
            this.label14.TabIndex = 155;
            this.label14.Text = "INGRESAR N° DE FICHA";
            // 
            // txtNumeroFichaBuscar
            // 
            this.txtNumeroFichaBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNumeroFichaBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumeroFichaBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroFichaBuscar.Location = new System.Drawing.Point(12, 35);
            this.txtNumeroFichaBuscar.Multiline = true;
            this.txtNumeroFichaBuscar.Name = "txtNumeroFichaBuscar";
            this.txtNumeroFichaBuscar.Size = new System.Drawing.Size(196, 30);
            this.txtNumeroFichaBuscar.TabIndex = 153;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(220, 26);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(128, 40);
            this.btnBuscar.TabIndex = 154;
            this.btnBuscar.Text = "Buscar ingreso";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gboxVisita
            // 
            this.gboxVisita.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(103)))), ((int)(((byte)(153)))));
            this.gboxVisita.Controls.Add(this.txtIdIngreso);
            this.gboxVisita.Controls.Add(this.txtEdad);
            this.gboxVisita.Controls.Add(this.label8);
            this.gboxVisita.Controls.Add(this.label2);
            this.gboxVisita.Controls.Add(this.lblDiscapacidad);
            this.gboxVisita.Controls.Add(this.lblCategoriaEdad);
            this.gboxVisita.Controls.Add(this.lblApellidoNombre);
            this.gboxVisita.Controls.Add(this.opMED);
            this.gboxVisita.Controls.Add(this.opAD);
            this.gboxVisita.Controls.Add(this.opMAD);
            this.gboxVisita.Controls.Add(this.txtNumeroFicha);
            this.gboxVisita.Controls.Add(this.opID);
            this.gboxVisita.Controls.Add(this.opPD);
            this.gboxVisita.Controls.Add(this.opPI);
            this.gboxVisita.Controls.Add(this.opII);
            this.gboxVisita.Controls.Add(this.label1);
            this.gboxVisita.Controls.Add(this.opMAI);
            this.gboxVisita.Controls.Add(this.opAI);
            this.gboxVisita.Controls.Add(this.opMEI);
            this.gboxVisita.Controls.Add(this.label70);
            this.gboxVisita.Controls.Add(this.label72);
            this.gboxVisita.Controls.Add(this.pictureBox4);
            this.gboxVisita.Controls.Add(this.txtSexo);
            this.gboxVisita.Controls.Add(this.label5);
            this.gboxVisita.Controls.Add(this.txtFechaNacimiento);
            this.gboxVisita.Controls.Add(this.label3);
            this.gboxVisita.Controls.Add(this.picFotoVisita);
            this.gboxVisita.Controls.Add(this.txtDni);
            this.gboxVisita.Controls.Add(this.label9);
            this.gboxVisita.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxVisita.ForeColor = System.Drawing.Color.White;
            this.gboxVisita.Location = new System.Drawing.Point(13, 72);
            this.gboxVisita.Name = "gboxVisita";
            this.gboxVisita.Size = new System.Drawing.Size(528, 420);
            this.gboxVisita.TabIndex = 157;
            this.gboxVisita.TabStop = false;
            this.gboxVisita.Text = "DATOS CIUDADANO";
            // 
            // txtIdIngreso
            // 
            this.txtIdIngreso.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtIdIngreso.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdIngreso.Location = new System.Drawing.Point(242, 35);
            this.txtIdIngreso.Name = "txtIdIngreso";
            this.txtIdIngreso.ReadOnly = true;
            this.txtIdIngreso.Size = new System.Drawing.Size(216, 26);
            this.txtIdIngreso.TabIndex = 158;
            // 
            // txtEdad
            // 
            this.txtEdad.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtEdad.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEdad.Location = new System.Drawing.Point(241, 379);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.ReadOnly = true;
            this.txtEdad.Size = new System.Drawing.Size(216, 26);
            this.txtEdad.TabIndex = 151;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(238, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 19);
            this.label8.TabIndex = 157;
            this.label8.Text = "Id Ingreso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(237, 360);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 19);
            this.label2.TabIndex = 150;
            this.label2.Text = "Edad";
            // 
            // lblDiscapacidad
            // 
            this.lblDiscapacidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscapacidad.ForeColor = System.Drawing.Color.White;
            this.lblDiscapacidad.Location = new System.Drawing.Point(238, 123);
            this.lblDiscapacidad.Name = "lblDiscapacidad";
            this.lblDiscapacidad.Size = new System.Drawing.Size(282, 55);
            this.lblDiscapacidad.TabIndex = 147;
            this.lblDiscapacidad.Text = "Discapacidad";
            // 
            // lblCategoriaEdad
            // 
            this.lblCategoriaEdad.AutoSize = true;
            this.lblCategoriaEdad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoriaEdad.ForeColor = System.Drawing.Color.White;
            this.lblCategoriaEdad.Location = new System.Drawing.Point(237, 98);
            this.lblCategoriaEdad.Name = "lblCategoriaEdad";
            this.lblCategoriaEdad.Size = new System.Drawing.Size(133, 18);
            this.lblCategoriaEdad.TabIndex = 134;
            this.lblCategoriaEdad.Text = "Categoria - edad";
            // 
            // lblApellidoNombre
            // 
            this.lblApellidoNombre.AutoSize = true;
            this.lblApellidoNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellidoNombre.ForeColor = System.Drawing.Color.Orange;
            this.lblApellidoNombre.Location = new System.Drawing.Point(13, 68);
            this.lblApellidoNombre.Name = "lblApellidoNombre";
            this.lblApellidoNombre.Size = new System.Drawing.Size(201, 25);
            this.lblApellidoNombre.TabIndex = 133;
            this.lblApellidoNombre.Text = "Apellido y nombre";
            // 
            // opMED
            // 
            this.opMED.AutoSize = true;
            this.opMED.BackColor = System.Drawing.Color.White;
            this.opMED.Enabled = false;
            this.opMED.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opMED.Location = new System.Drawing.Point(237, 221);
            this.opMED.Name = "opMED";
            this.opMED.Size = new System.Drawing.Size(12, 11);
            this.opMED.TabIndex = 132;
            this.opMED.UseVisualStyleBackColor = false;
            // 
            // opAD
            // 
            this.opAD.AutoSize = true;
            this.opAD.BackColor = System.Drawing.Color.White;
            this.opAD.Enabled = false;
            this.opAD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opAD.Location = new System.Drawing.Point(259, 198);
            this.opAD.Name = "opAD";
            this.opAD.Size = new System.Drawing.Size(12, 11);
            this.opAD.TabIndex = 131;
            this.opAD.UseVisualStyleBackColor = false;
            // 
            // opMAD
            // 
            this.opMAD.AutoSize = true;
            this.opMAD.BackColor = System.Drawing.Color.White;
            this.opMAD.Enabled = false;
            this.opMAD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opMAD.Location = new System.Drawing.Point(287, 189);
            this.opMAD.Name = "opMAD";
            this.opMAD.Size = new System.Drawing.Size(12, 11);
            this.opMAD.TabIndex = 130;
            this.opMAD.UseVisualStyleBackColor = false;
            // 
            // txtNumeroFicha
            // 
            this.txtNumeroFicha.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtNumeroFicha.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroFicha.Location = new System.Drawing.Point(18, 35);
            this.txtNumeroFicha.Name = "txtNumeroFicha";
            this.txtNumeroFicha.ReadOnly = true;
            this.txtNumeroFicha.Size = new System.Drawing.Size(216, 26);
            this.txtNumeroFicha.TabIndex = 149;
            // 
            // opID
            // 
            this.opID.AutoSize = true;
            this.opID.BackColor = System.Drawing.Color.White;
            this.opID.Enabled = false;
            this.opID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opID.Location = new System.Drawing.Point(314, 189);
            this.opID.Name = "opID";
            this.opID.Size = new System.Drawing.Size(12, 11);
            this.opID.TabIndex = 129;
            this.opID.UseVisualStyleBackColor = false;
            // 
            // opPD
            // 
            this.opPD.AutoSize = true;
            this.opPD.BackColor = System.Drawing.Color.White;
            this.opPD.Enabled = false;
            this.opPD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opPD.Location = new System.Drawing.Point(356, 242);
            this.opPD.Name = "opPD";
            this.opPD.Size = new System.Drawing.Size(12, 11);
            this.opPD.TabIndex = 128;
            this.opPD.UseVisualStyleBackColor = false;
            // 
            // opPI
            // 
            this.opPI.AutoSize = true;
            this.opPI.BackColor = System.Drawing.Color.White;
            this.opPI.Enabled = false;
            this.opPI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opPI.Location = new System.Drawing.Point(383, 243);
            this.opPI.Name = "opPI";
            this.opPI.Size = new System.Drawing.Size(12, 11);
            this.opPI.TabIndex = 127;
            this.opPI.UseVisualStyleBackColor = false;
            // 
            // opII
            // 
            this.opII.AutoSize = true;
            this.opII.BackColor = System.Drawing.Color.White;
            this.opII.Enabled = false;
            this.opII.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opII.Location = new System.Drawing.Point(428, 185);
            this.opII.Name = "opII";
            this.opII.Size = new System.Drawing.Size(12, 11);
            this.opII.TabIndex = 126;
            this.opII.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 19);
            this.label1.TabIndex = 148;
            this.label1.Text = "N° de ficha";
            // 
            // opMAI
            // 
            this.opMAI.AutoSize = true;
            this.opMAI.BackColor = System.Drawing.Color.White;
            this.opMAI.Enabled = false;
            this.opMAI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opMAI.Location = new System.Drawing.Point(456, 185);
            this.opMAI.Name = "opMAI";
            this.opMAI.Size = new System.Drawing.Size(12, 11);
            this.opMAI.TabIndex = 125;
            this.opMAI.UseVisualStyleBackColor = false;
            // 
            // opAI
            // 
            this.opAI.AutoSize = true;
            this.opAI.BackColor = System.Drawing.Color.White;
            this.opAI.Enabled = false;
            this.opAI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opAI.ForeColor = System.Drawing.Color.White;
            this.opAI.Location = new System.Drawing.Point(484, 193);
            this.opAI.Name = "opAI";
            this.opAI.Size = new System.Drawing.Size(12, 11);
            this.opAI.TabIndex = 124;
            this.opAI.UseVisualStyleBackColor = false;
            // 
            // opMEI
            // 
            this.opMEI.AutoSize = true;
            this.opMEI.BackColor = System.Drawing.Color.White;
            this.opMEI.Enabled = false;
            this.opMEI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opMEI.ForeColor = System.Drawing.Color.White;
            this.opMEI.Location = new System.Drawing.Point(506, 206);
            this.opMEI.Name = "opMEI";
            this.opMEI.Size = new System.Drawing.Size(12, 11);
            this.opMEI.TabIndex = 123;
            this.opMEI.UseVisualStyleBackColor = false;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.BackColor = System.Drawing.Color.Transparent;
            this.label70.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.ForeColor = System.Drawing.Color.White;
            this.label70.Location = new System.Drawing.Point(242, 274);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(116, 16);
            this.label70.TabIndex = 122;
            this.label70.Text = "MANO DERECHA";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.BackColor = System.Drawing.Color.Transparent;
            this.label72.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.ForeColor = System.Drawing.Color.White;
            this.label72.Location = new System.Drawing.Point(395, 274);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(122, 16);
            this.label72.TabIndex = 121;
            this.label72.Text = "MANO IZQUIERDA";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::CapaPresentacion.Properties.Resources.manos_lila;
            this.pictureBox4.Location = new System.Drawing.Point(237, 181);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(282, 124);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 120;
            this.pictureBox4.TabStop = false;
            // 
            // txtSexo
            // 
            this.txtSexo.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtSexo.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSexo.Location = new System.Drawing.Point(241, 332);
            this.txtSexo.Name = "txtSexo";
            this.txtSexo.ReadOnly = true;
            this.txtSexo.Size = new System.Drawing.Size(216, 26);
            this.txtSexo.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(237, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 19);
            this.label5.TabIndex = 30;
            this.label5.Text = "Sexo";
            // 
            // txtFechaNacimiento
            // 
            this.txtFechaNacimiento.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtFechaNacimiento.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaNacimiento.Location = new System.Drawing.Point(15, 379);
            this.txtFechaNacimiento.Name = "txtFechaNacimiento";
            this.txtFechaNacimiento.ReadOnly = true;
            this.txtFechaNacimiento.Size = new System.Drawing.Size(216, 26);
            this.txtFechaNacimiento.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(11, 360);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 19);
            this.label3.TabIndex = 24;
            this.label3.Text = "Fecha nacimiento";
            // 
            // picFotoVisita
            // 
            this.picFotoVisita.BackColor = System.Drawing.Color.Transparent;
            this.picFotoVisita.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFotoVisita.Location = new System.Drawing.Point(15, 101);
            this.picFotoVisita.Name = "picFotoVisita";
            this.picFotoVisita.Size = new System.Drawing.Size(215, 205);
            this.picFotoVisita.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFotoVisita.TabIndex = 19;
            this.picFotoVisita.TabStop = false;
            // 
            // txtDni
            // 
            this.txtDni.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtDni.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDni.Location = new System.Drawing.Point(15, 331);
            this.txtDni.Name = "txtDni";
            this.txtDni.ReadOnly = true;
            this.txtDni.Size = new System.Drawing.Size(216, 26);
            this.txtDni.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(11, 312);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 19);
            this.label9.TabIndex = 20;
            this.label9.Text = "DNI";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(133, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 19);
            this.label11.TabIndex = 143;
            this.label11.Text = "Hora ingreso";
            // 
            // txtHoraIngreso
            // 
            this.txtHoraIngreso.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtHoraIngreso.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoraIngreso.Location = new System.Drawing.Point(137, 91);
            this.txtHoraIngreso.Name = "txtHoraIngreso";
            this.txtHoraIngreso.ReadOnly = true;
            this.txtHoraIngreso.Size = new System.Drawing.Size(120, 26);
            this.txtHoraIngreso.TabIndex = 144;
            // 
            // txtFechaIngreso
            // 
            this.txtFechaIngreso.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtFechaIngreso.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaIngreso.Location = new System.Drawing.Point(10, 91);
            this.txtFechaIngreso.Name = "txtFechaIngreso";
            this.txtFechaIngreso.ReadOnly = true;
            this.txtFechaIngreso.Size = new System.Drawing.Size(120, 26);
            this.txtFechaIngreso.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(6, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 19);
            this.label4.TabIndex = 26;
            this.label4.Text = "Fecha ingreso";
            // 
            // gboxDatosParaIngreso
            // 
            this.gboxDatosParaIngreso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(103)))), ((int)(((byte)(153)))));
            this.gboxDatosParaIngreso.Controls.Add(this.label10);
            this.gboxDatosParaIngreso.Controls.Add(this.txtObservaciones);
            this.gboxDatosParaIngreso.Controls.Add(this.label7);
            this.gboxDatosParaIngreso.Controls.Add(this.txtIntrno);
            this.gboxDatosParaIngreso.Controls.Add(this.txtParentesco);
            this.gboxDatosParaIngreso.Controls.Add(this.btnGuardar);
            this.gboxDatosParaIngreso.Controls.Add(this.label13);
            this.gboxDatosParaIngreso.Controls.Add(this.label12);
            this.gboxDatosParaIngreso.Controls.Add(this.dtgMenores);
            this.gboxDatosParaIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxDatosParaIngreso.ForeColor = System.Drawing.Color.White;
            this.gboxDatosParaIngreso.Location = new System.Drawing.Point(548, 72);
            this.gboxDatosParaIngreso.Name = "gboxDatosParaIngreso";
            this.gboxDatosParaIngreso.Size = new System.Drawing.Size(585, 562);
            this.gboxDatosParaIngreso.TabIndex = 158;
            this.gboxDatosParaIngreso.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(6, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 19);
            this.label7.TabIndex = 155;
            this.label7.Text = "Parentesco";
            // 
            // txtOrganismo
            // 
            this.txtOrganismo.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtOrganismo.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrganismo.Location = new System.Drawing.Point(264, 91);
            this.txtOrganismo.Name = "txtOrganismo";
            this.txtOrganismo.ReadOnly = true;
            this.txtOrganismo.Size = new System.Drawing.Size(258, 26);
            this.txtOrganismo.TabIndex = 153;
            // 
            // txtIntrno
            // 
            this.txtIntrno.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtIntrno.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIntrno.Location = new System.Drawing.Point(10, 32);
            this.txtIntrno.Name = "txtIntrno";
            this.txtIntrno.Size = new System.Drawing.Size(569, 26);
            this.txtIntrno.TabIndex = 154;
            // 
            // txtParentesco
            // 
            this.txtParentesco.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtParentesco.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParentesco.Location = new System.Drawing.Point(10, 79);
            this.txtParentesco.Name = "txtParentesco";
            this.txtParentesco.ReadOnly = true;
            this.txtParentesco.Size = new System.Drawing.Size(216, 26);
            this.txtParentesco.TabIndex = 156;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(260, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 19);
            this.label6.TabIndex = 152;
            this.label6.Text = "Organismo";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(6, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 19);
            this.label15.TabIndex = 153;
            this.label15.Text = "Casillero";
            // 
            // txtCasillero
            // 
            this.txtCasillero.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtCasillero.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCasillero.Location = new System.Drawing.Point(10, 36);
            this.txtCasillero.Multiline = true;
            this.txtCasillero.Name = "txtCasillero";
            this.txtCasillero.ReadOnly = true;
            this.txtCasillero.Size = new System.Drawing.Size(513, 30);
            this.txtCasillero.TabIndex = 152;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Green;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(406, 505);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(173, 40);
            this.btnGuardar.TabIndex = 151;
            this.btnGuardar.Text = "GUARDAR EGRESO";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(6, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 19);
            this.label13.TabIndex = 148;
            this.label13.Text = "Interno";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(6, 119);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 19);
            this.label12.TabIndex = 147;
            this.label12.Text = "Menores ";
            // 
            // dtgMenores
            // 
            this.dtgMenores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMenores.Location = new System.Drawing.Point(9, 140);
            this.dtgMenores.Name = "dtgMenores";
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            this.dtgMenores.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgMenores.Size = new System.Drawing.Size(569, 224);
            this.dtgMenores.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(5, 400);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 19);
            this.label10.TabIndex = 158;
            this.label10.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.BackColor = System.Drawing.Color.White;
            this.txtObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.Location = new System.Drawing.Point(9, 420);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(569, 65);
            this.txtObservaciones.TabIndex = 157;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(103)))), ((int)(((byte)(153)))));
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtHoraIngreso);
            this.groupBox1.Controls.Add(this.txtCasillero);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtOrganismo);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtFechaIngreso);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(13, 494);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 140);
            this.groupBox1.TabIndex = 159;
            this.groupBox1.TabStop = false;
            // 
            // FormEgresoVisita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(103)))), ((int)(((byte)(153)))));
            this.ClientSize = new System.Drawing.Size(1145, 661);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gboxDatosParaIngreso);
            this.Controls.Add(this.gboxVisita);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtNumeroFichaBuscar);
            this.Controls.Add(this.btnBuscar);
            this.Name = "FormEgresoVisita";
            this.Text = "FormEgresoVisita";
            this.Load += new System.EventHandler(this.FormEgresoVisita_Load);
            this.gboxVisita.ResumeLayout(false);
            this.gboxVisita.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFotoVisita)).EndInit();
            this.gboxDatosParaIngreso.ResumeLayout(false);
            this.gboxDatosParaIngreso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMenores)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtNumeroFichaBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox gboxVisita;
        private System.Windows.Forms.Label lblDiscapacidad;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtHoraIngreso;
        private System.Windows.Forms.Label lblCategoriaEdad;
        private System.Windows.Forms.Label lblApellidoNombre;
        public System.Windows.Forms.CheckBox opMED;
        public System.Windows.Forms.CheckBox opAD;
        public System.Windows.Forms.CheckBox opMAD;
        public System.Windows.Forms.CheckBox opID;
        public System.Windows.Forms.CheckBox opPD;
        public System.Windows.Forms.CheckBox opPI;
        public System.Windows.Forms.CheckBox opII;
        public System.Windows.Forms.CheckBox opMAI;
        public System.Windows.Forms.CheckBox opAI;
        public System.Windows.Forms.CheckBox opMEI;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox txtSexo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFechaIngreso;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFechaNacimiento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picFotoVisita;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gboxDatosParaIngreso;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCasillero;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dtgMenores;
        private System.Windows.Forms.TextBox txtIntrno;
        private System.Windows.Forms.TextBox txtNumeroFicha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrganismo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtParentesco;
        private System.Windows.Forms.TextBox txtIdIngreso;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}