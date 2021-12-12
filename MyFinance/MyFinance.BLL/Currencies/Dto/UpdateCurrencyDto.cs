﻿using MyFinance.BLL.Common.Abstracts;

namespace MyFinance.BLL.Currencies.Dto
{
    public class UpdateCurrencyDto: BaseDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal ExchangeRate { get; set; }
    }
}
