namespace LawFirm.UI
{
    using System;
    using System.Linq;
    using System.Windows.Forms;

    using LawFirm.BLL.Contract;

    public partial class CompletedOrderForm : Form
    {
        private readonly ICompletedOrderManager completedOrderManager;

        private readonly IOrderManager orderManager;

        public CompletedOrderForm()
        {
            this.InitializeComponent();
        }

        public CompletedOrderForm(ICompletedOrderManager completedOrderManager, IOrderManager orderManager)
        {
            this.completedOrderManager = completedOrderManager;
            this.orderManager = orderManager;
            this.InitializeComponent();
            this.FillCompletedOrderTable();
            this.FillUnCompletedOrderTable();
        }

        private void FillCompletedOrderTable()
        {
            this.dataGridView1.DataSource =
                this.completedOrderManager.GetAllCompletedOrder(this.orderManager.GetAllOrderDtoes());
        }

        private void FillUnCompletedOrderTable()
        {
            var completeds = this.completedOrderManager.GetAllCompletedOrder(this.orderManager.GetAllOrderDtoes()).ToList();
            var uncompleted = this.orderManager.GetAllOrderDtoes().Where(order => completeds.Find(x => x.OrderId == order.OrderId) == null).ToList();
            this.dataGridView4.DataSource = uncompleted.ToDataTable();
        }

        private void CompletedOrderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (this.dataGridView4.CurrentCell != null)
                {
                    var expenses = decimal.Parse(this.textBox6.Text);
                    var orderId = long.Parse(this.dataGridView4.CurrentCell.OwningRow.Cells[0].Value.ToString());
                    this.completedOrderManager.AddCompletedOrder(orderId, expenses);
                    this.FillCompletedOrderTable();
                    this.FillUnCompletedOrderTable();
                }
                else
                {
                    throw new ArgumentException("Выберите незафиксированую услугу");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.StackTrace);
            }
        }
    }
}

