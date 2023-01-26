using Person_Registration_System.Database;
using Person_Registration_System.Database.Entities;

namespace Person_Registration_System
{
    public class ResidenceAddressRepository : IResidenceAddressRepository
    {

        private readonly ApplicationDbContext _context;

        public ResidenceAddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Address Add(Address residenceAddress)
        {
            var newResidenceAddress = new Address
            {
               // Id = residenceAddress.Id,
                City = residenceAddress.City,
                Street = residenceAddress.Street,
                HouseNumber = residenceAddress.HouseNumber,
                FlatNumber = residenceAddress.FlatNumber,
            };

            _context.Addresses.Add(newResidenceAddress);
            _context.SaveChanges();
            return newResidenceAddress;
        }
        public Address Get(int id)
        {
            return _context.Addresses.SingleOrDefault(x => x.Id == id);
        }

        public Address Update(int id, string city, string street, string houseNumber, string flatNumber)
        {
            var resicenceAddressToUpdate = _context.Addresses.Single(x => x.Id == id);

            resicenceAddressToUpdate.City = city;
            resicenceAddressToUpdate.Street = street;
            resicenceAddressToUpdate.HouseNumber = houseNumber;
            resicenceAddressToUpdate.FlatNumber = flatNumber;
            _context.SaveChanges();

            return resicenceAddressToUpdate;
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
