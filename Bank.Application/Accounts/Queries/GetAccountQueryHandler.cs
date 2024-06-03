using AutoMapper;
using Bank.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bank.Application.Accounts.Queries
{
	public class GetAccountQueryHandler : IRequestHandler<GetAccountsQuery, AccountListVm>
	{
		private readonly IApplicationDbContext _dbContext;

        private readonly IMapper _mapper;//здесь нам также потребуется маппер, чтобы преобразовать входные данные в команду
      
        public GetAccountQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
            _mapper = mapper;
        }
		public async Task<AccountListVm> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
		{
			var accountsQuery = await _dbContext.Accounts.Where(ac => ac.ClientId == request.Id && ac.IsExistance == true).AsNoTracking()
				.ToListAsync(cancellationToken);

			return new AccountListVm { Accounts = _mapper.Map<List<AccountLookUpDTO>>(accountsQuery)  };
		}
	}
}
