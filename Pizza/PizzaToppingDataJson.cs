using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Linq;
using System.IO;

namespace PizzaConsole.Pizza
{
    public class PizzaToppingDataJson: IPizzaToppingData
    {

        private string PizzaToppingURL { get;  } = "";

        private static IAppHostSingleton _AppHostSingleton;

        public PizzaToppingDataJson(IAppHostSingleton appHostSingleton)
        {

            _AppHostSingleton = appHostSingleton;
            _AppHostSingleton = AppHostSingleton.GetInstance();

            var HostAppConfig = _AppHostSingleton.GetConfiguration();

            PizzaToppingURL = HostAppConfig.GetSection("PizzaToppingsJsonfile").Value;
        }

        public string[] Toppings { get; set; }

        public  List<IPizzaToppingData> GetData()
        {

            var PizzaToppins = new List<IPizzaToppingData>();

            try
            {

                string PizzaJson;

                var DirectoryPath = Directory.GetCurrentDirectory();

                using (WebClient aWebClient = new WebClient())
                {
                    PizzaJson = aWebClient.DownloadString($"{DirectoryPath}\\{PizzaToppingURL}");
                }

                PizzaToppins.AddRange(
                    JsonConvert.DeserializeObject<List<PizzaToppingDataJson>>(PizzaJson)
                );


            }
            catch (Exception e)
            {
                throw new Exception("Could not retrieve Pizza toppping data");
            }

            return PizzaToppins;
        }

        public string ToppingToStringList() {

            return String.Join(',', Toppings.OrderBy(aItem => aItem.ToLower()));

        }

    }
}
