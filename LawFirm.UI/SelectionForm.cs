namespace LawFirm.UI
{
    using System;
    using System.Linq;
    using System.Windows.Forms;

    using LawFirm.BLL.Contract;

    public partial class SelectionForm : Form
    {
        private readonly ICustomerManager customerManager;

        private readonly ISelectionManager selectionManager;

        public SelectionForm()
        {
            this.InitializeComponent();
        }

        public SelectionForm(ICustomerManager customerManager, ISelectionManager selectionManager)
        {
            this.customerManager = customerManager;
            this.selectionManager = selectionManager;
            this.InitializeComponent();
            this.FillCustomerTable();
        }

        private void SelectionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void FillCustomerTable()
        {
            this.dataGridView1.DataSource = this.customerManager.GetAllCustomers().ToDataTable();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (this.dataGridView1.CurrentCell != null)
                {
                    var customerId = long.Parse(this.dataGridView1.CurrentCell.OwningRow.Cells[0].Value.ToString());
                    var customer = this.customerManager.GetAllCustomers().FirstOrDefault(x => x.CustomerId == customerId);

                    var begin = this.dateTimePicker1.Value;
                    var end = this.dateTimePicker3.Value;

                    var dt = this.selectionManager.GetOrdersByCustomerAndPeriod(customer, begin, end).ToDataTable();

                    if (dt.Rows.Count != 0)
                    {
                        this.dataGridView4.DataSource = dt;
                    }
                    else
                    {
                        this.dataGridView4.DataSource = null;
                        MessageBox.Show(@"По заданном запросу не найдены обращения.");
                    }
                }
                else
                {
                    MessageBox.Show(@"Выберите клиента.");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
