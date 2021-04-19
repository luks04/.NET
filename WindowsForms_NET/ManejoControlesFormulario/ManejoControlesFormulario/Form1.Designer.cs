namespace ManejoControlesFormulario
{
    partial class Form1
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblComboBox = new System.Windows.Forms.Label();
            this.listaSeleccionItems = new System.Windows.Forms.ComboBox();
            this.radioOpcion1 = new System.Windows.Forms.RadioButton();
            this.radioOpcion3 = new System.Windows.Forms.RadioButton();
            this.lblRadios = new System.Windows.Forms.Label();
            this.lblCheckboxes = new System.Windows.Forms.Label();
            this.marca1 = new System.Windows.Forms.CheckBox();
            this.marca2 = new System.Windows.Forms.CheckBox();
            this.marca3 = new System.Windows.Forms.CheckBox();
            this.lblTituloSueldo = new System.Windows.Forms.Label();
            this.lblSueldo = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSalidaPasatiempos = new System.Windows.Forms.TextBox();
            this.radioOpcion2 = new System.Windows.Forms.RadioButton();
            this.lblBono = new System.Windows.Forms.Label();
            this.labelTituloBono = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.labelTituloDescuento = new System.Windows.Forms.Label();
            this.btnBonoSueldo = new System.Windows.Forms.Button();
            this.btnDescuento = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(413, 34);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(264, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Taller Windows Forms";
            // 
            // lblComboBox
            // 
            this.lblComboBox.AutoSize = true;
            this.lblComboBox.Font = new System.Drawing.Font("Verdana", 12F);
            this.lblComboBox.Location = new System.Drawing.Point(47, 148);
            this.lblComboBox.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComboBox.Name = "lblComboBox";
            this.lblComboBox.Size = new System.Drawing.Size(192, 25);
            this.lblComboBox.TabIndex = 1;
            this.lblComboBox.Text = "Lista de Selección";
            // 
            // listaSeleccionItems
            // 
            this.listaSeleccionItems.FormattingEnabled = true;
            this.listaSeleccionItems.Items.AddRange(new object[] {
            "Abogado",
            "Médico",
            "Ingeniero",
            "Docente",
            "Arquitecto",
            "Aviador"});
            this.listaSeleccionItems.Location = new System.Drawing.Point(284, 149);
            this.listaSeleccionItems.Margin = new System.Windows.Forms.Padding(4);
            this.listaSeleccionItems.Name = "listaSeleccionItems";
            this.listaSeleccionItems.Size = new System.Drawing.Size(160, 24);
            this.listaSeleccionItems.TabIndex = 2;
            this.listaSeleccionItems.SelectedIndexChanged += new System.EventHandler(this.listaSeleccionItems_SelectedIndexChanged);
            // 
            // radioOpcion1
            // 
            this.radioOpcion1.AutoSize = true;
            this.radioOpcion1.Location = new System.Drawing.Point(284, 219);
            this.radioOpcion1.Margin = new System.Windows.Forms.Padding(4);
            this.radioOpcion1.Name = "radioOpcion1";
            this.radioOpcion1.Size = new System.Drawing.Size(121, 21);
            this.radioOpcion1.TabIndex = 3;
            this.radioOpcion1.TabStop = true;
            this.radioOpcion1.Text = "Pago a crédito";
            this.radioOpcion1.UseVisualStyleBackColor = true;
            this.radioOpcion1.CheckedChanged += new System.EventHandler(this.radioOpcion1_CheckedChanged);
            // 
            // radioOpcion3
            // 
            this.radioOpcion3.AutoSize = true;
            this.radioOpcion3.Location = new System.Drawing.Point(284, 278);
            this.radioOpcion3.Margin = new System.Windows.Forms.Padding(4);
            this.radioOpcion3.Name = "radioOpcion3";
            this.radioOpcion3.Size = new System.Drawing.Size(119, 21);
            this.radioOpcion3.TabIndex = 5;
            this.radioOpcion3.TabStop = true;
            this.radioOpcion3.Text = "Pago en Bono";
            this.radioOpcion3.UseVisualStyleBackColor = true;
            this.radioOpcion3.CheckedChanged += new System.EventHandler(this.radioOpcion3_CheckedChanged);
            // 
            // lblRadios
            // 
            this.lblRadios.AutoSize = true;
            this.lblRadios.Font = new System.Drawing.Font("Verdana", 12F);
            this.lblRadios.Location = new System.Drawing.Point(47, 246);
            this.lblRadios.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRadios.Name = "lblRadios";
            this.lblRadios.Size = new System.Drawing.Size(189, 25);
            this.lblRadios.TabIndex = 6;
            this.lblRadios.Text = "Opciones de pago";
            // 
            // lblCheckboxes
            // 
            this.lblCheckboxes.AutoSize = true;
            this.lblCheckboxes.Font = new System.Drawing.Font("Verdana", 12F);
            this.lblCheckboxes.Location = new System.Drawing.Point(47, 383);
            this.lblCheckboxes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCheckboxes.Name = "lblCheckboxes";
            this.lblCheckboxes.Size = new System.Drawing.Size(137, 25);
            this.lblCheckboxes.TabIndex = 7;
            this.lblCheckboxes.Text = "Pasatiempos";
            // 
            // marca1
            // 
            this.marca1.AutoSize = true;
            this.marca1.Location = new System.Drawing.Point(284, 358);
            this.marca1.Margin = new System.Windows.Forms.Padding(4);
            this.marca1.Name = "marca1";
            this.marca1.Size = new System.Drawing.Size(115, 21);
            this.marca1.TabIndex = 8;
            this.marca1.Text = "Ver televisión";
            this.marca1.UseVisualStyleBackColor = true;
            // 
            // marca2
            // 
            this.marca2.AutoSize = true;
            this.marca2.Location = new System.Drawing.Point(284, 388);
            this.marca2.Margin = new System.Windows.Forms.Padding(4);
            this.marca2.Name = "marca2";
            this.marca2.Size = new System.Drawing.Size(83, 21);
            this.marca2.TabIndex = 9;
            this.marca2.Text = "Ir al cine";
            this.marca2.UseVisualStyleBackColor = true;
            // 
            // marca3
            // 
            this.marca3.AutoSize = true;
            this.marca3.Location = new System.Drawing.Point(284, 417);
            this.marca3.Margin = new System.Windows.Forms.Padding(4);
            this.marca3.Name = "marca3";
            this.marca3.Size = new System.Drawing.Size(153, 21);
            this.marca3.TabIndex = 10;
            this.marca3.Text = "Leer libros de .NET";
            this.marca3.UseVisualStyleBackColor = true;
            // 
            // lblTituloSueldo
            // 
            this.lblTituloSueldo.AutoSize = true;
            this.lblTituloSueldo.Font = new System.Drawing.Font("Verdana", 12F);
            this.lblTituloSueldo.Location = new System.Drawing.Point(551, 149);
            this.lblTituloSueldo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTituloSueldo.Name = "lblTituloSueldo";
            this.lblTituloSueldo.Size = new System.Drawing.Size(189, 25);
            this.lblTituloSueldo.TabIndex = 11;
            this.lblTituloSueldo.Text = "Sueldo del cargo:";
            // 
            // lblSueldo
            // 
            this.lblSueldo.AutoSize = true;
            this.lblSueldo.Font = new System.Drawing.Font("Verdana", 12F);
            this.lblSueldo.Location = new System.Drawing.Point(857, 149);
            this.lblSueldo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSueldo.Name = "lblSueldo";
            this.lblSueldo.Size = new System.Drawing.Size(0, 25);
            this.lblSueldo.TabIndex = 12;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(749, 457);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(267, 80);
            this.btnAceptar.TabIndex = 13;
            this.btnAceptar.Text = "Mostrar Pasatiempos";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F);
            this.label1.Location = new System.Drawing.Point(47, 578);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "Pasatiempos del usuario:";
            // 
            // txtSalidaPasatiempos
            // 
            this.txtSalidaPasatiempos.Location = new System.Drawing.Point(357, 567);
            this.txtSalidaPasatiempos.Margin = new System.Windows.Forms.Padding(4);
            this.txtSalidaPasatiempos.Multiline = true;
            this.txtSalidaPasatiempos.Name = "txtSalidaPasatiempos";
            this.txtSalidaPasatiempos.Size = new System.Drawing.Size(343, 129);
            this.txtSalidaPasatiempos.TabIndex = 15;
            // 
            // radioOpcion2
            // 
            this.radioOpcion2.AutoSize = true;
            this.radioOpcion2.Location = new System.Drawing.Point(284, 250);
            this.radioOpcion2.Margin = new System.Windows.Forms.Padding(4);
            this.radioOpcion2.Name = "radioOpcion2";
            this.radioOpcion2.Size = new System.Drawing.Size(135, 21);
            this.radioOpcion2.TabIndex = 16;
            this.radioOpcion2.TabStop = true;
            this.radioOpcion2.Text = "Pago en efectivo";
            this.radioOpcion2.UseVisualStyleBackColor = true;
            this.radioOpcion2.CheckedChanged += new System.EventHandler(this.radioOpcion2_CheckedChanged);
            // 
            // lblBono
            // 
            this.lblBono.AutoSize = true;
            this.lblBono.Font = new System.Drawing.Font("Verdana", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBono.Location = new System.Drawing.Point(631, 183);
            this.lblBono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBono.Name = "lblBono";
            this.lblBono.Size = new System.Drawing.Size(0, 18);
            this.lblBono.TabIndex = 20;
            // 
            // labelTituloBono
            // 
            this.labelTituloBono.AutoSize = true;
            this.labelTituloBono.Font = new System.Drawing.Font("Verdana", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTituloBono.Location = new System.Drawing.Point(551, 183);
            this.labelTituloBono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTituloBono.Name = "labelTituloBono";
            this.labelTituloBono.Size = new System.Drawing.Size(0, 18);
            this.labelTituloBono.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(384, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(343, 22);
            this.label2.TabIndex = 21;
            this.label2.Text = "Lucas Alejandro Patiño Dorado";
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Verdana", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuento.Location = new System.Drawing.Point(662, 222);
            this.lblDescuento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(0, 18);
            this.lblDescuento.TabIndex = 23;
            // 
            // labelTituloDescuento
            // 
            this.labelTituloDescuento.AutoSize = true;
            this.labelTituloDescuento.Font = new System.Drawing.Font("Verdana", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTituloDescuento.Location = new System.Drawing.Point(553, 219);
            this.labelTituloDescuento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTituloDescuento.Name = "labelTituloDescuento";
            this.labelTituloDescuento.Size = new System.Drawing.Size(0, 18);
            this.labelTituloDescuento.TabIndex = 22;
            // 
            // btnBonoSueldo
            // 
            this.btnBonoSueldo.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBonoSueldo.Location = new System.Drawing.Point(749, 635);
            this.btnBonoSueldo.Name = "btnBonoSueldo";
            this.btnBonoSueldo.Size = new System.Drawing.Size(267, 61);
            this.btnBonoSueldo.TabIndex = 25;
            this.btnBonoSueldo.Text = "Calcular bono y actualizar sueldo";
            this.btnBonoSueldo.UseVisualStyleBackColor = true;
            this.btnBonoSueldo.Click += new System.EventHandler(this.btnBonoSueldo_Click);
            // 
            // btnDescuento
            // 
            this.btnDescuento.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescuento.Location = new System.Drawing.Point(749, 567);
            this.btnDescuento.Name = "btnDescuento";
            this.btnDescuento.Size = new System.Drawing.Size(267, 50);
            this.btnDescuento.TabIndex = 26;
            this.btnDescuento.Text = "Calcular descuento";
            this.btnDescuento.UseVisualStyleBackColor = true;
            this.btnDescuento.Click += new System.EventHandler(this.btnDescuento_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 718);
            this.Controls.Add(this.btnDescuento);
            this.Controls.Add(this.btnBonoSueldo);
            this.Controls.Add(this.lblDescuento);
            this.Controls.Add(this.labelTituloDescuento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblBono);
            this.Controls.Add(this.labelTituloBono);
            this.Controls.Add(this.radioOpcion2);
            this.Controls.Add(this.txtSalidaPasatiempos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblSueldo);
            this.Controls.Add(this.lblTituloSueldo);
            this.Controls.Add(this.marca3);
            this.Controls.Add(this.marca2);
            this.Controls.Add(this.marca1);
            this.Controls.Add(this.lblCheckboxes);
            this.Controls.Add(this.lblRadios);
            this.Controls.Add(this.radioOpcion3);
            this.Controls.Add(this.radioOpcion1);
            this.Controls.Add(this.listaSeleccionItems);
            this.Controls.Add(this.lblComboBox);
            this.Controls.Add(this.lblTitulo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblComboBox;
        private System.Windows.Forms.ComboBox listaSeleccionItems;
        private System.Windows.Forms.RadioButton radioOpcion1;
        private System.Windows.Forms.RadioButton radioOpcion3;
        private System.Windows.Forms.Label lblRadios;
        private System.Windows.Forms.Label lblCheckboxes;
        private System.Windows.Forms.CheckBox marca1;
        private System.Windows.Forms.CheckBox marca2;
        private System.Windows.Forms.CheckBox marca3;
        private System.Windows.Forms.Label lblTituloSueldo;
        private System.Windows.Forms.Label lblSueldo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSalidaPasatiempos;
        private System.Windows.Forms.RadioButton radioOpcion2;
        private System.Windows.Forms.Label lblBono;
        private System.Windows.Forms.Label labelTituloBono;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label labelTituloDescuento;
        private System.Windows.Forms.Button btnBonoSueldo;
        private System.Windows.Forms.Button btnDescuento;
    }
}

