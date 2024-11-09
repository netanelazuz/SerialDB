using System;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class AddComponentForm : Form
{
    public AddComponentForm()
    {
        InitializeComponent();
    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
        // שמירת קומפוננטה חדשה בבסיס הנתונים
        string connectionString = "Data Source=SERVER_NAME;Initial Catalog=LabIntake;Integrated Security=True";
        string query = "INSERT INTO Components (ClientName, ContactPhone, Purpose) VALUES (@ClientName, @ContactPhone, @Purpose)";

        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@ClientName", clientNameTextBox.Text);
            command.Parameters.AddWithValue("@ContactPhone", phoneTextBox.Text);
            command.Parameters.AddWithValue("@Purpose", purposeTextBox.Text);

            connection.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("הקומפוננטה נשמרה בהצלחה.");
            this.Close();
        }
    }
}
