using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LabIntakeApp
{
    public partial class MainForm : Form
{
    private DatabaseManager dbManager;

    public MainForm()
    {
        InitializeComponent();
        dbManager = new DatabaseManager();
        LoadData();
    }

    private void LoadData()
    {
        DataTable dataTable = dbManager.GetComponents();
        dataGridView.DataSource = dataTable;
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
        // פתח Form חדש להוספת רכיב ושלח פרטים ל-DatabaseManager
    }
}

}
