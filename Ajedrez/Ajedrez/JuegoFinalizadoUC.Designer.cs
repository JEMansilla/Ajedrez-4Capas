namespace Ajedrez
{
    partial class JuegoFinalizadoUC
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.boton_salir = new System.Windows.Forms.Button();
            this.boton_reiniciar = new System.Windows.Forms.Button();
            this.texto_razon = new System.Windows.Forms.Label();
            this.texto_ganador = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // boton_salir
            // 
            this.boton_salir.Location = new System.Drawing.Point(179, 105);
            this.boton_salir.Name = "boton_salir";
            this.boton_salir.Size = new System.Drawing.Size(163, 47);
            this.boton_salir.TabIndex = 7;
            this.boton_salir.Text = "SALIR";
            this.boton_salir.UseVisualStyleBackColor = true;
            this.boton_salir.Click += new System.EventHandler(this.boton_salir_Click);
            // 
            // boton_reiniciar
            // 
            this.boton_reiniciar.Location = new System.Drawing.Point(11, 105);
            this.boton_reiniciar.Name = "boton_reiniciar";
            this.boton_reiniciar.Size = new System.Drawing.Size(163, 47);
            this.boton_reiniciar.TabIndex = 6;
            this.boton_reiniciar.Text = "REINICIAR";
            this.boton_reiniciar.UseVisualStyleBackColor = true;
            this.boton_reiniciar.Click += new System.EventHandler(this.boton_reiniciar_Click);
            // 
            // texto_razon
            // 
            this.texto_razon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.texto_razon.AutoSize = true;
            this.texto_razon.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texto_razon.Location = new System.Drawing.Point(94, 71);
            this.texto_razon.Name = "texto_razon";
            this.texto_razon.Size = new System.Drawing.Size(156, 31);
            this.texto_razon.TabIndex = 5;
            this.texto_razon.Text = "texto_razon";
            this.texto_razon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // texto_ganador
            // 
            this.texto_ganador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.texto_ganador.AutoSize = true;
            this.texto_ganador.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texto_ganador.Location = new System.Drawing.Point(60, 11);
            this.texto_ganador.Name = "texto_ganador";
            this.texto_ganador.Size = new System.Drawing.Size(238, 39);
            this.texto_ganador.TabIndex = 4;
            this.texto_ganador.Text = "texto_ganador";
            this.texto_ganador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // JuegoFinalizadoUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.boton_salir);
            this.Controls.Add(this.boton_reiniciar);
            this.Controls.Add(this.texto_razon);
            this.Controls.Add(this.texto_ganador);
            this.MaximumSize = new System.Drawing.Size(359, 171);
            this.MinimumSize = new System.Drawing.Size(359, 171);
            this.Name = "JuegoFinalizadoUC";
            this.Size = new System.Drawing.Size(359, 171);
            this.Load += new System.EventHandler(this.JuegoFinalizadoUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button boton_salir;
        private System.Windows.Forms.Button boton_reiniciar;
        private System.Windows.Forms.Label texto_razon;
        private System.Windows.Forms.Label texto_ganador;
    }
}
