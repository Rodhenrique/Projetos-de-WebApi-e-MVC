using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Canil.Models
{
    public class ConfigFactory
    {
        public static c GetAppSetting()
        {
            string settings = File.ReadAllText("../../../configsettings.json");

            AppSettings appSettings = JsonConvert.DeserializeObject<AppSettings>(settings);

            return appSettings;
        }
    }
}
