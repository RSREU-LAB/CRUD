namespace CRUD
{
    partial class MainForm
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
            this.entityConnection1 = new System.Data.Entity.Core.EntityClient.EntityConnection();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.tabControlProductivity = new System.Windows.Forms.TabControl();
            this.Productivity = new System.Windows.Forms.TabPage();
            this.addButtonProductivity = new System.Windows.Forms.Button();
            this.editButtonProductivity = new System.Windows.Forms.Button();
            this.deleteButtonProductivity = new System.Windows.Forms.Button();
            this.dataGridViewProductivity = new System.Windows.Forms.DataGridView();
            this.Culture = new System.Windows.Forms.TabPage();
            this.addButtonCulture = new System.Windows.Forms.Button();
            this.editButtonCulture = new System.Windows.Forms.Button();
            this.deleteButtonCulture = new System.Windows.Forms.Button();
            this.dataGridViewCulture = new System.Windows.Forms.DataGridView();
            this.District = new System.Windows.Forms.TabPage();
            this.addButtonDistrict = new System.Windows.Forms.Button();
            this.editButtonDistrict = new System.Windows.Forms.Button();
            this.deleteButtonDistrict = new System.Windows.Forms.Button();
            this.dataGridViewDistrict = new System.Windows.Forms.DataGridView();
            this.tabControlProductivity.SuspendLayout();
            this.Productivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductivity)).BeginInit();
            this.Culture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCulture)).BeginInit();
            this.District.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDistrict)).BeginInit();
            this.SuspendLayout();
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // tabControlProductivity
            // 
            this.tabControlProductivity.Controls.Add(this.Productivity);
            this.tabControlProductivity.Controls.Add(this.Culture);
            this.tabControlProductivity.Controls.Add(this.District);
            this.tabControlProductivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlProductivity.Location = new System.Drawing.Point(0, 0);
            this.tabControlProductivity.Name = "tabControlProductivity";
            this.tabControlProductivity.SelectedIndex = 0;
            this.tabControlProductivity.Size = new System.Drawing.Size(953, 450);
            this.tabControlProductivity.TabIndex = 0;
            // 
            // Productivity
            // 
            this.Productivity.Controls.Add(this.addButtonProductivity);
            this.Productivity.Controls.Add(this.editButtonProductivity);
            this.Productivity.Controls.Add(this.deleteButtonProductivity);
            this.Productivity.Controls.Add(this.dataGridViewProductivity);
            this.Productivity.Location = new System.Drawing.Point(4, 25);
            this.Productivity.Name = "Productivity";
            this.Productivity.Padding = new System.Windows.Forms.Padding(3);
            this.Productivity.Size = new System.Drawing.Size(945, 421);
            this.Productivity.TabIndex = 1;
            this.Productivity.Text = "Productivity";
            this.Productivity.UseVisualStyleBackColor = true;
            // 
            // addButtonProductivity
            // 
            this.addButtonProductivity.Location = new System.Drawing.Point(489, 363);
            this.addButtonProductivity.Name = "addButtonProductivity";
            this.addButtonProductivity.Size = new System.Drawing.Size(144, 50);
            this.addButtonProductivity.TabIndex = 3;
            this.addButtonProductivity.Text = "Add";
            this.addButtonProductivity.UseVisualStyleBackColor = true;
            this.addButtonProductivity.Click += new System.EventHandler(this.addButtonProductivity_Click);
            // 
            // editButtonProductivity
            // 
            this.editButtonProductivity.Location = new System.Drawing.Point(339, 363);
            this.editButtonProductivity.Name = "editButtonProductivity";
            this.editButtonProductivity.Size = new System.Drawing.Size(144, 50);
            this.editButtonProductivity.TabIndex = 2;
            this.editButtonProductivity.Text = "Edit";
            this.editButtonProductivity.UseVisualStyleBackColor = true;
            this.editButtonProductivity.Click += new System.EventHandler(this.editButtonProductivity_Click);
            // 
            // deleteButtonProductivity
            // 
            this.deleteButtonProductivity.Location = new System.Drawing.Point(8, 363);
            this.deleteButtonProductivity.Name = "deleteButtonProductivity";
            this.deleteButtonProductivity.Size = new System.Drawing.Size(144, 50);
            this.deleteButtonProductivity.TabIndex = 1;
            this.deleteButtonProductivity.Text = "Delete";
            this.deleteButtonProductivity.UseVisualStyleBackColor = true;
            this.deleteButtonProductivity.Click += new System.EventHandler(this.deleteButtonProductivity_Click);
            // 
            // dataGridViewProductivity
            // 
            this.dataGridViewProductivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProductivity.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewProductivity.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewProductivity.Name = "dataGridViewProductivity";
            this.dataGridViewProductivity.RowHeadersWidth = 51;
            this.dataGridViewProductivity.RowTemplate.Height = 24;
            this.dataGridViewProductivity.Size = new System.Drawing.Size(939, 354);
            this.dataGridViewProductivity.TabIndex = 0;
            // 
            // Culture
            // 
            this.Culture.Controls.Add(this.addButtonCulture);
            this.Culture.Controls.Add(this.editButtonCulture);
            this.Culture.Controls.Add(this.deleteButtonCulture);
            this.Culture.Controls.Add(this.dataGridViewCulture);
            this.Culture.Location = new System.Drawing.Point(4, 25);
            this.Culture.Name = "Culture";
            this.Culture.Padding = new System.Windows.Forms.Padding(3);
            this.Culture.Size = new System.Drawing.Size(945, 421);
            this.Culture.TabIndex = 2;
            this.Culture.Text = "Culture";
            this.Culture.UseVisualStyleBackColor = true;
            // 
            // addButtonCulture
            // 
            this.addButtonCulture.Location = new System.Drawing.Point(489, 365);
            this.addButtonCulture.Name = "addButtonCulture";
            this.addButtonCulture.Size = new System.Drawing.Size(144, 50);
            this.addButtonCulture.TabIndex = 6;
            this.addButtonCulture.Text = "Add";
            this.addButtonCulture.UseVisualStyleBackColor = true;
            this.addButtonCulture.Click += new System.EventHandler(this.addButtonCulture_Click);
            // 
            // editButtonCulture
            // 
            this.editButtonCulture.Location = new System.Drawing.Point(339, 365);
            this.editButtonCulture.Name = "editButtonCulture";
            this.editButtonCulture.Size = new System.Drawing.Size(144, 50);
            this.editButtonCulture.TabIndex = 5;
            this.editButtonCulture.Text = "Edit";
            this.editButtonCulture.UseVisualStyleBackColor = true;
            this.editButtonCulture.Click += new System.EventHandler(this.editButtonCulture_Click);
            // 
            // deleteButtonCulture
            // 
            this.deleteButtonCulture.Location = new System.Drawing.Point(8, 365);
            this.deleteButtonCulture.Name = "deleteButtonCulture";
            this.deleteButtonCulture.Size = new System.Drawing.Size(144, 50);
            this.deleteButtonCulture.TabIndex = 4;
            this.deleteButtonCulture.Text = "Delete";
            this.deleteButtonCulture.UseVisualStyleBackColor = true;
            this.deleteButtonCulture.Click += new System.EventHandler(this.deleteButtonCulture_Click);
            // 
            // dataGridViewCulture
            // 
            this.dataGridViewCulture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCulture.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewCulture.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewCulture.Name = "dataGridViewCulture";
            this.dataGridViewCulture.RowHeadersWidth = 51;
            this.dataGridViewCulture.RowTemplate.Height = 24;
            this.dataGridViewCulture.Size = new System.Drawing.Size(939, 355);
            this.dataGridViewCulture.TabIndex = 1;
            // 
            // District
            // 
            this.District.Controls.Add(this.addButtonDistrict);
            this.District.Controls.Add(this.editButtonDistrict);
            this.District.Controls.Add(this.deleteButtonDistrict);
            this.District.Controls.Add(this.dataGridViewDistrict);
            this.District.Location = new System.Drawing.Point(4, 25);
            this.District.Name = "District";
            this.District.Padding = new System.Windows.Forms.Padding(3);
            this.District.Size = new System.Drawing.Size(945, 421);
            this.District.TabIndex = 3;
            this.District.Text = "District";
            this.District.UseVisualStyleBackColor = true;
            // 
            // addButtonDistrict
            // 
            this.addButtonDistrict.Location = new System.Drawing.Point(489, 363);
            this.addButtonDistrict.Name = "addButtonDistrict";
            this.addButtonDistrict.Size = new System.Drawing.Size(144, 50);
            this.addButtonDistrict.TabIndex = 6;
            this.addButtonDistrict.Text = "Add";
            this.addButtonDistrict.UseVisualStyleBackColor = true;
            this.addButtonDistrict.Click += new System.EventHandler(this.addButtonDistrict_Click);
            // 
            // editButtonDistrict
            // 
            this.editButtonDistrict.Location = new System.Drawing.Point(339, 363);
            this.editButtonDistrict.Name = "editButtonDistrict";
            this.editButtonDistrict.Size = new System.Drawing.Size(144, 50);
            this.editButtonDistrict.TabIndex = 5;
            this.editButtonDistrict.Text = "Edit";
            this.editButtonDistrict.UseVisualStyleBackColor = true;
            this.editButtonDistrict.Click += new System.EventHandler(this.editButtonDistrict_Click);
            // 
            // deleteButtonDistrict
            // 
            this.deleteButtonDistrict.Location = new System.Drawing.Point(8, 363);
            this.deleteButtonDistrict.Name = "deleteButtonDistrict";
            this.deleteButtonDistrict.Size = new System.Drawing.Size(144, 50);
            this.deleteButtonDistrict.TabIndex = 4;
            this.deleteButtonDistrict.Text = "Delete";
            this.deleteButtonDistrict.UseVisualStyleBackColor = true;
            this.deleteButtonDistrict.Click += new System.EventHandler(this.deleteButtonDistrict_Click);
            // 
            // dataGridViewDistrict
            // 
            this.dataGridViewDistrict.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDistrict.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewDistrict.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewDistrict.Name = "dataGridViewDistrict";
            this.dataGridViewDistrict.RowHeadersWidth = 51;
            this.dataGridViewDistrict.RowTemplate.Height = 24;
            this.dataGridViewDistrict.Size = new System.Drawing.Size(939, 353);
            this.dataGridViewDistrict.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 450);
            this.Controls.Add(this.tabControlProductivity);
            this.Name = "MainForm";
            this.Text = "Crud";
            this.tabControlProductivity.ResumeLayout(false);
            this.Productivity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductivity)).EndInit();
            this.Culture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCulture)).EndInit();
            this.District.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDistrict)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.Entity.Core.EntityClient.EntityConnection entityConnection1;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.TabControl tabControlProductivity;
        private System.Windows.Forms.TabPage Productivity;
        private System.Windows.Forms.TabPage Culture;
        private System.Windows.Forms.TabPage District;
        private System.Windows.Forms.DataGridView dataGridViewProductivity;
        private System.Windows.Forms.DataGridView dataGridViewCulture;
        private System.Windows.Forms.DataGridView dataGridViewDistrict;
        private System.Windows.Forms.Button addButtonProductivity;
        private System.Windows.Forms.Button editButtonProductivity;
        private System.Windows.Forms.Button deleteButtonProductivity;
        private System.Windows.Forms.Button addButtonCulture;
        private System.Windows.Forms.Button editButtonCulture;
        private System.Windows.Forms.Button deleteButtonCulture;
        private System.Windows.Forms.Button addButtonDistrict;
        private System.Windows.Forms.Button editButtonDistrict;
        private System.Windows.Forms.Button deleteButtonDistrict;
    }
}

