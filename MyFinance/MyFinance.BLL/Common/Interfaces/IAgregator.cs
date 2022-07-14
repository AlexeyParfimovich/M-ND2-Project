namespace MyFinance.BLL.Common.Interfaces
{
    public interface IAgregator<TEntity, TDto, TCreateDto, TUpdateDto>
    {
        ICreator<TEntity, TDto, TCreateDto> Creator { get; }

        IUpdater<TEntity, TDto, TUpdateDto> Updater { get; }

        IFetcher<TEntity, TDto> Fetcher { get; }

        IRemover<TEntity> Remover { get; }
    }
}
