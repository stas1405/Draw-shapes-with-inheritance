﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawShapesWithInheritance
{
     class NameValue
    {
         public string Name {get;set;}
        public string Value{get;set;}
        public NameValue(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
