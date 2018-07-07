﻿namespace LawFirm.UI
{
    using System;
    using System.Windows.Forms;

    using LawFirm.BLL.Contract;

    public partial class RegistrationForm : Form
    {
        private readonly IUserManager userManager;

        public RegistrationForm()
        {
            this.InitializeComponent();
        }

        public RegistrationForm(IUserManager userManager)
        {
            this.userManager = userManager;
            this.InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            var name = this.textBox1.Text;
            var lastName = this.textBox2.Text;
            var login = this.textBox3.Text;
            var password = this.textBox4.Text;

            try
            {
                this.userManager.Registration(name, lastName, login, password);
                this.Owner.Show();
                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void RegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.FormOwnerClosing)
                Application.Exit();
        }
    }
}
