using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PizzaConsole
{
    public class AppHostSingleton : IAppHostSingleton
    {

        static AppHostSingleton _AppHostSingleTon = null;

        IConfigurationRoot _ConfigConfigRoot = null;

        public static AppHostSingleton GetInstance() {

            if (_AppHostSingleTon == null) {

                lock (new object()) {

                    _AppHostSingleTon = new AppHostSingleton();
                    _AppHostSingleTon.PrepareAppSetting();

                }

            }

            return _AppHostSingleTon;
        }

        public IConfigurationRoot GetConfiguration() {

            return _ConfigConfigRoot;
        }

        private void PrepareAppSetting()
        {

            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");

            _ConfigConfigRoot = builder.Build();
        }


    }
}
