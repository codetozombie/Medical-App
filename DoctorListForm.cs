using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Medical_App
{
    public partial class DoctorListForm : Form
    {
        public DoctorListForm()
        {
            InitializeComponent();
            LoadDoctors();
        }

        private void LoadDoctors()
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT DoctorID, FullName, Specialty, " +
                                   "CASE WHEN Availability = 1 THEN 'Available' ELSE 'Not Available' END AS Status " +
                                   "FROM Doctors";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            dgvDoctors.DataSource = dataTable;
                        }
                    }
                }

                // Format the DataGridView
                dgvDoctors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvDoctors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvDoctors.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading doctors: {ex.Message}", "Database Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterDoctors();
        }

        private void cmbSpecialty_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterDoctors();
        }

        private void FilterDoctors()
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT DoctorID, FullName, Specialty, " +
                                   "CASE WHEN Availability = 1 THEN 'Available' ELSE 'Not Available' END AS Status " +
                                   "FROM Doctors WHERE 1=1";

                    if (!string.IsNullOrEmpty(txtSearch.Text))
                    {
                        query += " AND FullName LIKE @SearchTerm";
                    }

                    if (cmbSpecialty.SelectedItem != null && cmbSpecialty.SelectedItem.ToString() != "All")
                    {
                        query += " AND Specialty = @Specialty";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (!string.IsNullOrEmpty(txtSearch.Text))
                        {
                            command.Parameters.AddWithValue("@SearchTerm", "%" + txtSearch.Text + "%");
                        }

                        if (cmbSpecialty.SelectedItem != null && cmbSpecialty.SelectedItem.ToString() != "All")
                        {
                            command.Parameters.AddWithValue("@Specialty", cmbSpecialty.SelectedItem.ToString());
                        }

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            dgvDoctors.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering doctors: {ex.Message}", "Database Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSpecialties()
        {
            try
            {
                cmbSpecialty.Items.Add("All");

                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT DISTINCT Specialty FROM Doctors ORDER BY Specialty";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbSpecialty.Items.Add(reader["Specialty"].ToString());
                            }
                        }
                    }
                }

                cmbSpecialty.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading specialties: {ex.Message}", "Database Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoctorListForm_Load(object sender, EventArgs e)
        {
            LoadSpecialties();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}