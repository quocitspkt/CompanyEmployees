﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class CompanyCollectionBadRequest : BadRequestException
    {
        public CompanyCollectionBadRequest() : base("CompanyCollection send from client is null")
        {
        }
    }
}
