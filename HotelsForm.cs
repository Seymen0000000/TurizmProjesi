using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SkySea
{
    public partial class HotelsForm : Form
    {
        private Database db;
        private DataGridView dataGridView;

        public HotelsForm()
        {
            InitializeComponent();
            db = new Database();
            LoadHotels();
        }

        private void InitializeComponent()
        {
            this.Text = LanguageManager.Instance.GetString("HotelsTitle");
            this.Size = new Size(900, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitle = new Label();
            lblTitle.Text = LanguageManager.Instance.GetString("Hotels");
            lblTitle.Location = new Point(350, 20);
            lblTitle.Size = new Size(200, 30);
            lblTitle.Font = new Font("Arial", 16, FontStyle.Bold);

            dataGridView = new DataGridView();
            dataGridView.Location = new Point(50, 70);
            dataGridView.Size = new Size(800, 400);
            dataGridView.ReadOnly = true;

            Button btnReserve = new Button();
            btnReserve.Text = LanguageManager.Instance.GetString("Reserve");
            btnReserve.Location = new Point(350, 500);
            btnReserve.Size = new Size(100, 30);
            btnReserve.Click += (s, e) =>
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    string hotelName = dataGridView.SelectedRows[0].Cells["adi"].Value.ToString();
                    string price = dataGridView.SelectedRows[0].Cells["fiyat"].Value.ToString();
                    this.Hide();
                    new PaymentForm("Otel Rezervasyonu", price).Show();
                    this.Opacity = 0;
                    this.Show();
                    this.Opacity = 1;
                }
                else
                {
                    MessageBox.Show(LanguageManager.Instance.GetString("SelectItem"));
                }
            };

            Button btnBack = new Button();
            btnBack.Text = LanguageManager.Instance.GetString("Back");
            btnBack.Location = new Point(350, 550);
            btnBack.Size = new Size(100, 30);
            btnBack.Click += (s, e) =>
            {
                this.Hide();
                new MainForm().Show();
                this.Opacity = 0;
                this.Show();
                this.Opacity = 1;
            };

            this.Controls.AddRange(new Control[] { lblTitle, dataGridView, btnReserve, btnBack });
        }

        private void LoadHotels()
        {
            if (db.OpenConnection())
            {
                string query = "SELECT * FROM oteller";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, db.GetConnection());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView.DataSource = dt;
                db.CloseConnection();
            }
        }
    }
}