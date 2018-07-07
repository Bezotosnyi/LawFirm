
namespace LawFirm.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    using LawFirm.BLL.Contract;
    using LawFirm.Domain;

    public partial class OrderForm : Form
    {
        private readonly ICustomerManager customerManager;

        private readonly ILawyerManager lawyerManager;

        private readonly IOrderManager orderManager;

        private readonly IServiceManager serviceManager;

        private List<Service> serviceOfOrder;

        public OrderForm()
        {
            this.InitializeComponent();
        }

        public OrderForm(ICustomerManager customerManager, ILawyerManager lawyerManager, IOrderManager orderManager, IServiceManager serviceManager)
        {
            this.customerManager = customerManager;
            this.lawyerManager = lawyerManager;
            this.orderManager = orderManager;
            this.serviceManager = serviceManager;
            this.serviceOfOrder = new List<Service>();
            this.InitializeComponent();
            this.FillCustomerTable();
            this.FillLawyerTable();
            this.FillServiceTable();
            this.FillOrderTable();
        }

        private void FillCustomerTable()
        {
            this.dataGridView1.DataSource = this.customerManager.GetAllCustomers().ToDataTable();
        }

        private void FillLawyerTable()
        {
            this.dataGridView2.DataSource = this.lawyerManager.GetAlLawyers().ToDataTable();
        }


        private void FillServiceTable()
        {
            this.dataGridView3.DataSource = this.serviceManager.GetAllServices().ToDataTable();
        }

        private void FillOrderServiceTable()
        {
            this.dataGridView5.DataSource = this.serviceOfOrder.ToDataTable();
        }

        private void FillOrderTable()
        {
            this.dataGridView4.DataSource = this.orderManager.GetAllOrderDtoes().ToDataTable();
        }

        private void OrderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                var lastName = this.textBox1.Text;
                var name = this.textBox2.Text;
                var patronimyc = this.textBox3.Text;
                var address = this.textBox4.Text;
                var phone1 = this.textBox5.Text;
                var phone2 = this.textBox6.Text;

                this.customerManager.AddCustomer(lastName, name, patronimyc, address, phone1, phone2);

                this.FillCustomerTable();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (this.serviceOfOrder.Count == 0)
                {
                    throw new ArgumentException("Выберите услугу из переченья услуг.");
                }

                Customer customer;
                Lawyer lawyer;

                if (this.dataGridView1.CurrentCell != null)
                {
                    var customerId = long.Parse(this.dataGridView1.CurrentCell.OwningRow.Cells[0].Value.ToString());
                    customer = this.customerManager.GetAllCustomers().ToList().Find(x => x.CustomerId == customerId);
                }
                else
                {
                    throw new ArgumentException("Выберите клиента из базы клиентов.");
                }

                if (this.dataGridView2.CurrentCell != null)
                {
                    var lawyerId = long.Parse(this.dataGridView2.CurrentCell.OwningRow.Cells[0].Value.ToString());
                    lawyer = this.lawyerManager.GetAlLawyers().ToList().Find(x => x.LawyerId == lawyerId);
                }
                else
                {
                    throw new ArgumentException("Выберите юриста из базы юристов.");
                }

                var beginDate = this.dateTimePicker1.Value;
                var expirationDate = this.dateTimePicker3.Value;

                this.orderManager.AddOrder(this.serviceOfOrder, beginDate, expirationDate, customer.CustomerId, lawyer.LawyerId);
                this.serviceOfOrder.Clear();
                this.FillOrderServiceTable();
                this.FillOrderTable();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.StackTrace);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.dataGridView3.CurrentCell != null)
            {
                var serviceId = long.Parse(this.dataGridView3.CurrentCell.OwningRow.Cells[0].Value.ToString());
                var service = this.serviceManager.GetAllServices().ToList().Find(x => x.ServiceId == serviceId);
                this.serviceOfOrder.Add(service);
                this.FillOrderServiceTable();
            }
            else
            {
                MessageBox.Show(@"Выберите услугу из списка услуг обращения.");
            }          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.dataGridView5.CurrentCell != null)
            {
                var serviceId = long.Parse(this.dataGridView5.CurrentCell.OwningRow.Cells[0].Value.ToString());
                var service = this.serviceManager.GetAllServices().ToList().Find(x => x.ServiceId == serviceId);
                this.serviceOfOrder = this.serviceOfOrder.Where(x => x.ServiceId != service.ServiceId).ToList();
                this.FillOrderServiceTable();
            }
            else
            {
                MessageBox.Show(@"Выберите услугу для удаления из списка услуг обращения.");
            }
        }
    }
}
