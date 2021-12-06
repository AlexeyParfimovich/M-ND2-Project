using Microsoft.AspNetCore.Mvc;
using MyFinance.API.Models;
using MyFinance.BLL.Budgets;
using MyFinance.BLL.Budgets.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BudgetsController : ControllerBase
    {
        readonly IBudgetAgregator _service;

        public BudgetsController(IBudgetAgregator service)
        {
            _service = service;
        }

        // GET api/budgets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BudgetModel>>> Get()
        {
            var result =  await _service.Fetcher.FetchAll();

            if (result == null) return NotFound();

            List<BudgetModel> models = new();
            foreach (var dto in result)
            {
                models.Add(BudgetModelMapper.MapToModel(dto));
            }

            return new ObjectResult(models);
        }

        // GET api/budgets/id
        [HttpGet("{id}")]
        public async Task<ActionResult<BudgetDto>> Get(int id)
        {
            var result = await _service.Fetcher.FetchByKey(id);

            if (result == null) return NotFound();

            return new ObjectResult(BudgetModelMapper.MapToModel(result));
        }

        // POST api/budgets
        [HttpPost]
        public async Task<ActionResult<BudgetModel>> Post(CreateBudgetModel model)
        {
            if (model == null) return BadRequest();

            var dto = BudgetModelMapper.MapToDtoCreate(model);

            var result = await _service.Creator.Create(dto);

            return Ok(BudgetModelMapper.MapToModel(result));
        }

        // PUT api/budgets
        [HttpPut]
        public async Task<ActionResult<BudgetModel>> Put(UpdateBudgetModel model)
        {
            if (model == null || model.Id <= 0) return BadRequest();

            var dto = BudgetModelMapper.MapToDtoUpdate(model);

            var result = await _service.Updater.Update(dto);

            return Ok(BudgetModelMapper.MapToModel(result));
        }

        // DELETE api/budgets/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.Remover.Remove(id);
            
            return Ok();
        }
      
    }
}
