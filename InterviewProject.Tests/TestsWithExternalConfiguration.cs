using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace InterviewProject.Tests
{
    public abstract class TestsWithExternalConfiguration
    {
        protected IConfiguration Configuration { get; private set; }

        [SetUp]
        public void Setup()
        {
            Configuration = new ConfigurationBuilder()
                .AddUserSecrets(Startup.UserSecretsId)
                .Build();
        }
    }
}
