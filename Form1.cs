using System;
using System.Windows.Forms;

namespace Medical_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Medical Appointment System - Main Menu";
            TestDatabaseConnection();
        }

        private void TestDatabaseConnection()
        {
            if (!DatabaseHelper.TestConnection())
            {
                MessageBox.Show("Cannot connect to the database. Please check your connection string in App.config.", 
                               "Database Connection Error", 
                               MessageBoxButtons.OK, 
                               MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Database connection successful!", 
                               "Connection Test", 
                               MessageBoxButtons.OK, 
                               MessageBoxIcon.Information);
            }
        }

        private void btnViewDoctors_Click(object sender, EventArgs e)
        {
            DoctorListForm doctorForm = new DoctorListForm();
            doctorForm.ShowDialog();
        }

        private void btnBookAppointment_Click(object sender, EventArgs e)
        {
            AppointmentForm appointmentForm = new AppointmentForm();
            appointmentForm.ShowDialog();
        }

        private void btnManageAppointments_Click(object sender, EventArgs e)
        {
            ManageAppointmentsForm manageForm = new ManageAppointmentsForm();
            manageForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
