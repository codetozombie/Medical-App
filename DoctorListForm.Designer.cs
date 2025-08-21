using System.Windows.Forms;

namespace Medical_App
{
    partial class DoctorListForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvDoctors;
        private TextBox txtSearch;
        private ComboBox cmbSpecialty;
        private Label lblSearch;
        private Label lblSpecialty;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvDoctors = new DataGridView();
            this.txtSearch = new TextBox();
            this.cmbSpecialty = new ComboBox();
            this.lblSearch = new Label();
            this.lblSpecialty = new Label();
            this.btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).BeginInit();
            this.SuspendLayout();
            
            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(30, 30);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(75, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search Doctor:";
            
            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(120, 27);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            
            // lblSpecialty
            this.lblSpecialty.AutoSize = true;
            this.lblSpecialty.Location = new System.Drawing.Point(350, 30);
            this.lblSpecialty.Name = "lblSpecialty";
            this.lblSpecialty.Size = new System.Drawing.Size(55, 13);
            this.lblSpecialty.TabIndex = 2;
            this.lblSpecialty.Text = "Specialty:";
            
            // cmbSpecialty
            this.cmbSpecialty.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSpecialty.Location = new System.Drawing.Point(420, 27);
            this.cmbSpecialty.Name = "cmbSpecialty";
            this.cmbSpecialty.Size = new System.Drawing.Size(150, 21);
            this.cmbSpecialty.TabIndex = 3;
            this.cmbSpecialty.SelectedIndexChanged += new System.EventHandler(this.cmbSpecialty_SelectedIndexChanged);
            
            // dgvDoctors
            this.dgvDoctors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoctors.Location = new System.Drawing.Point(30, 70);
            this.dgvDoctors.Name = "dgvDoctors";
            this.dgvDoctors.Size = new System.Drawing.Size(740, 300);
            this.dgvDoctors.TabIndex = 4;
            
            // btnClose
            this.btnClose.Location = new System.Drawing.Point(695, 390);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            
            // DoctorListForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvDoctors);
            this.Controls.Add(this.cmbSpecialty);
            this.Controls.Add(this.lblSpecialty);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Name = "DoctorListForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Doctors List";
            this.Load += new System.EventHandler(this.DoctorListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}