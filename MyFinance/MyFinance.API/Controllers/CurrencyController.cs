using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFinance.API.Models;
using MyFinance.BLL.Common.Exceptions;
using MyFinance.BLL.Common.Infrastructure;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.BLL.Currencies.Dto;
using MyFinance.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace MyFinance.API.Controllers
{
    //[Authorize]
    [ApiController]
    //[Route("api/v1/budgets/{budgetid:int}/Currencys")]
    [Route("api/v1/currencies")]
    public class CurrenciesController : ControllerBase
    {
        private readonly ILogger<CurrenciesController> _logger;
        readonly IAgregator<CurrencyEntity, FetchCurrencyDto, CreateCurrencyDto, UpdateCurrencyDto> _service;

        public CurrenciesController(
            ILogger<CurrenciesController> logger,
            IAgregator<CurrencyEntity, FetchCurrencyDto, CreateCurrencyDto, UpdateCurrencyDto> service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrencyModel>>> Get()
        {
            var result = await _service.Fetcher.FetchByFilter(null);
            if (result == null)
                throw new NoContentException($"Data not found");

            return new ObjectResult(ContractsMapper.MapEnumarable<FetchCurrencyDto, CurrencyModel>(result));
        }

        [HttpGet("{id:alpha:length(3)}")]
        public async Task<ActionResult<CurrencyModel>> Get([FromRoute] string id)
        {
            var qFilter = new QueryFilter().AddCondition("Id", id);
            var result = await _service.Fetcher.FetchByFilter(qFilter);
            if (result == null || !result.Any())
                throw new NoContentException($"Data not found");

            return new ObjectResult(ContractsMapper.Map<FetchCurrencyDto, CurrencyModel>(result.FirstOrDefault()));
        }

        [HttpPost]
        public async Task<ActionResult<CurrencyModel>> Post(CreateCurrencyModel model)
        {
            if (model == null)
                throw new DataNullReferenceException();

            if (string.IsNullOrWhiteSpace(model.Id))
                throw new ValueOutOfRangeException();

            var dto = ContractsMapper.Map<CreateCurrencyModel, CreateCurrencyDto>(model);
            var result = await _service.Creator.Create(dto);

            return Ok(ContractsMapper.Map<FetchCurrencyDto, CurrencyModel>(result));
        }

        [HttpPut]
        public async Task<ActionResult<CurrencyModel>> Put(UpdateCurrencyModel model)
        {
            if (model == null)
                throw new DataNullReferenceException();

            if (string.IsNullOrWhiteSpace(model.Id))
                throw new ValueNotSpecifiedException();

            var dto = ContractsMapper.Map<UpdateCurrencyModel, UpdateCurrencyDto>(model);
            var result = await _service.Updater.Update(dto);

            return Ok(ContractsMapper.Map<FetchCurrencyDto, CurrencyModel>(result));
        }

        [HttpDelete("{id:alpha:length(3)}")]
        public async Task<ActionResult> Delete([FromRoute] string id)
        {
            var qFilter = new QueryFilter().AddCondition("Id", id);

            await _service.Remover.Remove(qFilter);
            return Ok();
        }
    }
}
