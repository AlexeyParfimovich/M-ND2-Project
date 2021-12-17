using Microsoft.AspNetCore.Mvc;
using MyFinance.API.Models;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Common.Exceptions;
using MyFinance.BLL.Common.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

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
                models.Add(_mapper.Map<BudgetDto, BudgetModel>(dto));
            }

            return new ObjectResult(models);
        }

        // GET api/budgets/id
        [HttpGet]
        [Route("{id:long}")]
        public async Task<ActionResult<BudgetModel>> Get([FromRoute] long id)
        {
            var dto = await _service.Fetcher.FetchByKey(id);

            if (dto == null)
                throw new NoContentException($"Data not found");

            return new ObjectResult(_mapper.Map<BudgetDto, BudgetModel>(dto));
        }

        // POST api/budgets
        [HttpPost]
        public async Task<ActionResult<BudgetModel>> Post(CreateBudgetModel model)
        {
            if (model == null)
                throw new DataNullReferenceException();

            var dto = _mapper.Map<CreateBudgetModel, CreateBudgetDto>(model);

            var result = await _service.Creator.Create(dto);

            return Ok(_mapper.Map<BudgetDto, BudgetModel>(result));
        }

        // PUT api/budgets/id
        [HttpPut]
        [Route("{id:long}")]
        public async Task<ActionResult<BudgetModel>> Put(UpdateBudgetModel model)
        {
            if (model == null)
                throw new DataNullReferenceException();

            if (model.Id <= 0)
                throw new ValueOutOfRangeException();

            var dto = _mapper.Map<UpdateBudgetModel, UpdateBudgetDto>(model);

            var result = await _service.Updater.Update(dto);

            return Ok(_mapper.Map<BudgetDto, BudgetModel>(result));
        }

        // DELETE api/budgets/id
        [HttpDelete]
        [Route("{id:long}")]
        public async Task<ActionResult> Delete([FromRoute] long id)
        {
            if (id <= 0)
                throw new ValueOutOfRangeException();

            await _service.Remover.Remove(id);

            return Ok();
        }

    }
}
