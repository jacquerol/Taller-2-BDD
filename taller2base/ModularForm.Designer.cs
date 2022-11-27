
namespace taller2base
{
    partial class ModularForm
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
            this.label1 = new global::System.Windows.Forms.Label();
            this.boxLabel = new global::System.Windows.Forms.Label();
            this.button1 = new global::System.Windows.Forms.Button();
            this.comboBox1 = new global::System.Windows.Forms.ComboBox();
            this.textBox1 = new global::System.Windows.Forms.TextBox();
            this.button2 = new global::System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new global::System.Drawing.Font("Impact", 24F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new global::System.Drawing.Point(104, 44);
            this.label1.Name = "label1";
            this.label1.Size = new global::System.Drawing.Size(69, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "title";
            this.label1.Click += new global::System.EventHandler(this.label1_Click);
            // 
            // boxLabel
            // 
            this.boxLabel.AutoSize = true;
            this.boxLabel.Location = new global::System.Drawing.Point(175, 94);
            this.boxLabel.Name = "boxLabel";
            this.boxLabel.Size = new global::System.Drawing.Size(35, 13);
            this.boxLabel.TabIndex = 2;
            this.boxLabel.Text = "label2";
            // 
            // button1
            // 
            this.button1.Location = new global::System.Drawing.Point(284, 110);
            this.button1.Name = "button1";
            this.button1.Size = new global::System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Enviar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new global::System.EventHandler(this.click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new global::System.Drawing.Point(157, 110);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new global::System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new global::System.Drawing.Point(157, 110);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new global::System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new global::System.Drawing.Point(178, 137);
            this.button2.Name = "button2";
            this.button2.Size = new global::System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new global::System.EventHandler(this.cancelButtonk);
            // 
            // ModularForm
            // 
            this.AutoScaleDimensions = new global::System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new global::System.Drawing.Size(451, 238);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.boxLabel);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModularForm";
            this.Text = "Ingreso de datos";
            //this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private global::System.Windows.Forms.Label label1;
        private global::System.Windows.Forms.Label boxLabel;
        private global::System.Windows.Forms.Button button1;
        private global::System.Windows.Forms.ComboBox comboBox1;
        private global::System.Windows.Forms.TextBox textBox1;
        private global::System.Windows.Forms.Button button2;
    }
}