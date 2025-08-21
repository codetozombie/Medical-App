using System.Windows.Forms;

namespace Medical_App
{
    partial class UpdateAppointmentForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.Label lblPatientValue;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.Label lblDoctorValue;
        private System.Windows.Forms.Label lblNewDate;
        private System.Windows.Forms.DateTimePicker dtpNewDate;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;

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
            this.lblPatient = new System.Windows.Forms.Label();
            this.lblPatientValue = new System.Windows.Forms.Label();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.lblDoctorValue = new System.Windows.Forms.Label();
            this.lblNewDate = new System.Windows.Forms.Label();
            this.dtpNewDate = new System.Windows.Forms.DateTimePicker();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            // lblPatient
            this.lblPatient.AutoSize = true;
            this.lblPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPatient.Location = new System.Drawing.Point(30, 30);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(50, 13);
            this.lblPatient.TabIndex = 0;
            this.lblPatient.Text = "Patient:";
            
            // lblPatientValue
            this.lblPatientValue.AutoSize = true;
            this.lblPatientValue.Location = new System.Drawing.Point(100, 30);
            this.lblPatientValue.Name = "lblPatientValue";
            this.lblPatientValue.Size = new System.Drawing.Size(0, 13);
            this.lblPatientValue.TabIndex = 1;
            
            // lblDoctor
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDoctor.Location = new System.Drawing.Point(30, 60);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(48, 13);
            this.lblDoctor.TabIndex = 2;
            this.lblDoctor.Text = "Doctor:";
            
            // lblDoctorValue
            this.lblDoctorValue.AutoSize = true;
            this.lblDoctorValue.Location = new System.Drawing.Point(100, 60);
            this.lblDoctorValue.Name = "lblDoctorValue";
            this.lblDoctorValue.Size = new System.Drawing.Size(0, 13);
            this.lblDoctorValue.TabIndex = 3;
            
            // lblNewDate
            this.lblNewDate.AutoSize = true;
            this.lblNewDate.Location = new System.Drawing.Point(30, 100);
            this.lblNewDate.Name = "lblNewDate";
            this.lblNewDate.Size = new System.Drawing.Size(105, 13);
            this.lblNewDate.TabIndex = 4;
            this.lblNewDate.Text = "New Date and Time:";
            
            // dtpNewDate
            this.dtpNewDate.CustomFormat = "dddd, MMMM dd, yyyy hh:mm tt";
            this.dtpNewDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNewDate.Location = new System.Drawing.Point(150, 97);
            this.dtpNewDate.Name = "dtpNewDate";
            this.dtpNewDate.Size = new System.Drawing.Size(250, 20);
            this.dtpNewDate.TabIndex = 5;
            
            // lblNotes
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(30, 140);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 13);
            this.lblNotes.TabIndex = 6;
            this.lblNotes.Text = "Notes:";
            
            // txtNotes
            this.txtNotes.Location = new System.Drawing.Point(150, 137);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(250, 80);
            this.txtNotes.TabIndex = 7;
            
            // btnUpdate
            this.btnUpdate.Location = new System.Drawing.Point(200, 250);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 30);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            
            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(290, 250);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            
            // UpdateAppointmentForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 320);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.dtpNewDate);
            this.Controls.Add(this.lblNewDate);
            this.Controls.Add(this.lblDoctorValue);
            this.Controls.Add(this.lblDoctor);
            this.Controls.Add(this.lblPatientValue);
            this.Controls.Add(this.lblPatient);
            this.Name = "UpdateAppointmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Appointment";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}