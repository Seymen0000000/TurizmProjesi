using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SkySea
{
    public partial class ProfileForm : Form
    {
        private Database db;
        private string username;

        public ProfileForm()
        {
            InitializeComponent();
            db = new Database();
            username = "testkullanici"; // Simülasyon için sabit, gerçekte oturumdan alınmalı
            LoadProfile();
        }

        private void InitializeComponent()
        {
            this.Text = LanguageManager.Instance.GetString("ProfileTitle");
            this.Size = new Size(900, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitle = new Label();
            lblTitle.Text = LanguageManager.Instance.GetString("Profile");
            lblTitle.Location = new Point(350, 20);
            lblTitle.Size = new Size(200, 30);
            lblTitle.Font = new Font("Arial", 16, FontStyle.Bold);

            Label lblUsername = new Label();
            lblUsername.Text = LanguageManager.Instance.GetString("Username") + ": ";
            lblUsername.Location = new Point(50, 70);
            lblUsername.Size = new Size(100, 20);

            Label lblUserValue = new Label();
            lblUserValue.Location = new Point(150, 70);
            lblUserValue.Size = new Size(200, 20);

            Label lblEmail = new Label();
            lblEmail.Text = LanguageManager.Instance.GetString("Email") + ": ";
            lblEmail.Location = new Point(50, 100);
            lblEmail.Size = new Size(100, 20);

            Label lblEmailValue = new Label();
            lblEmailValue.Location = new Point(150, 100);
            lblEmailValue.Size = new Size(200, 20);

            Button btnHistory = new Button();
            btnHistory.Text = LanguageManager.Instance.GetString("History");
            btnHistory.Location = new Point(350, 150);
            btnHistory.Size = new Size(200, 50);
            btnHistory.Click += (s, e) =>
            {
                this.Hide();
                new HistoryForm().Show();
                this.Opacity = 0;
                this.Show();
                this.Opacity = 1;
            };

            Button btnSupport = new Button();
            btnSupport.Text = LanguageManager.Instance.GetString("Support");
            btnSupport.Location = new Point(350, 220);
            btnSupport.Size = new Size(200, 50);
            btnSupport.Click += (s, e) =>
            {
                this.Hide();
                new SupportForm().Show();
                this.Opacity = 0;
                this.Show();
                this.Opacity = 1;
            };

            Button btnBack = new Button();
            btnBack.Text = LanguageManager.Instance.GetString("Back");
            btnBack.Location = new Point(350, 300);
            btnBack.Size = new Size(100, 30);
            btnBack.Click += (s, e) =>
            {
                this.Hide();
                new MainForm().Show();
                this.Opacity = 0;
                this.Show();
                this.Opacity = 1;
            };

            this.Controls.AddRange(new Control[] { lblTitle, lblUsername, lblUserValue, lblEmail, lblEmailValue, btnHistory, btnSupport, btnBack });
        }

        private void LoadProfile()
        {
            if (db.OpenConnection())
            {
                string query = "SELECT kullanici_adi, email FROM kullanicilar WHERE kullanici_adi = @username";
                MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                cmd.Parameters.AddWithValue("@username", username);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    foreach (Control control in this.Controls)
                    {
                        if (control is Label lbl && lbl.Text.StartsWith(LanguageManager.Instance.GetString("Username") + ": "))
                            lbl.Text = LanguageManager.Instance.GetString("Username") + ": " + reader["kullanici_adi"].ToString();
                        else if (control is Label lbl2 && lbl2.Text.StartsWith(LanguageManager.Instance.GetString("Email") + ": "))
                            lbl2.Text = LanguageManager.Instance.GetString("Email") + ": " + reader["email"].ToString();
                    }
                }
                db.CloseConnection();
            }
        }
    }
}