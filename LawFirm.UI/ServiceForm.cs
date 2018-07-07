namespace LawFirm.UI
{
    using System;
    using System.Windows.Forms;

    using LawFirm.BLL.Contract;

    public partial class ServiceForm : Form
    {
        private readonly IServiceManager serviceManager;

        public ServiceForm()
        {
            this.InitializeComponent();
        }

        public ServiceForm(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
            this.InitializeComponent();
            this.FillServiceTable();
        }

        private void FillServiceTable()
        {
            var services = this.serviceManager.GetAllServices();
            this.dataGridView1.DataSource = services.ToDataTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var name = this.textBox1.Text;
                var description = this.textBox2.Text;
                var cost = decimal.Parse(this.textBox3.Text);

                this.serviceManager.AddServiceClassification(name, description, cost);
                this.FillServiceTable();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void AddServiceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
