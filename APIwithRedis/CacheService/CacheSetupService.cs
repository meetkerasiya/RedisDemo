using APIwithRedis.CacheSetup;

namespace APIwithRedis.CacheService
{
    public class CacheSetupService : IHostedService
    {
        private readonly IServiceProvider _service;
        private readonly ICacheSetup _setup;

        public CacheSetupService(IServiceProvider service,ICacheSetup setup)
        {
            _service = service;
            _setup = setup;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _setup.LoadData();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
