using Account.Core.Interfaces;
using Account.Core.Models;
using MediatR;

namespace Account.Core.Commands
{
    public class CreateAccount : IRequest<bool>
    {
        public Accounts Account { get; set; }
        public CreateAccount(Accounts account)
        {
            Account = account;
        }
    }

    public class CreateAccountCommandHandler : IRequestHandler<CreateAccount, bool>
    {
        private readonly IAccountRepository _repository;

        public CreateAccountCommandHandler(IAccountRepository accountRepository)
        {
            _repository = accountRepository;
        }

        public async Task<bool> Handle(CreateAccount request, CancellationToken cancellationToken)
        {
            return await _repository.AddAccount(request.Account);
        }
    }
}
