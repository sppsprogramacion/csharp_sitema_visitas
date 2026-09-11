namespace CapaPresentacion
{
    partial class FormInternos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInternos));
            this.label28 = new System.Windows.Forms.Label();
            this.dtvInternos = new System.Windows.Forms.DataGridView();
            this.txtBuscarApellidoInternos = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.btnBuscarApellido = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtvInternos)).BeginInit();
            this.SuspendLayout();
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Indigo;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(-1, -1);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(700, 29);
            this.label28.TabIndex = 75;
            this.label28.Text = "BUSCAR INTERNO";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtvInternos
            // 
            this.dtvInternos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtvInternos.Location = new System.Drawing.Point(12, 93);
            this.dtvInternos.Name = "dtvInternos";
            this.dtvInternos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtvInternos.Size = new System.Drawing.Size(677, 345);
            this.dtvInternos.TabIndex = 2;
            this.dtvInternos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtvInternos_KeyDown);
            // 
            // txtBuscarApellidoInternos
            // 
            this.txtBuscarApellidoInternos.Location = new System.Drawing.Point(89, 49);
            this.txtBuscarApellidoInternos.Name = "txtBuscarApellidoInternos";
            this.txtBuscarApellidoInternos.Size = new System.Drawing.Size(216, 20);
            this.txtBuscarApellidoInternos.TabIndex = 0;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(12, 51);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(74, 16);
            this.label26.TabIndex = 79;
            this.label26.Text = "APELLIDO:";
            // 
            // btnBuscarApellido
            // 
            this.btnBuscarApellido.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnBuscarApellido.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscarApellido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarApellido.ForeColor = System.Drawing.Color.White;
            this.btnBuscarApellido.Location = new System.Drawing.Point(315, 37);
            this.btnBuscarApellido.Name = "btnBuscarApellido";
            this.btnBuscarApellido.Size = new System.Drawing.Size(80, 45);
            this.btnBuscarApellido.TabIndex = 1;
            this.btnBuscarApellido.Text = "BUSCAR";
            this.btnBuscarApellido.UseVisualStyleBackColor = false;
            this.btnBuscarApellido.Click += new System.EventHandler(this.btnBuscarApellido_Click);
            // 
            // FormInternos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 450);
            this.Controls.Add(this.btnBuscarApellido);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.dtvInternos);
            this.Controls.Add(this.txtBuscarApellidoInternos);
            this.Controls.Add(this.label28);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormInternos";
            this.ShowInTaskbar = false;
            this.Text = "Buscar interno";
            ((System.ComponentModel.ISupportInitialize)(this.dtvInternos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.DataGridView dtvInternos;
        private System.Windows.Forms.TextBox txtBuscarApellidoInternos;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnBuscarApellido;
    }
}