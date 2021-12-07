using Microsoft.EntityFrameworkCore;
using MyFinance.BLL.Abstracts;
using MyFinance.BLL.Accounts.Dto;
using MyFinance.BLL.Interfaces;
using MyFinance.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFinance.BLL.Accounts.Services
{
    public class AccountFetcher : BaseService, IFetcher<long, AccountDto>
    {
        public AccountFetcher(IFinanceDbContext database) : base(database)
        {
        }

        public async Task<IEnumerable<AccountDto>> FetchAll()
        {
            var entities = await _db.Context.Accounts.ToListAsync();

            List<AccountDto> dtos = new();
            foreach (var entity in entities)
            {
                dtos.Add(AccountDtoMapper.MapToDto(entity));
            }

            return dtos;
        }

        public async Task<AccountDto> FetchByKey(long key)
        {
            var entity = await _db.Context.Accounts.FirstOrDefaultAsync(x => x.Id == key);

            return AccountDtoMapper.MapToDto(entity);
        }
    }
}
