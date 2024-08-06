using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace DAL_DBSlide.Services
{
    public abstract class BaseService
    {
        protected readonly string _connectionString;

        public BaseService(IConfiguration config, string connectionStringKey)
        {
#if DEBUG
            _connectionString = config.GetSection("DevConnectionStrings")[connectionStringKey];
#else
            _connectionString = config.GetConnectionString(connectionStringKey);
#endif
        }
    }
}
