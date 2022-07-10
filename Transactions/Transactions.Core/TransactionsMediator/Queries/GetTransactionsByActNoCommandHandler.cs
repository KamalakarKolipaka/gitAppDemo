using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Core.Interfaces;
using Transactions.Core.Models;

namespace Transactions.Core.TransactionsMediator.Queries
{
    public class GetTransactionsByActNo : IRequest<List<Transaction>>
    {
        public string AccountNumber { get; set; }
        public GetTransactionsByActNo(string accountNumber)
        {
            AccountNumber = accountNumber;
        }
    }

    // Query Handler
    public class GetTransactionsByActNoCommandHandler : IRequestHandler<GetTransactionsByActNo, List<Transaction>>
    {
        private readonly ITransactionsRepository _repository;

        public GetTransactionsByActNoCommandHandler(ITransactionsRepository transactionsRepository)
        {
            _repository = transactionsRepository;
        }
        public async Task<List<Transaction>> Handle(GetTransactionsByActNo request, CancellationToken cancellationToken)
        {
            return await _repository.GetTransactions(request.AccountNumber);
        }
    }
}
