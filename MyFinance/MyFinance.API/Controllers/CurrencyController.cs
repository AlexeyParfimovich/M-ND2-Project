using Microsoft.AspNetCore.Mvc;
using MyFinance.API.Models;
using MyFinance.BLL.Common.Exceptions;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.BLL.Currencies.Dto;
using MyFinance.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFinance.API.Controllers
{
    [ApiController]
    //[Route("api/v1/budgets/{budgetid:int}/Currencys")]
    [Route("api/v1/Currencies")]
    public class CurrencysController : ControllerBase
    {
        readonly IContractMapper _mapper;
        readonly IAgregator<CurrencyEntity, string, CurrencyDto, CreateCurrencyDto, UpdateCurrencyDto> _service;

        public CurrencysController(
            IContractMapper mapper,
            IAgregator<CurrencyEntity, string, CurrencyDto, CreateCurrencyDto, UpdateCurrencyDto> service)
        {
            _mapper = mapper;
            _service = service;
        }

        // GET api/Currencys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrencyModel>>> Get()
        {
            var result = await _service.Fetcher.FetchAll();

            if (result == null)
                throw new NoContentException($"Data not found");

            List<CurrencyModel> models = new();
            foreach (var dto in result)
            {
                models.Add(_mapper.Map<CurrencyDto, CurrencyModel>(dto));
            }

            return new ObjectResult(models);
        }

        // GET api/Currencys/id
        [HttpGet("{id:alpha:length(3)}")]
        public async Task<ActionResult<CurrencyDto>> Get(string id)
        {
            var result = await _service.Fetcher.FetchByKey(id);

            if (result == null)
                throw new NoContentException($"Data not found");

            return new ObjectResult(_mapper.Map<CurrencyDto, CurrencyModel>(result));
        }

        // POST api/Currencys
        [HttpPost]
        public async Task<ActionResult<CurrencyModel>> Post(CreateCurrencyModel model)
        {
            if (model == null)
                throw new DataNullReferenceException();

            var dto = _mapper.Map<CreateCurrencyModel, CreateCurrencyDto>(model);

            var result = await _service.Creator.Create(dto);

            return Ok(_mapper.Map<CurrencyDto, CurrencyModel>(result));
        }

        // PUT api/Currencys
        [HttpPut]
        public async Task<ActionResult<CurrencyModel>> Put(UpdateCurrencyModel model)
        {
            if (model == null)
                throw new DataNullReferenceException();

            if (string.IsNullOrWhiteSpace(model.Id))
                throw new ValueNotSpecifiedException();

            var dto = _mapper.Map<UpdateCurrencyModel, UpdateCurrencyDto>(model);

            var result = await _service.Updater.Update(dto);

            return Ok(_mapper.Map<CurrencyDto, CurrencyModel>(result));
        }

        // DELETE api/Currencys/id
        [HttpDelete("{id:alpha:length(3)}")]
        public async Task<ActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ValueNotSpecifiedException();

            await _service.Remover.Remove(id);

            return Ok();
        }
    }
}
