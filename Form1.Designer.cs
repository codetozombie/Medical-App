using System.Windows.Forms;

namespace Medical_App
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnViewDoctors;
        private Button btnBookAppointment;
        private Button btnManageAppointments;
        private Button btnExit;
        private Label lblTitle;

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
            this.btnViewDoctors = new Button();
            this.btnBookAppointment = new Button();
            this.btnManageAppointments = new Button();
            this.btnExit = new Button();
            this.lblTitle = new Label();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(200, 50);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Medical Appointment Booking System";

            // btnViewDoctors
            this.btnViewDoctors.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnViewDoctors.Location = new System.Drawing.Point(300, 120);
            this.btnViewDoctors.Name = "btnViewDoctors";
            this.btnViewDoctors.Size = new System.Drawing.Size(200, 50);
            this.btnViewDoctors.TabIndex = 1;
            this.btnViewDoctors.Text = "View Doctors";
            this.btnViewDoctors.UseVisualStyleBackColor = true;
            this.btnViewDoctors.Click += new System.EventHandler(this.btnViewDoctors_Click);

            // btnBookAppointment
            this.btnBookAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnBookAppointment.Location = new System.Drawing.Point(300, 190);
            this.btnBookAppointment.Name = "btnBookAppointment";
            this.btnBookAppointment.Size = new System.Drawing.Size(200, 50);
            this.btnBookAppointment.TabIndex = 2;
            this.btnBookAppointment.Text = "Book Appointment";
            this.btnBookAppointment.UseVisualStyleBackColor = true;
            this.btnBookAppointment.Click += new System.EventHandler(this.btnBookAppointment_Click);

            // btnManageAppointments
            this.btnManageAppointments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnManageAppointments.Location = new System.Drawing.Point(300, 260);
            this.btnManageAppointments.Name = "btnManageAppointments";
            this.btnManageAppointments.Size = new System.Drawing.Size(200, 50);
            this.btnManageAppointments.TabIndex = 3;
            this.btnManageAppointments.Text = "Manage Appointments";
            this.btnManageAppointments.UseVisualStyleBackColor = true;
            this.btnManageAppointments.Click += new System.EventHandler(this.btnManageAppointments_Click);

            // btnExit
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnExit.Location = new System.Drawing.Point(300, 330);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(200, 50);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnManageAppointments);
            this.Controls.Add(this.btnBookAppointment);
            this.Controls.Add(this.btnViewDoctors);
            this.Controls.Add(this.lblTitle);
            this.Name = "Form1";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Medical Appointment System";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

