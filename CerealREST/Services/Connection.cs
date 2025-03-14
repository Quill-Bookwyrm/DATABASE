﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CerealREST.Services
{
    public abstract class Connection
    {
        protected string connectionString;
        public IConfiguration Configuration { get; }

        public Connection(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:DefaultConnection"];
        }
        public Connection(string connectionString)
        {
            Configuration = null;
            this.connectionString = connectionString;
        }
    }
}
