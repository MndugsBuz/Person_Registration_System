using Person_Registration_System.Database.Entities;

namespace Person_Registration_System
{
    public interface IPersonInfoRepository
    {
        PersonInfo Add(PersonInfo account);
        PersonInfo Get(int id);
        PersonInfo Update(int id, string name, string surname, int personalCode, int phoneNumber, string emailAddress);
        PersonInfo Delete(int id);
    }
}
