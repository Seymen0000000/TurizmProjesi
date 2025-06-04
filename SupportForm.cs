using System;
using System.Drawing;
using System.Windows.Forms;

namespace SkySea
{
    public partial class SupportForm : Form
    {
        public SupportForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = LanguageManager.Instance.GetString("SupportTitle");
            this.Size = new Size(900, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitle = new Label();
            lblTitle.Text = LanguageManager.Instance.GetString("Support");
            lblTitle.Location = new Point(350, 20);
            lblTitle.Size = new Size(200, 30);
            lblTitle.Font = new Font("Arial", 16, FontStyle.Bold);

            Label lblMessage = new Label();
            lblMessage.Text = LanguageManager.Instance.GetString("SupportMessage");
            lblMessage.Location = new Point(50, 70);
            lblMessage.Size = new Size(800, 400);

            Button btnBack = new Button();
            btnBack.Text = LanguageManager.Instance.GetString("Back");
            btnBack.Location = new Point(350, 500);
            btnBack.Size = new Size(100, 30);
            btnBack.Click += (s, e) =>
            {
                this.Hide();
                new ProfileForm().Show();
                this.Opacity = 0;
                this.Show();
                this.Opacity = 1;
            };

            this.Controls.AddRange(new Control[] { lblTitle, lblMessage, btnBack });
        }
    }
}