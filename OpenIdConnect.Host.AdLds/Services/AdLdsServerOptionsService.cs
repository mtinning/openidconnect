﻿using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using OpenIDConnect.IdentityServer3.AdLds.Factories;
using OpenIDConnect.IdentityServer3.AdLds.Models;
using OpenIDConnect.IdentityServer3.AdLds.Services;

namespace OpenIdConnect.Host.AdLds.Services
{
    public class AdLdsServerOptionsService
    {
        public IdentityServerOptions GetServerOptions()
        {
            var factory = new IdentityServerServiceFactory();

            factory.UserService = new Registration<IUserService, AdLdsUserService>();

            factory.Register(new Registration<IDirectoryContextFactory, AdLdsDirectoryContextFactory>());
            factory.Register(new Registration<DirectoryConnectionConfig>(new DirectoryConnectionConfig("localhost", "389", "LDAP://", "CN=ADLDSUsers,DC=ScottLogic,DC=local")));

            var options = new IdentityServerOptions
            {
                Factory = factory
            };

            return options;
        }
    }
}
