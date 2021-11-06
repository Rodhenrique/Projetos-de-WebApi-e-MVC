using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Canil.Domains
{
    public class AppSettings
    {
        public DatabaseSettings DatabaseSettings { get; set; }
    }

    public class DatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string Path { get; set; }
        public bool SqlServer { get; set; }

    }
}
