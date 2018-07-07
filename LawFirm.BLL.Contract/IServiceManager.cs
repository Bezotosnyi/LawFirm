namespace LawFirm.BLL.Contract
{
    using System.Collections.Generic;

    using LawFirm.Domain;

    public interface IServiceManager
    {
        void AddServiceClassification(string name, string description, decimal cost);

        IEnumerable<Service> GetAllServices();
    }
}