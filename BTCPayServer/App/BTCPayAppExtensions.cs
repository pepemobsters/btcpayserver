﻿using BTCPayServer.App;
using BTCPayServer.Lightning;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BTCPayServer.Controllers;

public static class BTCPayAppExtensions
{
    public static IServiceCollection AddBTCPayApp(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<BTCPayAppState>();
        serviceCollection.AddSingleton<ILightningConnectionStringHandler, BTCPayAppLightningConnectionStringHandler>();
        serviceCollection.AddHostedService(serviceProvider => serviceProvider.GetRequiredService<BTCPayAppState>());
        return serviceCollection;
    }

    public static void UseBTCPayApp(this IApplicationBuilder builder)
    {
        builder.UseEndpoints(routeBuilder =>
        {
            routeBuilder.MapHub<BTCPayAppHub>("hub/btcpayapp");
        });
    }
}
