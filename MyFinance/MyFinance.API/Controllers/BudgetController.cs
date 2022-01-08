using Microsoft.AspNetCore.Mvc;
using MyFinance.API.Models;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Common.Exceptions;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.BLL.Common.Infrastructure;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MyFinance.API.Controllers
{
    [ApiController]
    [Route("api/v1/budgets")]
    public class BudgetsController : ControllerBase
    {
        private readonly ILogger<BudgetsController> _logger;
        private readonly IAgregator<BudgetEntity, BudgetDto, CreateBudgetDto, UpdateBudgetDto> _service;

        public BudgetsController(
            ILogger<BudgetsController> logger,
            IAgregator<BudgetEntity, BudgetDto, CreateBudgetDto, UpdateBudgetDto> service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<ActionResult<BudgetModel>> Get([FromRoute] long id)
        {
            var filter = new BudgetFilterModel()
            {
                Id = new string[] { id.ToString() }            
            };

            var qFilter = ContractsMapper.MapQueryFilter<BudgetDto>(filter);

            var result = await _service.Fetcher.FetchByFilter(qFilter);

            if (result == null)
                throw new NoContentException($"Data not found");

            return new ObjectResult(ContractsMapper.MapEnumarable<BudgetDto, BudgetModel>(result));
        }

        
        [HttpGet]
        [Route("filter")]
        public async Task<ActionResult<BudgetModel>> Filter([FromQuery] BudgetFilterModel filter)
        {
            var qFilter = ContractsMapper.MapQueryFilter<BudgetDto>(filter);

            var result = await _service.Fetcher.FetchByFilter(qFilter);

            if (result == null)
                throw new NoContentException($"Data not found");

            return new ObjectResult(ContractsMapper.MapEnumarable<BudgetDto, BudgetModel>(result));
        }

        [HttpPost]
        public async Task<ActionResult<BudgetModel>> Post(CreateBudgetModel model)
        {
            if (model == null)
                throw new DataNullReferenceException();

            var dto = ContractsMapper.Map<CreateBudgetModel, CreateBudgetDto>(model);

            var result = await _service.Creator.Create(dto);

            return Ok(ContractsMapper.Map<BudgetDto, BudgetModel>(result));
        }

        [HttpPut]
        [Route("{id:long}")]
        public async Task<ActionResult<BudgetModel>> Put(UpdateBudgetModel model)
        {
            if (model == null)
                throw new DataNullReferenceException();

            var dto = ContractsMapper.Map<UpdateBudgetModel, UpdateBudgetDto>(model);

            var result = await _service.Updater.Update(dto);

            return Ok(ContractsMapper.Map<BudgetDto, BudgetModel>(result));
        }

        [HttpDelete]
        [Route("{id:long}")]
        public async Task<ActionResult> Delete([FromRoute] long id)
        {
            var filter = new BudgetFilterModel()
            {
                Id = new string[] { id.ToString() }
            };

            var qFilter = ContractsMapper.MapQueryFilter<BudgetDto>(filter);

            await _service.Remover.Remove(qFilter);
            return Ok();
        }
    }
}
