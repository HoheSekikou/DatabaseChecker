namespace DatabaseChecker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMirarRegistros = new System.Windows.Forms.Button();
            this.lblCadenaConexion = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tbCadenaConexion = new System.Windows.Forms.TextBox();
            this.lblResultados = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMirarRegistros
            // 
            this.btnMirarRegistros.Location = new System.Drawing.Point(609, 1);
            this.btnMirarRegistros.Name = "btnMirarRegistros";
            this.btnMirarRegistros.Size = new System.Drawing.Size(101, 23);
            this.btnMirarRegistros.TabIndex = 0;
            this.btnMirarRegistros.Text = "Mirar registros";
            this.btnMirarRegistros.UseVisualStyleBackColor = true;
            this.btnMirarRegistros.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblCadenaConexion
            // 
            this.lblCadenaConexion.AutoSize = true;
            this.lblCadenaConexion.Location = new System.Drawing.Point(12, 9);
            this.lblCadenaConexion.Name = "lblCadenaConexion";
            this.lblCadenaConexion.Size = new System.Drawing.Size(118, 15);
            this.lblCadenaConexion.TabIndex = 1;
            this.lblCadenaConexion.Text = "Cadena de conexion:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 27);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(776, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // tbCadenaConexion
            // 
            this.tbCadenaConexion.Location = new System.Drawing.Point(136, 1);
            this.tbCadenaConexion.Name = "tbCadenaConexion";
            this.tbCadenaConexion.PlaceholderText = "Introduce una cadena de conexion";
            this.tbCadenaConexion.Size = new System.Drawing.Size(467, 23);
            this.tbCadenaConexion.TabIndex = 3;
            // 
            // lblResultados
            // 
            this.lblResultados.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblResultados.Location = new System.Drawing.Point(12, 53);
            this.lblResultados.Multiline = true;
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.ReadOnly = true;
            this.lblResultados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lblResultados.Size = new System.Drawing.Size(776, 385);
            this.lblResultados.TabIndex = 4;
            this.lblResultados.Text = "Resultados de la busqueda: \r\n";
            this.lblResultados.WordWrap = false;
            // 
            // button1
            // 
            this.btnReset.Location = new System.Drawing.Point(716, 1);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(72, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.Reset);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblResultados);
            this.Controls.Add(this.tbCadenaConexion);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblCadenaConexion);
            this.Controls.Add(this.btnMirarRegistros);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Button btnMirarRegistros;
        private Label lblCadenaConexion;
        private ProgressBar progressBar1;
        private TextBox tbCadenaConexion;
        private TextBox lblResultados;
        private Button btnReset;
    }
}