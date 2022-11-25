
namespace taller2base
{
    partial class ModificarDatos
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
            this.salesButton = new System.Windows.Forms.Button();
            this.stockButton = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.modifyComboBox = new System.Windows.Forms.ComboBox();
            this.insertComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // salesButton
            // 
            this.salesButton.Location = new System.Drawing.Point(114, 132);
            this.salesButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.salesButton.Name = "salesButton";
            this.salesButton.Size = new System.Drawing.Size(172, 36);
            this.salesButton.TabIndex = 11;
            this.salesButton.Text = "Atender compra";
            this.salesButton.UseVisualStyleBackColor = true;
            // 
            // stockButton
            // 
            this.stockButton.Location = new System.Drawing.Point(322, 132);
            this.stockButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.stockButton.Name = "stockButton";
            this.stockButton.Size = new System.Drawing.Size(172, 36);
            this.stockButton.TabIndex = 14;
            this.stockButton.Text = "Editar stock";
            this.stockButton.UseVisualStyleBackColor = true;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.title.Location = new System.Drawing.Point(194, 79);
            this.title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(221, 39);
            this.title.TabIndex = 20;
            this.title.Text = "Modificar datos";
            this.title.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.modifyComboBox);
            this.groupBox1.Controls.Add(this.insertComboBox);
            this.groupBox1.Controls.Add(this.title);
            this.groupBox1.Controls.Add(this.salesButton);
            this.groupBox1.Controls.Add(this.stockButton);
            this.groupBox1.Location = new System.Drawing.Point(155, 77);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(619, 324);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(358, 185);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 28);
            this.label2.TabIndex = 24;
            this.label2.Text = "Modificar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(151, 185);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 28);
            this.label1.TabIndex = 23;
            this.label1.Text = "Insertar";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // modifyComboBox
            // 
            this.modifyComboBox.FormattingEnabled = true;
            this.modifyComboBox.Location = new System.Drawing.Point(322, 216);
            this.modifyComboBox.Name = "modifyComboBox";
            this.modifyComboBox.Size = new System.Drawing.Size(172, 23);
            this.modifyComboBox.TabIndex = 22;
            // 
            // insertComboBox
            // 
            this.insertComboBox.FormattingEnabled = true;
            this.insertComboBox.Location = new System.Drawing.Point(114, 216);
            this.insertComboBox.Name = "insertComboBox";
            this.insertComboBox.Size = new System.Drawing.Size(172, 23);
            this.insertComboBox.TabIndex = 21;
            // 
            // ModificarDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModificarDatos";
            this.Text = "Modificar datos";
            this.Load += new System.EventHandler(this.ModificarDatos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Button salesButton;
        internal System.Windows.Forms.Button stockButton;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox modifyComboBox;
        private System.Windows.Forms.ComboBox insertComboBox;
    }
}