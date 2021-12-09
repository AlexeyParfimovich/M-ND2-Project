using MyFinance.BLL.Interfaces;

namespace MyFinance.BLL.Abstracts
{
    public abstract class BaseAgregator<TEntity, TKey, TDto, TCreateDto, TUpdateDto> : IAgregator<TEntity, TKey, TDto, TCreateDto, TUpdateDto>
    {
        private readonly ICreator<TEntity, TDto, TCreateDto> _creator;
        private readonly IUpdater<TEntity, TDto, TUpdateDto> _updater;
        private readonly IFetcher<TEntity, TKey, TDto> _fetcher;
        private readonly IRemover<TEntity, TKey> _remover;

        public BaseAgregator(
            ICreator<TEntity, TDto, TCreateDto> creator,
            IUpdater<TEntity, TDto, TUpdateDto> updater,
            IFetcher<TEntity, TKey, TDto> fetcher,
            IRemover<TEntity, TKey> remover)
        {
            _creator = creator;
            _updater = updater;
            _fetcher = fetcher;
            _remover = remover;
        }

        public Interfaces.ICreator<TEntity, TDto, TCreateDto> Creator => _creator;

        public Interfaces.IUpdater<TEntity, TDto, TUpdateDto> Updater => _updater;

        public Interfaces.IFetcher<TEntity, TKey, TDto> Fetcher => _fetcher;

        public Interfaces.IRemover<TEntity, TKey> Remover => _remover;
    }
}
