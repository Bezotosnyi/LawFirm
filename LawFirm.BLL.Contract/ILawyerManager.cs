namespace LawFirm.BLL.Contract
{
    using System;
    using System.Collections.Generic;

    using LawFirm.Domain;

    public interface ILawyerManager
    {
        void AddLawyer(
            string lastName,
            string name,
            string patronymic,
            string address,
            string contactPhone,
            string contactPhone2,
            DateTime hireDate);

        IEnumerable<Lawyer> GetAlLawyers();
    }
}