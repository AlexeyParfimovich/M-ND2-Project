using MyFinance.BLL.Common.Interfaces;

namespace MyFinance.BLL.Common.Abstracts
{
    public abstract class BaseAgregator<TEntity, TDto, TCreateDto, TUpdateDto> : IAgregator<TEntity, TDto, TCreateDto, TUpdateDto>
    {
        private readonly ICreator<TEntity, TDto, TCreateDto> _creator;
        private readonly IUpdater<TEntity, TDto, TUpdateDto> _updater;
        private readonly IFetcher<TEntity, TDto> _fetcher;
        private readonly IRemover<TEntity> _remover;

        public BaseAgregator(
            ICreator<TEntity, TDto, TCreateDto> creator,
            IUpdater<TEntity, TDto, TUpdateDto> updater,
            IFetcher<TEntity, TDto> fetcher,
            IRemover<TEntity> remover)
        {
            _creator = creator;
            _updater = updater;
            _fetcher = fetcher;
            _remover = remover;
        }

        public Interfaces.ICreator<TEntity, TDto, TCreateDto> Creator => _creator;

        public Interfaces.IUpdater<TEntity, TDto, TUpdateDto> Updater => _updater;

        public Interfaces.IFetcher<TEntity, TDto> Fetcher => _fetcher;

        public Interfaces.IRemover<TEntity> Remover => _remover;
    }
}
