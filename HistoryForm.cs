using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SkySea
{
    public partial class HistoryForm : Form
    {
        private Database db;

        public HistoryForm()
        {
            InitializeComponent();
            db = new Database();
            LoadHistory();
        }

        private void InitializeComponent()
        {
            this.Text = LanguageManager.Instance.GetString("HistoryTitle");
            this.Size = new Size(900, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitle = new Label();
            lblTitle.Text = LanguageManager.Instance.GetString("History");
            lblTitle.Location = new Point(350, 20);
            lblTitle.Size = new Size(200, 30);
            lblTitle.Font = new Font("Arial", 16, FontStyle.Bold);

            DataGridView dataGridView = new DataGridView();
            dataGridView.Location = new Point(50, 70);
            dataGridView.Size = new Size(800, 500);
            dataGridView.ReadOnly = true;

            Button btnBack = new Button();
            btnBack.Text = LanguageManager.Instance.GetString("Back");
            btnBack.Location = new Point(350, 600);
            btnBack.Size = new Size(100, 30);
            btnBack.Click += (s, e) =>
            {
                this.Hide();
                new ProfileForm().Show();
                this.Opacity = 0;
                this.Show();
                this.Opacity = 1;
            };

            this.Controls.AddRange(new Control[] { lblTitle, dataGridView, btnBack });
        }

        private void LoadHistory()
        {
            if (db.OpenConnection())
            {
                string query = "SELECT * FROM rezervasyonlar WHERE kullanici_adi = 'testkullanici'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, db.GetConnection());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (Control control in this.Controls)
                {
                    if (control is DataGridView dgv)
                    {
                        dgv.DataSource = dt;
                    }
                }
                db.CloseConnection();
            }
        }
    }
}