using System;
using System.Drawing;
using System.Windows.Forms;

namespace SkySea
{
    public class SplashScreen : Form
    {
        private Timer timer;
        private int progress = 0;

        public SplashScreen()
        {
            this.Text = "SkySea - Yükleniyor";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(0, 120, 215);

            Label lblTitle = new Label();
            lblTitle.Text = "SkySea Turizm";
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font("Arial", 20, FontStyle.Bold);
            lblTitle.Location = new Point(120, 100);
            lblTitle.Size = new Size(160, 30);

            ProgressBar progressBar = new ProgressBar();
            progressBar.Location = new Point(50, 150);
            progressBar.Size = new Size(300, 20);
            progressBar.Style = ProgressBarStyle.Continuous;

            timer = new Timer();
            timer.Interval = 50;
            timer.Tick += (s, e) =>
            {
                progress += 2;
                progressBar.Value = progress;
                if (progress >= 100)
                {
                    timer.Stop();
                    this.Hide();
                    new LoginForm().Show();
                }
            };
            timer.Start();

            this.Controls.Add(lblTitle);
            this.Controls.Add(progressBar);
        }
    }
}