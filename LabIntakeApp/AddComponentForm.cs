using System;
using Microsoft.Data.Sqlite;
using System.Windows.Forms;

public partial class AddComponentForm : Form
{
    public AddComponentForm()
    {
        InitializeComponent();
    }

    private void saveButton_Click(object sender, EventArgs e)
    {
        string clientName = clientNameTextBox.Text;
        string contactPhone = contactPhoneTextBox.Text;
        string purpose = purposeTextBox.Text;
        string serialNumber = serialNumberTextBox.Text;

        // בדיקה שכל השדות מולאו
        if (string.IsNullOrWhiteSpace(clientName) || string.IsNullOrWhiteSpace(serialNumber))
        {
            MessageBox.Show("אנא מלא את שם הלקוח והסיריאלי.");
            return;
        }

        // הוספת הנתונים למסד הנתונים
        dbManager.AddComponent(clientName, contactPhone, purpose, serialNumber);

        // עדכון והצגת הודעה על הצלחה
        MessageBox.Show("מחשב הוכנס בהצלחה למערכת.");
        this.Close();
    }
}

}
