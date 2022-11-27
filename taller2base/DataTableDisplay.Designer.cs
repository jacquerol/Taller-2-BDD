
namespace taller2base
{
    partial class DataTableDisplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private global::System.ComponentModel.IContainer components = null;

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
            this.dataGridView = new global::System.Windows.Forms.DataGridView();
            this.label = new global::System.Windows.Forms.Label();
            this.button1 = new global::System.Windows.Forms.Button();
            ((global::System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.EditMode = global::System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView.Location = new global::System.Drawing.Point(-6, 136);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new global::System.Drawing.Size(660, 226);
            this.dataGridView.TabIndex = 1;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new global::System.Drawing.Font("Segoe UI", 18F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point);
            this.label.Location = new global::System.Drawing.Point(155, 51);
            this.label.Name = "label";
            this.label.Size = new global::System.Drawing.Size(193, 32);
            this.label.TabIndex = 2;
            this.label.Text = "changeableLabel";
            this.label.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
            this.label.Click += new global::System.EventHandler(this.label_Click);
            // 
            // button1
            // 
            this.button1.Location = new global::System.Drawing.Point(273, 313);
            this.button1.Name = "button1";
            this.button1.Size = new global::System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new global::System.EventHandler(this.exit);
            // 
            // DataTableDisplay
            // 
            this.AutoScaleDimensions = new global::System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new global::System.Drawing.Size(651, 352);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.dataGridView);
            this.Name = "DataTableDisplay";
            this.Text = "Resultado";
            this.Load += new global::System.EventHandler(this.DataTableDisplay_Load);
            ((global::System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private global::System.Windows.Forms.DataGridView dataGridView;
        private global::System.Windows.Forms.Label label;
        private global::System.Windows.Forms.Button button1;
    }
}