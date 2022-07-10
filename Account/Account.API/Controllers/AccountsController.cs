using Account.Core.Commands;
using Account.Core.Models;
using Account.Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Account.API.Controllers
{
   
    [ServiceFilter(typeof(ExceptionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<AccountsController>
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var accounts = await _mediator.Send(new GetAccounts());
            return Ok(accounts);             
        }

        // GET api/<AccountsController>/5
        [HttpGet("{accountNumber}")]
        public async Task<IActionResult> Get(string accountNumber)
        {
            var accounts = await _mediator.Send(new GetAccountByNumber(accountNumber));
            return Ok(accounts);
        }

        // POST api/<AccountsController>
        [HttpPost]

        public async Task<IActionResult> Post([FromBody] Accounts account)
        {
            var result = await _mediator.Send(new CreateAccount(account));
            return Ok(result);
        }

        // PUT api/<AccountsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
