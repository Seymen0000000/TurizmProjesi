using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SkySea
{
    public partial class GuidesForm : Form
    {
        private Database db;
        private DataGridView dataGridView;

        public GuidesForm()
        {
            InitializeComponent();
            db = new Database();
            LoadGuides();
        }

        private void InitializeComponent()
        {
            this.Text = LanguageManager.Instance.GetString("GuidesTitle");
            this.Size = new Size(900, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitle = new Label();
            lblTitle.Text = LanguageManager.Instance.GetString("Guides");
            lblTitle.Location = new Point(350, 20);
            lblTitle.Size = new Size(200, 30);
            lblTitle.Font = new Font("Arial", 16, FontStyle.Bold);

            dataGridView = new DataGridView();
            dataGridView.Location = new Point(50, 70);
            dataGridView.Size = new Size(800, 400);
            dataGridView.ReadOnly = true;

            Button btnContact = new Button();
            btnContact.Text = LanguageManager.Instance.GetString("Contact");
            btnContact.Location = new Point(350, 500);
            btnContact.Size = new Size(100, 30);
            btnContact.Click += (s, e) =>
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    string guide = dataGridView.SelectedRows[0].Cells["adi"].Value.ToString();
                    MessageBox.Show(LanguageManager.Instance.GetString("ContactGuide") + guide);
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

            this.Controls.AddRange(new Control[] { lblTitle, dataGridView, btnContact, btnBack });
        }

        private void LoadGuides()
        {
            if (db.OpenConnection())
            {
                string query = "SELECT * FROM rehberler";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, db.GetConnection());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView.DataSource = dt;
                db.CloseConnection();
            }
        }
    }
}