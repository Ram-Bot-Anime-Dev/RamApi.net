﻿using DalSoft.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamApidotnet
{
    
    public class RamApi
    {
        private static string APIURL = $"https://api.rambot.xyz";
        public static async Task<dynamic> helloAsync(string ApiKey, string Version, string lang = "english")
        {
            string requestUrl = APIURL + $"/{Version}/public/hello/{lang}";

            dynamic client = new RestClient(requestUrl, new Config().UseRetryHandler(
                 maxRetries: 5,
                    waitToRetryInSeconds: 6,
                    maxWaitToRetryInSeconds: 10,
                    backOffStrategy: DalSoft.RestClient.Handlers.RetryHandler.BackOffStrategy.Linear
                ));

            return await client.Headers(new Dictionary<string, string> { { "api-key", ApiKey } }).Get();
        }
    }



}
