namespace LawFirm.UI
{
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.InitializeComponent();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var serviceForm = new ServiceForm(ManagerFactoryHelper.GetServiceManager()) { Owner = this };
            serviceForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            var orderForm = new OrderForm(
                                ManagerFactoryHelper.GetCustomerManager(),
                                ManagerFactoryHelper.GetLawyerManager(),
                                ManagerFactoryHelper.GetOrderManager(),
                                ManagerFactoryHelper.GetServiceManager()) { Owner = this };
            orderForm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, System.EventArgs e)
        {
            var lawyerForm = new LawyerForm(ManagerFactoryHelper.GetLawyerManager()) { Owner = this };
            lawyerForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            var completedOrderForm = new CompletedOrderForm(
                                         ManagerFactoryHelper.GetCompletedOrderManager(),
                                         ManagerFactoryHelper.GetOrderManager()) { Owner = this };
            completedOrderForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            var selectionForm = new SelectionForm(
                                    ManagerFactoryHelper.GetCustomerManager(),
                                    ManagerFactoryHelper.GetSelectionManager()) { Owner = this };
            selectionForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            var reportForm = new ReportForm(ManagerFactoryHelper.GetReportManager()) { Owner = this };
            reportForm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            var reportForm = new ProtocolForm(ManagerFactoryHelper.GetReportManager()) { Owner = this };
            reportForm.Show();
            this.Hide();
        }
    }
}
