﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrtgAPI
{
    public enum VMwareSessionMode
    {
        [XmlEnum("1")]
        ReuseSession,

        [XmlEnum("0")]
        CreateNewSession
    }
}