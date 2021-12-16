using Microsoft.AspNetCore.Mvc;
using MyFinance.API.Models;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Common.Exceptions;
using MyFinance.BLL.Common.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyFinance.API.Controllers
{
    [ApiController]
    [Route("api/v1/budgets")]
    public class BudgetsController : ControllerBase
    {
        readonly IContractMapper _mapper;
        readonly IAgregator<BudgetEntity, long, BudgetDto, CreateBudgetDto, UpdateBudgetDto> _service;

        public BudgetsController(
            IContractMapper mapper,
            IAgregator<BudgetEntity, long, BudgetDto, CreateBudgetDto, UpdateBudgetDto> service)
        {
            _mapper = mapper;
            _service = service;
        }

        // GET api/budgets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BudgetModel>>> Get()
        {
            var result = await _service.Fetcher.FetchAll();

            if (result == null)
                throw new NoContentException($"Data not found");

            List<BudgetModel> models = new();
            foreach (var dto in result)
            {
                models.Add(BudgetModelMapper.MapToModel(dto));
            }

            return new ObjectResult(models);
        }

        // GET api/budgets/id
        [HttpGet("{id:long}")]
        public async Task<ActionResult<BudgetModel>> Get(long id)
        {
            var dto = await _service.Fetcher.FetchByKey(id);

            if (dto == null)
                throw new NoContentException($"Data not found");

            return new ObjectResult(BudgetModelMapper.MapToModel(dto));
        }

        // POST api/budgets
        [HttpPost]
        public async Task<ActionResult<BudgetModel>> Post(CreateBudgetModel model)
        {
            if (model == null)
                throw new DataNullReferenceException();

            var dto = _mapper.Map<CreateBudgetModel, CreateBudgetDto>(model);
                //BudgetModelMapper.MapToDtoCreate(model);

            var result = await _service.Creator.Create(dto);

            return Ok(_mapper.Map<BudgetDto, BudgetModel>(result));
        }

        // PUT api/budgets
        [HttpPut]
        public async Task<ActionResult<BudgetModel>> Put(UpdateBudgetModel model)
        {
            if (model == null)
                throw new DataNullReferenceException();

            if (model.Id <= 0)
                throw new ValueOutOfRangeException();

            var dto = BudgetModelMapper.MapToDtoUpdate(model);

            var result = await _service.Updater.Update(dto);

            return Ok(BudgetModelMapper.MapToModel(result));
        }

        // DELETE api/budgets/id
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
