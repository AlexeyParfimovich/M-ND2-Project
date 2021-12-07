using MyFinance.BLL.Interfaces;

namespace MyFinance.BLL.Abstracts
{
    public abstract class BaseAgregator<TKey, TDto, TCreateDto, TUpdateDto> : IAgregator<TKey, TDto, TCreateDto, TUpdateDto>
    {
        private readonly ICreator<TCreateDto, TDto> _creator;
        private readonly IUpdater<TUpdateDto, TDto> _updater;
        private readonly IFetcher<TKey, TDto> _fetcher;
        private readonly IRemover<TKey> _remover;

        public BaseAgregator(
            ICreator<TCreateDto, TDto> creator,
            IUpdater<TUpdateDto, TDto> updater,
            IFetcher<TKey, TDto> fetcher,
            IRemover<TKey> remover)
        {
            _creator = creator;
            _updater = updater;
            _fetcher = fetcher;
            _remover = remover;
        }

        public Interfaces.ICreator<TCreateDto, TDto> Creator => _creator;

        public Interfaces.IUpdater<TUpdateDto, TDto> Updater => _updater;

        public Interfaces.IFetcher<TKey, TDto> Fetcher => _fetcher;

        public Interfaces.IRemover<TKey> Remover => _remover;
    }
}
