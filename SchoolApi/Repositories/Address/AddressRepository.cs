using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Models;

namespace SchoolApi.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly SchoolContext context;

        public AddressRepository(SchoolContext context)
        {
            this.context = context;
        }
        public async Task Create(Address address)
        {
            await context.Addresses.AddAsync(address);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = await GetById(id);
            context.Addresses.Remove(result);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Address>> Get()
        {
            return await context.Addresses.ToListAsync();
        }

        public async Task<Address> GetById(int id)
        {
            var result = await context.Addresses.FirstOrDefaultAsync(a => a.Id == id);
            if (result == null)
            {
                throw new KeyNotFoundException($"No address with id {id} found");
            }

            return result;
        }

        public async Task Update(Address address)
        {
            var result = await GetById(address.Id);
            result.Detail = address.Detail;
            result.City = address.City;
            result.State = address.State;
            result.Country = address.Country;
            await context.SaveChangesAsync();
        }
    }
}