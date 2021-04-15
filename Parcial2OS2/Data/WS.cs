﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Parcial2OS2.Data
{
    public class WS
    {
        public static async Task WeSservicePublicoAsync()
        {

        var url = "https://app.swaggerhub.com/apis/ECompres/contabilidad/v1#/AccountingEntry/post_api_accountingEntry";

            using (var http = new HttpClient())
            {
               var response = await http.GetStringAsync(url);
                var Post = JsonConvert.DeserializeObject<List<Models.AsientosContables>>(response);

                foreach(var post in Post)
                {
                    Console.WriteLine($"User id: { post.ID_AsientoCOntable}");
                }
            }   
            
        }
    }
}
