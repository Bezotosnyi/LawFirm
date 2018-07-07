namespace LawFirm.UI
{
    using System;
    using System.Windows.Forms;

    using LawFirm.BLL.Contract;

    public partial class ReportForm : Form
    {
        private readonly IReportManager reportManager;

        public ReportForm()
        {
            this.InitializeComponent();
        }

        public ReportForm(IReportManager reportManager)
        {
            this.reportManager = reportManager;
            this.InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var begin = this.dateTimePicker1.Value;
                var end = this.dateTimePicker3.Value;

                var report = this.reportManager.GetFinanceReportByPeriod(begin, end).ToDataTable();

                if (report.Rows.Count != 0)
                {
                    this.dataGridView1.DataSource = report;
                }
                else
                {
                    this.dataGridView1.DataSource = null;
                    MessageBox.Show(@"По заданной дате нет услуг.");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ReportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
