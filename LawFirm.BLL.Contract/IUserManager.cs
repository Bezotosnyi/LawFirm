namespace LawFirm.BLL.Contract
{
    public interface IUserManager
    {
        bool Login(string login, string password);

        void Registration(string name, string lastName, string login, string password);
    }
}