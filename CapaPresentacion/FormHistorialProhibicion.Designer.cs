namespace CapaPresentacion
{
    partial class FormHistorialProhibicion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHistorialProhibicion));
            this.label28 = new System.Windows.Forms.Label();
            this.dtgvHistorialProhibicion = new System.Windows.Forms.DataGridView();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDEtalle = new System.Windows.Forms.TextBox();
            this.chkAnulado = new System.Windows.Forms.CheckBox();
            this.chkVigente = new System.Windows.Forms.CheckBox();
            this.txtFechaFin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFechaInicio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDisposicion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtDetalleMotivo = new System.Windows.Forms.TextBox();
            this.txtOrganismo = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.txtFechaCambio = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHistorialProhibicion)).BeginInit();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Indigo;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(-2, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(1044, 29);
            this.label28.TabIndex = 75;
            this.label28.Text = "HISTORIAL DE PROHIBICION";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtgvHistorialProhibicion
            // 
            this.dtgvHistorialProhibicion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvHistorialProhibicion.Location = new System.Drawing.Point(7, 49);
            this.dtgvHistorialProhibicion.Name = "dtgvHistorialProhibicion";
            this.dtgvHistorialProhibicion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvHistorialProhibicion.Size = new System.Drawing.Size(1020, 214);
            this.dtgvHistorialProhibicion.TabIndex = 18;
            this.dtgvHistorialProhibicion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgvHistorialProhibicion_KeyDown);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label4);
            this.groupBox10.Controls.Add(this.txtDEtalle);
            this.groupBox10.Controls.Add(this.chkAnulado);
            this.groupBox10.Controls.Add(this.chkVigente);
            this.groupBox10.Controls.Add(this.txtFechaFin);
            this.groupBox10.Controls.Add(this.label3);
            this.groupBox10.Controls.Add(this.txtFechaInicio);
            this.groupBox10.Controls.Add(this.label2);
            this.groupBox10.Controls.Add(this.txtDisposicion);
            this.groupBox10.Controls.Add(this.label1);
            this.groupBox10.Controls.Add(this.label47);
            this.groupBox10.Controls.Add(this.txtMotivo);
            this.groupBox10.Controls.Add(this.txtUsuario);
            this.groupBox10.Controls.Add(this.label23);
            this.groupBox10.Controls.Add(this.label20);
            this.groupBox10.Controls.Add(this.txtDetalleMotivo);
            this.groupBox10.Controls.Add(this.txtOrganismo);
            this.groupBox10.Controls.Add(this.label43);
            this.groupBox10.Controls.Add(this.txtFechaCambio);
            this.groupBox10.Controls.Add(this.label45);
            this.groupBox10.Controls.Add(this.txtId);
            this.groupBox10.Controls.Add(this.label46);
            this.groupBox10.Location = new System.Drawing.Point(10, 274);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(880, 275);
            this.groupBox10.TabIndex = 81;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Datos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 96;
            this.label4.Text = "DETALLE:";
            // 
            // txtDEtalle
            // 
            this.txtDEtalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDEtalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDEtalle.Location = new System.Drawing.Point(9, 84);
            this.txtDEtalle.Multiline = true;
            this.txtDEtalle.Name = "txtDEtalle";
            this.txtDEtalle.ReadOnly = true;
            this.txtDEtalle.Size = new System.Drawing.Size(735, 60);
            this.txtDEtalle.TabIndex = 95;
            // 
            // chkAnulado
            // 
            this.chkAnulado.AutoSize = true;
            this.chkAnulado.Enabled = false;
            this.chkAnulado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAnulado.Location = new System.Drawing.Point(661, 39);
            this.chkAnulado.Name = "chkAnulado";
            this.chkAnulado.Size = new System.Drawing.Size(83, 19);
            this.chkAnulado.TabIndex = 94;
            this.chkAnulado.Text = "ANULADO";
            this.chkAnulado.UseVisualStyleBackColor = true;
            // 
            // chkVigente
            // 
            this.chkVigente.AutoSize = true;
            this.chkVigente.Enabled = false;
            this.chkVigente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVigente.Location = new System.Drawing.Point(563, 39);
            this.chkVigente.Name = "chkVigente";
            this.chkVigente.Size = new System.Drawing.Size(77, 19);
            this.chkVigente.TabIndex = 93;
            this.chkVigente.Text = "VIGENTE";
            this.chkVigente.UseVisualStyleBackColor = true;
            // 
            // txtFechaFin
            // 
            this.txtFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaFin.Location = new System.Drawing.Point(450, 37);
            this.txtFechaFin.Name = "txtFechaFin";
            this.txtFechaFin.ReadOnly = true;
            this.txtFechaFin.Size = new System.Drawing.Size(95, 21);
            this.txtFechaFin.TabIndex = 91;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(447, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 92;
            this.label3.Text = "FECHA FIN:";
            // 
            // txtFechaInicio
            // 
            this.txtFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaInicio.Location = new System.Drawing.Point(342, 37);
            this.txtFechaInicio.Name = "txtFechaInicio";
            this.txtFechaInicio.ReadOnly = true;
            this.txtFechaInicio.Size = new System.Drawing.Size(95, 21);
            this.txtFechaInicio.TabIndex = 89;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(339, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 90;
            this.label2.Text = "FECHA INICIO:";
            // 
            // txtDisposicion
            // 
            this.txtDisposicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisposicion.Location = new System.Drawing.Point(104, 36);
            this.txtDisposicion.Name = "txtDisposicion";
            this.txtDisposicion.ReadOnly = true;
            this.txtDisposicion.Size = new System.Drawing.Size(227, 21);
            this.txtDisposicion.TabIndex = 88;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(100, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 87;
            this.label1.Text = "DISPOSICION:";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(6, 204);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(105, 15);
            this.label47.TabIndex = 86;
            this.label47.Text = "MOTIVO CAMBIO:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivo.Location = new System.Drawing.Point(9, 223);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.ReadOnly = true;
            this.txtMotivo.Size = new System.Drawing.Size(227, 30);
            this.txtMotivo.TabIndex = 85;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(476, 179);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(227, 21);
            this.txtUsuario.TabIndex = 84;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(472, 160);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 15);
            this.label23.TabIndex = 83;
            this.label23.Text = "USUARIO:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(242, 204);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(112, 15);
            this.label20.TabIndex = 82;
            this.label20.Text = "DETALLE MOTIVO:";
            // 
            // txtDetalleMotivo
            // 
            this.txtDetalleMotivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetalleMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetalleMotivo.Location = new System.Drawing.Point(245, 223);
            this.txtDetalleMotivo.Multiline = true;
            this.txtDetalleMotivo.Name = "txtDetalleMotivo";
            this.txtDetalleMotivo.ReadOnly = true;
            this.txtDetalleMotivo.Size = new System.Drawing.Size(606, 40);
            this.txtDetalleMotivo.TabIndex = 81;
            // 
            // txtOrganismo
            // 
            this.txtOrganismo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrganismo.Location = new System.Drawing.Point(116, 177);
            this.txtOrganismo.Name = "txtOrganismo";
            this.txtOrganismo.ReadOnly = true;
            this.txtOrganismo.Size = new System.Drawing.Size(349, 21);
            this.txtOrganismo.TabIndex = 80;
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
            // txtFechaCambio
            // 
            this.txtFechaCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaCambio.Location = new System.Drawing.Point(9, 178);
            this.txtFechaCambio.Name = "txtFechaCambio";
            this.txtFechaCambio.ReadOnly = true;
            this.txtFechaCambio.Size = new System.Drawing.Size(95, 21);
            this.txtFechaCambio.TabIndex = 64;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(6, 158);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(98, 15);
            this.label45.TabIndex = 66;
            this.label45.Text = "FECHA CAMBIO:";
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(9, 37);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(80, 21);
            this.txtId.TabIndex = 77;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(112, 158);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(84, 15);
            this.label46.TabIndex = 72;
            this.label46.Text = "ORGANISMO:";
            // 
            // FormHistorialProhibicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 561);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.dtgvHistorialProhibicion);
            this.Controls.Add(this.label28);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormHistorialProhibicion";
            this.ShowInTaskbar = false;
            this.Text = "Historial Prohibicion";
            this.Load += new System.EventHandler(this.FormHistorialProhibicion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHistorialProhibicion)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.DataGridView dtgvHistorialProhibicion;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtDetalleMotivo;
        private System.Windows.Forms.TextBox txtOrganismo;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox txtFechaCambio;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox txtFechaFin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFechaInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDisposicion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAnulado;
        private System.Windows.Forms.CheckBox chkVigente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDEtalle;
    }
}