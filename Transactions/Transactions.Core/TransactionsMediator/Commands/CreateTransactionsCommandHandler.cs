using MediatR;
using Transactions.Core.Interfaces;
using Transactions.Core.Models;

namespace Transactions.Core.TransactionsMediator.Commands
{
    public class CreateTransactions : IRequest<bool>
    {
        public Transaction Transaction { get; set; }
        public CreateTransactions(Transaction transaction)
        {
            Transaction = transaction;
        }
    }

    public class CreateTransactionsCommandHandler : IRequestHandler<CreateTransactions, bool>
    {
        private readonly ITransactionsRepository _repository;

        public CreateTransactionsCommandHandler(ITransactionsRepository transactionsRepository)
        {
            _repository = transactionsRepository;
        }

        public async Task<bool> Handle(CreateTransactions request, CancellationToken cancellationToken)
        {
            return await _repository.CreateNewTransaction(request.Transaction);
        }
    }
}
