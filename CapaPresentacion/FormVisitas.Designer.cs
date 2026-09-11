namespace CapaPresentacion
{
    partial class FormVisitas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVisitas));
            this.dtgvVisitas = new System.Windows.Forms.DataGridView();
            this.btnBuscarApellido = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.btnBuscarDni = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvVisitas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgvVisitas
            // 
            this.dtgvVisitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvVisitas.Location = new System.Drawing.Point(9, 26);
            this.dtgvVisitas.Name = "dtgvVisitas";
            this.dtgvVisitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvVisitas.Size = new System.Drawing.Size(747, 349);
            this.dtgvVisitas.TabIndex = 5;
            this.dtgvVisitas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgvVisitas_KeyDown);
            // 
            // btnBuscarApellido
            // 
            this.btnBuscarApellido.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnBuscarApellido.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscarApellido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarApellido.ForeColor = System.Drawing.Color.White;
            this.btnBuscarApellido.Location = new System.Drawing.Point(11, 70);
            this.btnBuscarApellido.Name = "btnBuscarApellido";
            this.btnBuscarApellido.Size = new System.Drawing.Size(80, 45);
            this.btnBuscarApellido.TabIndex = 2;
            this.btnBuscarApellido.Text = "BUSCAR";
            this.btnBuscarApellido.UseVisualStyleBackColor = false;
            this.btnBuscarApellido.Click += new System.EventHandler(this.btnBuscarApellido_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(8, 19);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(71, 16);
            this.label26.TabIndex = 68;
            this.label26.Text = "APELLIDO";
            this.label26.Click += new System.EventHandler(this.label26_Click);
            // 
            // txtApellido
            // 
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.Location = new System.Drawing.Point(11, 39);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(214, 22);
            this.txtApellido.TabIndex = 1;
            // 
            // btnBuscarDni
            // 
            this.btnBuscarDni.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnBuscarDni.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBuscarDni.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscarDni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarDni.ForeColor = System.Drawing.Color.White;
            this.btnBuscarDni.Location = new System.Drawing.Point(267, 70);
            this.btnBuscarDni.Name = "btnBuscarDni";
            this.btnBuscarDni.Size = new System.Drawing.Size(80, 45);
            this.btnBuscarDni.TabIndex = 4;
            this.btnBuscarDni.Text = "BUSCAR";
            this.btnBuscarDni.UseVisualStyleBackColor = false;
            this.btnBuscarDni.Click += new System.EventHandler(this.btnBuscarDni_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(264, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 71;
            this.label1.Text = "DNI";
            // 
            // txtDni
            // 
            this.txtDni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDni.Location = new System.Drawing.Point(267, 39);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(214, 22);
            this.txtDni.TabIndex = 3;
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
            this.label28.Text = "VISITAS";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.btnBuscarApellido);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtApellido);
            this.groupBox1.Controls.Add(this.txtDni);
            this.groupBox1.Controls.Add(this.btnBuscarDni);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 137);
            this.groupBox1.TabIndex = 76;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgvVisitas);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(764, 388);
            this.groupBox2.TabIndex = 77;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Visitas";
            // 
            // FormVisitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(837, 590);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label28);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormVisitas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  ";
            this.Load += new System.EventHandler(this.Visitas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvVisitas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dtgvVisitas;
        private System.Windows.Forms.Button btnBuscarApellido;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Button btnBuscarDni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}