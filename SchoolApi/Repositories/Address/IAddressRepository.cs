using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolApi.Models;

namespace SchoolApi.Repositories
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> Get();
        Task<Address> GetById(int id);
        Task Create(Address address);
        Task Update(Address address);
        Task Delete(int id);
    }
}