﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<IEnumerable<BudgetDto>>> Get()
        {
            var result =  await _service.Fetcher.FetchAll();

            if (result == null) return NotFound();

            return new ObjectResult(result);
        }

        // GET api/budgets/id
        [HttpGet("{id}")]
        public async Task<ActionResult<BudgetDto>> Get(int id)
        {
            var result = await _service.Fetcher.FetchByKey(id);

            if (result == null) return NotFound();

            return new ObjectResult(result);
        }

        // POST api/budgets
        [HttpPost]
        public async Task<ActionResult<BudgetDto>> Post(CreateBudgetDto dto)
        {
            if (dto == null) return BadRequest();

            var result = await _service.Creator.Create(dto);

            return Ok(result);
        }

        // PUT api/budgets
        [HttpPut]
        public async Task<ActionResult<BudgetDto>> Put(UpdateBudgetDto dto)
        {
            if (dto == null || dto.Id <= 0) return BadRequest();

            var result = await _service.Updater.Update(dto);

            return Ok(result);
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