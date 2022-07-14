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
using Swashbuckle.AspNetCore.Annotations;

namespace MyFinance.API.Controllers
{
    //[Authorize]
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
        public async Task<ActionResult<BudgetModel>> GetAll()
        {
            var qFilter = new QueryFilter()
                .AddCondition("UserId", HttpContext.Items["UserId"]);

            var result = await _service.Fetcher.FetchFiltered(qFilter);

            if (result == null)
            {
                _logger.LogInformation($"Fetching budgets: no data found");
                //throw new NoContentException($"Data not found");
            };

            return new ObjectResult(ContractsMapper.MapEnumarable<FetchBudgetDto, BudgetModel>(result));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<BudgetModel>> GetById([FromRoute] Guid id)
        {
            var qFilter = new QueryFilter()
                .AddCondition("UserId", HttpContext.Items["UserId"])
                .AddCondition("Id", id);

            var result = await _service.Fetcher.FetchFirst(qFilter);

            if (result == null)
            {
                _logger.LogInformation($"Fetching budget {id}: no data found");
                //throw new NoContentException($"Data not found");
            }

            return new ObjectResult(ContractsMapper.Map<FetchBudgetDto, BudgetModel>(result));
        }

        [HttpGet]
        [Route("filter")]
        [SwaggerOperation(
            Summary = "Querying data using a filter",
            Description = "Use filter syntax is as follows: \\<operator\\>:\\<arguments\\>")]
        public async Task<ActionResult<BudgetModel>> GetByFilter([FromQuery] BudgetFilterModel filter)
        {
            var qFilter = ContractsMapper.MapQueryFilter<FetchBudgetDto>(filter)
                .AddCondition("UserId", HttpContext.Items["UserId"]);

            var result = await _service.Fetcher.FetchFiltered(qFilter);

            if (result == null)
            {
                _logger.LogInformation($"Fetching budgets: no data found");
                //throw new NoContentException($"Data not found");
            }

            return new ObjectResult(ContractsMapper.MapEnumarable<FetchBudgetDto, BudgetModel>(result));
        }
        

        [HttpPost]
        public async Task<ActionResult<BudgetModel>> Post(CreateBudgetModel model)
        {
            if (model == null)
                throw new DataNullReferenceException();

            var dto = ContractsMapper.Map<CreateBudgetModel, CreateBudgetDto>(model);
            dto.UserId = (Guid)HttpContext.Items["UserId"];

            var result = await _service.Creator.Create(dto);

            return Ok(ContractsMapper.Map<FetchBudgetDto, BudgetModel>(result));
        }

        [HttpPut]
        public async Task<ActionResult<BudgetModel>> Put(UpdateBudgetModel model)
        {
            if (model == null)
                throw new DataNullReferenceException();

            var dto = ContractsMapper.Map<UpdateBudgetModel, UpdateBudgetDto>(model);
            dto.UserId = (Guid)HttpContext.Items["UserId"];

            var result = await _service.Updater.Update(dto);

            return Ok(ContractsMapper.Map<FetchBudgetDto, BudgetModel>(result));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            var qFilter = new QueryFilter()
                .AddCondition("UserId", HttpContext.Items["UserId"])
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
