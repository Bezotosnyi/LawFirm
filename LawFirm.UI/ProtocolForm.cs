namespace LawFirm.UI
{
    using System.Windows.Forms;

    using LawFirm.BLL.Contract;

    public partial class ProtocolForm : Form
    {
        private readonly IReportManager reportManager;

        public ProtocolForm()
        {
            this.InitializeComponent();
        }

        public ProtocolForm(IReportManager reportManager)
        {
            this.reportManager = reportManager;
            this.InitializeComponent();
            this.FillOrderTable();
        }

        private void FillOrderTable()
        {
            this.dataGridView1.DataSource = this.reportManager.GetAllShortOrderDtos().ToDataTable();
        }

        private void ProtocolForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, System.EventArgs e)
        {
            if (this.dataGridView1.CurrentCell != null)
            {
                var orderId = long.Parse(this.dataGridView1.CurrentCell.OwningRow.Cells[0].Value.ToString());
                this.richTextBox1.Text = this.reportManager.GetDetailedProtocol(orderId).ToString();
            }
            else
            {
                MessageBox.Show(@"Выберите обращение.");
            }
        }
    }
}
