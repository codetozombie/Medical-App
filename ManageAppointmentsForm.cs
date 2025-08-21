using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Medical_App
{
    public partial class ManageAppointmentsForm : Form
    {
        private DataSet appointmentsDataSet;
        private SqlDataAdapter dataAdapter;

        public ManageAppointmentsForm()
        {
            InitializeComponent();
            LoadAppointments();
            LoadPatients();
        }

        private void LoadAppointments()
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = @"SELECT a.AppointmentID, p.FullName AS Patient, 
                                    d.FullName AS Doctor, d.Specialty, 
                                    a.AppointmentDate, a.Notes 
                                    FROM Appointments a 
                                    INNER JOIN Patients p ON a.PatientID = p.PatientID 
                                    INNER JOIN Doctors d ON a.DoctorID = d.DoctorID 
                                    ORDER BY a.AppointmentDate";

                    dataAdapter = new SqlDataAdapter(query, connection);
                    appointmentsDataSet = new DataSet();
                    dataAdapter.Fill(appointmentsDataSet, "Appointments");
                    
                    dgvAppointments.DataSource = appointmentsDataSet.Tables["Appointments"];
                    
                    // Format the DataGridView
                    dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvAppointments.ReadOnly = true;
                    dgvAppointments.Columns["AppointmentID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}", "Database Error", 
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
                            cmbPatientFilter.Items.Add(new ComboBoxItem { Text = "All Patients", Value = -1 });
                            
                            while (reader.Read())
                            {
                                cmbPatientFilter.Items.Add(new ComboBoxItem
                                {
                                    Text = reader["FullName"].ToString(),
                                    Value = Convert.ToInt32(reader["PatientID"])
                                });
                            }
                        }
                    }
                }
                
                cmbPatientFilter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading patients: {ex.Message}", "Database Error", 
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbPatientFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterAppointments();
        }

        private void FilterAppointments()
        {
            try
            {
                if (appointmentsDataSet?.Tables["Appointments"] != null)
                {
                    string filter = "";
                    
                    if (cmbPatientFilter.SelectedItem is ComboBoxItem selectedPatient && selectedPatient.Value != -1)
                    {
                        using (SqlConnection connection = DatabaseHelper.GetConnection())
                        {
                            connection.Open();
                            string patientName = selectedPatient.Text;
                            filter = $"Patient = '{patientName.Replace("'", "''")}'";
                        }
                    }
                    
                    appointmentsDataSet.Tables["Appointments"].DefaultView.RowFilter = filter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering appointments: {ex.Message}", "Filter Error", 
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to update.", "Selection Error", 
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UpdateAppointmentForm updateForm = new UpdateAppointmentForm(
                Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells["AppointmentID"].Value));
            
            if (updateForm.ShowDialog() == DialogResult.OK)
            {
                LoadAppointments();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to delete.", "Selection Error", 
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this appointment?", 
                                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                DeleteAppointment();
            }
        }

        private void DeleteAppointment()
        {
            try
            {
                int appointmentId = Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells["AppointmentID"].Value);
                
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM Appointments WHERE AppointmentID = @AppointmentID";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@AppointmentID", SqlDbType.Int).Value = appointmentId;
                        
                        int rowsAffected = command.ExecuteNonQuery();
                        
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Appointment deleted successfully!", "Success", 
                                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAppointments();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete appointment.", "Error", 
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting appointment: {ex.Message}", "Database Error", 
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAppointments();
        }
    }
}