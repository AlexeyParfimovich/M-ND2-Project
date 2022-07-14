using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFinance.API.Models;
using MyFinance.BLL.Cards.Dto;
using MyFinance.BLL.Common.Exceptions;
using MyFinance.BLL.Common.Infrastructure;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.DAL.Entities;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MyFinance.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v1/budgets/{budgetid:guid}")]
    public class CardsController : ControllerBase
    {
        private readonly ILogger<CardsController> _logger;
        readonly IAgregator<CardEntity, FetchCardDto, CreateCardDto, UpdateCardDto> _service;

        public CardsController(
            ILogger<CardsController> logger,
            IAgregator<CardEntity, FetchCardDto, CreateCardDto, UpdateCardDto> service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("cards")]
        public async Task<ActionResult<IEnumerable<CardModel>>> GetAll(
            [FromRoute] Guid budgetid)
        {
            var qFilter = new QueryFilter()
                .AddCondition("BudgetId", budgetid);

            var result = await _service.Fetcher.FetchFiltered(qFilter);
            if (result == null)
            {
                _logger.LogInformation($"Fetching cards for budget {budgetid}: no data found");
                //throw new NoContentException($"Data not found");
            }

            return new ObjectResult(ContractsMapper.MapEnumarable<FetchCardDto, CardModel>(result));
        }

        [HttpGet]
        [Route("accounts/{accountid:long}/cards")]
        public async Task<ActionResult<CardModel>> GetById(
            [FromRoute] Guid budgetid,
            [FromRoute] long accountid,
            [FromQuery] long id)
        {
            var qFilter = new QueryFilter()
                .AddCondition("BudgetId", budgetid)
                .AddCondition("AccountId", accountid)
                .AddCondition("Id", id);

            var result = await _service.Fetcher.FetchFirst(qFilter);
            if (result == null)
                throw new NoContentException($"Data not found");

            return new ObjectResult(ContractsMapper.Map<FetchCardDto, CardModel>(result));
        }

        [HttpPost]
        [Route("cards")]
        public async Task<ActionResult<CardModel>> Post(
            [FromRoute] Guid budgetid,
            CreateCardModel model)
        {
            if (model == null)
                throw new DataNullReferenceException();

            var dto = ContractsMapper.Map<CreateCardModel, CreateCardDto>(model);
            dto.BudgetId = budgetid;

            var result = await _service.Creator.Create(dto);

            return Ok(ContractsMapper.Map<FetchCardDto, CardModel>(result));
        }

        [HttpPut]
        [Route("cards")]
        public async Task<ActionResult<CardModel>> Put(
            [FromRoute] Guid budgetid,
            UpdateCardModel model)
        {
            if (model == null)
                throw new DataNullReferenceException();

            if (model.Id <= 0)
                throw new ValueOutOfRangeException();

            var dto = ContractsMapper.Map<UpdateCardModel, UpdateCardDto>(model);
            dto.BudgetId = budgetid;

            var result = await _service.Updater.Update(dto);

            return Ok(ContractsMapper.Map<FetchCardDto, CardModel>(result));
        }

        [HttpDelete]
        [Route("accounts/{accountid:long}/cards")]
        public async Task<ActionResult> Delete(
            [FromRoute] Guid budgetid,
            [FromRoute] long accountid,
            [FromQuery] long id)
        {
            if (id <= 0)
                throw new ValueOutOfRangeException();

            var qFilter = new QueryFilter()
                .AddCondition("BudgetId", budgetid)
                .AddCondition("AccountId", accountid)
                .AddCondition("Id", id);

            await _service.Remover.Remove(qFilter);
            return Ok();
        }
    }
}
