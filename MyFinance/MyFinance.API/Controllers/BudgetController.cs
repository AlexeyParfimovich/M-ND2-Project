using MyFinance.API.Models;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Common.Exceptions;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.BLL.Common.Infrastructure;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace MyFinance.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/budgets")]
    public class BudgetsController : ControllerBase
    {
        private readonly ILogger<BudgetsController> _logger;
        private readonly IAgregator<BudgetEntity, FetchBudgetDto, CreateBudgetDto, UpdateBudgetDto> _service;

        public BudgetsController(
            ILogger<BudgetsController> logger,
            IAgregator<BudgetEntity, FetchBudgetDto, CreateBudgetDto, UpdateBudgetDto> service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<BudgetModel>> Get([FromRoute] Guid id)
        {
            var qFilter = new QueryFilter()
                .AddCondition("UserId", new Guid("49478411-92f0-4c3a-9c7e-69e7b2bbe8e7"))
                .AddCondition("Id", id);

            var result = await _service.Fetcher.FetchByFilter(qFilter);

            if (result == null)
                throw new NoContentException($"Data not found");

            return new ObjectResult(ContractsMapper.MapEnumarable<FetchBudgetDto, BudgetModel>(result));
        }

        [HttpGet]
        [Route("filter")]
        public async Task<ActionResult<BudgetModel>> Filter([FromQuery] BudgetFilterModel filter)
        {
            var qFilter = ContractsMapper.MapQueryFilter<FetchBudgetDto>(filter)
                .AddCondition("UserId", new Guid("49478411-92f0-4c3a-9c7e-69e7b2bbe8e7"));

            var result = await _service.Fetcher.FetchByFilter(qFilter);

            if (result == null)
                throw new NoContentException($"Data not found");

            return new ObjectResult(ContractsMapper.MapEnumarable<FetchBudgetDto, BudgetModel>(result));
        }

        [HttpPost]
        public async Task<ActionResult<BudgetModel>> Post(CreateBudgetModel model)
        {
            if (model == null)
                throw new DataNullReferenceException();

            var dto = ContractsMapper.Map<CreateBudgetModel, CreateBudgetDto>(model);
            dto.UserId = new Guid("49478411-92f0-4c3a-9c7e-69e7b2bbe8e7");

            var result = await _service.Creator.Create(dto);

            return Ok(ContractsMapper.Map<FetchBudgetDto, BudgetModel>(result));
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult<BudgetModel>> Put(UpdateBudgetModel model)
        {
            if (model == null)
                throw new DataNullReferenceException();

            var dto = ContractsMapper.Map<UpdateBudgetModel, UpdateBudgetDto>(model);
            dto.UserId = new Guid("49478411-92f0-4c3a-9c7e-69e7b2bbe8e7");

            var result = await _service.Updater.Update(dto);

            return Ok(ContractsMapper.Map<FetchBudgetDto, BudgetModel>(result));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            var qFilter = new QueryFilter()
                .AddCondition("UserId", new Guid("49478411-92f0-4c3a-9c7e-69e7b2bbe8e7"))
                .AddCondition("Id", id);

            await _service.Remover.Remove(qFilter);
            return Ok();
        }

        [HttpGet]
        [Route("[action]")]
        public string Secret()
        {
            //var accessToken = HttpContext.GetTokenAsync("access_token").GetAwaiter().GetResult();
            //var tokenClaims = ((JwtSecurityToken)new JwtSecurityTokenHandler().ReadToken(accessToken)).Claims; //?.ToList();
            //var idToken = HttpContext.GetTokenAsync("id_token").GetAwaiter().GetResult();
            //var userClaims = User.Claims;

            return "Secret string from MyFinance.API";
        }
    }
}
