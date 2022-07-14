using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using MyFinance.API.Models;
using MyFinance.BLL.Accounts.Dto;
using MyFinance.BLL.Common.Exceptions;
using MyFinance.BLL.Common.Infrastructure;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.DAL.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MyFinance.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v1/budgets/{budgetid:guid}/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger<AccountsController> _logger;
        readonly IAgregator<AccountEntity, FetchAccountDto, CreateAccountDto, UpdateAccountDto> _service;

        public AccountsController(
            ILogger<AccountsController> logger,
            IAgregator<AccountEntity, FetchAccountDto, CreateAccountDto, UpdateAccountDto> service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountModel>>> Get([FromRoute] Guid budgetid)
        {
            var qFilter = new QueryFilter().AddCondition("BudgetId", budgetid);

            var result = await _service.Fetcher.FetchFiltered(qFilter);
            if (result == null)
                throw new NoContentException($"Data not found");

            return new ObjectResult(ContractsMapper.MapEnumarable<FetchAccountDto, AccountModel>(result));
        }

        [HttpGet("{id:long:min(1)}")]
        public async Task<ActionResult<AccountModel>> Get([FromRoute] Guid budgetid, [FromRoute] long id)
        {
            var qFilter = new QueryFilter()
                .AddCondition("BudgetId", budgetid)
                .AddCondition("Id", id);

            var result = await _service.Fetcher.FetchFirst(qFilter);
            if (result == null)
                throw new NoContentException($"Data not found");

            return new ObjectResult(ContractsMapper.Map<FetchAccountDto, AccountModel>(result));
        }

        [HttpPost]
        public async Task<ActionResult<AccountModel>> Post([FromRoute] Guid budgetid, CreateAccountModel model)
        {
            if (model == null)
                throw new DataNullReferenceException();

            var dto = ContractsMapper.Map<CreateAccountModel, CreateAccountDto>(model);
            dto.BudgetId = budgetid;

            var result = await _service.Creator.Create(dto);

            return Ok(ContractsMapper.Map<FetchAccountDto, AccountModel>(result));
        }

        [HttpPut]
        public async Task<ActionResult<AccountModel>> Put([FromRoute] Guid budgetid, UpdateAccountModel model)
        {
            if (model == null)
                throw new DataNullReferenceException();

            if (model.Id <= 0)
                throw new ValueOutOfRangeException();

            var dto = ContractsMapper.Map<UpdateAccountModel, UpdateAccountDto>(model);
            dto.BudgetId = budgetid;

            var result = await _service.Updater.Update(dto);

            return Ok(ContractsMapper.Map<FetchAccountDto, AccountModel>(result));
        }

        [HttpDelete("{id:long:min(1)}")]
        public async Task<ActionResult> Delete([FromRoute] Guid budgetid, [FromRoute] long id)
        {
            if (id <= 0)
                throw new ValueOutOfRangeException();

            var qFilter = new QueryFilter()
                .AddCondition("Id", id)
                .AddCondition("BudgetId", budgetid);

            await _service.Remover.Remove(qFilter);
            return Ok();
        }
    }
}
