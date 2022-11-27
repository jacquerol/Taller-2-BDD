
namespace taller2base
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private global::System.ComponentModel.IContainer components = null;

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
            this.modifyButton = new global::System.Windows.Forms.Button();
            this.statisticsButton = new global::System.Windows.Forms.Button();
            this.title = new global::System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // modifyButton
            // 
            this.modifyButton.Location = new global::System.Drawing.Point(393, 195);
            this.modifyButton.Margin = new global::System.Windows.Forms.Padding(4, 3, 4, 3);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new global::System.Drawing.Size(132, 58);
            this.modifyButton.TabIndex = 0;
            this.modifyButton.Text = "Modificar datos";
            this.modifyButton.UseVisualStyleBackColor = true;
            this.modifyButton.Click += new global::System.EventHandler(this.modifyButton_Click);
            // 
            // statisticsButton
            // 
            this.statisticsButton.Location = new global::System.Drawing.Point(393, 260);
            this.statisticsButton.Margin = new global::System.Windows.Forms.Padding(4, 3, 4, 3);
            this.statisticsButton.Name = "statisticsButton";
            this.statisticsButton.Size = new global::System.Drawing.Size(132, 65);
            this.statisticsButton.TabIndex = 2;
            this.statisticsButton.Text = "Consultar datos";
            this.statisticsButton.UseVisualStyleBackColor = true;
            this.statisticsButton.Click += new global::System.EventHandler(this.statisticsButton_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = global::System.Drawing.SystemColors.GradientInactiveCaption;
            this.title.Font = new global::System.Drawing.Font("Impact", 24F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point);
            this.title.ForeColor = global::System.Drawing.SystemColors.ActiveCaptionText;
            this.title.Location = new global::System.Drawing.Point(338, 133);
            this.title.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
            this.title.Name = "title";
            this.title.Size = new global::System.Drawing.Size(246, 39);
            this.title.TabIndex = 5;
            this.title.Text = "Empresa ABC S. A.";
            this.title.Click += new global::System.EventHandler(this.label1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new global::System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new global::System.Drawing.Size(933, 545);
            this.Controls.Add(this.title);
            this.Controls.Add(this.statisticsButton);
            this.Controls.Add(this.modifyButton);
            this.Margin = new global::System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Librería antofagasta libros";
            this.Load += new global::System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private global::System.Windows.Forms.Button modifyButton;
        private global::System.Windows.Forms.Button statisticsButton;
        private global::System.Windows.Forms.Label title;
    }
}

