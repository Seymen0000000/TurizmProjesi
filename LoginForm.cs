using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
string query = "SELECT * FROM kullanicilar WHERE kullanici_adi = @username AND sifre = @password";
namespace SkySea
{
    public partial class LoginForm : Form
    {
        private Database db;

        public LoginForm()
        {
            InitializeComponent();
            db = new Database();
            LanguageManager.Instance.LoadLanguage("tr");
        }

        private void InitializeComponent()
        {
            this.Text = LanguageManager.Instance.GetString("LoginTitle");
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 248, 255);

            Label lblUsername = new Label();
            lblUsername.Text = LanguageManager.Instance.GetString("Username");
            lblUsername.Location = new Point(50, 50);
            lblUsername.Size = new Size(100, 20);

            TextBox txtUsername = new TextBox();
            txtUsername.Location = new Point(150, 50);
            txtUsername.Size = new Size(150, 20);

            Label lblPassword = new Label();
            lblPassword.Text = LanguageManager.Instance.GetString("Password");
            lblPassword.Location = new Point(50, 90);
            lblPassword.Size = new Size(100, 20);

            TextBox txtPassword = new TextBox();
            txtPassword.Location = new Point(150, 90);
            txtPassword.Size = new Size(150, 20);
            txtPassword.UseSystemPasswordChar = true;

            Button btnLogin = new Button();
            btnLogin.Text = LanguageManager.Instance.GetString("Login");
            btnLogin.Location = new Point(150, 130);
            btnLogin.Size = new Size(100, 30);
            btnLogin.Click += (s, e) =>
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                if (db.OpenConnection())
                {
                    string query = "SELECT * FROM kullanicilar WHERE kullanici_adi = @username AND sifre = @password";
                    MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        MessageBox.Show(LanguageManager.Instance.GetString("LoginSuccess"));
                        this.Hide();
                        new MainForm().Show();
                    }
                    else
                    {
                        MessageBox.Show(LanguageManager.Instance.GetString("LoginFailed"));
                    }
                    db.CloseConnection();
                }
            };

            Button btnRegister = new Button();
            btnRegister.Text = LanguageManager.Instance.GetString("Register");
            btnRegister.Location = new Point(150, 170);
            btnRegister.Size = new Size(100, 30);
            btnRegister.Click += (s, e) =>
            {
                this.Hide();
                new RegisterForm().Show();
            };

            ComboBox cbLanguage = new ComboBox();
            cbLanguage.Items.AddRange(new string[] { "Türkçe", "English" });
            cbLanguage.SelectedIndex = 0;
            cbLanguage.Location = new Point(150, 210);
            cbLanguage.Size = new Size(100, 20);
            cbLanguage.SelectedIndexChanged += (s, e) =>
            {
                LanguageManager.Instance.LoadLanguage(cbLanguage.SelectedItem.ToString() == "Türkçe" ? "tr" : "en");
                this.Controls.Clear();
                InitializeComponent();
            };

            this.Controls.AddRange(new Control[] { lblUsername, txtUsername, lblPassword, txtPassword, btnLogin, btnRegister, cbLanguage });
        }
    }
}