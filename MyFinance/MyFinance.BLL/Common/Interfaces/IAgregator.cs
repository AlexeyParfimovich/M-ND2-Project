namespace MyFinance.BLL.Common.Interfaces
{
    public interface IAgregator<TEntity, TKey, TDto, TCreateDto, TUpdateDto>
    {
        ICreator<TEntity, TDto, TCreateDto> Creator { get; }

        IUpdater<TEntity, TDto, TUpdateDto> Updater { get; }

        IFetcher<TEntity, TKey, TDto> Fetcher { get; }

        IRemover<TEntity, TKey> Remover { get; }
    }
}
