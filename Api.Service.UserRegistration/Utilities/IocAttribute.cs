﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.UserRegistration.Utilities
{
    public class IocAttribute : Attribute
    {
        public Type Interface { get; set; }
    }
}
