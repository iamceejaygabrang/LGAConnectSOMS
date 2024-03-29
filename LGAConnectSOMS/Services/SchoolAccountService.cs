﻿using LGAConnectSOMS.Gateway;
using LGAConnectSOMS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGAConnectSOMS.Services
{
    public class SchoolAccountService
    {
        public async Task<IEnumerable<SchoolAccount>> GetSchoolAccountDetails()
        {
            var apiGateway = new SchoolAccountGateway();
            var content = await apiGateway.GetSchoolAccountDetails();
            return content;
        }     
    }
}
