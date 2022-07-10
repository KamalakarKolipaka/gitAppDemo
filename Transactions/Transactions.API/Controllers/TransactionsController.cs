using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Transactions.Core.Models;
using Transactions.Core.TransactionsMediator.Commands;
using Transactions.Core.TransactionsMediator.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Transactions.API.Controllers
{
    [ServiceFilter(typeof(ExceptionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<TransactionsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TransactionsController>/5
        [HttpGet("{accountNo}")]
        public async Task<IActionResult> Get(string accountNo)
        {
            var transactions = await _mediator.Send(new GetTransactionsByActNo(accountNo));
            return Ok(transactions);
        }

        // POST api/<TransactionsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Transaction transaction)
        {
            var result = await _mediator.Send(new CreateTransactions(transaction));
            return Ok(result);
        }

        // PUT api/<TransactionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TransactionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
