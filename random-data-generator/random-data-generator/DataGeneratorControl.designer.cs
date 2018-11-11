namespace random_data_generator
{
    partial class DataGeneratorControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.entityDropdown = new Futurez.XrmToolBox.Controls.EntitiesDropdownControl();
            this.listbox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDataType = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.numberOfRecordsControl = new System.Windows.Forms.NumericUpDown();
            this.btnGenerateData = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfRecordsControl)).BeginInit();
            this.SuspendLayout();
            // 
            // entityDropdown
            // 
            this.entityDropdown.AutoLoadData = false;
            this.entityDropdown.Dock = System.Windows.Forms.DockStyle.Top;
            this.entityDropdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entityDropdown.Location = new System.Drawing.Point(10, 33);
            this.entityDropdown.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.entityDropdown.Name = "entityDropdown";
            this.entityDropdown.ParentBaseControl = this;
            this.entityDropdown.Service = null;
            this.entityDropdown.Size = new System.Drawing.Size(414, 40);
            this.entityDropdown.TabIndex = 2;
            this.entityDropdown.SelectedItemChanged += new System.EventHandler<Futurez.XrmToolBox.Controls.EntitiesDropdownControl.SelectedItemChangedEventArgs>(this.DoStuffWhenSelectingEntity);
            // 
            // listbox
            // 
            this.listbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.listbox.Enabled = false;
            this.listbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox.FormattingEnabled = true;
            this.listbox.Location = new System.Drawing.Point(10, 99);
            this.listbox.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.listbox.Name = "listbox";
            this.listbox.Size = new System.Drawing.Size(414, 574);
            this.listbox.TabIndex = 4;
            this.listbox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.DoStuffWhenSelectingAField);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select entity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(10, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Select fields to populate";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.entityDropdown);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.listbox);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 673);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.lblDataType);
            this.panel2.Location = new System.Drawing.Point(435, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panel2.Size = new System.Drawing.Size(582, 673);
            this.panel2.TabIndex = 9;
            // 
            // lblDataType
            // 
            this.lblDataType.AutoSize = true;
            this.lblDataType.BackColor = System.Drawing.SystemColors.Control;
            this.lblDataType.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDataType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataType.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblDataType.Location = new System.Drawing.Point(3, 75);
            this.lblDataType.Margin = new System.Windows.Forms.Padding(3, 75, 3, 10);
            this.lblDataType.Name = "lblDataType";
            this.lblDataType.Size = new System.Drawing.Size(424, 20);
            this.lblDataType.TabIndex = 8;
            this.lblDataType.Text = "Select what kind of data should be generated for each field";
            this.lblDataType.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.numberOfRecordsControl);
            this.panel3.Controls.Add(this.btnGenerateData);
            this.panel3.Location = new System.Drawing.Point(0, 679);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(226, 100);
            this.panel3.TabIndex = 10;
            this.panel3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(10, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 3, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(211, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Number of records to create:";
            // 
            // numberOfRecordsControl
            // 
            this.numberOfRecordsControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfRecordsControl.Location = new System.Drawing.Point(14, 26);
            this.numberOfRecordsControl.Margin = new System.Windows.Forms.Padding(14, 3, 3, 3);
            this.numberOfRecordsControl.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numberOfRecordsControl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfRecordsControl.Name = "numberOfRecordsControl";
            this.numberOfRecordsControl.Size = new System.Drawing.Size(175, 24);
            this.numberOfRecordsControl.TabIndex = 13;
            this.numberOfRecordsControl.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnGenerateData
            // 
            this.btnGenerateData.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateData.Location = new System.Drawing.Point(14, 59);
            this.btnGenerateData.Margin = new System.Windows.Forms.Padding(14, 6, 3, 3);
            this.btnGenerateData.Name = "btnGenerateData";
            this.btnGenerateData.Size = new System.Drawing.Size(175, 30);
            this.btnGenerateData.TabIndex = 12;
            this.btnGenerateData.Text = "Generate data";
            this.btnGenerateData.UseVisualStyleBackColor = true;
            this.btnGenerateData.Click += new System.EventHandler(this.GenerateData);
            // 
            // DataGeneratorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "DataGeneratorControl";
            this.Size = new System.Drawing.Size(1400, 800);
            this.Load += new System.EventHandler(this.OnLoad);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfRecordsControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Futurez.XrmToolBox.Controls.EntitiesDropdownControl entityDropdown;
        private System.Windows.Forms.CheckedListBox listbox;
        private System.Windows.Forms.FlowLayoutPanel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel panel2;
        private System.Windows.Forms.Label lblDataType;
        private System.Windows.Forms.FlowLayoutPanel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numberOfRecordsControl;
        private System.Windows.Forms.Button btnGenerateData;
    }
}
