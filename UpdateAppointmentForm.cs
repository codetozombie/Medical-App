using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Medical_App
{
    public partial class UpdateAppointmentForm : Form
    {
        private int appointmentId;

        public UpdateAppointmentForm(int appointmentId)
        {
            InitializeComponent();
            this.appointmentId = appointmentId;
            LoadAppointmentData();
        }

        private void LoadAppointmentData()
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT a.AppointmentDate, a.Notes, 
                                    p.FullName AS PatientName, d.FullName AS DoctorName 
                                    FROM Appointments a 
                                    INNER JOIN Patients p ON a.PatientID = p.PatientID 
                                    INNER JOIN Doctors d ON a.DoctorID = d.DoctorID 
                                    WHERE a.AppointmentID = @AppointmentID";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AppointmentID", appointmentId);
                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblPatientValue.Text = reader["PatientName"].ToString();
                                lblDoctorValue.Text = reader["DoctorName"].ToString();
                                dtpNewDate.Value = Convert.ToDateTime(reader["AppointmentDate"]);
                                txtNotes.Text = reader["Notes"]?.ToString() ?? "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointment data: {ex.Message}", "Database Error", 
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dtpNewDate.Value <= DateTime.Now)
            {
                MessageBox.Show("Please select a future date and time.", "Validation Error", 
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UpdateAppointment();
        }

        private void UpdateAppointment()
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Appointments SET AppointmentDate = @AppointmentDate, " +
                                  "Notes = @Notes WHERE AppointmentID = @AppointmentID";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@AppointmentDate", SqlDbType.DateTime).Value = dtpNewDate.Value;
                        command.Parameters.Add("@Notes", SqlDbType.VarChar).Value = 
                            string.IsNullOrEmpty(txtNotes.Text) ? (object)DBNull.Value : txtNotes.Text;
                        command.Parameters.Add("@AppointmentID", SqlDbType.Int).Value = appointmentId;
                        
                        int rowsAffected = command.ExecuteNonQuery();
                        
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Appointment updated successfully!", "Success", 
                                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update appointment.", "Error", 
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating appointment: {ex.Message}", "Database Error", 
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}