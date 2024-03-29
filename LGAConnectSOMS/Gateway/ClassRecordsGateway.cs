﻿using LGAConnectSOMS.Helpers;
using LGAConnectSOMS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGAConnectSOMS.Gateway
{
    public class ClassRecordsGateway
    {
        static string BaseUrl = "http://ceejaygabrang-001-site1.itempurl.com/api/lga/classrecord";

        public async Task<IEnumerable<ClassRecords>> GetClassRecords(int ID)
        {
            try
            {
                string url = $"{BaseUrl}/get_all/{ID}"; ;
                
                var content = await WebMethods.MakeGetRequest(url);
                var result = JsonConvert.DeserializeObject<IEnumerable<ClassRecords>>(content);
                return result;
            }
            catch
            {
                return Enumerable.Empty<ClassRecords>();
            }
        }
    }
}
