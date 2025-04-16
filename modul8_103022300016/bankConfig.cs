using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_103022300016
{
    class Transfer
    {
        public int threshold { get; set; } // getter setter untuk threshold
        public int low_fee { get; set; } // getter setter low_fee
        public int high_fee { get; set; } // getter setter high_fee
    }

    class Confirmation
    {
        public string id { get; set; } // getter setter id
        public string en { get; set; } // getter setter en
    }

    class Config
    {
        // attribute untuk deserialisasi
        public string lang { get; set; } // getter setter lang
        public Transfer transfer { get; set; } // getter setter transfer
        public List<string> methods { get; set; } // getter setter method
        public Confirmation confirmation { get; set; } // getter setter confirmation

        // constructor kosong untuk deserialisasi
        public Config()
        {
        }

        // constructor untuk config
        public Config(string lang, Transfer transfer, List<string> methods, Confirmation confirmation)
        {
            this.lang = lang;
            this.transfer = transfer;
            this.methods = methods;
            this.confirmation = confirmation;
        }

    }
    class BankConfig
    {

        public Config config;
        // filePath Json
        public String filePath = @"bank_transfer_config.json";

        public BankConfig()
        {
            try
            // exception untuk mengatasi error
            {
                config = ReadConfigFile(); // memanggil method readConfigFile
            }
            catch (Exception ex)
            {
                setDefault(); // memanggil method setDefault
                WriteConfigFile(); // memanggil method WriteConfigFile
            }
        }

        private Config ReadConfigFile()
        {
            string Filejson = File.ReadAllText(filePath); // Membaca file json
            Config config = JsonSerializer.Deserialize<Config>(Filejson); // melakukan deserialisasi file json
            return config;
        }

        private void WriteConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true 
            };

            string jsonString = JsonSerializer.Serialize(config, options); // serialisasi json
            File.WriteAllText(filePath, jsonString); // menulis file json
        }

        public void ubahBahasa()
        // method untuk mengubah bahasa
        {
            if (config.lang == "en")
            {
                config.lang = "id";
            }
            else
            {
                config.lang = "en";
            }
        }

        private void setDefault()
        // method untuk set default
        {
            config = new Config();
            config.lang = "en";
            config.transfer = new Transfer();
            config.transfer.threshold = 25000000;
            config.transfer.low_fee = 6500;
            config.transfer.high_fee = 15000;
            config.methods = new List<string>();
            config.methods.Add("RTO (Real Time");
            config.methods.Add("SKN");
            config.methods.Add("RTGS");
            config.methods.Add("BI Fast");
            config.confirmation = new Confirmation();
            config.confirmation.id = "ya";
            config.confirmation.en = "yes";
        }


    }
}
