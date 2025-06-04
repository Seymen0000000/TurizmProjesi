using System;
using System.Drawing;
using System.Windows.Forms;

namespace SkySea
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = LanguageManager.Instance.GetString("MainTitle");
            this.Size = new Size(900, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 248, 255);

            Label lblWelcome = new Label();
            lblWelcome.Text = LanguageManager.Instance.GetString("WelcomeMessage");
            lblWelcome.Location = new Point(300, 50);
            lblWelcome.Size = new Size(300, 30);
            lblWelcome.Font = new Font("Arial", 16, FontStyle.Bold);
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;

            Button btnHotels = new Button();
            btnHotels.Text = LanguageManager.Instance.GetString("Hotels");
            btnHotels.Location = new Point(350, 150);
            btnHotels.Size = new Size(200, 50);
            btnHotels.BackColor = Color.FromArgb(135, 206, 250);
            btnHotels.Click += (s, e) =>
            {
                this.Hide();
                new HotelsForm().Show();
                this.Opacity = 0;
                this.Show();
                this.Opacity = 1;
            };

            Button btnCarRental = new Button();
            btnCarRental.Text = LanguageManager.Instance.GetString("CarRental");
            btnCarRental.Location = new Point(350, 220);
            btnCarRental.Size = new Size(200, 50);
            btnCarRental.BackColor = Color.FromArgb(135, 206, 250);
            btnCarRental.Click += (s, e) =>
            {
                this.Hide();
                new CarRentalForm().Show();
                this.Opacity = 0;
                this.Show();
                this.Opacity = 1;
            };

            Button btnFlights = new Button();
            btnFlights.Text = LanguageManager.Instance.GetString("Flights");
            btnFlights.Location = new Point(350, 290);
            btnFlights.Size = new Size(200, 50);
            btnFlights.BackColor = Color.FromArgb(135, 206, 250);
            btnFlights.Click += (s, e) =>
            {
                this.Hide();
                new FlightForm().Show();
                this.Opacity = 0;
                this.Show();
                this.Opacity = 1;
            };

            Button btnBus = new Button();
            btnBus.Text = LanguageManager.Instance.GetString("Bus");
            btnBus.Location = new Point(350, 360);
            btnBus.Size = new Size(200, 50);
            btnBus.BackColor = Color.FromArgb(135, 206, 250);
            btnBus.Click += (s, e) =>
            {
                this.Hide();
                new BusForm().Show();
                this.Opacity = 0;
                this.Show();
                this.Opacity = 1;
            };

            Button btnTours = new Button();
            btnTours.Text = LanguageManager.Instance.GetString("Tours");
            btnTours.Location = new Point(350, 430);
            btnTours.Size = new Size(200, 50);
            btnTours.BackColor = Color.FromArgb(135, 206, 250);
            btnTours.Click += (s, e) =>
            {
                this.Hide();
                new ToursForm().Show();
                this.Opacity = 0;
                this.Show();
                this.Opacity = 1;
            };

            Button btnGuides = new Button();
            btnGuides.Text = LanguageManager.Instance.GetString("Guides");
            btnGuides.Location = new Point(350, 500);
            btnGuides.Size = new Size(200, 50);
            btnGuides.BackColor = Color.FromArgb(135, 206, 250);
            btnGuides.Click += (s, e) =>
            {
                this.Hide();
                new GuidesForm().Show();
                this.Opacity = 0;
                this.Show();
                this.Opacity = 1;
            };

            Button btnProfile = new Button();
            btnProfile.Text = LanguageManager.Instance.GetString("Profile");
            btnProfile.Location = new Point(350, 570);
            btnProfile.Size = new Size(200, 50);
            btnProfile.BackColor = Color.FromArgb(135, 206, 250);
            btnProfile.Click += (s, e) =>
            {
                this.Hide();
                new ProfileForm().Show();
                this.Opacity = 0;
                this.Show();
                this.Opacity = 1;
            };

            this.Controls.AddRange(new Control[] { lblWelcome, btnHotels, btnCarRental, btnFlights, btnBus, btnTours, btnGuides, btnProfile });
        }
    }
}