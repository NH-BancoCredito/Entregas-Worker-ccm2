﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregasWorker.CrossCutting.Configs
{
    public class AppConfiguration
    {
        private readonly IConfiguration _configInfo;
        public AppConfiguration(IConfiguration configInfo) {
            _configInfo = configInfo;
        }

        public string DbEntregasCnx
        {
            get
            {
                return _configInfo["dbEntregas-cnx"];
            }
            private set { }
        }

        public string DbEntregasDb
        {
            get
            {
                return _configInfo["dbEntregas-db"];
            }
            private set { }
        }

        public string UrlKafkaServer
        {
            get
            {
                return _configInfo["url-kafka-server"];
            }
            private set { }
        }

    }
}
