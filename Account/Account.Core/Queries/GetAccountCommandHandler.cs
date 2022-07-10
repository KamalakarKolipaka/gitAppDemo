using Account.Core.Interfaces;
using Account.Core.Models;
using MediatR;

namespace Account.Core.Queries
{
    public class GetAccounts : IRequest<List<Accounts>>
    {
        public GetAccounts() { }
    }


    // Query Handler
    public class GetAccountCommandHandler : IRequestHandler<GetAccounts, List<Accounts>>
    {
        private readonly IAccountRepository _repository;

        public GetAccountCommandHandler(IAccountRepository accountRepository)
        {
            _repository = accountRepository;
        }

        public async Task<List<Accounts>> Handle(GetAccounts request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAccounts();
        }
    }
}
