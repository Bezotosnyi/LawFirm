namespace LawFirm.BLL.Contract
{
    using System;
    using System.Collections.Generic;

    using LawFirm.Domain;
    using LawFirm.DTO;

    public interface IReportManager
    {
        IEnumerable<FinanceReport> GetFinanceReportByPeriod(
            DateTime dateOfBeginning,
            DateTime expirationDate);

        IEnumerable<ShortOrderDto> GetAllShortOrderDtos();

        DetailedProtocol GetDetailedProtocol(long orderId);
    }
}