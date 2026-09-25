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
            this.btnVerVisitas.Location = new System.Drawing.Point(416, 56);
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
            this.btnReimprimirFicha.Location = new System.Drawing.Point(286, 56);
            this.btnReimprimirFicha.Name = "btnReimprimirFicha";
            this.btnReimprimirFicha.Size = new System.Drawing.Size(120, 70);
            this.btnReimprimirFicha.TabIndex = 82;
            this.btnReimprimirFicha.Text = "Reimprimir ficha";
            this.btnReimprimirFicha.UseVisualStyleBackColor = false;
            this.btnReimprimirFicha.Click += new System.EventHandler(this.btnReimprimirFicha_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(103)))), ((int)(((byte)(153)))));
            this.ClientSize = new System.Drawing.Size(916, 606);
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
    }
}

