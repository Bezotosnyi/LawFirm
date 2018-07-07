namespace LawFirm.UI
{
    using System.Windows.Forms;

    using LawFirm.BLL.Contract;

    public partial class LoginForm : Form
    {
        private readonly IUserManager userManager;

        public LoginForm()
        {
            this.InitializeComponent();
        }

        public LoginForm(IUserManager userManager)
        {
            this.userManager = userManager;
            this.InitializeComponent();
        }

        private void LoginButton_Click(object sender, System.EventArgs e)
        {
            var login = this.loginTextBox.Text;
            var password = this.passwordTextBox.Text;
            if (this.userManager.Login(login, password))
            {
                var mainForm = new MainForm { Owner = this };
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(@"Неправильный данные входа. Повторите сново или зарегистрируйтесь в системе.");
            }
        }

        private void RegistrationButton_Click(object sender, System.EventArgs e)
        {
            var registrationForm = new RegistrationForm(this.userManager) { Owner = this };
            registrationForm.Show();
            this.Hide();
        }
    }
}
