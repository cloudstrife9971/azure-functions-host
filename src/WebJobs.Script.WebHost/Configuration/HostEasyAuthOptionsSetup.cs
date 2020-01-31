﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Script.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.Script.WebHost.Configuration
{
    public class HostEasyAuthOptionsSetup : IConfigureOptions<HostEasyAuthOptions>
    {
        private readonly IEnvironment _env;
        private readonly IConfiguration _configuration;

        public HostEasyAuthOptionsSetup(IEnvironment env, IConfiguration configuration)
        {
            _env = env;
            _configuration = configuration;
        }

        public void Configure(HostEasyAuthOptions options)
        {
            // TODO - confirm that this will only be for linux consumption/check here?
            IConfigurationSection jobHostSection = _configuration.GetSection(ConfigurationSectionNames.JobHost);
            var easyAuthSection = jobHostSection.GetSection(ConfigurationSectionNames.EasyAuth);
            easyAuthSection.Bind(options);
        }
    }
}
