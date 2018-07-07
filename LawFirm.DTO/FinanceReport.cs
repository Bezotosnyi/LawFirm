namespace LawFirm.DTO
{
    using System.ComponentModel;

    public class FinanceReport
    {
        public FinanceReport()
        {
        }

        public FinanceReport(string serviceName, decimal income, decimal expenses)
        {
            this.ServiceName = serviceName;
            this.Income = income;
            this.Expenses = expenses;
        }

        [DisplayName("Класс услуг")]
        public string ServiceName { get; set; }

        [DisplayName("Доходы")]
        public decimal Income { get; set; }

        [DisplayName("Расходы")]
        public decimal Expenses { get; set; }

        public override string ToString()
        {
            return $"ServiceName: {this.ServiceName}, Income: {this.Income}, Expenses: {this.Expenses}";
        }
    }
}