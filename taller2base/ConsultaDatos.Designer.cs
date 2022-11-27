
namespace taller2base
{
    partial class ConsultaDatos
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
            this.clientOrdersButton = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.VendorButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox14 = new System.Windows.Forms.ComboBox();
            this.comboBox15 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.NoSalesButton = new System.Windows.Forms.Button();
            this.productCategoryButton_category = new System.Windows.Forms.ComboBox();
            this.productCategoryButton_client = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.clientPurchaseYearComboBox = new System.Windows.Forms.ComboBox();
            this.Top5Button = new System.Windows.Forms.Button();
            this.rutTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.providerProductQuantity = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.providerProductsButton = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.productProvidersComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.productsByCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.categoryByProductComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.salesDataButton = new System.Windows.Forms.ComboBox();
            this.vendorComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ListadoUniversalComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clientOrdersButton
            // 
            this.clientOrdersButton.FormattingEnabled = true;
            this.clientOrdersButton.Location = new System.Drawing.Point(179, 172);
            this.clientOrdersButton.Name = "clientOrdersButton";
            this.clientOrdersButton.Size = new System.Drawing.Size(103, 23);
            this.clientOrdersButton.TabIndex = 41;
            this.clientOrdersButton.DropDown += new System.EventHandler(this.RellenarCliente);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(232, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 39);
            this.label1.TabIndex = 12;
            this.label1.Text = "Consultar datos";
            // 
            // VendorButton
            // 
            this.VendorButton.Location = new System.Drawing.Point(28, 144);
            this.VendorButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.VendorButton.Name = "VendorButton";
            this.VendorButton.Size = new System.Drawing.Size(115, 62);
            this.VendorButton.TabIndex = 18;
            this.VendorButton.Text = "Vendedores de mayor y menor antiguedad";
            this.VendorButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox14);
            this.groupBox1.Controls.Add(this.comboBox15);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.NoSalesButton);
            this.groupBox1.Controls.Add(this.productCategoryButton_category);
            this.groupBox1.Controls.Add(this.productCategoryButton_client);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.clientPurchaseYearComboBox);
            this.groupBox1.Controls.Add(this.Top5Button);
            this.groupBox1.Controls.Add(this.rutTextBox);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.providerProductQuantity);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.clientOrdersButton);
            this.groupBox1.Controls.Add(this.providerProductsButton);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.productProvidersComboBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.productsByCategoryComboBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.categoryByProductComboBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.salesDataButton);
            this.groupBox1.Controls.Add(this.vendorComboBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ListadoUniversalComboBox);
            this.groupBox1.Controls.Add(this.VendorButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(132, 59);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(685, 386);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // comboBox14
            // 
            this.comboBox14.FormattingEnabled = true;
            this.comboBox14.Location = new System.Drawing.Point(304, 336);
            this.comboBox14.Name = "comboBox14";
            this.comboBox14.Size = new System.Drawing.Size(174, 23);
            this.comboBox14.TabIndex = 56;
            // 
            // comboBox15
            // 
            this.comboBox15.FormattingEnabled = true;
            this.comboBox15.Location = new System.Drawing.Point(304, 307);
            this.comboBox15.Name = "comboBox15";
            this.comboBox15.Size = new System.Drawing.Size(174, 23);
            this.comboBox15.TabIndex = 55;
            this.comboBox15.DropDown += new System.EventHandler(this.RellenarCliente);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Impact", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(305, 286);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(173, 18);
            this.label15.TabIndex = 54;
            this.label15.Text = "Productos comprados por dia";
            // 
            // NoSalesButton
            // 
            this.NoSalesButton.Location = new System.Drawing.Point(524, 310);
            this.NoSalesButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.NoSalesButton.Name = "NoSalesButton";
            this.NoSalesButton.Size = new System.Drawing.Size(115, 62);
            this.NoSalesButton.TabIndex = 53;
            this.NoSalesButton.Text = "Productos sin demanda en el mes";
            this.NoSalesButton.UseVisualStyleBackColor = true;
            // 
            // productCategoryButton_category
            // 
            this.productCategoryButton_category.FormattingEnabled = true;
            this.productCategoryButton_category.Location = new System.Drawing.Point(304, 257);
            this.productCategoryButton_category.Name = "productCategoryButton_category";
            this.productCategoryButton_category.Size = new System.Drawing.Size(174, 23);
            this.productCategoryButton_category.TabIndex = 52;
            this.productCategoryButton_category.DropDown += new System.EventHandler(this.RellenarCategoria);
            // 
            // productCategoryButton_client
            // 
            this.productCategoryButton_client.FormattingEnabled = true;
            this.productCategoryButton_client.Location = new System.Drawing.Point(304, 228);
            this.productCategoryButton_client.Name = "productCategoryButton_client";
            this.productCategoryButton_client.Size = new System.Drawing.Size(174, 23);
            this.productCategoryButton_client.TabIndex = 51;
            this.productCategoryButton_client.DropDown += new System.EventHandler(this.RellenarCliente);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Impact", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(286, 207);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(210, 18);
            this.label14.TabIndex = 50;
            this.label14.Text = "Productos comprados por categoria";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Impact", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(28, 218);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(247, 18);
            this.label13.TabIndex = 49;
            this.label13.Text = "Productos comprados por cliente en el año";
            // 
            // clientPurchaseYearComboBox
            // 
            this.clientPurchaseYearComboBox.FormattingEnabled = true;
            this.clientPurchaseYearComboBox.Location = new System.Drawing.Point(55, 239);
            this.clientPurchaseYearComboBox.Name = "clientPurchaseYearComboBox";
            this.clientPurchaseYearComboBox.Size = new System.Drawing.Size(174, 23);
            this.clientPurchaseYearComboBox.TabIndex = 48;
            this.clientPurchaseYearComboBox.DropDown += new System.EventHandler(this.RellenarCliente);
            // 
            // Top5Button
            // 
            this.Top5Button.Location = new System.Drawing.Point(524, 242);
            this.Top5Button.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Top5Button.Name = "Top5Button";
            this.Top5Button.Size = new System.Drawing.Size(115, 62);
            this.Top5Button.TabIndex = 47;
            this.Top5Button.Text = "Top 5 productos de la semana anterior\r\n";
            this.Top5Button.UseVisualStyleBackColor = true;
            // 
            // rutTextBox
            // 
            this.rutTextBox.Location = new System.Drawing.Point(28, 58);
            this.rutTextBox.Name = "rutTextBox";
            this.rutTextBox.Size = new System.Drawing.Size(118, 23);
            this.rutTextBox.TabIndex = 46;
            this.rutTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DatosPorRut);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Impact", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(45, 37);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 18);
            this.label12.TabIndex = 45;
            this.label12.Text = "Datos por RUT";
            // 
            // providerProductQuantity
            // 
            this.providerProductQuantity.FormattingEnabled = true;
            this.providerProductQuantity.Location = new System.Drawing.Point(55, 297);
            this.providerProductQuantity.Name = "providerProductQuantity";
            this.providerProductQuantity.Size = new System.Drawing.Size(174, 23);
            this.providerProductQuantity.TabIndex = 44;
            this.providerProductQuantity.DropDown += new System.EventHandler(this.RellenarProveedor);
            this.providerProductQuantity.DropDownClosed += new System.EventHandler(this.CantProductosProveedor);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Impact", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(28, 276);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(212, 18);
            this.label11.TabIndex = 43;
            this.label11.Text = "Cantidad de productos de proveedor";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Impact", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(172, 151);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 18);
            this.label10.TabIndex = 42;
            this.label10.Text = "Ordenes de cliente";
            // 
            // providerProductsButton
            // 
            this.providerProductsButton.FormattingEnabled = true;
            this.providerProductsButton.Location = new System.Drawing.Point(343, 115);
            this.providerProductsButton.Name = "providerProductsButton";
            this.providerProductsButton.Size = new System.Drawing.Size(114, 23);
            this.providerProductsButton.TabIndex = 38;
            this.providerProductsButton.DropDown += new System.EventHandler(this.RellenarProveedor);
            this.providerProductsButton.DropDownClosed += new System.EventHandler(this.ProductosDeProveedor);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Impact", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(326, 93);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 18);
            this.label8.TabIndex = 37;
            this.label8.Text = "Productos de proveedor";
            // 
            // productProvidersComboBox
            // 
            this.productProvidersComboBox.FormattingEnabled = true;
            this.productProvidersComboBox.Location = new System.Drawing.Point(343, 172);
            this.productProvidersComboBox.Name = "productProvidersComboBox";
            this.productProvidersComboBox.Size = new System.Drawing.Size(114, 23);
            this.productProvidersComboBox.TabIndex = 36;
            this.productProvidersComboBox.DropDown += new System.EventHandler(this.RellenarProducto);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Impact", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(326, 151);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 18);
            this.label7.TabIndex = 35;
            this.label7.Text = "Proveedores de producto";
            // 
            // productsByCategoryComboBox
            // 
            this.productsByCategoryComboBox.FormattingEnabled = true;
            this.productsByCategoryComboBox.Location = new System.Drawing.Point(524, 115);
            this.productsByCategoryComboBox.Name = "productsByCategoryComboBox";
            this.productsByCategoryComboBox.Size = new System.Drawing.Size(114, 23);
            this.productsByCategoryComboBox.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Impact", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(511, 93);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 18);
            this.label6.TabIndex = 33;
            this.label6.Text = "Productos de categoria";
            // 
            // categoryByProductComboBox
            // 
            this.categoryByProductComboBox.FormattingEnabled = true;
            this.categoryByProductComboBox.Location = new System.Drawing.Point(524, 162);
            this.categoryByProductComboBox.Name = "categoryByProductComboBox";
            this.categoryByProductComboBox.Size = new System.Drawing.Size(114, 23);
            this.categoryByProductComboBox.TabIndex = 32;
            this.categoryByProductComboBox.DropDown += new System.EventHandler(this.RellenarProducto);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Impact", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(511, 141);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 18);
            this.label5.TabIndex = 31;
            this.label5.Text = "Categoria de producto";
            // 
            // salesDataButton
            // 
            this.salesDataButton.FormattingEnabled = true;
            this.salesDataButton.Location = new System.Drawing.Point(172, 115);
            this.salesDataButton.Name = "salesDataButton";
            this.salesDataButton.Size = new System.Drawing.Size(121, 23);
            this.salesDataButton.TabIndex = 30;
            this.salesDataButton.DropDown += new System.EventHandler(this.RellenarCompra);
            this.salesDataButton.DropDownClosed += new System.EventHandler(this.DatosCompra);
            // 
            // vendorComboBox
            // 
            this.vendorComboBox.FormattingEnabled = true;
            this.vendorComboBox.Location = new System.Drawing.Point(25, 115);
            this.vendorComboBox.Name = "vendorComboBox";
            this.vendorComboBox.Size = new System.Drawing.Size(121, 23);
            this.vendorComboBox.TabIndex = 29;
            this.vendorComboBox.DropDown += new System.EventHandler(this.RellenarVendedor);
            this.vendorComboBox.DropDownClosed += new System.EventHandler(this.DatosVendedor);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Impact", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(189, 93);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 18);
            this.label4.TabIndex = 28;
            this.label4.Text = "Datos compra";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Impact", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(43, 93);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 18);
            this.label3.TabIndex = 26;
            this.label3.Text = "Datos vendedor";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(111, 323);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 18);
            this.label2.TabIndex = 24;
            this.label2.Text = "Listado";
            // 
            // ListadoUniversalComboBox
            // 
            this.ListadoUniversalComboBox.FormattingEnabled = true;
            this.ListadoUniversalComboBox.Location = new System.Drawing.Point(84, 344);
            this.ListadoUniversalComboBox.Name = "ListadoUniversalComboBox";
            this.ListadoUniversalComboBox.Size = new System.Drawing.Size(103, 23);
            this.ListadoUniversalComboBox.TabIndex = 13;
            this.ListadoUniversalComboBox.DropDown += new System.EventHandler(this.RellenarListadoUniversal);
            // 
            // ConsultaDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConsultaDatos";
            this.Text = "Consultar datos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button VendorButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ListadoUniversalComboBox;
        private System.Windows.Forms.ComboBox productProvidersComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox productsByCategoryComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox categoryByProductComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox salesDataButton;
        private System.Windows.Forms.ComboBox vendorComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox providerProductsButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox rutTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox providerProductQuantity;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox clientOrdersButton;
        private System.Windows.Forms.ComboBox comboBox14;
        private System.Windows.Forms.ComboBox comboBox15;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button NoSalesButton;
        private System.Windows.Forms.ComboBox productCategoryButton_category;
        private System.Windows.Forms.ComboBox productCategoryButton_client;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox clientPurchaseYearComboBox;
        private System.Windows.Forms.Button Top5Button;
    }
}