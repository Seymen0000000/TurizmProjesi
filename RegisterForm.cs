using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SkySea


{
    public partial class RegisterForm : Form
    {
        private Database db;

        public RegisterForm()
        {
            InitializeComponent();
            db = new Database();
        }

        private void InitializeComponent()
        {
            this.Text = LanguageManager.Instance.GetString("RegisterTitle");
            this.Size = new Size(400, 400);
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

            Label lblEmail = new Label();
            lblEmail.Text = LanguageManager.Instance.GetString("Email");
            lblEmail.Location = new Point(50, 130);
            lblEmail.Size = new Size(100, 20);

            TextBox txtEmail = new TextBox();
            txtEmail.Location = new Point(150, 130);
            txtEmail.Size = new Size(150, 20);

            Button btnRegister = new Button();
            btnRegister.Text = LanguageManager.Instance.GetString("Register");
            btnRegister.Location = new Point(150, 170);
            btnRegister.Size = new Size(100, 30);
            btnRegister.Click += (s, e) =>
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                string email = txtEmail.Text;

                if (db.OpenConnection())
                {
                    string query = "INSERT INTO kullanicilar (kullanici_adi, sifre, email) VALUES (@username, @password, @email)";
                    MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@email", email);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show(LanguageManager.Instance.GetString("RegisterSuccess"));
                    db.CloseConnection();

                    this.Hide();
                    new LoginForm().Show();
                }
            };

            Button btnBack = new Button();
            btnBack.Text = LanguageManager.Instance.GetString("Back");
            btnBack.Location = new Point(150, 210);
            btnBack.Size = new Size(100, 30);
            btnBack.Click += (s, e) =>
            {
                this.Hide();
                new LoginForm().Show();
            };

            this.Controls.AddRange(new Control[] { lblUsername, txtUsername, lblPassword, txtPassword, lblEmail, txtEmail, btnRegister, btnBack });
        }
    }
}