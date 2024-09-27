using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using Person_Registration_System.Database.Entities;

namespace Person_Registration_System.Interfaces

{
    public interface IResidenceAddressRepository
    {
        Address Add(Address Address);
        Address Get(int id);
        Address Update(int id, string city, string street, string houseNumber, string flatNumber);
        Address Delete(int id);
    }
}
