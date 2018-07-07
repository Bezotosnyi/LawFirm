namespace LawFirm.UI
{
    using System;
    using System.Windows.Forms;

    using LawFirm.BLL.Contract;

    public partial class LawyerForm : Form
    {
        private readonly ILawyerManager lawyerManager;

        public LawyerForm()
        {
            this.InitializeComponent();
        }

        public LawyerForm(ILawyerManager lawyerManager)
        {
            this.lawyerManager = lawyerManager;
            this.InitializeComponent();
            this.FillLawyerTable();
        }

        private void FillLawyerTable()
        {
            this.dataGridView2.DataSource = this.lawyerManager.GetAlLawyers().ToDataTable();
        }

        private void LawyerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            try
            {
                var lastName = this.textBox12.Text;
                var name = this.textBox11.Text;
                var patronimyc = this.textBox10.Text;
                var address = this.textBox9.Text;
                var phone1 = this.textBox8.Text;
                var phone2 = this.textBox7.Text;
                var date = this.dateTimePicker1.Value;

                this.lawyerManager.AddLawyer(lastName, name, patronimyc, address, phone1, phone2, date);

                this.FillLawyerTable();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
