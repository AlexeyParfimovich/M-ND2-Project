﻿using Microsoft.EntityFrameworkCore;
using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Interfaces;
using MyFinance.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.BLL.Budgets.Services
{
    public class BudgetFetcher : IFetcher<long, BudgetDto>
    {
        private readonly IFinanceDbContext _db;

        public BudgetFetcher(
            IFinanceDbContext database)
        {
            _db = database;
        }

        public async Task<BudgetDto> GetByKey(long key)
        {
            var entity = await _db.Context.Budgets.FirstOrDefaultAsync(x => x.Id == key);

            return BudgetMapper.MapToDto(entity);
        }
    }
}
