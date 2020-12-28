using System;
using Microsoft.Extensions.DependencyInjection;

namespace _2020_12_28_dependency_injection_console
{
    class Program
    {
        private static readonly ServiceProvider _serviceProvider
            = new ServiceCollection()
                .AddTransient<IRepo, Repo>()
                .AddTransient<IManager, Manager>()
                .AddTransient<Program>()
                .BuildServiceProvider();

        private readonly IManager _manager;
        public Program(IManager manager) => _manager = manager;

        public void Go() => _manager.Go();

        static void Main() => _serviceProvider.GetService<Program>().Go();
    }
}
