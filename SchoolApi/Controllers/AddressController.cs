using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Models;
using SchoolApi.Repositories;

namespace SchoolApi.Controllers
{
    [ApiController]
    [Route("addresses")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository repository;

        public AddressController(IAddressRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Address>> Get()
        {
            return await repository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetById(int id)
        {
            try
            {
                return await repository.GetById(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (System.Exception)
            {

                return Problem();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Address>> Create(Address address)
        {
            await repository.Create(address);

            return CreatedAtAction(nameof(GetById), new { Id = address.Id }, address);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Address address)
        {
            try
            {
                address.Id = id;
                await repository.Update(address);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (System.Exception)
            {

                return Problem();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await repository.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (System.Exception)
            {

                return Problem();
            }
        }
    }
}