using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace mensstore.Infrastructure.Context
{
    public static class DbCommon
    {
        private static string conc = "Server = Local instance MySQL84; Database=mensstore;Uid=mensstore;Pwd=123mensstore;";

        public static string ReturnConnectionString() => conc;
    }
}
