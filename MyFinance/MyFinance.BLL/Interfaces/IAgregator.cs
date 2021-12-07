using MyFinance.BLL.Interfaces;

namespace MyFinance.BLL
{
    public interface IAgregator<TKey, TDto, TCreateDto, TUpdateDto>
    {
        ICreator<TCreateDto, TDto> Creator { get; }

        IUpdater<TUpdateDto, TDto> Updater { get; }

        IFetcher<TKey, TDto> Fetcher { get; }

        IRemover<TKey> Remover { get; }
    }
}
