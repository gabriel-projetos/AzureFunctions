﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.BookTrack.Ioc
{
    public class SingletonAttribute : Attribute
    {
        public Type Interface { get; set; }
    }
}
