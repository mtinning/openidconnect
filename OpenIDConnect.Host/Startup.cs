﻿using Microsoft.Owin;
using Owin;
using OpenIDConnect.IdentityServer;
using OpenIDConnect.IdentityAdmin;
using OpenIDConnect.IdentityManager;
using OpenIDConnect.Core;
using IdentityAdmin.Logging;
using Serilog;

[assembly: OwinStartup(typeof(OpenIDConnect.Host.Startup))]

namespace OpenIDConnect.Host
{
    public class Startup
    {        
        public void Configuration(IAppBuilder app)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Trace()
                .CreateLogger();

            var configurationService = new ApplicationSettingsConfigurationService();

            app.Map("/core", coreApp => {
                new IdentityServerBootstrapper().Run(coreApp);
            });

            app.Map("/admin", adminApp => {
                new IdentityAdminBootstrapper(configurationService).Run(adminApp);                
            });

            app.Map("/manage", manageApp =>
            {
                new IdentityManagerBootstrapper().Run(manageApp);                
            });
        }
    }
}