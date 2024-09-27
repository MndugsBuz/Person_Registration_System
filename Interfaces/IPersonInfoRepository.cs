using Person_Registration_System.Database.Entities;

namespace Person_Registration_System.Interfaces
{
    public interface IPersonInfoRepository
    {
        PersonInfo Add(PersonInfo personInfo);
        PersonInfo Get(int id);
        PersonInfo Update(int id, string name, string surname, long personalCode, long phoneNumber, string emailAddress);
        PersonInfo Delete(int id);
    }
}
