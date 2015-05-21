﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Joyride.Specflow.Configuration
{
   
    public class DeviceElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new DeviceElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DeviceElement)element).Name;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override string ElementName
        {
            get { return "device"; }
        }

        public DeviceElement this[int index]
        {
            get { return (DeviceElement) BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        new public DeviceElement this[string key]
        {
            get { return (DeviceElement)BaseGet(key); }
        }

        public bool ContainsKey(string key)
        {
            object[] keys = BaseGetAllKeys();
            foreach (object obj in keys)
            {
                if ((string) obj == key)
                   return  true;
            }
            return false;
        }
    }
 
}
