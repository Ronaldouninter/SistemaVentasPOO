namespace SistemaVentasPOO
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnVehiculos = new System.Windows.Forms.Button();
            this.btnMecanicos = new System.Windows.Forms.Button();
            this.btnReparaciones = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "SISTEMA DE TALLER MECÁNICO";
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(16, 91);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(229, 112);
            this.btnClientes.TabIndex = 1;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnVehiculos
            // 
            this.btnVehiculos.Location = new System.Drawing.Point(559, 289);
            this.btnVehiculos.Name = "btnVehiculos";
            this.btnVehiculos.Size = new System.Drawing.Size(229, 112);
            this.btnVehiculos.TabIndex = 2;
            this.btnVehiculos.Text = "Vehiculos";
            this.btnVehiculos.UseVisualStyleBackColor = true;
            this.btnVehiculos.Click += new System.EventHandler(this.btnVehiculos_Click);
            // 
            // btnMecanicos
            // 
            this.btnMecanicos.Location = new System.Drawing.Point(559, 91);
            this.btnMecanicos.Name = "btnMecanicos";
            this.btnMecanicos.Size = new System.Drawing.Size(229, 112);
            this.btnMecanicos.TabIndex = 3;
            this.btnMecanicos.Text = "Mecanicos";
            this.btnMecanicos.UseVisualStyleBackColor = true;
            // 
            // btnReparaciones
            // 
            this.btnReparaciones.Location = new System.Drawing.Point(16, 289);
            this.btnReparaciones.Name = "btnReparaciones";
            this.btnReparaciones.Size = new System.Drawing.Size(229, 112);
            this.btnReparaciones.TabIndex = 4;
            this.btnReparaciones.Text = "Reparaciones";
            this.btnReparaciones.UseVisualStyleBackColor = true;
            // 
            // btnReportes
            // 
            this.btnReportes.Location = new System.Drawing.Point(282, 183);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(229, 112);
            this.btnReportes.TabIndex = 5;
            this.btnReportes.Text = "Resportes";
            this.btnReportes.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReportes);
            this.Controls.Add(this.btnReparaciones);
            this.Controls.Add(this.btnMecanicos);
            this.Controls.Add(this.btnVehiculos);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "FrmPrincipal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnVehiculos;
        private System.Windows.Forms.Button btnMecanicos;
        private System.Windows.Forms.Button btnReparaciones;
        private System.Windows.Forms.Button btnReportes;
    }
}

