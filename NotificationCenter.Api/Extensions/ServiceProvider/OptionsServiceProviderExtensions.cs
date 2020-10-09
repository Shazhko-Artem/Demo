using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace NotificationCenter.Api.Extensions.ServiceProvider
{
    public static class OptionsServiceProviderExtensions
    {
        public static TOptions GetOptions<TOptions>(this IServiceProvider provider) where TOptions : class, new() => provider.GetService<IOptions<TOptions>>().Value;
    }
}