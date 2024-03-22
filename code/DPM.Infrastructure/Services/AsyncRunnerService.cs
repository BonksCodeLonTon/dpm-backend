using Autofac;
using DPM.Applications.Services;

namespace DPM.Infrastructure.Services
{
    internal class AsyncRunnerService : IAsyncRunnerService
    {
        private readonly ILifetimeScope _parentScope;

        public AsyncRunnerService(ILifetimeScope parentScope)
        {
            _parentScope = parentScope;
        }

        public void Run<TService>(Func<TService, Task> func) where TService : class
        {
            Task.Factory.StartNew(async () =>
            {
                using var scope = _parentScope.BeginLifetimeScope();
                var service = scope.Resolve<TService>();
                await func(service);
            });
        }
    }
}