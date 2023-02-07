using Person_Registration_System.Database;
using Person_Registration_System.Database.Entities;
using Person_Registration_System.Interfaces;
using System.Globalization;

namespace Person_Registration_System.Data
{
    public class ResidenceAddressRepository : IResidenceAddressRepository
    {

        private readonly ApplicationDbContext _context;

        public ResidenceAddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Address Add(Address address)
        {
            var newAddress = new Address
            {
                PersonInfoId = address.PersonInfoId,
                Id = address.Id,
                City = address.City,
                Street = address.Street,
                HouseNumber = address.HouseNumber,
                FlatNumber = address.FlatNumber,
            };

            _context.Addresses.Add(newAddress);
            _context.SaveChanges();
            return newAddress;
        }
        public Address Get(int id)
        {
            return _context.Addresses.SingleOrDefault(x => x.Id == id);
        }

        public Address Update(int id, string city, string street, string houseNumber, string flatNumber)
        {
            var addressToUpdate = _context.Addresses.Single(x => x.Id == id);

            addressToUpdate.City = city;
            addressToUpdate.Street = street;
            addressToUpdate.HouseNumber = houseNumber;
            addressToUpdate.FlatNumber = flatNumber;
            _context.SaveChanges();

            return addressToUpdate;
        }

        public Address Delete(int id)
        {
            var residenceAddressToDetele = _context.Addresses.Single(x => x.Id == id);
            _context.Remove(residenceAddressToDetele);
            _context.SaveChanges();
            return residenceAddressToDetele;
        }
    }
}
