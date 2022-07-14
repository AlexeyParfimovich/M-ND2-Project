using MyFinance.BLL.Common.Abstracts;
using System;

namespace MyFinance.BLL.Cards.Dto
{
    public class FetchCardDto: BaseDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime? ValidThru { get; set; }

        public long AccountId { get; set; }

        public ulong? LastTransaction { get; set; }
    }
}
