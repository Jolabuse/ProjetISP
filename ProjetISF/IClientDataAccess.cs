using ProjetISF.Person;

namespace ProjetISF
{
    public interface IClientDataAccess
    {
        void GetAll();
        void CreateUser();
        Client GetClient(int guid);
        void UpdateClient(Client c);
        void DeleteClient(int guid);
    }
}