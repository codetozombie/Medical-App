using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Medical_App
{
    public partial class AppointmentForm : Form
    {
        public AppointmentForm()
        {
            InitializeComponent();
            LoadDoctors();
            LoadPatients();
        }

        private void LoadDoctors()
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT DoctorID, FullName + ' (' + Specialty + ')' AS DisplayName " +
                                   "FROM Doctors WHERE Availability = 1 ORDER BY FullName";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            cmbDoctor.Items.Clear();
                            while (reader.Read())
                            {
                                cmbDoctor.Items.Add(new ComboBoxItem
                                {
                                    Text = reader["DisplayName"].ToString(),
                                    Value = Convert.ToInt32(reader["DoctorID"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading doctors: {ex.Message}", "Database Error", 
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPatients()
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT PatientID, FullName FROM Patients ORDER BY FullName";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            cmbPatient.Items.Clear();
                            while (reader.Read())
                            {
                                cmbPatient.Items.Add(new ComboBoxItem
                                {
                                    Text = reader["FullName"].ToString(),
                                    Value = Convert.ToInt32(reader["PatientID"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading patients: {ex.Message}", "Database Error", 
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                BookAppointment();
            }
        }

        private bool ValidateInput()
        {
            if (cmbDoctor.SelectedItem == null)
            {
                MessageBox.Show("Please select a doctor.", "Validation Error", 
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbPatient.SelectedItem == null)
            {
                MessageBox.Show("Please select a patient.", "Validation Error", 
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpAppointmentDate.Value <= DateTime.Now)
            {
                MessageBox.Show("Please select a future date and time.", "Validation Error", 
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void BookAppointment()
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    // Check for conflicting appointments
                    string checkQuery = "SELECT COUNT(*) FROM Appointments WHERE DoctorID = @DoctorID " +
                                       "AND AppointmentDate = @AppointmentDate";
                    
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.Add("@DoctorID", SqlDbType.Int).Value = 
                            ((ComboBoxItem)cmbDoctor.SelectedItem).Value;
                        checkCommand.Parameters.Add("@AppointmentDate", SqlDbType.DateTime).Value = 
                            dtpAppointmentDate.Value;
                        
                        int conflictCount = (int)checkCommand.ExecuteScalar();
                        
                        if (conflictCount > 0)
                        {
                            MessageBox.Show("The selected doctor already has an appointment at this time. " +
                                           "Please choose a different time.", "Conflict Error", 
                                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    
                    // Insert the new appointment
                    string insertQuery = "INSERT INTO Appointments (DoctorID, PatientID, AppointmentDate, Notes) " +
                                        "VALUES (@DoctorID, @PatientID, @AppointmentDate, @Notes)";
                    
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.Add("@DoctorID", SqlDbType.Int).Value = 
                            ((ComboBoxItem)cmbDoctor.SelectedItem).Value;
                        insertCommand.Parameters.Add("@PatientID", SqlDbType.Int).Value = 
                            ((ComboBoxItem)cmbPatient.SelectedItem).Value;
                        insertCommand.Parameters.Add("@AppointmentDate", SqlDbType.DateTime).Value = 
                            dtpAppointmentDate.Value;
                        insertCommand.Parameters.Add("@Notes", SqlDbType.VarChar).Value = 
                            string.IsNullOrEmpty(txtNotes.Text) ? (object)DBNull.Value : txtNotes.Text;
                        
                        int rowsAffected = insertCommand.ExecuteNonQuery();
                        
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Appointment booked successfully!", "Success", 
                                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm();
                        }
                        else
                        {
                            MessageBox.Show("Failed to book appointment.", "Error", 
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error booking appointment: {ex.Message}", "Database Error", 
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            cmbDoctor.SelectedIndex = -1;
            cmbPatient.SelectedIndex = -1;
            dtpAppointmentDate.Value = DateTime.Now.AddHours(1);
            txtNotes.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}