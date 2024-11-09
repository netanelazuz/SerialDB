namespace LabIntakeApp
{
    partial class AddComponentForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.clientNameTextBox = new System.Windows.Forms.TextBox();
            this.contactPhoneTextBox = new System.Windows.Forms.TextBox();
            this.purposeTextBox = new System.Windows.Forms.TextBox();
            this.serialNumberTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // הגדרות עבור כל רכיב (TextBox, Button, וכד')
            // 
            // לדוגמה:
            // 
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // AddComponentForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.clientNameTextBox);
            this.Controls.Add(this.contactPhoneTextBox);
            this.Controls.Add(this.purposeTextBox);
            this.Controls.Add(this.serialNumberTextBox);
            this.Controls.Add(this.saveButton);
            this.Name = "AddComponentForm";
            this.Text = "Add Component";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox clientNameTextBox;
        private System.Windows.Forms.TextBox contactPhoneTextBox;
        private System.Windows.Forms.TextBox purposeTextBox;
        private System.Windows.Forms.TextBox serialNumberTextBox;
        private System.Windows.Forms.Button saveButton;
    }
}
