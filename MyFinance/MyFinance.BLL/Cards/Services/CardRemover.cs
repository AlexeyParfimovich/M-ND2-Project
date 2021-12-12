using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;

namespace MyFinance.BLL.Cards.Services
{
    public class CardRemover : BaseRemoveService<CardEntity, string>, IRemover<CardEntity, string>
    {
        public CardRemover(IFinanceDbContext database): base(database)
        {
        }
    }
}
