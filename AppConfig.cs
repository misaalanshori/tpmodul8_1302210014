using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8_1302210014
{
    public class AppConfig
    {
        public CovidConfig config;

        public const string configFile = @"./covid_config.json";

        public AppConfig()
        {
            try
            {
                ReadConfigFile();
                Console.WriteLine("Membaca Config dari JSON");
            } 
            catch (FileNotFoundException)
            {
                Console.WriteLine("Membuat Config Default");
                setDefault();
                WriteConfigFile();
            }
            
        }

        public CovidConfig ReadConfigFile()
        {
            string jsonText = File.ReadAllText(configFile);
            config = JsonSerializer.Deserialize<CovidConfig>(jsonText);
            return config;
        }

        public void setDefault()
        {
            config = new CovidConfig("celcius", 
                                     14, 
                                     "Anda tidak diperbolehkan masuk ke daalm gedung ini", 
                                     "Anda dipersilahkan untuk masuk ke dalam gedung ini"
                                     );
        }

        public void WriteConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions() { 
                WriteIndented = true
            };
            string jsonText = JsonSerializer.Serialize<CovidConfig>(config, options);
            File.WriteAllText(configFile, jsonText);

        }

        public void UbahSatuan()
        {
            if (config.satuan_suhu.Equals("celcius"))
            {
                config.satuan_suhu = "fahrenheit";
            } else if (config.satuan_suhu.Equals("fahrenheit"))
            {
                config.satuan_suhu = "celcius";
            }
        }
    }
}
