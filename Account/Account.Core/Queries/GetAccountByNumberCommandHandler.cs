using Account.Core.Interfaces;
using Account.Core.Models;
using MediatR;

namespace Account.Core.Queries
{
    public class GetAccountByNumber : IRequest<Accounts>
    {
        public string AccountNumber { get; set; }
        public GetAccountByNumber(string accountNumber)
        {
            AccountNumber = accountNumber;
        }
    }

    // Query Handler
    public class GetAccountByNumberCommandHandler : IRequestHandler<GetAccountByNumber, Accounts>
    {
        private readonly IAccountRepository _repository;

        public GetAccountByNumberCommandHandler(IAccountRepository accountRepository)
        {
            _repository = accountRepository;
        }
        public async Task<Accounts> Handle(GetAccountByNumber request, CancellationToken cancellationToken)
        {
            return await _repository.GetAccount(request.AccountNumber);
        }
    }
}
