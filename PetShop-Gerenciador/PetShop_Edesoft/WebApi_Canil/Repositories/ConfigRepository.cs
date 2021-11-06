using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Canil.Domains;

namespace WebApi_Canil.Repositories
{
    public class ConfigRepository
    {
        public static AppSettings GetAppSetting()
        {
            string settings = File.ReadAllText("./appsettings.json");

            AppSettings appSettings = JsonConvert.DeserializeObject<AppSettings>(settings);

            return appSettings;
        }
    }
}
