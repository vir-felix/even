﻿using EvenCart.Core.Infrastructure;
using EvenCart.Core.Infrastructure.Providers;
using EvenCart.Data.Database;
using EvenCart.Services.Installation;
using NUnit.Framework;

namespace EvenCart.Services.Tests.MySql
{
    [SetUpFixture]
    public class MySqlFixture : BaseFixture
    {
        [OneTimeSetUp]
        public void OnetimeSetup()
        {
            TestDbInit.MySql(BaseTest.MySqlConnectionString);
            var installationService = new InstallationService(TestDbInit.DbSettings, DependencyResolver.Resolve<ILocalFileProvider>());
            installationService.Install();
            installationService.FillRequiredSeedData("admin@store.com", "@#$%^&*", "localhost", "Test Store");
        }

        [OneTimeTearDown]
        public void OnetimeTeardown()
        {
            DatabaseManager.CleanupDatabase(BaseTest.ContextKey);
        }
    }
}