using Microsoft.AspNetCore.Mvc;
using MyFinance.API.Models;
using MyFinance.BLL.Accounts.Dto;
using MyFinance.BLL.Common.Exceptions;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFinance.API.Controllers
{
    [ApiController]
    //[Route("api/v1/budgets/{budgetid:int}/accounts")]
    [Route("api/v1/accounts")]
    public class AccountsController : ControllerBase
    {
        readonly IAgregator<AccountEntity, long, AccountDto, CreateAccountDto, UpdateAccountDto> _service;

        public AccountsController(IAgregator<AccountEntity, long, AccountDto, CreateAccountDto, UpdateAccountDto> service)
        {
            _service = service;
        }

        // GET api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountModel>>> Get()
        {
            var result = await _service.Fetcher.FetchAll();

            if (result == null)
                throw new NoContentException($"Data not found");

            List<AccountModel> models = new();
            foreach (var dto in result)
            {
                models.Add(AccountModelMapper.MapToModel(dto));
            }

            return new ObjectResult(models);
        }

        // GET api/Accounts/id
        [HttpGet("{id:long}")]
        public async Task<ActionResult<AccountDto>> Get(long id)
        {
            var result = await _service.Fetcher.FetchByKey(id);

            if (result == null)
                throw new NoContentException($"Data not found");

            return new ObjectResult(AccountModelMapper.MapToModel(result));
        }

        // POST api/Accounts
        [HttpPost]
        public async Task<ActionResult<AccountModel>> Post(CreateAccountModel model)
        {
            if (model == null)
                throw new DataNullReferenceException();

            var dto = AccountModelMapper.MapToDtoCreate(model);

            var result = await _service.Creator.Create(dto);

            return Ok(AccountModelMapper.MapToModel(result));
        }

        // PUT api/Accounts
        [HttpPut]
        public async Task<ActionResult<AccountModel>> Put(UpdateAccountModel model)
        {
            if (model == null)
                throw new DataNullReferenceException();

            if (model.Id <= 0)
                throw new ValueOutOfRangeException();

            var dto = AccountModelMapper.MapToDtoUpdate(model);

            var result = await _service.Updater.Update(dto);

            return Ok(AccountModelMapper.MapToModel(result));
        }

        // DELETE api/Accounts/id
        [HttpDelete("{id:long}")]
        public async Task<ActionResult> Delete(long id)
        {
            if (id <= 0)
                throw new ValueOutOfRangeException();

            await _service.Remover.Remove(id);

            return Ok();
        }
    }
}
