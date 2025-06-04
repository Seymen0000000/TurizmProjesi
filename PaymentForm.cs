using System;
using System.Drawing;
using System.Windows.Forms;

namespace SkySea
{
    public partial class PaymentForm : Form
    {
        private string service;
        private string price;

        public PaymentForm(string service, string price)
        {
            this.service = service;
            this.price = price;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = LanguageManager.Instance.GetString("PaymentTitle");
            this.Size = new Size(400, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitle = new Label();
            lblTitle.Text = LanguageManager.Instance.GetString("Payment");
            lblTitle.Location = new Point(150, 20);
            lblTitle.Size = new Size(100, 30);
            lblTitle.Font = new Font("Arial", 14, FontStyle.Bold);

            Label lblService = new Label();
            lblService.Text = LanguageManager.Instance.GetString("Service") + ": " + service;
            lblService.Location = new Point(50, 60);
            lblService.Size = new Size(300, 20);

            Label lblPrice = new Label();
            lblPrice.Text = LanguageManager.Instance.GetString("Price") + ": " + price + " TL";
            lblPrice.Location = new Point(50, 90);
            lblPrice.Size = new Size(300, 20);

            Label lblCardNo = new Label();
            lblCardNo.Text = LanguageManager.Instance.GetString("CardNumber");
            lblCardNo.Location = new Point(50, 130);
            lblCardNo.Size = new Size(100, 20);

            TextBox txtCardNo = new TextBox();
            txtCardNo.Location = new Point(150, 130);
            txtCardNo.Size = new Size(150, 20);

            Label lblExpiry = new Label();
            lblExpiry.Text = LanguageManager.Instance.GetString("ExpiryDate");
            lblExpiry.Location = new Point(50, 170);
            lblExpiry.Size = new Size(100, 20);

            TextBox txtExpiry = new TextBox();
            txtExpiry.Location = new Point(150, 170);
            txtExpiry.Size = new Size(150, 20);

            Label lblCVV = new Label();
            lblCVV.Text = LanguageManager.Instance.GetString("CVV");
            lblCVV.Location = new Point(50, 210);
            lblCVV.Size = new Size(100, 20);

            TextBox txtCVV = new TextBox();
            txtCVV.Location = new Point(150, 210);
            txtCVV.Size = new Size(150, 20);

            Button btnPay = new Button();
            btnPay.Text = LanguageManager.Instance.GetString("Pay");
            btnPay.Location = new Point(150, 250);
            btnPay.Size = new Size(100, 30);
            btnPay.Click += (s, e) =>
            {
                if (string.IsNullOrEmpty(txtCardNo.Text) || string.IsNullOrEmpty(txtExpiry.Text) || string.IsNullOrEmpty(txtCVV.Text))
                {
                    MessageBox.Show(LanguageManager.Instance.GetString("FillAllFields"));
                }
                else
                {
                    MessageBox.Show(LanguageManager.Instance.GetString("PaymentSuccess") + service + " için " + price + " TL ödendi.");
                    this.Hide();
                    new MainForm().Show();
                    this.Opacity = 0;
                    this.Show();
                    this.Opacity = 1;
                }
            };

            Button btnBack = new Button();
            btnBack.Text = LanguageManager.Instance.GetString("Back");
            btnBack.Location = new Point(150, 290);
            btnBack.Size = new Size(100, 30);
            btnBack.Click += (s, e) =>
            {
                this.Hide();
                new MainForm().Show();
                this.Opacity = 0;
                this.Show();
                this.Opacity = 1;
            };

            this.Controls.AddRange(new Control[] { lblTitle, lblService, lblPrice, lblCardNo, txtCardNo, lblExpiry, txtExpiry, lblCVV, txtCVV, btnPay, btnBack });
        }
    }
}