using RESTAPI.Services.Interfaces.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using RESTAPI.Services.Interfaces;

namespace RESTAPI.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [Route("")]
        public async Task<IHttpActionResult> GetAllUsers()
        => Ok(await _service.GetAllUsersAsync());
        
        [Route("{login:maxlength(30)}/address")]
        public async Task<IHttpActionResult> GetAddressOfUser(string login)
        {
            try
            {
                return Ok(await _service.GetAddressOfUserAsync(login));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{login:maxlength(30)}/addresses")]
        public async Task<IHttpActionResult> GetAllAddresses(string login)
        {
            try
            {
                return Ok(await _service.GetAllAddressAsync(login));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateUser([FromBody]User user)
        {
            try
            {
                return Ok(await _service.CreateUserAsync(user, user.Address));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{login:maxlength(30)}")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateUser(string login, [FromBody]UserToUpdate user)
        {
            try
            {
                return Ok(await _service.UpdateUserAsync(login, user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{login:maxlength(30)}/{lastName:maxlength(30)}")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateLastName(string login, string lastName)
        {
            try
            {
                return Ok(await _service.UpdateLastNameAsync(login, lastName));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{login:maxlength(30)}/address/{street:maxlength(30)}")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateAddress(string login, string street, int building, int room, [FromBody]Address newAddress)
        {
            try
            {
                return Ok(await _service.UpdateUserAddressAsync(login, street, building, room, newAddress));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{login:maxlength(30)}/address")]
        [HttpPut]
        public async Task<IHttpActionResult> AddAddress(string login, [FromBody]Address address)
        {
            try
            {
                return Ok(await _service.AddAddressAsync(login, address));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
